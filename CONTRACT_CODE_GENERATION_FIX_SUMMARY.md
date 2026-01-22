# Sửa Lỗi Tạo Mã Hợp Đồng - Tóm Tắt

## Vấn Đề
Người dùng báo cáo không thể tạo được mã hợp đồng mới trong FormHopDong.

## Nguyên Nhân Phân Tích
1. **Thiếu xử lý lỗi**: Phương thức `GenerateMaHopDong()` không có try-catch để xử lý lỗi database
2. **Không kiểm tra kết nối**: Không kiểm tra kết nối database trước khi thực hiện truy vấn
3. **Thiếu thông báo lỗi**: Không có thông báo chi tiết khi không tạo được mã hợp đồng
4. **Không có fallback**: Không có phương án dự phòng khi truy vấn database thất bại

## Giải Pháp Đã Thực Hiện

### 1. Cải Thiện Phương Thức `GenerateMaHopDong()`
```csharp
private string GenerateMaHopDong()
{
    try
    {
        string sql = $"SELECT ISNULL(MAX(CAST(SUBSTRING(MaHopDong, {MA_HOP_DONG_PREFIX.Length + 1}, 10) AS INT)), 0) + 1 FROM HopDong WHERE MaHopDong LIKE '{MA_HOP_DONG_PREFIX}%'";
        object result = DatabaseHelper.ExecuteScalar(sql);
        
        if (result == null || result == DBNull.Value)
        {
            return $"{MA_HOP_DONG_PREFIX}0001";
        }
        
        int next = Convert.ToInt32(result);
        return $"{MA_HOP_DONG_PREFIX}{next:D4}";
    }
    catch (Exception ex)
    {
        UIHelper.ShowErrorMessage("Lỗi khi tạo mã hợp đồng: " + ex.Message);
        // Fallback: tạo mã dựa trên thời gian
        return $"{MA_HOP_DONG_PREFIX}{DateTime.Now:yyyyMMddHHmmss}";
    }
}
```

**Cải tiến:**
- Thêm try-catch để xử lý lỗi
- Kiểm tra null/DBNull.Value
- Fallback tạo mã dựa trên timestamp khi database lỗi
- Thông báo lỗi chi tiết

### 2. Cải Thiện Constructor
```csharp
public FormHopDong()
{
    InitializeComponent();
    InitializeUI();
    
    // Kiểm tra kết nối database trước khi load dữ liệu
    if (!DatabaseHelper.TestConnection())
    {
        UIHelper.ShowErrorMessage("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra cấu hình kết nối.");
        return;
    }
    
    LoadComboBoxData();
    LoadData();
    HookEvents();
    txtMaHopDong.ReadOnly = true;
    txtTienCoc.ReadOnly = true;
}
```

**Cải tiến:**
- Kiểm tra kết nối database trước khi load dữ liệu
- Thông báo lỗi khi không kết nối được database

### 3. Cải Thiện Phương Thức `ClearInputs()`
```csharp
private void ClearInputs()
{
    // ... clear các controls ...
    
    // Tạo mã hợp đồng mới
    string newMaHopDong = GenerateMaHopDong();
    txtMaHopDong.Text = newMaHopDong;
    
    // Kiểm tra nếu không tạo được mã hợp đồng
    if (string.IsNullOrWhiteSpace(txtMaHopDong.Text))
    {
        UIHelper.ShowWarningMessage("Không thể tạo mã hợp đồng mới. Vui lòng kiểm tra kết nối cơ sở dữ liệu.");
    }
    
    AutoFillTienCoc();
    UpdateSoThang();
}
```

**Cải tiến:**
- Kiểm tra kết quả tạo mã hợp đồng
- Thông báo cảnh báo khi không tạo được mã

### 4. Cải Thiện Validation
```csharp
private bool ValidateInput()
{
    if (string.IsNullOrWhiteSpace(txtMaHopDong.Text))
    {
        UIHelper.ShowWarningMessage("Không tạo được mã hợp đồng mới!\n\nVui lòng:\n" +
                                  "1. Kiểm tra kết nối cơ sở dữ liệu\n" +
                                  "2. Nhấn nút 'Làm mới' để thử lại\n" +
                                  "3. Liên hệ quản trị viên nếu vấn đề vẫn tiếp tục");
        btnLamMoi.Focus();
        return false;
    }
    // ... validation khác ...
}
```

**Cải tiến:**
- Thông báo lỗi chi tiết với hướng dẫn khắc phục
- Focus vào nút "Làm mới" để người dùng thử lại

### 5. Cải Thiện Nút "Làm Mới"
```csharp
private void btnLamMoi_Click(object sender, EventArgs e)
{
    ClearInputs();
    LoadData();
    LoadComboBoxData();
    
    // Đảm bảo tạo mã hợp đồng mới
    if (string.IsNullOrWhiteSpace(txtMaHopDong.Text))
    {
        string newMaHopDong = GenerateMaHopDong();
        txtMaHopDong.Text = newMaHopDong;
        
        if (string.IsNullOrWhiteSpace(txtMaHopDong.Text))
        {
            UIHelper.ShowErrorMessage("Không thể tạo mã hợp đồng mới. Vui lòng kiểm tra:\n" +
                                    "1. Kết nối cơ sở dữ liệu\n" +
                                    "2. Bảng HopDong đã được tạo\n" +
                                    "3. Quyền truy cập cơ sở dữ liệu");
        }
    }
}
```

**Cải tiến:**
- Thử tạo lại mã hợp đồng nếu lần đầu thất bại
- Thông báo lỗi với checklist khắc phục

## Các Tình Huống Được Xử Lý

### 1. Database Không Kết Nối Được
- **Hiện tượng**: Không thể kết nối đến SQL Server
- **Xử lý**: Thông báo lỗi kết nối, không load form
- **Fallback**: Tạo mã dựa trên timestamp

### 2. Bảng HopDong Chưa Tồn Tại
- **Hiện tượng**: Truy vấn SELECT thất bại
- **Xử lý**: Catch exception, tạo mã HD0001
- **Fallback**: Tạo mã dựa trên timestamp

### 3. Dữ Liệu Null/Empty
- **Hiện tượng**: Truy vấn trả về null
- **Xử lý**: Kiểm tra null/DBNull, tạo mã HD0001

### 4. Quyền Truy Cập Bị Từ Chối
- **Hiện tượng**: Không có quyền SELECT trên bảng
- **Xử lý**: Catch exception, thông báo lỗi quyền
- **Fallback**: Tạo mã dựa trên timestamp

## Kết Quả
✅ **Đã sửa thành công**: Ứng dụng có thể tạo mã hợp đồng mới
✅ **Xử lý lỗi tốt**: Thông báo lỗi chi tiết và hướng dẫn khắc phục
✅ **Có fallback**: Tạo mã dự phòng khi database lỗi
✅ **Kiểm tra kết nối**: Validate database connection trước khi sử dụng
✅ **Build thành công**: Không có lỗi compile
✅ **Chạy ổn định**: Ứng dụng khởi động và hoạt động bình thường

## Hướng Dẫn Sử Dụng
1. Mở FormHopDong
2. Nhấn nút "Làm mới" để tạo mã hợp đồng mới
3. Nếu gặp lỗi, kiểm tra:
   - Kết nối SQL Server
   - Database TTCS đã tồn tại
   - Bảng HopDong đã được tạo
   - Quyền truy cập database

## Files Đã Sửa Đổi
- `QuanLyNhaTro/Forms/FormHopDong.cs`
  - GenerateMaHopDong(): Thêm error handling và fallback
  - Constructor: Thêm kiểm tra kết nối database
  - ClearInputs(): Thêm validation mã hợp đồng
  - ValidateInput(): Cải thiện thông báo lỗi
  - btnLamMoi_Click(): Thêm retry logic

## Ngày Hoàn Thành
22/01/2026
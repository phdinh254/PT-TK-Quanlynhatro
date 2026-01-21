# Hướng dẫn sử dụng chức năng Xuất PDF Hóa đơn

## Tổng quan

Chức năng xuất PDF hóa đơn cho phép Admin xuất hóa đơn ra file PDF với định dạng chuyên nghiệp, bao gồm đầy đủ thông tin:
- Thông tin công ty
- Thông tin khách hàng và phòng
- Chi tiết các khoản thu (tiền phòng, điện, nước, phí khác)
- Tổng tiền và trạng thái thanh toán
- Chữ ký xác nhận

## Yêu cầu hệ thống

- Package: **iTextSharp 5.5.13.3** (đã được thêm vào project)
- Font: **Times New Roman** (có sẵn trong Windows)
- Quyền: **Chỉ Admin** mới có quyền xuất PDF

## Cách sử dụng

### Xuất PDF một hóa đơn

**Bước 1:** Vào menu **💵 Hóa đơn**

**Bước 2:** Chọn hóa đơn cần xuất trong danh sách

**Bước 3:** Click nút **📄 Xuất PDF**

**Bước 4:** Chọn nơi lưu file và đặt tên file

**Bước 5:** File PDF sẽ được tạo và có thể mở ngay

## Cấu trúc file PDF

### Header
- Logo công ty (placeholder)
- Thông tin công ty: địa chỉ, điện thoại, email

### Tiêu đề
- Tên: "HÓA ĐƠN TIỀN PHÒNG"
- Mã hóa đơn
- Ngày tạo

### Thông tin khách hàng
- Họ tên
- CMND
- Điện thoại
- Địa chỉ

### Thông tin phòng
- Tên phòng
- Loại phòng
- Tầng
- Mã hợp đồng

### Bảng chi tiết
| Khoản thu | Chỉ số cũ | Chỉ số mới | Đơn giá | Thành tiền |
|-----------|-----------|------------|---------|------------|
| Tiền phòng | - | - | - | xxx VNĐ |
| Tiền điện | xxx | xxx | xxx | xxx VNĐ |
| Tiền nước | xxx | xxx | xxx | xxx VNĐ |
| Phí khác | - | - | - | xxx VNĐ |
| **TỔNG CỘNG** | | | | **xxx VNĐ** |

### Footer
- Ghi chú (nếu có)
- Trạng thái thanh toán
- Ngày thanh toán (nếu đã thanh toán)
- Chữ ký khách hàng và người lập hóa đơn
- Thời gian in

## Tùy chỉnh

### Thay đổi thông tin công ty

Mở file `QuanLyNhaTro/Helpers/PdfExportHelper.cs` và sửa method `AddCompanyHeader`:

```csharp
companyInfo.Add(new Chunk("CÔNG TY QUẢN LÝ NHÀ TRỌ\n", FONT_HEADER));
companyInfo.Add(new Chunk("Địa chỉ: [Địa chỉ của bạn]\n", FONT_SMALL));
companyInfo.Add(new Chunk("Điện thoại: [Số điện thoại]\n", FONT_SMALL));
companyInfo.Add(new Chunk("Email: [Email của bạn]", FONT_SMALL));
```

### Thêm logo công ty

1. Chuẩn bị file logo (PNG, JPG) với kích thước phù hợp (khuyến nghị: 150x150px)
2. Đặt file logo vào thư mục `QuanLyNhaTro/Resources/`
3. Sửa method `AddCompanyHeader` trong `PdfExportHelper.cs`:

```csharp
// Thay thế phần logo placeholder
try
{
    string logoPath = Path.Combine(Application.StartupPath, "Resources", "logo.png");
    if (File.Exists(logoPath))
    {
        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
        logo.ScaleToFit(100f, 100f);
        logoCell.AddElement(logo);
    }
}
catch
{
    logoCell.AddElement(new Paragraph("LOGO", FONT_HEADER));
}
```

### Thay đổi font chữ

Mặc định sử dụng Times New Roman. Để thay đổi font:

1. Chuẩn bị file font (.ttf)
2. Sửa các biến font trong `PdfExportHelper.cs`:

```csharp
private static readonly Font FONT_TITLE = new Font(
    BaseFont.CreateFont("path/to/your/font.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), 
    18, Font.BOLD
);
```

## Xử lý lỗi

### Lỗi: "Không tìm thấy font Times New Roman"
- **Nguyên nhân:** Font Times New Roman không có trong hệ thống
- **Giải pháp:** Cài đặt font Times New Roman hoặc thay đổi font khác

### Lỗi: "Access denied" khi lưu file
- **Nguyên nhân:** Không có quyền ghi vào thư mục đã chọn
- **Giải pháp:** Chọn thư mục khác hoặc chạy ứng dụng với quyền Administrator

### Lỗi: "Không tìm thấy hóa đơn"
- **Nguyên nhân:** Hóa đơn đã bị xóa hoặc không tồn tại
- **Giải pháp:** Làm mới danh sách và chọn lại hóa đơn

### File PDF bị lỗi font tiếng Việt
- **Nguyên nhân:** Font không hỗ trợ Unicode
- **Giải pháp:** Đảm bảo sử dụng font hỗ trợ tiếng Việt và encoding IDENTITY_H

## Lưu ý

1. **Quyền truy cập:** Chỉ Admin mới có quyền xuất PDF
2. **Hiệu suất:** Xuất nhiều hóa đơn cùng lúc có thể mất thời gian, hãy kiên nhẫn
3. **Dung lượng:** Mỗi hóa đơn PDF khoảng 50-100KB
4. **In ấn:** File PDF được tối ưu cho khổ giấy A4
5. **Lưu trữ:** Nên lưu file PDF theo cấu trúc thư mục rõ ràng (ví dụ: theo tháng/năm)

## Ví dụ tên file

- Một hóa đơn: `HoaDon_HDN0001_20260121.pdf`
- Nhiều hóa đơn: `HoaDon_Nhieu_20260121_143052.pdf`

## Hỗ trợ

Nếu gặp vấn đề, vui lòng liên hệ:
- Email: support@nhatro.com
- Hotline: 0123.456.789

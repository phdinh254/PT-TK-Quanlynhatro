# 🏠 Hệ thống Quản lý Nhà trọ

Ứng dụng quản lý nhà trọ được phát triển bằng C# Windows Forms với .NET 8.0, cung cấp giải pháp toàn diện cho việc quản lý nhà trọ, khách hàng, hợp đồng và hóa đơn.

## ✨ Tính năng chính

### 🔐 Quản lý tài khoản
- Đăng nhập/Đăng ký tài khoản
- Phân quyền Admin/User
- Đổi mật khẩu và thông tin cá nhân

### 👥 Quản lý khách hàng
- Thêm, sửa, xóa thông tin khách hàng
- Tìm kiếm và lọc khách hàng
- Quản lý thông tin liên hệ

### 🏠 Quản lý phòng
- Quản lý danh sách phòng
- Theo dõi trạng thái phòng (trống, đã thuê)
- Đặt phòng cho khách hàng

### 📝 Quản lý hợp đồng
- Tạo và quản lý hợp đồng thuê
- Gia hạn hợp đồng
- Theo dõi thời hạn hợp đồng

### 💵 Quản lý hóa đơn
- Tạo hóa đơn điện nước hàng tháng
- Tính toán tự động tiền điện, nước
- Thanh toán và theo dõi công nợ
- **📄 Xuất PDF hóa đơn** (Chỉ dành cho Admin)

### 📊 Báo cáo thống kê
- Dashboard tổng quan
- Thống kê khách hàng, phòng, hợp đồng
- Báo cáo doanh thu

## 🎨 Cải tiến giao diện

### ✅ Đã hoàn thành
- **Font chuẩn hóa**: Toàn bộ ứng dụng sử dụng Times New Roman
- **Sửa lỗi encoding**: Hiển thị tiếng Việt chính xác
- **Màu nền hiện đại**: Thay đổi từ trắng sang xám nhạt (240,242,245)
- **Button layout**: Căn giữa và khoảng cách hài hòa
- **Responsive design**: Tự động điều chỉnh theo kích thước màn hình
- **DPI scaling**: Hỗ trợ màn hình độ phân giải cao

## 🛠️ Công nghệ sử dụng

- **Framework**: .NET 8.0 Windows Forms
- **Database**: SQL Server với Entity Framework
- **PDF Export**: iTextSharp 5.5.13.3
- **UI Components**: Windows Forms với custom styling

## 📋 Yêu cầu hệ thống

- Windows 10/11
- .NET 8.0 Runtime
- SQL Server 2019 hoặc SQL Server Express
- RAM: 4GB trở lên
- Dung lượng: 500MB trống

## 🚀 Cài đặt và chạy

1. **Clone repository**:
   ```bash
   git clone https://github.com/phdinh254/PT-TK-Quanlynhatro.git
   cd PT-TK-Quanlynhatro
   ```

2. **Cài đặt dependencies**:
   ```bash
   dotnet restore
   ```

3. **Cấu hình database**:
   - Tạo database từ file `CSDLNhaTro.sql`
   - Cập nhật connection string trong `App.config`

4. **Build và chạy**:
   ```bash
   dotnet build
   dotnet run --project QuanLyNhaTro
   ```

## 📖 Hướng dẫn sử dụng

### Đăng nhập
- **Admin**: Có quyền truy cập tất cả chức năng
- **User**: Chỉ xem và quản lý cơ bản

### Xuất PDF hóa đơn
1. Vào menu **Quản lý** → **Hóa đơn**
2. Chọn hóa đơn cần xuất
3. Nhấn nút **📄 Xuất PDF** (chỉ Admin)
4. Chọn vị trí lưu file PDF

Chi tiết xem file: [`HUONG_DAN_XUAT_PDF.md`](QuanLyNhaTro/HUONG_DAN_XUAT_PDF.md)

## 📁 Cấu trúc dự án

```
QuanLyNhaTro/
├── Forms/              # Các form giao diện
├── Helpers/            # Các class hỗ trợ
│   ├── UIHelper.cs     # Styling và UI utilities
│   └── PdfExportHelper.cs  # Xuất PDF
├── Models/             # Data models
├── Data/               # Database context
└── Database/           # SQL scripts
```

## 🔄 Lịch sử cập nhật

### Version 2.0 (Latest)
- ✅ Chuẩn hóa font Times New Roman
- ✅ Sửa lỗi encoding tiếng Việt
- ✅ Cập nhật màu nền hiện đại
- ✅ Thêm chức năng xuất PDF hóa đơn
- ✅ Cải thiện layout button
- ✅ Tối ưu responsive design

### Version 1.0
- ✅ Các chức năng cơ bản quản lý nhà trọ
- ✅ CRUD operations cho tất cả entities
- ✅ Authentication và authorization

## 🤝 Đóng góp

Mọi đóng góp đều được chào đón! Vui lòng:

1. Fork repository
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📄 License

Dự án này được phát hành dưới MIT License. Xem file `LICENSE` để biết thêm chi tiết.

## 👨‍💻 Tác giả

- **phdinh254** - *Initial work* - [GitHub](https://github.com/phdinh254)

## 📞 Liên hệ

Nếu có câu hỏi hoặc góp ý, vui lòng tạo issue trên GitHub hoặc liên hệ qua email.

---

⭐ **Nếu dự án hữu ích, hãy cho một star để ủng hộ!** ⭐
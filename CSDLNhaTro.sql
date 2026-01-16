-- =====================================================
-- CSDL QUẢN LÝ NHÀ TRỌ - TTCS
-- Tác giả: QuanLyNhaTro Team
-- Phiên bản: 1.0
-- =====================================================

-- Tạo database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TTCS')
BEGIN
    CREATE DATABASE TTCS;
END
GO

USE TTCS;
GO

-- =================a====================================
-- XÓA BẢNG CŨ (nếu cần reset)
-- =====================================================
-- DROP TABLE IF EXISTS HoaDon;
-- DROP TABLE IF EXISTS HopDong;
-- DROP TABLE IF EXISTS Phong;
-- DROP TABLE IF EXISTS KhachHang;
-- DROP TABLE IF EXISTS TaiKhoan;

-- =====================================================
-- BẢNG TÀI KHOẢN
-- =====================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TaiKhoan' AND xtype='U')
BEGIN
    CREATE TABLE TaiKhoan (
        TenDangNhap NVARCHAR(50) PRIMARY KEY,
        MatKhau NVARCHAR(100) NOT NULL,
        HoTen NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100),
        VaiTro NVARCHAR(20) DEFAULT 'User',  -- Admin, User
        NgayTao DATETIME DEFAULT GETDATE(),
        TrangThai BIT DEFAULT 1  -- 1: Hoạt động, 0: Khóa
    );
END
GO

-- =====================================================
-- BẢNG KHÁCH HÀNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='KhachHang' AND xtype='U')
BEGIN
    CREATE TABLE KhachHang (
        MaKhach NVARCHAR(20) PRIMARY KEY,
        TenKhach NVARCHAR(100) NOT NULL,
        SoDienThoai NVARCHAR(15),
        CMND NVARCHAR(20),
        Email NVARCHAR(100),
        DiaChi NVARCHAR(200),
        NgaySinh DATE,
        GioiTinh NVARCHAR(10),
        GhiChu NVARCHAR(500),
        NgayTao DATETIME DEFAULT GETDATE()
    );
END
GO

-- =====================================================
-- BẢNG PHÒNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Phong' AND xtype='U')
BEGIN
    CREATE TABLE Phong (
        MaPhong NVARCHAR(20) PRIMARY KEY,
        TenPhong NVARCHAR(50) NOT NULL,
        LoaiPhong NVARCHAR(50),
        DienTich INT,
        GiaPhong DECIMAL(18,0) NOT NULL,
        TrangThai NVARCHAR(20) DEFAULT N'Trống',  -- Trống, Đã thuê, Đang sửa
        MoTa NVARCHAR(500)
    );
END
GO

-- =====================================================
-- BẢNG HỢP ĐỒNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HopDong' AND xtype='U')
BEGIN
    CREATE TABLE HopDong (
        MaHopDong NVARCHAR(20) PRIMARY KEY,
        MaKhach NVARCHAR(20) NOT NULL,
        MaPhong NVARCHAR(20) NOT NULL,
        NgayBatDau DATE NOT NULL,
        NgayKetThuc DATE NOT NULL,
        TienCoc DECIMAL(18,0) DEFAULT 0,
        TrangThai NVARCHAR(30) DEFAULT N'Đang hiệu lực',  -- Đang hiệu lực, Hết hạn, Đã hủy
        GhiChu NVARCHAR(500),
        NgayTao DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
        FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
    );
END
GO

-- =====================================================
-- BẢNG HÓA ĐƠN
-- =====================================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HoaDon' AND xtype='U')
BEGIN
    CREATE TABLE HoaDon (
        MaHoaDon NVARCHAR(20) PRIMARY KEY,
        MaHopDong NVARCHAR(20) NOT NULL,
        ThangNam NVARCHAR(10),  -- VD: 01/2024
        NgayTao DATE DEFAULT GETDATE(),
        -- Chỉ số điện nước
        ChiSoDienCu INT DEFAULT 0,
        ChiSoDienMoi INT DEFAULT 0,
        ChiSoNuocCu INT DEFAULT 0,
        ChiSoNuocMoi INT DEFAULT 0,
        -- Đơn giá
        DonGiaDien DECIMAL(18,0) DEFAULT 3500,
        DonGiaNuoc DECIMAL(18,0) DEFAULT 15000,
        -- Tiền
        TienPhong DECIMAL(18,0) DEFAULT 0,
        TienDien DECIMAL(18,0) DEFAULT 0,
        TienNuoc DECIMAL(18,0) DEFAULT 0,
        TienDichVu DECIMAL(18,0) DEFAULT 0,
        TienKhac DECIMAL(18,0) DEFAULT 0,
        TongTien DECIMAL(18,0) DEFAULT 0,
        -- Trạng thái
        TrangThai NVARCHAR(30) DEFAULT N'Chưa thanh toán',  -- Chưa thanh toán, Đã thanh toán
        NgayThanhToan DATE NULL,
        GhiChu NVARCHAR(500),
        FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong)
    );
END
GO

-- =====================================================
-- DỮ LIỆU MẪU - TÀI KHOẢN
-- =====================================================
IF NOT EXISTS (SELECT * FROM TaiKhoan WHERE TenDangNhap = 'admin')
BEGIN
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, VaiTro, TrangThai)
    VALUES 
    ('admin', '123456', N'Quản trị viên', 'admin@nhatro.com', 'Admin', 1),
    ('user1', '123456', N'Người dùng 1', 'user1@nhatro.com', 'User', 1),
    ('user2', '123456', N'Người dùng 2', 'user2@nhatro.com', 'User', 1);
END
GO

-- =====================================================
-- DỮ LIỆU MẪU - KHÁCH HÀNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM KhachHang WHERE MaKhach = 'KH001')
BEGIN
    INSERT INTO KhachHang (MaKhach, TenKhach, SoDienThoai, CMND, Email, DiaChi, NgaySinh, GioiTinh, GhiChu)
    VALUES 
    ('KH001', N'Nguyễn Văn An', '0901234567', '079123456789', 'nguyenvanan@gmail.com', N'123 Nguyễn Huệ, Q.1, TP.HCM', '1995-03-15', N'Nam', N'Khách hàng VIP'),
    ('KH002', N'Trần Thị Bình', '0912345678', '079234567890', 'tranthibinh@gmail.com', N'456 Lê Lợi, Q.3, TP.HCM', '1998-07-20', N'Nữ', N''),
    ('KH003', N'Lê Văn Cường', '0923456789', '079345678901', 'levancuong@gmail.com', N'789 Trần Hưng Đạo, Q.5, TP.HCM', '1992-11-08', N'Nam', N''),
    ('KH004', N'Phạm Thị Dung', '0934567890', '079456789012', 'phamthidung@gmail.com', N'321 Võ Văn Tần, Q.3, TP.HCM', '2000-01-25', N'Nữ', N'Sinh viên'),
    ('KH005', N'Hoàng Văn Em', '0945678901', '079567890123', 'hoangvanem@gmail.com', N'654 Điện Biên Phủ, Q.10, TP.HCM', '1988-09-12', N'Nam', N'');
END
GO

-- =====================================================
-- DỮ LIỆU MẪU - PHÒNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM Phong WHERE MaPhong = 'P101')
BEGIN
    INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, DienTich, GiaPhong, TrangThai, MoTa)
    VALUES 
    ('P101', N'Phòng 101', N'Phòng đơn', 20, 2500000, N'Đã thuê', N'Tầng 1, có cửa sổ'),
    ('P102', N'Phòng 102', N'Phòng đơn', 20, 2500000, N'Trống', N'Tầng 1, có ban công'),
    ('P103', N'Phòng 103', N'Phòng đôi', 28, 3200000, N'Đã thuê', N'Tầng 1, phòng góc'),
    ('P201', N'Phòng 201', N'Phòng đơn', 22, 2800000, N'Trống', N'Tầng 2, view đẹp'),
    ('P202', N'Phòng 202', N'Phòng đôi', 30, 3500000, N'Đã thuê', N'Tầng 2, có máy lạnh'),
    ('P203', N'Phòng 203', N'Phòng VIP', 35, 4500000, N'Trống', N'Tầng 2, đầy đủ nội thất'),
    ('P301', N'Phòng 301', N'Phòng đơn', 18, 2200000, N'Trống', N'Tầng 3, phòng nhỏ'),
    ('P302', N'Phòng 302', N'Phòng đôi', 32, 3800000, N'Đang sửa', N'Tầng 3, đang sửa chữa');
END
GO

-- =====================================================
-- DỮ LIỆU MẪU - HỢP ĐỒNG
-- =====================================================
IF NOT EXISTS (SELECT * FROM HopDong WHERE MaHopDong = 'HD001')
BEGIN
    INSERT INTO HopDong (MaHopDong, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienCoc, TrangThai, GhiChu)
    VALUES 
    ('HD001', 'KH001', 'P101', '2024-01-01', '2024-12-31', 5000000, N'Đang hiệu lực', N'Hợp đồng 12 tháng'),
    ('HD002', 'KH002', 'P103', '2024-03-01', '2025-02-28', 6400000, N'Đang hiệu lực', N'Hợp đồng 12 tháng'),
    ('HD003', 'KH003', 'P202', '2024-06-01', '2024-11-30', 7000000, N'Đang hiệu lực', N'Hợp đồng 6 tháng');
END
GO

-- =====================================================
-- DỮ LIỆU MẪU - HÓA ĐƠN
-- =====================================================
IF NOT EXISTS (SELECT * FROM HoaDon WHERE MaHoaDon = 'HD001_2401')
BEGIN
    INSERT INTO HoaDon (MaHoaDon, MaHopDong, ThangNam, NgayTao, ChiSoDienCu, ChiSoDienMoi, ChiSoNuocCu, ChiSoNuocMoi, TienPhong, TienDien, TienNuoc, TienDichVu, TongTien, TrangThai, NgayThanhToan, GhiChu)
    VALUES 
    ('HD001_2401', 'HD001', '01/2024', '2024-01-31', 100, 150, 10, 15, 2500000, 175000, 75000, 100000, 2850000, N'Đã thanh toán', '2024-02-05', N''),
    ('HD001_2402', 'HD001', '02/2024', '2024-02-29', 150, 210, 15, 22, 2500000, 210000, 105000, 100000, 2915000, N'Đã thanh toán', '2024-03-05', N''),
    ('HD001_2403', 'HD001', '03/2024', '2024-03-31', 210, 280, 22, 30, 2500000, 245000, 120000, 100000, 2965000, N'Chưa thanh toán', NULL, N''),
    ('HD002_2403', 'HD002', '03/2024', '2024-03-31', 50, 100, 5, 10, 3200000, 175000, 75000, 100000, 3550000, N'Đã thanh toán', '2024-04-03', N''),
    ('HD002_2404', 'HD002', '04/2024', '2024-04-30', 100, 160, 10, 16, 3200000, 210000, 90000, 100000, 3600000, N'Chưa thanh toán', NULL, N''),
    ('HD003_2406', 'HD003', '06/2024', '2024-06-30', 0, 80, 0, 8, 3500000, 280000, 120000, 100000, 4000000, N'Chưa thanh toán', NULL, N'');
END
GO

PRINT N'==============================================';
PRINT N'CƠ SỞ DỮ LIỆU TTCS ĐÃ ĐƯỢC TẠO THÀNH CÔNG!';
PRINT N'==============================================';
PRINT N'Tài khoản mặc định:';
PRINT N'  - Admin: admin / 123456';
PRINT N'  - User:  user1 / 123456';
PRINT N'==============================================';

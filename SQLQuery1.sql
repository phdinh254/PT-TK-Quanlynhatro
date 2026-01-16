-- =============================================
-- HỆ THỐNG QUẢN LÝ NHÀ TRỌ
-- Phiên bản: 4.0 - FINAL
-- Ngày tạo: 2026-01-14
-- Mô tả: Hệ thống đơn giản với 2 loại tài khoản (Admin và Khách hàng)
--        Chỉ tính tiền phòng + điện + nước
-- =============================================

USE master;
GO

-- Xóa database cũ nếu tồn tại (CHỈ DÙNG KHI DEVELOPMENT)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyNhaTro')
BEGIN
    ALTER DATABASE QuanLyNhaTro SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyNhaTro;
END
GO

-- Tạo database mới
CREATE DATABASE QuanLyNhaTro;
GO

USE QuanLyNhaTro;
GO

-- =============================================
-- PHẦN 1: TẠO CÁC BẢNG
-- =============================================

-- 1. Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhach NVARCHAR(20) PRIMARY KEY,
    TenKhach NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(15),
    CMND NVARCHAR(20) UNIQUE,
    DiaChi NVARCHAR(200),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    Email NVARCHAR(100),
    GhiChu NVARCHAR(500),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT CK_KhachHang_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'))
);
GO

-- 2. Bảng TaiKhoan (Chung cho Admin và Khách hàng)
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    VaiTro NVARCHAR(20) NOT NULL DEFAULT 'KhachHang',
    MaKhach NVARCHAR(20), -- Chỉ có giá trị nếu VaiTro = 'KhachHang'
    NgayTao DATETIME DEFAULT GETDATE(),
    LanDangNhapCuoi DATETIME,
    TrangThai BIT DEFAULT 1,
    CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN ('Admin', 'KhachHang')),
    CONSTRAINT FK_TaiKhoan_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach)
);
GO

-- 3. Bảng Phong
CREATE TABLE Phong (
    MaPhong NVARCHAR(20) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    Tang INT,
    GiaPhong DECIMAL(18,0) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Trống',
    LoaiPhong NVARCHAR(50),
    DienTich INT,
    SoNguoiToiDa INT DEFAULT 2,
    TienIch NVARCHAR(500),
    MoTa NVARCHAR(500),
    HinhAnh NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT CK_Phong_TrangThai CHECK (TrangThai IN (N'Trống', N'Đã thuê', N'Đang sửa', N'Không khả dụng')),
    CONSTRAINT CK_Phong_GiaPhong CHECK (GiaPhong > 0),
    CONSTRAINT CK_Phong_DienTich CHECK (DienTich > 0)
);
GO

-- 4. Bảng HopDong
CREATE TABLE HopDong (
    MaHopDong NVARCHAR(20) PRIMARY KEY,
    MaKhach NVARCHAR(20) NOT NULL,
    MaPhong NVARCHAR(20) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    TienCoc DECIMAL(18,0) DEFAULT 0,
    GiaThue DECIMAL(18,0) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Đang hiệu lực',
    GhiChu NVARCHAR(500),
    FileDinhKem NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_HopDong_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
    CONSTRAINT FK_HopDong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT CK_HopDong_NgayHopLe CHECK (NgayKetThuc > NgayBatDau),
    CONSTRAINT CK_HopDong_TienCoc CHECK (TienCoc >= 0),
    CONSTRAINT CK_HopDong_TrangThai CHECK (TrangThai IN (N'Đang hiệu lực', N'Hết hạn', N'Đã thanh lý'))
);
GO

-- 5. Bảng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon NVARCHAR(20) PRIMARY KEY,
    MaHopDong NVARCHAR(20) NOT NULL,
    ThangNam NVARCHAR(7) NOT NULL, -- Format: YYYY-MM
    NgayTao DATE DEFAULT GETDATE(),
    NgayHetHan DATE,
    
    -- Chỉ số điện nước
    ChiSoDienCu INT DEFAULT 0,
    ChiSoDienMoi INT DEFAULT 0,
    SoDienTieuThu AS (ChiSoDienMoi - ChiSoDienCu) PERSISTED,
    DonGiaDien DECIMAL(18,0) DEFAULT 3500,
    
    ChiSoNuocCu INT DEFAULT 0,
    ChiSoNuocMoi INT DEFAULT 0,
    SoNuocTieuThu AS (ChiSoNuocMoi - ChiSoNuocCu) PERSISTED,
    DonGiaNuoc DECIMAL(18,0) DEFAULT 20000,
    
    -- Tiền các hạng mục
    TienPhong DECIMAL(18,0) DEFAULT 0,
    TienDien AS (CAST((ChiSoDienMoi - ChiSoDienCu) * DonGiaDien AS DECIMAL(18,0))) PERSISTED,
    TienNuoc AS (CAST((ChiSoNuocMoi - ChiSoNuocCu) * DonGiaNuoc AS DECIMAL(18,0))) PERSISTED,
    TienKhac DECIMAL(18,0) DEFAULT 0, -- Phí phát sinh khác (nếu có)
    GiamGia DECIMAL(18,0) DEFAULT 0,
    TongTien AS (
        TienPhong + 
        CAST((ChiSoDienMoi - ChiSoDienCu) * DonGiaDien AS DECIMAL(18,0)) + 
        CAST((ChiSoNuocMoi - ChiSoNuocCu) * DonGiaNuoc AS DECIMAL(18,0)) + 
        TienKhac - 
        GiamGia
    ) PERSISTED,
    
    TrangThai NVARCHAR(20) DEFAULT N'Chưa thanh toán',
    NgayThanhToan DATE NULL,
    HinhThucThanhToan NVARCHAR(50),
    GhiChu NVARCHAR(500),
    
    CONSTRAINT FK_HoaDon_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong),
    CONSTRAINT CK_HoaDon_ChiSoDien CHECK (ChiSoDienMoi >= ChiSoDienCu),
    CONSTRAINT CK_HoaDon_ChiSoNuoc CHECK (ChiSoNuocMoi >= ChiSoNuocCu),
    CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán', N'Quá hạn', N'Đã hủy'))
);
GO

-- 6. Bảng LichSuThanhToan
CREATE TABLE LichSuThanhToan (
    MaGiaoDich INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon NVARCHAR(20) NOT NULL,
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    SoTien DECIMAL(18,0) NOT NULL,
    HinhThuc NVARCHAR(50),
    GhiChu NVARCHAR(500),
    CONSTRAINT FK_LichSuThanhToan_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
);
GO

-- 7. Bảng BaoCaoSuCo
CREATE TABLE BaoCaoSuCo (
    MaSuCo INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong NVARCHAR(20) NOT NULL,
    MaKhach NVARCHAR(20),
    TieuDe NVARCHAR(200) NOT NULL,
    NoiDung NVARCHAR(1000) NOT NULL,
    HinhAnh NVARCHAR(255),
    MucDo NVARCHAR(20) DEFAULT N'Bình thường',
    TrangThai NVARCHAR(20) DEFAULT N'Chờ xử lý',
    NgayBaoCao DATETIME DEFAULT GETDATE(),
    NgayXuLy DATETIME,
    GhiChu NVARCHAR(500),
    CONSTRAINT FK_BaoCaoSuCo_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_BaoCaoSuCo_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
    CONSTRAINT CK_BaoCaoSuCo_MucDo CHECK (MucDo IN (N'Thấp', N'Bình thường', N'Cao', N'Khẩn cấp')),
    CONSTRAINT CK_BaoCaoSuCo_TrangThai CHECK (TrangThai IN (N'Chờ xử lý', N'Đang xử lý', N'Đã xử lý', N'Từ chối'))
);
GO

-- =============================================
-- PHẦN 2: TẠO INDEX ĐỂ TỐI ƯU HIỆU SUẤT
-- =============================================

-- Index cho bảng TaiKhoan
CREATE NONCLUSTERED INDEX IDX_TaiKhoan_VaiTro ON TaiKhoan(VaiTro);
CREATE NONCLUSTERED INDEX IDX_TaiKhoan_MaKhach ON TaiKhoan(MaKhach);
CREATE NONCLUSTERED INDEX IDX_TaiKhoan_Email ON TaiKhoan(Email);
GO

-- Index cho bảng KhachHang
CREATE NONCLUSTERED INDEX IDX_KhachHang_SoDienThoai ON KhachHang(SoDienThoai);
CREATE NONCLUSTERED INDEX IDX_KhachHang_CMND ON KhachHang(CMND);
GO

-- Index cho bảng Phong
CREATE NONCLUSTERED INDEX IDX_Phong_TrangThai ON Phong(TrangThai);
CREATE NONCLUSTERED INDEX IDX_Phong_LoaiPhong ON Phong(LoaiPhong);
GO

-- Index cho bảng HopDong
CREATE NONCLUSTERED INDEX IDX_HopDong_MaKhach ON HopDong(MaKhach);
CREATE NONCLUSTERED INDEX IDX_HopDong_MaPhong ON HopDong(MaPhong);
CREATE NONCLUSTERED INDEX IDX_HopDong_TrangThai ON HopDong(TrangThai);
CREATE NONCLUSTERED INDEX IDX_HopDong_NgayKetThuc ON HopDong(NgayKetThuc);
GO

-- Index cho bảng HoaDon
CREATE NONCLUSTERED INDEX IDX_HoaDon_MaHopDong ON HoaDon(MaHopDong);
CREATE NONCLUSTERED INDEX IDX_HoaDon_ThangNam ON HoaDon(ThangNam);
CREATE NONCLUSTERED INDEX IDX_HoaDon_TrangThai ON HoaDon(TrangThai);
CREATE NONCLUSTERED INDEX IDX_HoaDon_NgayThanhToan ON HoaDon(NgayThanhToan);
GO

-- Index cho bảng BaoCaoSuCo
CREATE NONCLUSTERED INDEX IDX_BaoCaoSuCo_TrangThai ON BaoCaoSuCo(TrangThai);
CREATE NONCLUSTERED INDEX IDX_BaoCaoSuCo_MaKhach ON BaoCaoSuCo(MaKhach);
GO

-- =============================================
-- PHẦN 3: TẠO VIEW
-- =============================================

-- View 1: Thông tin đầy đủ tài khoản
GO
CREATE VIEW vw_ThongTinTaiKhoan AS
SELECT 
    tk.TenDangNhap,
    tk.HoTen,
    tk. Email,
    tk.SoDienThoai,
    tk.VaiTro,
    tk.MaKhach,
    tk.NgayTao,
    tk.LanDangNhapCuoi,
    tk.TrangThai,
    kh.TenKhach,
    kh. CMND,
    kh. DiaChi
FROM TaiKhoan tk
LEFT JOIN KhachHang kh ON tk.MaKhach = kh.MaKhach;
GO

-- View 2: Thông tin phòng đầy đủ
CREATE VIEW vw_ThongTinPhong AS
SELECT 
    p.MaPhong,
    p.TenPhong,
    p.Tang,
    p. LoaiPhong,
    p.DienTich,
    p.GiaPhong,
    p. TrangThai,
    p.SoNguoiToiDa,
    p. TienIch,
    hd.MaHopDong,
    kh.MaKhach,
    kh.TenKhach,
    kh.SoDienThoai,
    hd.NgayBatDau,
    hd.NgayKetThuc,
    DATEDIFF(DAY, GETDATE(), hd.NgayKetThuc) AS SoNgayConLai
FROM Phong p
LEFT JOIN HopDong hd ON p.MaPhong = hd.MaPhong AND hd.TrangThai = N'Đang hiệu lực'
LEFT JOIN KhachHang kh ON hd.MaKhach = kh.MaKhach;
GO

-- View 3: Thông tin hóa đơn chi tiết
CREATE VIEW vw_HoaDonChiTiet AS
SELECT 
    hd. MaHoaDon,
    hd.ThangNam,
    hd.NgayTao,
    hd.NgayHetHan,
    hop.MaHopDong,
    p.MaPhong,
    p.TenPhong,
    kh.MaKhach,
    kh.TenKhach,
    kh. SoDienThoai AS SoDienThoaiKhach,
    kh. Email AS EmailKhach,
    hd.ChiSoDienCu,
    hd.ChiSoDienMoi,
    hd.SoDienTieuThu,
    hd.DonGiaDien,
    hd. ChiSoNuocCu,
    hd.ChiSoNuocMoi,
    hd.SoNuocTieuThu,
    hd.DonGiaNuoc,
    hd.TienPhong,
    hd.TienDien,
    hd.TienNuoc,
    hd.TienKhac,
    hd.GiamGia,
    hd. TongTien,
    hd.TrangThai,
    hd.NgayThanhToan,
    hd. HinhThucThanhToan,
    hd.GhiChu
FROM HoaDon hd
INNER JOIN HopDong hop ON hd. MaHopDong = hop.MaHopDong
INNER JOIN Phong p ON hop.MaPhong = p.MaPhong
INNER JOIN KhachHang kh ON hop.MaKhach = kh.MaKhach;
GO

-- View 4: Báo cáo doanh thu theo tháng
CREATE VIEW vw_DoanhThuThang AS
SELECT 
    hd.ThangNam,
    COUNT(hd.MaHoaDon) AS TongSoHoaDon,
    COUNT(CASE WHEN hd.TrangThai = N'Đã thanh toán' THEN 1 END) AS SoHoaDonDaThu,
    COUNT(CASE WHEN hd.TrangThai = N'Chưa thanh toán' THEN 1 END) AS SoHoaDonChuaThu,
    SUM(CASE WHEN hd.TrangThai = N'Đã thanh toán' THEN hd.TongTien ELSE 0 END) AS DoanhThuThucTe,
    SUM(hd.TongTien) AS DoanhThuDuKien,
    SUM(hd. TienPhong) AS TongTienPhong,
    SUM(hd.TienDien) AS TongTienDien,
    SUM(hd.TienNuoc) AS TongTienNuoc,
    SUM(hd.TienKhac) AS TongTienKhac
FROM HoaDon hd
GROUP BY hd.ThangNam;
GO

-- View 5: Hợp đồng sắp hết hạn (còn 30 ngày)
CREATE VIEW vw_HopDongSapHetHan AS
SELECT 
    hd.MaHopDong,
    hd. MaKhach,
    kh. TenKhach,
    kh.SoDienThoai,
    kh.Email,
    hd.MaPhong,
    p. TenPhong,
    hd.NgayBatDau,
    hd.NgayKetThuc,
    DATEDIFF(DAY, GETDATE(), hd.NgayKetThuc) AS SoNgayConLai,
    hd.TrangThai
FROM HopDong hd
INNER JOIN KhachHang kh ON hd.MaKhach = kh.MaKhach
INNER JOIN Phong p ON hd.MaPhong = p.MaPhong
WHERE hd.TrangThai = N'Đang hiệu lực'
  AND DATEDIFF(DAY, GETDATE(), hd.NgayKetThuc) BETWEEN 0 AND 30;
GO

-- View 6: Danh sách khách nợ tiền
CREATE VIEW vw_KhachNoTien AS
SELECT 
    kh.MaKhach,
    kh.TenKhach,
    kh.SoDienThoai,
    kh.Email,
    p.MaPhong,
    p. TenPhong,
    COUNT(hd.MaHoaDon) AS SoHoaDonNo,
    SUM(hd.TongTien) AS TongTienNo,
    MIN(hd.NgayHetHan) AS HoaDonCuNhat
FROM KhachHang kh
INNER JOIN HopDong hop ON kh.MaKhach = hop.MaKhach
INNER JOIN Phong p ON hop.MaPhong = p.MaPhong
INNER JOIN HoaDon hd ON hop.MaHopDong = hd.MaHopDong
WHERE hd.TrangThai = N'Chưa thanh toán'
  AND hop.TrangThai = N'Đang hiệu lực'
GROUP BY kh.MaKhach, kh.TenKhach, kh.SoDienThoai, kh.Email, p.MaPhong, p.TenPhong;
GO

-- View 7: Thống kê tổng quan hệ thống
CREATE VIEW vw_ThongKeTongQuan AS
SELECT 
    (SELECT COUNT(*) FROM Phong) AS TongSoPhong,
    (SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Trống') AS SoPhongTrong,
    (SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Đã thuê') AS SoPhongDaThue,
    (SELECT COUNT(*) FROM KhachHang) AS TongSoKhachHang,
    (SELECT COUNT(*) FROM HopDong WHERE TrangThai = N'Đang hiệu lực') AS SoHopDongHieuLuc,
    (SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Chưa thanh toán') AS SoHoaDonChuaThu,
    (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE TrangThai = N'Chưa thanh toán') AS TongTienChuaThu,
    (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE TrangThai = N'Đã thanh toán' AND MONTH(NgayThanhToan) = MONTH(GETDATE()) AND YEAR(NgayThanhToan) = YEAR(GETDATE())) AS DoanhThuThangNay,
    (SELECT COUNT(*) FROM BaoCaoSuCo WHERE TrangThai IN (N'Chờ xử lý', N'Đang xử lý')) AS SoSuCoChuaXuLy;
GO

-- =============================================
-- PHẦN 4: TẠO STORED PROCEDURES
-- =============================================

-- SP 1: Đăng nhập
GO
CREATE PROCEDURE sp_DangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @KetQua TABLE (
        TenDangNhap NVARCHAR(50),
        HoTen NVARCHAR(100),
        VaiTro NVARCHAR(20),
        MaKhach NVARCHAR(20),
        Email NVARCHAR(100),
        TrangThai BIT
    );
    
    INSERT INTO @KetQua
    SELECT 
        TenDangNhap,
        HoTen,
        VaiTro,
        MaKhach,
        Email,
        TrangThai
    FROM TaiKhoan
    WHERE TenDangNhap = @TenDangNhap 
      AND MatKhau = @MatKhau
      AND TrangThai = 1;
    
    IF EXISTS (SELECT 1 FROM @KetQua)
    BEGIN
        -- Cập nhật lần đăng nhập cuối
        UPDATE TaiKhoan 
        SET LanDangNhapCuoi = GETDATE()
        WHERE TenDangNhap = @TenDangNhap;
        
        -- Trả về thông tin
        SELECT * FROM @KetQua;
    END
    ELSE
    BEGIN
        -- Đăng nhập thất bại
        SELECT NULL AS TenDangNhap;
    END
END
GO

-- SP 2: Đổi mật khẩu
GO
CREATE PROCEDURE sp_DoiMatKhau
    @TenDangNhap NVARCHAR(50),
    @MatKhauCu NVARCHAR(100),
    @MatKhauMoi NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu)
    BEGIN
        SELECT 'ERROR' AS Status, N'Mật khẩu cũ không đúng' AS Message;
        RETURN;
    END
    
    UPDATE TaiKhoan
    SET MatKhau = @MatKhauMoi
    WHERE TenDangNhap = @TenDangNhap;
    
    SELECT 'SUCCESS' AS Status, N'Đổi mật khẩu thành công' AS Message;
END
GO

-- SP 3: Tạo hóa đơn tự động
GO
CREATE PROCEDURE sp_TaoHoaDonTuDong
    @ThangNam NVARCHAR(7),  -- Format: YYYY-MM
    @DonGiaDien DECIMAL(18,0) = 3500,
    @DonGiaNuoc DECIMAL(18,0) = 20000
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DECLARE @MaHopDong NVARCHAR(20);
        DECLARE @MaPhong NVARCHAR(20);
        DECLARE @GiaThue DECIMAL(18,0);
        DECLARE @MaHoaDon NVARCHAR(20);
        DECLARE @STT INT = 1;
        
        -- Cursor để duyệt qua các hợp đồng đang hiệu lực
        DECLARE cur_HopDong CURSOR FOR
        SELECT MaHopDong, MaPhong, GiaThue
        FROM HopDong
        WHERE TrangThai = N'Đang hiệu lực'
          AND NOT EXISTS (
              SELECT 1 FROM HoaDon 
              WHERE MaHopDong = HopDong.MaHopDong 
                AND ThangNam = @ThangNam
          );
        
        OPEN cur_HopDong;
        FETCH NEXT FROM cur_HopDong INTO @MaHopDong, @MaPhong, @GiaThue;
        
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Tạo mã hóa đơn:  HD + YYYYMM + STT
            SET @MaHoaDon = 'HD' + REPLACE(@ThangNam, '-', '') + RIGHT('000' + CAST(@STT AS NVARCHAR), 3);
            
            -- Lấy chỉ số điện nước cũ từ hóa đơn tháng trước
            DECLARE @ChiSoDienCu INT = 0;
            DECLARE @ChiSoNuocCu INT = 0;
            
            SELECT TOP 1 
                @ChiSoDienCu = ChiSoDienMoi,
                @ChiSoNuocCu = ChiSoNuocMoi
            FROM HoaDon
            WHERE MaHopDong = @MaHopDong
            ORDER BY ThangNam DESC;
            
            -- Tạo hóa đơn mới
            INSERT INTO HoaDon (
                MaHoaDon, MaHopDong, ThangNam, 
                NgayTao, NgayHetHan,
                ChiSoDienCu, ChiSoDienMoi,
                DonGiaDien,
                ChiSoNuocCu, ChiSoNuocMoi,
                DonGiaNuoc,
                TienPhong, TrangThai
            )
            VALUES (
                @MaHoaDon, @MaHopDong, @ThangNam,
                GETDATE(), 
                DATEADD(DAY, 5, DATEFROMPARTS(CAST(LEFT(@ThangNam, 4) AS INT), CAST(RIGHT(@ThangNam, 2) AS INT), 1)),
                @ChiSoDienCu, @ChiSoDienCu,
                @DonGiaDien,
                @ChiSoNuocCu, @ChiSoNuocCu,
                @DonGiaNuoc,
                @GiaThue, N'Chưa thanh toán'
            );
            
            SET @STT = @STT + 1;
            FETCH NEXT FROM cur_HopDong INTO @MaHopDong, @MaPhong, @GiaThue;
        END
        
        CLOSE cur_HopDong;
        DEALLOCATE cur_HopDong;
        
        COMMIT TRANSACTION;
        
        SELECT 'SUCCESS' AS Status, @STT - 1 AS SoHoaDonTao, N'Tạo hóa đơn thành công' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- SP 4: Cập nhật chỉ số điện nước
GO
CREATE PROCEDURE sp_CapNhatChiSoDienNuoc
    @MaHoaDon NVARCHAR(20),
    @ChiSoDienMoi INT,
    @ChiSoNuocMoi INT,
    @TienKhac DECIMAL(18,0) = 0,
    @GiamGia DECIMAL(18,0) = 0,
    @GhiChu NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @ChiSoDienCu INT;
        DECLARE @ChiSoNuocCu INT;
        
        SELECT @ChiSoDienCu = ChiSoDienCu, @ChiSoNuocCu = ChiSoNuocCu
        FROM HoaDon
        WHERE MaHoaDon = @MaHoaDon;
        
        IF @ChiSoDienMoi < @ChiSoDienCu
        BEGIN
            SELECT 'ERROR' AS Status, N'Chỉ số điện mới phải lớn hơn hoặc bằng chỉ số cũ' AS Message;
            RETURN;
        END
        
        IF @ChiSoNuocMoi < @ChiSoNuocCu
        BEGIN
            SELECT 'ERROR' AS Status, N'Chỉ số nước mới phải lớn hơn hoặc bằng chỉ số cũ' AS Message;
            RETURN;
        END
        
        UPDATE HoaDon
        SET ChiSoDienMoi = @ChiSoDienMoi,
            ChiSoNuocMoi = @ChiSoNuocMoi,
            TienKhac = @TienKhac,
            GiamGia = @GiamGia,
            GhiChu = ISNULL(@GhiChu, GhiChu)
        WHERE MaHoaDon = @MaHoaDon;
        
        SELECT 'SUCCESS' AS Status, N'Cập nhật chỉ số thành công' AS Message;
    END TRY
    BEGIN CATCH
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- SP 5: Thanh toán hóa đơn
GO
CREATE PROCEDURE sp_ThanhToanHoaDon
    @MaHoaDon NVARCHAR(20),
    @HinhThucThanhToan NVARCHAR(50),
    @SoTien DECIMAL(18,0) = NULL,
    @GhiChu NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DECLARE @TongTien DECIMAL(18,0);
        
        SELECT @TongTien = TongTien
        FROM HoaDon
        WHERE MaHoaDon = @MaHoaDon;
        
        IF @SoTien IS NULL
            SET @SoTien = @TongTien;
        
        -- Cập nhật trạng thái hóa đơn
        UPDATE HoaDon
        SET TrangThai = N'Đã thanh toán',
            NgayThanhToan = GETDATE(),
            HinhThucThanhToan = @HinhThucThanhToan
        WHERE MaHoaDon = @MaHoaDon;
        
        -- Lưu lịch sử thanh toán
        INSERT INTO LichSuThanhToan (MaHoaDon, SoTien, HinhThuc, GhiChu)
        VALUES (@MaHoaDon, @SoTien, @HinhThucThanhToan, @GhiChu);
        
        COMMIT TRANSACTION;
        
        SELECT 'SUCCESS' AS Status, N'Thanh toán thành công' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- SP 6: Lập hợp đồng
GO
CREATE PROCEDURE sp_LapHopDong
    @MaHopDong NVARCHAR(20),
    @MaKhach NVARCHAR(20),
    @MaPhong NVARCHAR(20),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @TienCoc DECIMAL(18,0),
    @GiaThue DECIMAL(18,0),
    @GhiChu NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra phòng có trống không
        DECLARE @TrangThaiPhong NVARCHAR(20);
        SELECT @TrangThaiPhong = TrangThai FROM Phong WHERE MaPhong = @MaPhong;
        
        IF @TrangThaiPhong != N'Trống'
        BEGIN
            SELECT 'ERROR' AS Status, N'Phòng không ở trạng thái trống' AS Message;
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Tạo hợp đồng
        INSERT INTO HopDong (MaHopDong, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienCoc, GiaThue, GhiChu)
        VALUES (@MaHopDong, @MaKhach, @MaPhong, @NgayBatDau, @NgayKetThuc, @TienCoc, @GiaThue, @GhiChu);
        
        -- Cập nhật trạng thái phòng
        UPDATE Phong
        SET TrangThai = N'Đã thuê'
        WHERE MaPhong = @MaPhong;
        
        COMMIT TRANSACTION;
        
        SELECT 'SUCCESS' AS Status, N'Lập hợp đồng thành công' AS Message, @MaHopDong AS MaHopDong;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- SP 7: Thanh lý hợp đồng
GO
CREATE PROCEDURE sp_ThanhLyHopDong
    @MaHopDong NVARCHAR(20),
    @LyDo NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        DECLARE @MaPhong NVARCHAR(20);
        
        SELECT @MaPhong = MaPhong FROM HopDong WHERE MaHopDong = @MaHopDong;
        
        -- Cập nhật trạng thái hợp đồng
        UPDATE HopDong
        SET TrangThai = N'Đã thanh lý',
            GhiChu = @LyDo
        WHERE MaHopDong = @MaHopDong;
        
        -- Cập nhật trạng thái phòng
        UPDATE Phong
        SET TrangThai = N'Trống'
        WHERE MaPhong = @MaPhong;
        
        COMMIT TRANSACTION;
        
        SELECT 'SUCCESS' AS Status, N'Thanh lý hợp đồng thành công' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- SP 8: Gia hạn hợp đồng
GO
CREATE PROCEDURE sp_GiaHanHopDong
    @MaHopDong NVARCHAR(20),
    @NgayKetThucMoi DATE,
    @GiaThue DECIMAL(18,0) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @NgayKetThucCu DATE;
        
        SELECT @NgayKetThucCu = NgayKetThuc FROM HopDong WHERE MaHopDong = @MaHopDong;
        
        IF @NgayKetThucMoi <= @NgayKetThucCu
        BEGIN
            SELECT 'ERROR' AS Status, N'Ngày kết thúc mới phải sau ngày kết thúc cũ' AS Message;
            RETURN;
        END
        
        IF @GiaThue IS NOT NULL
        BEGIN
            UPDATE HopDong
            SET NgayKetThuc = @NgayKetThucMoi,
                GiaThue = @GiaThue,
                TrangThai = N'Đang hiệu lực'
            WHERE MaHopDong = @MaHopDong;
        END
        ELSE
        BEGIN
            UPDATE HopDong
            SET NgayKetThuc = @NgayKetThucMoi,
                TrangThai = N'Đang hiệu lực'
            WHERE MaHopDong = @MaHopDong;
        END
        
        SELECT 'SUCCESS' AS Status, N'Gia hạn hợp đồng thành công' AS Message;
    END TRY
    BEGIN CATCH
        SELECT 'ERROR' AS Status, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- =============================================
-- PHẦN 5: TẠO TRIGGERS
-- =============================================

-- Trigger 1: Tự động cập nhật NgayCapNhat
GO
CREATE TRIGGER trg_Phong_Update
ON Phong
AFTER UPDATE
AS
BEGIN
    UPDATE Phong
    SET NgayCapNhat = GETDATE()
    WHERE MaPhong IN (SELECT MaPhong FROM inserted);
END
GO

CREATE TRIGGER trg_KhachHang_Update
ON KhachHang
AFTER UPDATE
AS
BEGIN
    UPDATE KhachHang
    SET NgayCapNhat = GETDATE()
    WHERE MaKhach IN (SELECT MaKhach FROM inserted);
END
GO

CREATE TRIGGER trg_HopDong_Update
ON HopDong
AFTER UPDATE
AS
BEGIN
    UPDATE HopDong
    SET NgayCapNhat = GETDATE()
    WHERE MaHopDong IN (SELECT MaHopDong FROM inserted);
END
GO

-- Trigger 2: Tự động cập nhật trạng thái hóa đơn quá hạn
GO
CREATE TRIGGER trg_HoaDon_KiemTraQuaHan
ON HoaDon
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE HoaDon
    SET TrangThai = N'Quá hạn'
    WHERE NgayHetHan < GETDATE()
      AND TrangThai = N'Chưa thanh toán';
END
GO

-- =============================================
-- PHẦN 6: THÊM DỮ LIỆU MẪU
-- =============================================

-- 1. Thêm Tài khoản Admin
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro) VALUES
('admin', '123456', N'Quản trị viên', 'admin@nhatro.vn', '0900000000', 'Admin');
GO

-- 2. Thêm Khách hàng
INSERT INTO KhachHang (MaKhach, TenKhach, SoDienThoai, CMND, DiaChi, NgaySinh, GioiTinh, Email) VALUES
('KH001', N'Phạm Minh Đức', '0911234567', '001234567890', N'123 Lê Lợi, Q1, TP.HCM', '1995-05-10', N'Nam', 'pmd@gmail.com'),
('KH002', N'Nguyễn Thị Em', '0912345678', '001234567891', N'456 Nguyễn Huệ, Q1, TP.HCM', '1998-08-15', N'Nữ', 'nte@gmail.com'),
('KH003', N'Trần Văn Phong', '0913456789', '001234567892', N'789 Trần Hưng Đạo, Q5, TP.HCM', '1992-12-20', N'Nam', 'tvp@gmail.com'),
('KH004', N'Lê Thị Giang', '0914567890', '001234567893', N'321 Cách Mạng Tháng 8, Q3, TP.HCM', '1997-03-25', N'Nữ', 'ltg@gmail.com'),
('KH005', N'Hoàng Văn Hùng', '0915678901', '001234567894', N'654 Lý Thường Kiệt, Q10, TP.HCM', '1994-07-30', N'Nam', 'hvh@gmail.com');
GO

-- 3. Thêm Tài khoản Khách hàng
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, MaKhach) VALUES
('khach001', '123456', N'Phạm Minh Đức', 'pmd@gmail.com', '0911234567', 'KhachHang', 'KH001'),
('khach002', '123456', N'Nguyễn Thị Em', 'nte@gmail.com', '0912345678', 'KhachHang', 'KH002'),
('khach003', '123456', N'Trần Văn Phong', 'tvp@gmail. com', '0913456789', 'KhachHang', 'KH003');
GO

-- 4. Thêm Phòng
INSERT INTO Phong (MaPhong, TenPhong, Tang, GiaPhong, TrangThai, LoaiPhong, DienTich, SoNguoiToiDa, TienIch) VALUES
('P101', N'Phòng 101', 1, 3000000, N'Đã thuê', N'Phòng đơn', 20, 2, N'Điều hòa, Nóng lạnh, WiFi, Giường, Tủ'),
('P102', N'Phòng 102', 1, 3500000, N'Đã thuê', N'Phòng đôi', 25, 3, N'Điều hòa, Nóng lạnh, WiFi, Tủ lạnh, Giường, Tủ'),
('P103', N'Phòng 103', 1, 3200000, N'Trống', N'Phòng đơn', 22, 2, N'Điều hòa, Nóng lạnh, WiFi, Giường, Tủ'),
('P201', N'Phòng 201', 2, 4000000, N'Đã thuê', N'Phòng VIP', 30, 4, N'Điều hòa, Nóng lạnh, WiFi, Tủ lạnh, Máy giặt, Bếp'),
('P202', N'Phòng 202', 2, 3800000, N'Trống', N'Phòng đôi', 28, 3, N'Điều hòa, Nóng lạnh, WiFi, Tủ lạnh, Giường, Tủ'),
('P203', N'Phòng 203', 2, 3500000, N'Đang sửa', N'Phòng đơn', 24, 2, N'Điều hòa, Nóng lạnh, WiFi, Giường, Tủ'),
('P301', N'Phòng 301', 3, 4500000, N'Đã thuê', N'Phòng VIP', 35, 4, N'Full nội thất cao cấp'),
('P302', N'Phòng 302', 3, 4200000, N'Trống', N'Phòng VIP', 32, 4, N'Full nội thất cao cấp');
GO

-- 5. Thêm Hợp đồng
INSERT INTO HopDong (MaHopDong, MaKhach, MaPhong, NgayBatDau, NgayKetThuc, TienCoc, GiaThue, TrangThai) VALUES
('HD2024001', 'KH001', 'P101', '2024-01-01', '2024-12-31', 3000000, 3000000, N'Đang hiệu lực'),
('HD2024002', 'KH002', 'P102', '2024-02-01', '2025-01-31', 3500000, 3500000, N'Đang hiệu lực'),
('HD2024003', 'KH003', 'P201', '2024-03-01', '2025-02-28', 4000000, 4000000, N'Đang hiệu lực'),
('HD2024004', 'KH005', 'P301', '2024-04-01', '2025-03-31', 4500000, 4500000, N'Đang hiệu lực');
GO

-- 6. Thêm Hóa đơn
INSERT INTO HoaDon (MaHoaDon, MaHopDong, ThangNam, NgayTao, NgayHetHan, 
    ChiSoDienCu, ChiSoDienMoi, ChiSoNuocCu, ChiSoNuocMoi, TienPhong, TrangThai, NgayThanhToan, HinhThucThanhToan) 
VALUES
-- Hóa đơn tháng 1/2024 - Đã thanh toán
('HD202401001', 'HD2024001', '2024-01', '2024-01-25', '2024-02-05', 0, 120, 0, 15, 3000000, N'Đã thanh toán', '2024-02-03', N'Tiền mặt'),
-- Hóa đơn tháng 2/2024 - Đã thanh toán
('HD202402001', 'HD2024001', '2024-02', '2024-02-25', '2024-03-05', 120, 245, 15, 32, 3000000, N'Đã thanh toán', '2024-03-02', N'Chuyển khoản'),
('HD202402002', 'HD2024002', '2024-02', '2024-02-25', '2024-03-05', 0, 100, 0, 12, 3500000, N'Đã thanh toán', '2024-03-01', N'Tiền mặt'),
-- Hóa đơn tháng 3/2024 - Đã thanh toán
('HD202403001', 'HD2024001', '2024-03', '2024-03-25', '2024-04-05', 245, 368, 32, 48, 3000000, N'Đã thanh toán', '2024-04-03', N'Chuyển khoản'),
('HD202403002', 'HD2024002', '2024-03', '2024-03-25', '2024-04-05', 100, 215, 12, 26, 3500000, N'Đã thanh toán', '2024-04-02', N'Tiền mặt'),
('HD202403003', 'HD2024003', '2024-03', '2024-03-25', '2024-04-05', 0, 150, 0, 18, 4000000, N'Đã thanh toán', '2024-04-02', N'Chuyển khoản'),
-- Hóa đơn tháng 1/2026 - Chưa thanh toán (tháng hiện tại)
('HD202601001', 'HD2024001', '2026-01', '2026-01-25', '2026-02-05', 368, 490, 48, 65, 3000000, N'Chưa thanh toán', NULL, NULL),
('HD202601002', 'HD2024002', '2026-01', '2026-01-25', '2026-02-05', 215, 335, 26, 42, 3500000, N'Chưa thanh toán', NULL, NULL),
('HD202601003', 'HD2024003', '2026-01', '2026-01-25', '2026-02-05', 150, 280, 18, 35, 4000000, N'Chưa thanh toán', NULL, NULL),
('HD202601004', 'HD2024004', '2026-01', '2026-01-25', '2026-02-05', 0, 140, 0, 20, 4500000, N'Chưa thanh toán', NULL, NULL);
GO

-- 7. Thêm Báo cáo sự cố
INSERT INTO BaoCaoSuCo (MaPhong, MaKhach, TieuDe, NoiDung, MucDo, TrangThai, NgayXuLy, GhiChu) VALUES
('P101', 'KH001', N'Điều hòa không lạnh', N'Điều hòa trong phòng không hoạt động tốt, không đủ lạnh', N'Cao', N'Đã xử lý', '2024-03-16', N'Đã thay gas điều hòa'),
('P201', 'KH003', N'Vòi nước bị rỉ', N'Vòi nước trong nhà tắm bị rỉ nước', N'Bình thường', N'Đang xử lý', NULL, NULL),
('P102', 'KH002', N'Bóng đèn hỏng', N'Bóng đèn trong phòng ngủ bị hỏng', N'Thấp', N'Chờ xử lý', NULL, NULL);
GO

-- =============================================
-- PHẦN 7: QUERY KIỂM TRA
-- =============================================

-- Query 1: Xem tất cả tài khoản
SELECT * FROM vw_ThongTinTaiKhoan ORDER BY VaiTro;
GO

-- Query 2: Xem thông tin phòng
SELECT * FROM vw_ThongTinPhong ORDER BY MaPhong;
GO

-- Query 3: Xem hóa đơn chi tiết
SELECT * FROM vw_HoaDonChiTiet ORDER BY ThangNam DESC, MaHoaDon;
GO

-- Query 4: Báo cáo doanh thu
SELECT * FROM vw_DoanhThuThang ORDER BY ThangNam DESC;
GO

-- Query 5: Hợp đồng sắp hết hạn
SELECT * FROM vw_HopDongSapHetHan ORDER BY SoNgayConLai;
GO

-- Query 6: Danh sách khách nợ tiền
SELECT * FROM vw_KhachNoTien ORDER BY TongTienNo DESC;
GO

-- Query 7: Thống kê tổng quan
SELECT * FROM vw_ThongKeTongQuan;
GO

-- Query 8: Báo cáo sự cố chưa xử lý
SELECT * FROM BaoCaoSuCo WHERE TrangThai IN (N'Chờ xử lý', N'Đang xử lý') ORDER BY MucDo DESC, NgayBaoCao DESC;
GO

PRINT N'============================================='
PRINT N'TẠO DATABASE THÀNH CÔNG!'
PRINT N'============================================='
PRINT N'Tài khoản Admin:'
PRINT N'  Username: admin'
PRINT N'  Password: 123456'
PRINT N''
PRINT N'Tài khoản Khách hàng:'
PRINT N'  Username: khach001 / Password: 123456'
PRINT N'  Username: khach002 / Password:  123456'
PRINT N'  Username: khach003 / Password: 123456'
PRINT N'============================================='
PRINT N'Cấu trúc hệ thống:'
PRINT N'- 7 bảng chính'
PRINT N'- Chỉ 1 Admin quản lý'
PRINT N'- Khách hàng có tài khoản xem hóa đơn'
PRINT N'- Hóa đơn:  Tiền phòng + Điện + Nước + Khác'
PRINT N'- Có báo cáo sự cố'
PRINT N'============================================='
GO
-- T?o b?ng DonDatPhong
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DonDatPhong]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[DonDatPhong](
        [MaDonDat] NVARCHAR(50) PRIMARY KEY,
        [MaPhong] NVARCHAR(50) NOT NULL,
        [TenDangNhap] NVARCHAR(50) NOT NULL,
        [NgayDat] DATETIME NOT NULL DEFAULT GETDATE(),
        [TrangThai] NVARCHAR(50) NOT NULL DEFAULT N'Ch? x? lý',
        [GhiChu] NVARCHAR(500),
        [NgayXuLy] DATETIME NULL,
        [NguoiXuLy] NVARCHAR(50) NULL,
        FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
        FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
    )
END
GO

-- Thêm c?t IsVerified vào b?ng TaiKhoan n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'IsVerified')
BEGIN
    ALTER TABLE TaiKhoan ADD IsVerified BIT NOT NULL DEFAULT 0
END
GO

-- Thêm c?t VerificationToken n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'VerificationToken')
BEGIN
    ALTER TABLE TaiKhoan ADD VerificationToken NVARCHAR(100) NULL
END
GO

-- Thêm c?t ResetPasswordToken n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'ResetPasswordToken')
BEGIN
    ALTER TABLE TaiKhoan ADD ResetPasswordToken NVARCHAR(100) NULL
END
GO

-- Thêm c?t ResetPasswordExpiry n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'ResetPasswordExpiry')
BEGIN
    ALTER TABLE TaiKhoan ADD ResetPasswordExpiry DATETIME NULL
END
GO

-- Thêm c?t Email n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'Email')
BEGIN
    ALTER TABLE TaiKhoan ADD Email NVARCHAR(100) NULL
END
GO

-- C?p nh?t t?t c? tài kho?n hi?n t?i là ?ã verified
UPDATE TaiKhoan SET IsVerified = 1 WHERE IsVerified = 0
GO

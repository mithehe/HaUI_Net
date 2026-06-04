CREATE DATABASE QLKhachSan;
GO
USE QLKhachSan;
GO
CREATE TABLE KhachHang (
    MaKH NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(150) NOT NULL,
    SDT NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
CREATE TABLE Phong (
    MaPhong NVARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50) NOT NULL,
    GiaThue INT NOT NULL CHECK (GiaThue > 0),
    TrangThai NVARCHAR(20) NOT NULL
);
CREATE TABLE DatPhong (
    MaDatPhong NVARCHAR(10) NOT NULL,
    MaKH NVARCHAR(10) NOT NULL,
    MaPhong NVARCHAR(10) NOT NULL,
    NgayNhanPhong DATE NOT NULL,
    NgayTraPhong DATE NOT NULL,
    TongTien INT NOT NULL CHECK (TongTien > 0),
    PRIMARY KEY (MaDatPhong, MaPhong),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);
INSERT INTO KhachHang VALUES
    (N'KH01', N'Nguyễn Minh Tuấn', N'0901234567', N'tuan@email.com'),
    (N'KH02', N'Trần Thị Lan', N'0912345678', N'lan@email.com'),
    (N'KH03', N'Lê Hoàng Nam', N'0923456789', N'nam@email.com');
INSERT INTO Phong VALUES
    (N'P101', N'Standard', 500000, N'Trống'),
    (N'P201', N'Deluxe', 900000, N'Đã đặt'),
    (N'P301', N'Suite', 1500000, N'Trống'),
    (N'P202', N'Deluxe', 850000, N'Đã đặt');
INSERT INTO DatPhong VALUES
    (N'DP01', N'KH01', N'P201', '2026-05-10', '2026-05-13', 2700000),
    (N'DP02', N'KH02', N'P202', '2026-05-12', '2026-05-15', 2550000),
    (N'DP03', N'KH03', N'P101', '2026-05-14', '2026-05-16', 1000000);

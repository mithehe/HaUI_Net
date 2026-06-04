CREATE DATABASE QLNhaSach;
GO
USE QLNhaSach;
GO
CREATE TABLE PhongBan (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(100) NOT NULL
);
CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(150) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    Luong INT NOT NULL CHECK (Luong > 0),
    MaPhong INT NOT NULL,
    FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
);
CREATE TABLE DonHang (
    MaDH NVARCHAR(10) NOT NULL,
    MaNV NVARCHAR(10) NOT NULL,
    NgayDat DATE NOT NULL,
    TongTien INT NOT NULL CHECK (TongTien > 0),
    PRIMARY KEY (MaDH, MaNV),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
INSERT INTO PhongBan(TenPhong) VALUES
    (N'Kinh doanh'), (N'Kế toán'), (N'Kỹ thuật');
INSERT INTO NhanVien(MaNV, HoTen, ChucVu, Luong, MaPhong) VALUES
    (N'NV01', N'Nguyễn Văn An', N'Trưởng phòng', 15000000, 1),
    (N'NV02', N'Trần Thị Bình', N'Nhân viên', 8000000, 1),
    (N'NV03', N'Lê Văn Cường', N'Nhân viên', 7500000, 2),
    (N'NV04', N'Phạm Thị Dung', N'Kế toán', 9000000, 2);
INSERT INTO DonHang(MaDH, MaNV, NgayDat, TongTien) VALUES
    (N'DH01', N'NV01', '2026-05-01', 5000000),
    (N'DH01', N'NV02', '2026-05-01', 3000000),
    (N'DH02', N'NV03', '2026-05-02', 7000000),
    (N'DH03', N'NV04', '2026-05-03', 4500000);
 
 SELECT *FROM PhongBan
  SELECT *FROM NhanVien
   SELECT *FROM DonHang
 
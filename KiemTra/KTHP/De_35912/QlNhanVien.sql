CREATE DATABASE QLNhanVien
GO

USE QLNhanVien
GO

CREATE TABLE PhongBan(
MaPB nchar(10) NOT NULL PRIMARY KEY,
TenPB nvarchar(50),
);

CREATE TABLE NhanVien(
MaNV nchar(10) NOT NULL PRIMARY KEY,
HoTen nvarchar(100),
NgaySinh Date,
LuongCB Float,
MaPB nchar(10) FOREIGN KEY REFERENCES PhongBan(MaPB)
);

INSERT INTO PhongBan(MaPB, TenPB) values
('PB01', N'Kế toán'),
('PB02', N'Kỹ thuật');

INSERT INTO NhanVien(MaNV, HoTen, NgaySinh, LuongCB, MaPB) values
('NV01', N'Nguyễn Văn Bình', '1990-05-12', 8000000, 'PB01'),
('NV02', N'Trần Thị Lan', '1995-03-20', 6500000, 'PB02'),
('NV03', N'Lê Quang Hải', '1988-11-08', 10000000, 'PB01'),
('NV04', N'Phạm Thị Ngọc', '1992-07-15', 4500000, 'PB02');

SELECT * FROM PhongBan
SELECT * FROM NhanVien

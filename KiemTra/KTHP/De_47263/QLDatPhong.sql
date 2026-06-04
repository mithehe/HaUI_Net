CREATE DATABASE QLDatPhong
GO

USE QLDatPhong
GO

CREATE TABLE LoaiPhong(
MaLoai nchar(10) NOT NULL PRIMARY KEY,
TenLoai nvarchar(100)
);

CREATE TABLE DatPhong(
MaDP nchar(10) NOT NULL PRIMARY KEY,
TenKhach nvarchar(100),
SoNgayO int,
GiaPhong float,
MaLoai nchar(10) NOT NULL FOREIGN KEY REFERENCES LoaiPhong(MaLoai),
);

INSERT INTO LoaiPhong(MaLoai, TenLoai) values
('LP01', N'Phòng đơn'),
('LP02', N'Phòng đôi');

INSERT INTO DatPhong(MaDP, TenKhach, SoNgayO, GiaPhong, MaLoai) values
('DP01', N'Hoàng Văn Nam', 5, 500000,'LP01'),
('DP02', N'Vũ Thị Hoa', 10, 800000,'LP02'),
('DP03', N'Đinh Quang Hùng', 3, 500000,'LP01'),
('DP04', N'Bùi Thị Mai', 14, 1200000,'LP02');

SELECT *FROM LoaiPhong
SELECT *FROM DatPhong
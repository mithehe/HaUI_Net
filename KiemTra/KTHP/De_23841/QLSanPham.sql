CREATE DATABASE QLSanPham
GO

USE QLSanPham
GO

CREATE TABLE DanhMuc(
MaDM nchar(10) NOT NULL PRIMARY KEY,
TenDM nvarchar(50),
);

CREATE TABLE SanPham(
MaSP nchar(10) NOT NULL PRIMARY KEY,
TenSP nvarchar(100),
DonGia float,
SoLuong int,
MaDM nchar(10) FOREIGN KEY REFERENCES DanhMuc(MaDM)
);

INSERT INTO DanhMuc(MaDM, TenDM) values
('DM01', N'Điện tử'),
('DM02', N'Gia dụng');

INSERT INTO SanPham(MaSP, TenSP, DonGia, SoLuong, MaDM) values
('SP01', N'Tivi Samsung', 8500000, 30, 'DM01'),
('SP02', N'Tủ lạnh Panasonic', 12000000, 15, 'DM02'),
('SP03', N'Điện thoại Oppo', 4500000, 60, 'DM01'),
('SP04', N'Máy giặt LG', 9000000, 20, 'DM02');

SELECT *FROM DanhMuc
SELECT *FROM SanPham
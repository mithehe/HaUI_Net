CREATE DATABASE QLKhoHang;
GO
USE QLKhoHang;
GO

-- 1. Tạo bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    MaNCC nchar(10) PRIMARY KEY,
    TenNCC nvarchar(50)
);

-- 2. Tạo bảng Hàng Hóa (Khai báo luôn khóa ngoại tại đây)
CREATE TABLE HangHoa (
    MaHH nchar(10) PRIMARY KEY,
    TenHH nvarchar(100),
    DonGia int,
    SoLuongTon int,
    MaNCC nchar(10) FOREIGN KEY REFERENCES NhaCungCap(MaNCC)
);
GO

-- 3. Thêm dữ liệu (Gộp các dòng lệnh Insert)
INSERT INTO NhaCungCap (MaNCC, TenNCC) VALUES 
    ('NCC01', N'Công ty ABC'),
    ('NCC02', N'Công ty XYZ');

INSERT INTO HangHoa (MaHH, TenHH, DonGia, SoLuongTon, MaNCC) VALUES 
    ('HH01', N'Gạo tẻ', 18000, 500, 'NCC01'),
    ('HH02', N'Đường cát',22000, 8, 'NCC02'),
    ('HH03', N'Dầu ăn', 45000, 0, 'NCC01'),
    ('HH04', N'Muối', 7000, 120, 'NCC02');
GO

-- 4. Truy xuất kiểm tra dữ liệu
SELECT * FROM NhaCungCap;
SELECT * FROM HangHoa;
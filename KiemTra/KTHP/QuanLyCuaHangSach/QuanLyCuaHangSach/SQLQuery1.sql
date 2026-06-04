CREATE DATABASE QLCuaHangSach;
GO
USE QLCuaHangSach;
GO
CREATE TABLE TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL
);
CREATE TABLE Sach (
    MaSach NVARCHAR(10) PRIMARY KEY,
    TenSach NVARCHAR(150) NOT NULL,
    DonGia INT NOT NULL CHECK (DonGia > 0),
    SoLuongTon INT NOT NULL CHECK (SoLuongTon >= 0),
    MaTheLoai INT NOT NULL,
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai)
);
CREATE TABLE ChiTietBanSach (
    MaHD NVARCHAR(10) NOT NULL,
    MaSach NVARCHAR(10) NOT NULL,
    NgayBan DATE NOT NULL,
    SoLuongBan INT NOT NULL CHECK (SoLuongBan > 0),
    PRIMARY KEY (MaHD, MaSach),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);
INSERT INTO TheLoai(TenTheLoai) VALUES
(N'Công nghệ'), (N'Kinh tế'), (N'Ngoại ngữ');
INSERT INTO Sach(MaSach, TenSach, DonGia, SoLuongTon, MaTheLoai) VALUES
(N'S01', N'Lập trình C# căn bản', 120000, 35, 1),
(N'S02', N'Phân tích dữ liệu với Python', 180000, 20, 1),
(N'S03', N'Kinh tế học ứng dụng', 150000, 28, 2),
(N'S04', N'Tiếng Anh giao tiếp', 95000, 42, 3);
INSERT INTO ChiTietBanSach(MaHD, MaSach, NgayBan, SoLuongBan) VALUES
(N'HD01', N'S01', '2026-05-01', 3),
(N'HD01', N'S02', '2026-05-01', 2),
(N'HD02', N'S03', '2026-05-02', 4),
(N'HD03', N'S04', '2026-05-03', 5);


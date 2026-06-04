CREATE DATABASE QuanLyTTDT;
GO

USE QuanLyTTDT;
GO

CREATE TABLE KhoaHoc (
    MaKhoaHoc VARCHAR(50) NOT NULL,    
    TenKhoaHoc NVARCHAR(255) NOT NULL, 
    GiangVien NVARCHAR(100),           
    SoTinChi INT,                     
    HocPhi DECIMAL(18, 2),             
    
    CONSTRAINT PK_KhoaHoc PRIMARY KEY (MaKhoaHoc)
);
GO

INSERT INTO KhoaHoc (MaKhoaHoc, TenKhoaHoc, GiangVien, SoTinChi, HocPhi)
VALUES 
('WPF01', N'Lập trình WPF Cơ bản', N'Nguyễn Văn A', 3, 1500000.00),
('WPF02', N'Lập trình WPF Nâng cao', N'Trần Thị B', 4, 2000000.00);
GO
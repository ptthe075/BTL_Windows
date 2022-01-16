CREATE DATABASE QLBANQUANAO
GO

USE QLBANQUANAO
GO

CREATE TABLE TaiKhoan(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenDangNhap varchar(100) not null unique,
	MatKhau varchar(100),
	LoaiTaiKhoan BIT, --0: admin 1: nhan vien
	ThoiGianDangNhapCuoi DateTime
)

INSERT INTO TaiKhoan(TenDangNhap,MatKhau,LoaiTaiKhoan)
VALUES ('Admin','Admin', 0)
GO

select * from TaiKhoan


CREATE TABLE NhanVien(
	ID int IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien char(5),
	HoTen nvarchar(100),
	NgaySinh date,
	GioiTinh nvarchar(3),
	SoDienThoai char(10),
	DiaChi nvarchar(500),
	LuongCoBanNgay int,
	IdTK int,
	FOREIGN KEY(IdTK) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE Luong(
	ID_Luong int IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien int,
	ThangNam date,
	SoNgayCong int,
	Thuong int,
	LuongCoBanNgay int,
	FOREIGN KEY(MaNhanVien) REFERENCES NhanVien(ID) ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE KhuyenMai(
	MaKhuyenMai int IDENTITY(1,1) PRIMARY KEY,
	Code varchar(10) not null unique,
	GiaTri int,
	SoLuongCon int,
	HanSuDung Date
)

insert into KhuyenMai values('GiangSinh', 20000, 10, '01-20-2022')
insert into KhuyenMai values('GiangSinh1', 30000, 10, '01-20-2022')
insert into KhuyenMai values('GiangSinh2', 40000, 10, '01-20-2022')


CREATE TABLE HoaDon(
	MaHoaDon char(14) PRIMARY KEY,
	ThoiGian datetime,
	LoaiHoaDon BIT, --0: hoa don nhap 1: hoa don ban
	GiamGia int,
	TongTien int,
	ID int,
	FOREIGN KEY(ID) REFERENCES TaiKhoan(ID) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE LoaiSanPham(
	MaLoaiSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenLoaiSanPham nvarchar(300)
)

insert into LoaiSanPham values(N'Áo phông')
insert into LoaiSanPham values(N'Áo polo')
insert into LoaiSanPham values(N'Áo sơ mi')
insert into LoaiSanPham values(N'Áo len')

insert into LoaiSanPham values(N'Quần jeans')
insert into LoaiSanPham values(N'Quần quần nỉ')
insert into LoaiSanPham values(N'Quần shorts')



CREATE TABLE SanPham(
	MaSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenSanPham nvarchar(300),
	DonGiaBan int,
	DonGiaNhap int,
	MoTa nvarchar(Max),
	--HinhAnh varchar(100),
	MaLoaiSanPham int,
	FOREIGN KEY(MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham) ON DELETE CASCADE ON UPDATE CASCADE
)

insert into SanPham values(N'Áo phông nữ cotton USA', 249000, 200000, '', 1)
insert into SanPham values(N'Áo phông cổ tròn', 249000, 200000, '', 1)
insert into SanPham values(N'Áo phông cổ tim', 249000, 200000, '', 1)
insert into SanPham values(N'Áo phông có cổ sơ mi', 249000, 200000, '', 1)
insert into SanPham values(N'Áo phông cổ chữ V', 249000, 200000, '', 1)

insert into SanPham values(N'Sơ mi kẻ sọc lịch lãm', 249000, 200000, '', 2)
insert into SanPham values(N'Sơ mi Oxford', 249000, 200000, '', 2)
insert into SanPham values(N'Sơ mi Dress Shirt', 249000, 200000, '', 2)
insert into SanPham values(N'Sơ mi cổ tàu', 249000, 200000, '', 2)
insert into SanPham values(N'Sơ mi cổ Cuba', 249000, 200000, '', 2)

insert into SanPham values(N'Áo polo Heyley', 249000, 200000, '', 3)
insert into SanPham values(N'Áo polo cổ điển', 249000, 200000, '', 3)

insert into SanPham values(N'Áo len nam cổ tròn', 249000, 200000, '', 4)
insert into SanPham values(N'Áo len nam cổ chữ V (cổ tim)', 249000, 200000, '', 4)
insert into SanPham values(N'Áo khoác len nam Cardigan', 249000, 200000, '', 4)
insert into SanPham values(N'Áo len nam ghi-le', 249000, 200000, '', 4)

insert into SanPham values(N'Quần Jean Ống Đứng', 249000, 200000, '', 5)
insert into SanPham values(N'Quần Jean Skinny', 249000, 200000, '', 5)
insert into SanPham values(N'Quần Short Jean', 249000, 200000, '', 5)
insert into SanPham values(N'Quần jean ống rộng', 249000, 200000, '', 5)

insert into SanPham values(N'Quần jogger thun', 249000, 200000, '', 6)
insert into SanPham values(N'Quần jogger nỉ', 249000, 200000, '', 6)
insert into SanPham values(N'Quần jogger kaki nam', 249000, 200000, '', 6)
insert into SanPham values(N'Quần jogger có sọc', 249000, 200000, '', 6)


insert into SanPham values(N'Quần short jean', 249000, 200000, '', 7)
insert into SanPham values(N'Quần short đơn sắc', 249000, 200000, '', 7)
insert into SanPham values(N'Quần short họa tiết hoa', 249000, 200000, '', 7)
insert into SanPham values(N'Quần short sọc dọc', 249000, 200000, '', 7)



CREATE TABLE KichThuoc(
	ID_KichThuoc int IDENTITY(1,1) PRIMARY KEY,
	Ten varchar(10)
)

insert into KichThuoc values('M')
insert into KichThuoc values('S')
insert into KichThuoc values('L')
insert into KichThuoc values('XL')
insert into KichThuoc values('XXL')

CREATE TABLE ChiTietSanPham(
	MaSanPham int,
	ID_KichThuoc int,
	SoLuongCon int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ID_KichThuoc) REFERENCES KichThuoc(ID_KichThuoc) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, ID_KichThuoc)
)

insert into ChiTietSanPham values(1, 1, 100)
insert into ChiTietSanPham values(1, 2, 100)
insert into ChiTietSanPham values(1, 3, 100)
insert into ChiTietSanPham values(1, 4, 100)

insert into ChiTietSanPham values(2, 1, 100)
insert into ChiTietSanPham values(2, 2, 100)
insert into ChiTietSanPham values(2, 3, 100)
insert into ChiTietSanPham values(2, 4, 100)

insert into ChiTietSanPham values(3, 1, 100)
insert into ChiTietSanPham values(3, 2, 100)
insert into ChiTietSanPham values(3, 3, 100)
insert into ChiTietSanPham values(3, 4, 100)

insert into ChiTietSanPham values(4, 1, 100)
insert into ChiTietSanPham values(4, 2, 100)
insert into ChiTietSanPham values(4, 3, 100)
insert into ChiTietSanPham values(4, 4, 100)

insert into ChiTietSanPham values(5, 1, 100)
insert into ChiTietSanPham values(5, 2, 100)
insert into ChiTietSanPham values(5, 3, 100)
insert into ChiTietSanPham values(5, 4, 100)

insert into ChiTietSanPham values(6, 1, 100)
insert into ChiTietSanPham values(6, 2, 100)
insert into ChiTietSanPham values(6, 3, 100)
insert into ChiTietSanPham values(6, 4, 100)

insert into ChiTietSanPham values(7, 1, 100)
insert into ChiTietSanPham values(7, 2, 100)
insert into ChiTietSanPham values(7, 3, 100)
insert into ChiTietSanPham values(7, 4, 100)


insert into ChiTietSanPham values(8, 1, 100)
insert into ChiTietSanPham values(8, 2, 100)
insert into ChiTietSanPham values(8, 3, 100)
insert into ChiTietSanPham values(8, 4, 100)


insert into ChiTietSanPham values(9, 1, 100)
insert into ChiTietSanPham values(9, 2, 100)
insert into ChiTietSanPham values(9, 3, 100)
insert into ChiTietSanPham values(9, 4, 100)


insert into ChiTietSanPham values(10, 1, 100)
insert into ChiTietSanPham values(10, 2, 100)
insert into ChiTietSanPham values(10, 3, 100)
insert into ChiTietSanPham values(10, 4, 100)

insert into ChiTietSanPham values(11, 1, 100)
insert into ChiTietSanPham values(11, 2, 100)
insert into ChiTietSanPham values(11, 3, 100)
insert into ChiTietSanPham values(11, 4, 100)


insert into ChiTietSanPham values(12, 1, 100)
insert into ChiTietSanPham values(12, 2, 100)
insert into ChiTietSanPham values(12, 3, 100)
insert into ChiTietSanPham values(12, 4, 100)


insert into ChiTietSanPham values(13, 1, 100)
insert into ChiTietSanPham values(13, 2, 100)
insert into ChiTietSanPham values(13, 3, 100)
insert into ChiTietSanPham values(13, 4, 100)


insert into ChiTietSanPham values(14, 1, 100)
insert into ChiTietSanPham values(14, 2, 100)
insert into ChiTietSanPham values(14, 3, 100)
insert into ChiTietSanPham values(14, 4, 100)



insert into ChiTietSanPham values(15, 1, 100)
insert into ChiTietSanPham values(15, 2, 100)
insert into ChiTietSanPham values(15, 3, 100)
insert into ChiTietSanPham values(15, 4, 100)


insert into ChiTietSanPham values(16, 1, 100)
insert into ChiTietSanPham values(16, 2, 100)
insert into ChiTietSanPham values(16, 3, 100)
insert into ChiTietSanPham values(16, 4, 100)

insert into ChiTietSanPham values(17, 1, 100)
insert into ChiTietSanPham values(17, 2, 100)
insert into ChiTietSanPham values(17, 3, 100)
insert into ChiTietSanPham values(17, 4, 100)

insert into ChiTietSanPham values(18, 1, 100)
insert into ChiTietSanPham values(18, 2, 100)
insert into ChiTietSanPham values(18, 3, 100)
insert into ChiTietSanPham values(18, 4, 100)

insert into ChiTietSanPham values(19, 1, 100)
insert into ChiTietSanPham values(19, 2, 100)
insert into ChiTietSanPham values(19, 3, 100)
insert into ChiTietSanPham values(19, 4, 100)

insert into ChiTietSanPham values(20, 1, 100)
insert into ChiTietSanPham values(20, 2, 100)
insert into ChiTietSanPham values(20, 3, 100)
insert into ChiTietSanPham values(20, 4, 100)

insert into ChiTietSanPham values(21, 1, 100)
insert into ChiTietSanPham values(21, 2, 100)
insert into ChiTietSanPham values(21, 3, 100)
insert into ChiTietSanPham values(21, 4, 100)

insert into ChiTietSanPham values(22, 1, 100)
insert into ChiTietSanPham values(22, 2, 100)
insert into ChiTietSanPham values(22, 3, 100)
insert into ChiTietSanPham values(22, 4, 100)

insert into ChiTietSanPham values(23, 1, 100)
insert into ChiTietSanPham values(23, 2, 100)
insert into ChiTietSanPham values(23, 3, 100)
insert into ChiTietSanPham values(23, 4, 100)

insert into ChiTietSanPham values(24, 1, 100)
insert into ChiTietSanPham values(24, 2, 100)
insert into ChiTietSanPham values(24, 3, 100)
insert into ChiTietSanPham values(24, 4, 100)

insert into ChiTietSanPham values(25, 1, 100)
insert into ChiTietSanPham values(25, 2, 100)
insert into ChiTietSanPham values(25, 3, 100)
insert into ChiTietSanPham values(25, 4, 100)

insert into ChiTietSanPham values(26, 1, 100)
insert into ChiTietSanPham values(26, 2, 100)
insert into ChiTietSanPham values(26, 3, 100)
insert into ChiTietSanPham values(26, 4, 100)


insert into ChiTietSanPham values(27, 1, 100)
insert into ChiTietSanPham values(27, 2, 100)
insert into ChiTietSanPham values(27, 3, 100)
insert into ChiTietSanPham values(27, 4, 100)

insert into ChiTietSanPham values(28, 1, 100)
insert into ChiTietSanPham values(28, 2, 100)
insert into ChiTietSanPham values(28, 3, 100)
insert into ChiTietSanPham values(28, 4, 100)



CREATE TABLE DongHoaDon(
	MaSanPham int,
	ID_KichThuoc int,
	MaHoaDon char(14),
	SoLuong int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ID_KichThuoc) REFERENCES KichThuoc(ID_KichThuoc) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, ID_KichThuoc, MaHoaDon)
)


















///////////////////////////////////////

select * from taikhoan
select * from nhanvien
select * from hoadon
select * from donghoadon
select * from luong




















INSERT INTO TaiKhoan(TenDangNhap,MatKhau,LoaiTaiKhoan)
VALUES ('user','123',0)

insert into NhanVien(HoTen, IdTK) values('Ngo van A', 2)


select * from HoaDon
select * from DongHoaDon

select * from TaiKhoan
select * from Luong

insert into HoaDon values('01','01-03-2022', 1, 0, 2000000, 2)
insert into HoaDon values('02','01-03-2022', 1, 0, 2000000, 2)
insert into HoaDon values('03','01-03-2021', 1, 0, 2000000, 2)
insert into HoaDon values('04','01-03-2021', 1, 0, 2000000, 2)
insert into HoaDon values('05','01-04-2022', 1, 0, 10000000, 2)

insert into SanPham(TenSanPham) values('So mi')
insert into SanPham(TenSanPham) values('Ao')
insert into SanPham(TenSanPham) values('Quan')
insert into SanPham(TenSanPham) values('Mu')
insert into SanPham(TenSanPham) values('Non')

insert into KichThuoc values('M')
insert into KichThuoc values('S')
insert into KichThuoc values('L')
insert into KichThuoc values('XL')

insert into DongHoaDon values(1, 1, '01', 2)
insert into DongHoaDon values(2, 1, '01', 5)


insert into DongHoaDon values(1, 1, '02', 2)
insert into DongHoaDon values(1, 2, '02', 1)
insert into DongHoaDon values(3, 1, '02', 10)

insert into DongHoaDon values(1, 1, '03', 2)

insert into DongHoaDon values(1, 1, '04', 2)
insert into DongHoaDon values(1, 2, '04', 1)
insert into DongHoaDon values(3, 1, '04', 10)


insert into DongHoaDon values(2, 1, '05', 2)
insert into DongHoaDon values(1, 2, '05', 4)



select *
from HoaDon inner join TaiKhoan on HoaDon.ID = TaiKhoan.ID
inner join NhanVien on TaiKhoan.ID = NhanVien.IdTK

select *
from HoaDon inner join TaiKhoan on HoaDon.ID = TaiKhoan.ID
inner join NhanVien on TaiKhoan.ID = NhanVien.IdTK
where MONTH(HoaDon.ThoiGian) = 1 AND YEAR(HoaDon.ThoiGian) = 8 AND HoaDon.LoaiHoaDon = 1









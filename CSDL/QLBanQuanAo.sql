CREATE DATABASE QLBANQUANAO
GO

USE QLBANQUANAO
GO

CREATE TABLE TaiKhoan(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenDangNhap varchar(100),
	MatKhau varchar(100),
	LoaiTaiKhoan BIT, --0: admin 1: nhan vien
)

INSERT INTO TaiKhoan(TenDangNhap,MatKhau,LoaiTaiKhoan)
VALUES ('Admin','Admin',0)
GO

CREATE TABLE NhanVien(
	ID int IDENTITY(1,1) PRIMARY KEY,
	MaNhanVien char(5),
	HoTen nvarchar(100),
	NgaySinh date,
	GioiTinh nvarchar(3),
	SoDienThoai char(10),
	DiaChi nvarchar(500),
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
	Code varchar(10),
	GiaTri int,
	SoLuongCon int,
	HanSuDung Date
)

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

CREATE TABLE SanPham(
	MaSanPham int IDENTITY(1,1) PRIMARY KEY,
	TenSanPham nvarchar(300),
	DonGiaBan int,
	DonGiaNhap int,
	MoTa nvarchar(Max),
	HinhAnh varchar(100),
	MaLoaiSanPham int,
	FOREIGN KEY(MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham) ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE KichThuoc(
	ID_KichThuoc int IDENTITY(1,1) PRIMARY KEY,
	Ten varchar(10)
)

CREATE TABLE ChiTietSanPham(
	MaSanPham int,
	ID_KichThuoc int,
	SoLuongCon int,
	FOREIGN KEY(MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(ID_KichThuoc) REFERENCES KichThuoc(ID_KichThuoc) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(MaSanPham, ID_KichThuoc)
)


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
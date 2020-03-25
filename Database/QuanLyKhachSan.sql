
CREATE  DATABASE QuanLyKhachSan
GO
USE QuanLyKhachSan
GO
 ---------------------------TẠO BẢNG----------------------------

CREATE TABLE VATDUNG(
  MaVatDung INT IDENTITY(1,1) NOT NULL,
  TenVatDung NVARCHAR(50),
  TinhTrang NVARCHAR(50),
  GiaVatDung INT,
  MaPhong INT
)
GO
CREATE TABLE PHONG(
   MaPhong INT IDENTITY(1,1) NOT NULL,
   TenPhong NVARCHAR (50),
   MaLoai INT,
   TrangThai BIT
)
GO
CREATE TABLE LOAIPHONG(
    MaLoai INT IDENTITY(1,1) NOT NULL,
	TenLoai NVARCHAR (50),
	GiaThue INT,
	GhiChu NVARCHAR(50)
)
GO
CREATE TABLE NHANVIEN(
    MaNV INT IDENTITY(1,1) NOT NULL ,
	TaiKhoan VARCHAR(50),
	MatKhau VARCHAR(50),
	HoTen NVARCHAR(100),
	NgaySinh DATE ,
	GioiTinh NVARCHAR (50),
	SDT CHAR(10) 
	)
GO
CREATE TABLE KHACHHANG(
    MaKH INT IDENTITY(1,1) NOT NULL, 
	TenKH NVARCHAR(100),
	SDT CHAR(10) 
	)
GO
CREATE TABLE DICHVU(
   MaDichVu INT IDENTITY(1,1) NOT NULL ,
   TENDV NVARCHAR(100),
   GiaDichVu INT
   )
GO
CREATE TABLE THUEPHONG(
  MaPhong INT NOT NULL ,
  MaKH INT NOT NULL,
  MaHoaDon INT NOT NULL,
  NgayBatDauThue DATE,
  NgayTraPhong DATE,
  DatCoc INT 
  )
GO
CREATE TABLE SuDungDichVu(
   MaDichVu INT NOT NULL,
   MaHoaDon INT NOT NULL,
   MaKH INT NOT NULL
  )
GO

GO
CREATE TABLE HOADON(
 MaHoaDon INT IDENTITY(1,1) NOT NULL ,
 MaNV INT,
 SoLuong INT,
 NgayLapHoaDon DATE ,
 ThanhTien INT,
 GhiChu NVARCHAR(100)
 )
 GO
 
 ----------------KHÁO CHÍNH------------
 ALTER TABLE dbo.PHONG ADD CONSTRAINT PK_MAPHONG PRIMARY KEY(MaPhong)
 ALTER TABLE dbo.NHANVIEN ADD CONSTRAINT PK_MANV PRIMARY KEY(MaNV)
 ALTER TABLE dbo.KHACHHANG ADD CONSTRAINT PK_MAKH PRIMARY KEY(MaKH)
 ALTER TABLE dbo.HOADON ADD CONSTRAINT PK_MAHD PRIMARY KEY(MaHoaDon)
 ALTER TABLE dbo.DICHVU ADD CONSTRAINT PK_MADV PRIMARY KEY(MaDichVu)
 ALTER TABLE dbo.LOAIPHONG ADD CONSTRAINT PK_MaLoaiPhong PRIMARY KEY(MaLoai)
 ALTER TABLE dbo.VATDUNG ADD CONSTRAINT PK_MAVD PRIMARY KEY(MaVatDung)

 ALTER TABLE dbo.SuDungDichVu ADD CONSTRAINT PK_SuDungDichVu PRIMARY KEY(MaKH,MaHoaDon,MaDichVu)
 ALTER TABLE dbo.THUEPHONG ADD CONSTRAINT PK_MAThuePhong PRIMARY KEY(MaKH,MaHoaDon,MaPhong)
 GO
 ----KHÓA NGOẠI--------

alter table dbo.PHONG add constraint fk_Phong_LoaiPhong foreign key(MaLoai) references dbo.LOAIPHONG(MaLoai) 
alter table dbo.VATDUNG add constraint fk_Phong_VatDung foreign key(MaPhong) references dbo.PHONG(MaPhong)
alter table dbo.THUEPHONG add constraint fk_THUEPHONG_Phong foreign key(MaPhong) references dbo.PHONG(MaPhong) 
alter table dbo.THUEPHONG add constraint fk_ThuePhong_Khach foreign key(MaKH) references dbo.KHACHHANG(MaKH)  
alter table dbo.THUEPHONG add constraint fk_ThuePhong_HoaDon foreign key(MaHoaDon) references dbo.HOADON(MaHoaDon)  
alter table dbo.SuDungDichVu add constraint fk_SDDichVu_DichVu foreign key(MaDichVu) references dbo.DICHVU(MaDichVu) 
alter table dbo.SuDungDichVu add constraint fk_SDDichVu_Khach foreign key(MaKH) references dbo.KHACHHANG(MaKH)  
alter table dbo.SuDungDichVu add constraint fk_SDDichVu_Hoadon foreign key(MaHoaDon) references dbo.HOADON(MaHoaDon) 
alter table dbo.HOADON add constraint fk_HoaDon_NhanVien foreign key(MaNV) references dbo.NhanVien(MaNV) 

insert dbo.NHANVIEN values('giang','123',N'Trần Hoàng Giang','3-7-1999','Nam',123)













select * from VatDung vd where vd.TinhTrang = 0 
 
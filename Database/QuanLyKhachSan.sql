USE [master]
GO
/****** Object:  Database [QuanLyKhachSan]    Script Date: 4/22/2020 12:27:21 PM ******/
CREATE DATABASE [QuanLyKhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyKhachSan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyKhachSan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyKhachSan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyKhachSan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyKhachSan] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyKhachSan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyKhachSan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyKhachSan] SET QUERY_STORE = OFF
GO
USE [QuanLyKhachSan]
GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TENDV] [nvarchar](100) NULL,
	[GiaDichVu] [int] NULL,
 CONSTRAINT [PK_MADV] PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[NgayLapHoaDon] [date] NULL,
	[ThanhTien] [int] NULL,
	[GhiChu] [nvarchar](100) NULL,
	[TinhTrangThanhToan] [bit] NULL,
 CONSTRAINT [PK_MAHD] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[SDT] [char](10) NULL,
 CONSTRAINT [PK_MAKH] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[GiaThue] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaLoaiPhong] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
 CONSTRAINT [PK_MANV] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_MAPHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuDungDichVu]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuDungDichVu](
	[MaDichVu] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_SuDungDichVu] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaHoaDon] ASC,
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUEPHONG]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUEPHONG](
	[MaPhong] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[NgayBatDauThue] [date] NULL,
	[NgayTraPhong] [date] NULL,
	[DatCoc] [int] NULL,
	[SoDem] [int] NULL,
 CONSTRAINT [PK_MAThuePhong] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaHoaDon] ASC,
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VATDUNG]    Script Date: 4/22/2020 12:27:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VATDUNG](
	[MaVatDung] [int] IDENTITY(1,1) NOT NULL,
	[TenVatDung] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[GiaVatDung] [int] NULL,
	[MaPhong] [int] NULL,
 CONSTRAINT [PK_MAVD] PRIMARY KEY CLUSTERED 
(
	[MaVatDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DICHVU] ON 

INSERT [dbo].[DICHVU] ([MaDichVu], [TENDV], [GiaDichVu]) VALUES (1, N'Buffe', 50000)
INSERT [dbo].[DICHVU] ([MaDichVu], [TENDV], [GiaDichVu]) VALUES (2, N'Coca', 50000)
INSERT [dbo].[DICHVU] ([MaDichVu], [TENDV], [GiaDichVu]) VALUES (3, N'Massage', 50000)
INSERT [dbo].[DICHVU] ([MaDichVu], [TENDV], [GiaDichVu]) VALUES (4, N'Bể Bơi', 150000)
SET IDENTITY_INSERT [dbo].[DICHVU] OFF
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MaHoaDon], [MaNV], [SoLuong], [NgayLapHoaDon], [ThanhTien], [GhiChu], [TinhTrangThanhToan]) VALUES (1, 2, 1, CAST(N'2020-02-02' AS Date), 500000, NULL, 0)
INSERT [dbo].[HOADON] ([MaHoaDon], [MaNV], [SoLuong], [NgayLapHoaDon], [ThanhTien], [GhiChu], [TinhTrangThanhToan]) VALUES (2, 2, 1, CAST(N'2020-02-02' AS Date), 500000, NULL, 0)
INSERT [dbo].[HOADON] ([MaHoaDon], [MaNV], [SoLuong], [NgayLapHoaDon], [ThanhTien], [GhiChu], [TinhTrangThanhToan]) VALUES (3, 2, 1, CAST(N'2020-02-02' AS Date), 500000, NULL, 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [SDT]) VALUES (1, N'Hoàng Văn Việt 1', N'123')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [SDT]) VALUES (2, N'Hoàng Văn Việt 2', N'124')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [SDT]) VALUES (3, N'Hoàng Văn Việt 3', N'125')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[LOAIPHONG] ON 

INSERT [dbo].[LOAIPHONG] ([MaLoai], [TenLoai], [GiaThue], [GhiChu]) VALUES (1, N'Thường', 230000, NULL)
INSERT [dbo].[LOAIPHONG] ([MaLoai], [TenLoai], [GiaThue], [GhiChu]) VALUES (2, N'VIP', 430000, NULL)
SET IDENTITY_INSERT [dbo].[LOAIPHONG] OFF
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MaNV], [TaiKhoan], [MatKhau], [HoTen], [NgaySinh], [GioiTinh], [SDT]) VALUES (1, N'giang', N'123', N'việt hoàng 1', CAST(N'1999-08-22' AS Date), N'nam', N'0359999573')
INSERT [dbo].[NHANVIEN] ([MaNV], [TaiKhoan], [MatKhau], [HoTen], [NgaySinh], [GioiTinh], [SDT]) VALUES (2, N'admin', N'123', N'việt hoàng 2', CAST(N'1999-08-22' AS Date), N'nam', N'0359999532')
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
SET IDENTITY_INSERT [dbo].[PHONG] ON 

INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoai], [TrangThai]) VALUES (1, N'P101', 1, 1)
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoai], [TrangThai]) VALUES (2, N'P102', 2, 1)
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoai], [TrangThai]) VALUES (3, N'P103', 1, 1)

SET IDENTITY_INSERT [dbo].[PHONG] OFF
INSERT [dbo].[SuDungDichVu] ([MaDichVu], [MaHoaDon], [MaKH],[SoLuong]) VALUES (1, 1, 1,2)
INSERT [dbo].[SuDungDichVu] ([MaDichVu], [MaHoaDon], [MaKH],[SoLuong]) VALUES (2, 1, 1,1)
INSERT [dbo].[SuDungDichVu] ([MaDichVu], [MaHoaDon], [MaKH],[SoLuong]) VALUES (3, 2, 2,3)

INSERT [dbo].[THUEPHONG] ([MaPhong], [MaKH], [MaHoaDon], [NgayBatDauThue], [NgayTraPhong], [DatCoc],[SoDem]) VALUES (1, 1, 1, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-03' AS Date), 50000,1)
INSERT [dbo].[THUEPHONG] ([MaPhong], [MaKH], [MaHoaDon], [NgayBatDauThue], [NgayTraPhong], [DatCoc],[SoDem]) VALUES (2, 1, 1, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-03' AS Date), 50000,1)
INSERT [dbo].[THUEPHONG] ([MaPhong], [MaKH], [MaHoaDon], [NgayBatDauThue], [NgayTraPhong], [DatCoc],[SoDem]) VALUES (3, 2, 2, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-03' AS Date), 50000,1)
INSERT [dbo].[THUEPHONG] ([MaPhong], [MaKH], [MaHoaDon], [NgayBatDauThue], [NgayTraPhong], [DatCoc],[SoDem]) VALUES (2, 3, 3, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-03' AS Date), 50000,1)
SET IDENTITY_INSERT [dbo].[VATDUNG] ON 

INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (1, N'Dao', N'tốt', 13000, 1)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (2, N'TiVi', N'hỏng', 43000, 1)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (3, N'Đèn ngủ', N'tốt', 43000, 1)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (4, N'Dao', N'tốt', 13000, 2)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (5, N'TiVi', N'tốt', 43000, 2)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (6, N'Đèn ngủ', N'tốt', 43000, 2)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (7, N'Dao', N'tốt', 13000, 3)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (8, N'TiVi', N'tốt', 43000, 3)
INSERT [dbo].[VATDUNG] ([MaVatDung], [TenVatDung], [TinhTrang], [GiaVatDung], [MaPhong]) VALUES (9, N'Đèn ngủ', N'tốt', 43000, 3)

SET IDENTITY_INSERT [dbo].[VATDUNG] OFF
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [fk_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [fk_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [fk_Phong_LoaiPhong] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAIPHONG] ([MaLoai])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [fk_Phong_LoaiPhong]
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD  CONSTRAINT [fk_SDDichVu_DichVu] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DICHVU] ([MaDichVu])
GO
ALTER TABLE [dbo].[SuDungDichVu] CHECK CONSTRAINT [fk_SDDichVu_DichVu]
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD  CONSTRAINT [fk_SDDichVu_Hoadon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
GO
ALTER TABLE [dbo].[SuDungDichVu] CHECK CONSTRAINT [fk_SDDichVu_Hoadon]
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD  CONSTRAINT [fk_SDDichVu_Khach] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[SuDungDichVu] CHECK CONSTRAINT [fk_SDDichVu_Khach]
GO
ALTER TABLE [dbo].[THUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_THUEPHONG_HOADON1] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
GO
ALTER TABLE [dbo].[THUEPHONG] CHECK CONSTRAINT [FK_THUEPHONG_HOADON1]
GO
ALTER TABLE [dbo].[THUEPHONG]  WITH CHECK ADD  CONSTRAINT [fk_ThuePhong_Khach] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[THUEPHONG] CHECK CONSTRAINT [fk_ThuePhong_Khach]
GO
ALTER TABLE [dbo].[THUEPHONG]  WITH CHECK ADD  CONSTRAINT [fk_THUEPHONG_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[THUEPHONG] CHECK CONSTRAINT [fk_THUEPHONG_Phong]
GO
ALTER TABLE [dbo].[VATDUNG]  WITH CHECK ADD  CONSTRAINT [fk_Phong_VatDung] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[VATDUNG] CHECK CONSTRAINT [fk_Phong_VatDung]
GO
USE [master]
GO
ALTER DATABASE [QuanLyKhachSan] SET  READ_WRITE 
GO

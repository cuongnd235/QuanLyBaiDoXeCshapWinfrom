USE [master]
GO
/****** Object:  Database [QLBaiDoXe]    Script Date: 2/5/2019 12:36:57 PM ******/
CREATE DATABASE [QLBaiDoXe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBaiDoXe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLBaiDoXe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBaiDoXe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLBaiDoXe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLBaiDoXe] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBaiDoXe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBaiDoXe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBaiDoXe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBaiDoXe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBaiDoXe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBaiDoXe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET RECOVERY FULL 
GO
ALTER DATABASE [QLBaiDoXe] SET  MULTI_USER 
GO
ALTER DATABASE [QLBaiDoXe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBaiDoXe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBaiDoXe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBaiDoXe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBaiDoXe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLBaiDoXe', N'ON'
GO
ALTER DATABASE [QLBaiDoXe] SET QUERY_STORE = OFF
GO
USE [QLBaiDoXe]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [datetime] NULL,
	[TongTien] [int] NULL,
	[BienSoXe] [nvarchar](50) NULL,
	[IDLoaiXe] [int] NULL,
	[IDNhanVien] [nvarchar](50) NULL,
	[IDTheGuiXe] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiThe]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThe](
	[IDLoaiThe] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiThe] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiThe] PRIMARY KEY CLUSTERED 
(
	[IDLoaiThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiXe]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiXe](
	[IDLoaiXe] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiXe] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_LoaiXe] PRIMARY KEY CLUSTERED 
(
	[IDLoaiXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[IDQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[IDQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IDNhanVien] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](max) NULL,
	[HoTen] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SinhNhat] [date] NULL,
	[DiaChi] [nvarchar](max) NULL,
	[IDQuyen] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhatKyRa]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhatKyRa](
	[IDNhatKyRa] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [int] NULL,
	[BienSoXe] [nvarchar](50) NULL,
	[IDLoaiXe] [int] NULL,
	[IDTheGuiXe] [int] NULL,
	[IDNhanVien] [nvarchar](50) NULL,
	[Urlanh] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhatKyRa] PRIMARY KEY CLUSTERED 
(
	[IDNhatKyRa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhatKyVao]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhatKyVao](
	[IDNhatKyVao] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGian] [datetime] NULL,
	[BienSoXe] [nvarchar](50) NULL,
	[IDLoaiXe] [int] NULL,
	[IDTheGuiXe] [int] NULL,
	[IDNhanVien] [nvarchar](50) NULL,
	[Urlanh] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhatKyVao] PRIMARY KEY CLUSTERED 
(
	[IDNhatKyVao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TheGuiXe]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheGuiXe](
	[IDTheGuiXe] [int] IDENTITY(1,1) NOT NULL,
	[NgayCap] [date] NULL,
	[NgayHetHan] [date] NULL,
	[MoTa] [nvarchar](max) NULL,
	[DangSuDung] [bit] NULL,
	[IDLoaiThe] [int] NULL,
 CONSTRAINT [PK_TheGuiXe] PRIMARY KEY CLUSTERED 
(
	[IDTheGuiXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XeThang]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XeThang](
	[IDTheGuiXe] [int] NOT NULL,
	[BienSo] [nvarchar](50) NOT NULL,
	[NgayDangKy] [date] NULL,
	[NgayHetHan] [date] NULL,
	[UrlAnh] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_XeThang] PRIMARY KEY CLUSTERED 
(
	[BienSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XeTrongBai]    Script Date: 2/5/2019 12:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XeTrongBai](
	[IDXeTrongBai] [nvarchar](50) NOT NULL,
	[ThoiGianVao] [datetime] NULL,
	[ThoiGianRa] [datetime] NULL,
	[IDTheGuiXe] [int] NULL,
	[IDLoaiXe] [int] NULL,
	[UrlAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_XeTrongBai] PRIMARY KEY CLUSTERED 
(
	[IDXeTrongBai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Quyen] ON 
INSERT [dbo].[Quyen] ([IDQuyen], [TenQuyen], [MoTa]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[Quyen] ([IDQuyen], [TenQuyen], [MoTa]) VALUES (2, N'Nhân viên', NULL)
SET IDENTITY_INSERT [dbo].[Quyen] OFF

SET IDENTITY_INSERT [dbo].[HoaDon] ON 
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [TongTien], [BienSoXe], [IDLoaiXe], [IDNhanVien], [IDTheGuiXe], [MoTa]) VALUES (1, CAST(N'2018-04-20T17:48:46.237' AS DateTime), 5000, N'60U14632', 1, N'lehaisonmath6', 1, NULL)
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [TongTien], [BienSoXe], [IDLoaiXe], [IDNhanVien], [IDTheGuiXe], [MoTa]) VALUES (2, CAST(N'2019-04-21T09:40:45.330' AS DateTime), 5000, N'60U14632', 1, N'admin2', 3, NULL)
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [TongTien], [BienSoXe], [IDLoaiXe], [IDNhanVien], [IDTheGuiXe], [MoTa]) VALUES (1002, CAST(N'2019-04-26T01:26:52.493' AS DateTime), 5000, N'60U14632', 1, N'admin2', 3, NULL)
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [TongTien], [BienSoXe], [IDLoaiXe], [IDNhanVien], [IDTheGuiXe], [MoTa]) VALUES (1003, CAST(N'2019-05-01T14:55:39.777' AS DateTime), 5000, N'60U14632', 1, N'admin', 1, NULL)
INSERT [dbo].[HoaDon] ([IDHoaDon], [ThoiGian], [TongTien], [BienSoXe], [IDLoaiXe], [IDNhanVien], [IDTheGuiXe], [MoTa]) VALUES (1004, CAST(N'2019-05-02T00:25:28.220' AS DateTime), 5000, N'60U14632', 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF

SET IDENTITY_INSERT [dbo].[LoaiThe] ON 
INSERT [dbo].[LoaiThe] ([IDLoaiThe], [TenLoaiThe], [MoTa]) VALUES (1, N'Thẻ lượt', NULL)
INSERT [dbo].[LoaiThe] ([IDLoaiThe], [TenLoaiThe], [MoTa]) VALUES (2, N'Thẻ tháng', NULL)
INSERT [dbo].[LoaiThe] ([IDLoaiThe], [TenLoaiThe], [MoTa]) VALUES (3, N'Thẻ năm', NULL)
SET IDENTITY_INSERT [dbo].[LoaiThe] OFF

SET IDENTITY_INSERT [dbo].[LoaiXe] ON 
INSERT [dbo].[LoaiXe] ([IDLoaiXe], [TenLoaiXe], [MoTa], [DonGia]) VALUES (1, N'Xe máy', NULL, 5000)
INSERT [dbo].[LoaiXe] ([IDLoaiXe], [TenLoaiXe], [MoTa], [DonGia]) VALUES (2, N'Xe đạp', NULL, 3000)
INSERT [dbo].[LoaiXe] ([IDLoaiXe], [TenLoaiXe], [MoTa], [DonGia]) VALUES (3, N'Xe ô tô 4 chỗ', NULL, 10000)
INSERT [dbo].[LoaiXe] ([IDLoaiXe], [TenLoaiXe], [MoTa], [DonGia]) VALUES (4, N'Xe tải', NULL, 20000)
SET IDENTITY_INSERT [dbo].[LoaiXe] OFF

INSERT [dbo].[NhanVien] ([IDNhanVien], [MatKhau], [HoTen], [SDT], [Email], [SinhNhat], [DiaChi], [IDQuyen]) VALUES (N'admin', N'19951995', N'Admin', N'00000000', N'admin@gmail.com', NULL, NULL, 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MatKhau], [HoTen], [SDT], [Email], [SinhNhat], [DiaChi], [IDQuyen]) VALUES (N'admin2', N'123456', N'Lê Văn Tuấn', N'0384399862', N'aaa@gmail.com', NULL, N'Trầng Hưng Đạo ', 1)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MatKhau], [HoTen], [SDT], [Email], [SinhNhat], [DiaChi], [IDQuyen]) VALUES (N'hahaha', N'123456', NULL, NULL, N'a', NULL, NULL, 2)
INSERT [dbo].[NhanVien] ([IDNhanVien], [MatKhau], [HoTen], [SDT], [Email], [SinhNhat], [DiaChi], [IDQuyen]) VALUES (N'lehaisonmath6', N'123456', N'Lê Hải Sơn', N'03812312321', N'lehaisonmath6@gmail.com', NULL, N'Hà Nội', 2)

SET IDENTITY_INSERT [dbo].[NhatKyVao] ON 
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1, CAST(N'2019-04-20T16:58:49.637' AS DateTime), N'60U14632', 1, 1, N'lehaisonmath6', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (2, CAST(N'2019-04-21T09:34:53.340' AS DateTime), N'65D108424', 1, 1, N'lehaisonmath6', N'C:\Users\lehai\Desktop\Bike_back\0425.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (3, CAST(N'2019-04-21T09:36:25.930' AS DateTime), N'65P79679', 1, 2, N'admin2', N'C:\Users\lehai\Desktop\Bike_back\33.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (4, CAST(N'2019-04-21T09:37:37.720' AS DateTime), N'60U14632', 1, 3, N'admin2', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1002, CAST(N'2019-04-26T01:26:27.260' AS DateTime), N'60U14632', 1, 3, N'admin2', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1003, CAST(N'2019-05-01T14:29:21.630' AS DateTime), N'60U14632', 1, 4, N'admin', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1004, CAST(N'2019-05-01T14:51:40.793' AS DateTime), N'60U14632', 1, 1, N'admin', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1005, CAST(N'2019-05-01T14:54:45.897' AS DateTime), N'64U13872', 1, 4, N'admin', N'C:\Users\lehai\Desktop\Bike_back\2.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1006, CAST(N'2019-05-02T00:11:04.140' AS DateTime), N'60U14632', 1, 1, N'admin', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
INSERT [dbo].[NhatKyVao] ([IDNhatKyVao], [ThoiGian], [BienSoXe], [IDLoaiXe], [IDTheGuiXe], [IDNhanVien], [Urlanh]) VALUES (1007, CAST(N'2019-05-02T00:24:56.687' AS DateTime), N'60U14632', 1, 2, N'admin', N'C:\Users\lehai\Desktop\Bike_back\1.jpg')
SET IDENTITY_INSERT [dbo].[NhatKyVao] OFF

SET IDENTITY_INSERT [dbo].[TheGuiXe] ON 
INSERT [dbo].[TheGuiXe] ([IDTheGuiXe], [NgayCap], [NgayHetHan], [MoTa], [DangSuDung], [IDLoaiThe]) VALUES (1, CAST(N'2022-05-20' AS Date), CAST(N'2022-05-20' AS Date), N'', 0, 1)
INSERT [dbo].[TheGuiXe] ([IDTheGuiXe], [NgayCap], [NgayHetHan], [MoTa], [DangSuDung], [IDLoaiThe]) VALUES (2, CAST(N'2015-09-14' AS Date), CAST(N'2022-05-20' AS Date), NULL, 0, 1)
INSERT [dbo].[TheGuiXe] ([IDTheGuiXe], [NgayCap], [NgayHetHan], [MoTa], [DangSuDung], [IDLoaiThe]) VALUES (3, CAST(N'2015-09-14' AS Date), CAST(N'2022-05-20' AS Date), NULL, 0, 1)
INSERT [dbo].[TheGuiXe] ([IDTheGuiXe], [NgayCap], [NgayHetHan], [MoTa], [DangSuDung], [IDLoaiThe]) VALUES (4, CAST(N'2019-04-18' AS Date), CAST(N'2019-05-18' AS Date), NULL, 1, 2)
INSERT [dbo].[TheGuiXe] ([IDTheGuiXe], [NgayCap], [NgayHetHan], [MoTa], [DangSuDung], [IDLoaiThe]) VALUES (5, CAST(N'2019-05-06' AS Date), CAST(N'2022-07-05' AS Date), N'', 0, 2)
SET IDENTITY_INSERT [dbo].[TheGuiXe] OFF

INSERT [dbo].[XeThang] ([IDTheGuiXe], [BienSo], [NgayDangKy], [NgayHetHan], [UrlAnh], [MoTa], [TongTien]) VALUES (4, N'64U13872', CAST(N'2019-05-01' AS Date), CAST(N'2019-06-01' AS Date), N'C:\Users\lehai\Desktop\Bike_back\2.jpg', N'', 150000)
 
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_LoaiThe] FOREIGN KEY([IDTheGuiXe])
REFERENCES [dbo].[LoaiThe] ([IDLoaiThe])

GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Quyen] FOREIGN KEY([IDQuyen])
REFERENCES [dbo].[Quyen] ([IDQuyen])

GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_LoaiThe]

GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_LoaiXe] FOREIGN KEY([IDLoaiXe])
REFERENCES [dbo].[LoaiXe] ([IDLoaiXe])

GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_LoaiXe]

GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])

GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]

GO
ALTER TABLE [dbo].[NhatKyRa]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyRa_LoaiXe] FOREIGN KEY([IDLoaiXe])
REFERENCES [dbo].[LoaiXe] ([IDLoaiXe])

GO
ALTER TABLE [dbo].[NhatKyRa] CHECK CONSTRAINT [FK_NhatKyRa_LoaiXe]

GO
ALTER TABLE [dbo].[NhatKyRa]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyRa_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])

GO
ALTER TABLE [dbo].[NhatKyRa] CHECK CONSTRAINT [FK_NhatKyRa_NhanVien]

GO
ALTER TABLE [dbo].[NhatKyRa]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyRa_TheGuiXe] FOREIGN KEY([IDTheGuiXe])
REFERENCES [dbo].[TheGuiXe] ([IDTheGuiXe])

GO
ALTER TABLE [dbo].[NhatKyRa] CHECK CONSTRAINT [FK_NhatKyRa_TheGuiXe]

GO
ALTER TABLE [dbo].[NhatKyVao]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyVao_LoaiXe] FOREIGN KEY([IDLoaiXe])
REFERENCES [dbo].[LoaiXe] ([IDLoaiXe])

GO
ALTER TABLE [dbo].[NhatKyVao] CHECK CONSTRAINT [FK_NhatKyVao_LoaiXe]

GO
ALTER TABLE [dbo].[NhatKyVao]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyVao_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([IDNhanVien])

GO
ALTER TABLE [dbo].[NhatKyVao] CHECK CONSTRAINT [FK_NhatKyVao_NhanVien]

GO
ALTER TABLE [dbo].[NhatKyVao]  WITH CHECK ADD  CONSTRAINT [FK_NhatKyVao_TheGuiXe] FOREIGN KEY([IDTheGuiXe])
REFERENCES [dbo].[TheGuiXe] ([IDTheGuiXe])

GO
ALTER TABLE [dbo].[NhatKyVao] CHECK CONSTRAINT [FK_NhatKyVao_TheGuiXe]

GO
ALTER TABLE [dbo].[TheGuiXe]  WITH CHECK ADD  CONSTRAINT [FK_TheGuiXe_LoaiThe] FOREIGN KEY([IDLoaiThe])
REFERENCES [dbo].[LoaiThe] ([IDLoaiThe])

GO
ALTER TABLE [dbo].[TheGuiXe] CHECK CONSTRAINT [FK_TheGuiXe_LoaiThe]

GO
ALTER TABLE [dbo].[XeThang]  WITH CHECK ADD  CONSTRAINT [FK_XeThang_TheGuiXe] FOREIGN KEY([IDTheGuiXe])
REFERENCES [dbo].[TheGuiXe] ([IDTheGuiXe])

GO
ALTER TABLE [dbo].[XeThang] CHECK CONSTRAINT [FK_XeThang_TheGuiXe]

GO
ALTER TABLE [dbo].[XeTrongBai]  WITH CHECK ADD  CONSTRAINT [FK_XeTrongBai_LoaiXe] FOREIGN KEY([IDLoaiXe])
REFERENCES [dbo].[LoaiXe] ([IDLoaiXe])

GO
ALTER TABLE [dbo].[XeTrongBai] CHECK CONSTRAINT [FK_XeTrongBai_LoaiXe]

GO
ALTER TABLE [dbo].[XeTrongBai]  WITH CHECK ADD  CONSTRAINT [FK_XeTrongBai_TheGuiXe] FOREIGN KEY([IDTheGuiXe])
REFERENCES [dbo].[TheGuiXe] ([IDTheGuiXe])

GO
ALTER TABLE [dbo].[XeTrongBai] CHECK CONSTRAINT [FK_XeTrongBai_TheGuiXe]

GO
USE [master]

GO
ALTER DATABASE [QLBaiDoXe] SET  READ_WRITE 
GO

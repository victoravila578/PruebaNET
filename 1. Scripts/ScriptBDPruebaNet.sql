USE [master]
GO
/****** Object:  Database [PruebaNet]    Script Date: 01/31/2019 16:47:27 ******/
CREATE DATABASE [PruebaNet] ON  PRIMARY 
( NAME = N'PruebaNet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PruebaNet.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PruebaNet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PruebaNet_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PruebaNet] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaNet] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PruebaNet] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PruebaNet] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PruebaNet] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PruebaNet] SET ARITHABORT OFF
GO
ALTER DATABASE [PruebaNet] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [PruebaNet] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PruebaNet] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PruebaNet] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PruebaNet] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PruebaNet] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PruebaNet] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PruebaNet] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PruebaNet] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PruebaNet] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PruebaNet] SET  ENABLE_BROKER
GO
ALTER DATABASE [PruebaNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PruebaNet] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PruebaNet] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PruebaNet] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PruebaNet] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PruebaNet] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PruebaNet] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PruebaNet] SET  READ_WRITE
GO
ALTER DATABASE [PruebaNet] SET RECOVERY FULL
GO
ALTER DATABASE [PruebaNet] SET  MULTI_USER
GO
ALTER DATABASE [PruebaNet] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PruebaNet] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaNet', N'ON'
GO
USE [PruebaNet]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[iRolesId] [int] IDENTITY(1,1) NOT NULL,
	[vNombre] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenesPago]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesPago](
	[iOrdenId] [int] IDENTITY(1,1) NOT NULL,
	[iSucursalId] [int] NULL,
	[fMonto] [float] NULL,
	[iTipoMoneda] [int] NULL,
	[iEstadoId] [int] NULL,
	[dFechaPago] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrdenesPago] ON
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (1, 1, 48, 1, 1, CAST(0x0000A9D801418D58 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (2, 1, 400, 2, 3, CAST(0x0000A9D801430A51 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (3, 1, 600, 2, 2, CAST(0x0000A9D80148E28D AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (4, 1, 345, 1, 1, CAST(0x0000A9D80148EA4D AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (5, 12, 689, 1, 1, CAST(0x0000A9D80167DB30 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (6, 12, 667, 2, 1, CAST(0x0000A9D80167E52D AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (7, 4, 688, 1, 1, CAST(0x0000A9D8016D8DF1 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (8, 1, 46, 1, 2, CAST(0x0000A9D8016DECEC AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (9, 3, 3444, 1, 3, CAST(0x0000A9D8016FB30A AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (10, 1, 334, 2, 4, CAST(0x0000A9D80148F4A5 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (11, 8, 80, 1, 4, CAST(0x0000A9D8014A6293 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (12, 8, 355, 2, 1, CAST(0x0000A9D8014A69D7 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (13, 7, 50, 1, 1, CAST(0x0000A9D8014A9541 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (14, 9, 546, 2, 2, CAST(0x0000A9D8014BB958 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (15, 9, 498, 2, 3, CAST(0x0000A9D8014BC5E4 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (16, 9, 56, 1, 1, CAST(0x0000A9D8014BDDD3 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (17, 10, 60, 1, 1, CAST(0x0000A9D8015EAC40 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (18, 10, 50, 1, 1, CAST(0x0000A9D8015EC05C AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (19, 11, 30, 1, 1, CAST(0x0000A9D80165CA37 AS DateTime))
INSERT [dbo].[OrdenesPago] ([iOrdenId], [iSucursalId], [fMonto], [iTipoMoneda], [iEstadoId], [dFechaPago]) VALUES (20, 11, 60, 2, 1, CAST(0x0000A9D80165D085 AS DateTime))
SET IDENTITY_INSERT [dbo].[OrdenesPago] OFF
/****** Object:  Table [dbo].[Monedas]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Monedas](
	[iMonedaId] [int] NULL,
	[vNombreMoneda] [varchar](150) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Monedas] ([iMonedaId], [vNombreMoneda]) VALUES (1, N'Soles')
INSERT [dbo].[Monedas] ([iMonedaId], [vNombreMoneda]) VALUES (2, N'Dólares')
/****** Object:  Table [dbo].[Estados]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[iEstadoId] [int] NULL,
	[vDescripcionEstado] [varchar](150) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Estados] ([iEstadoId], [vDescripcionEstado]) VALUES (1, N'PAGADA')
INSERT [dbo].[Estados] ([iEstadoId], [vDescripcionEstado]) VALUES (2, N'DECLINADA')
INSERT [dbo].[Estados] ([iEstadoId], [vDescripcionEstado]) VALUES (3, N'FALLIDA')
INSERT [dbo].[Estados] ([iEstadoId], [vDescripcionEstado]) VALUES (4, N'ANULADA')
/****** Object:  Table [dbo].[Bancos]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bancos](
	[iBancoId] [int] IDENTITY(1,1) NOT NULL,
	[vNombreBanco] [varchar](100) NULL,
	[vDireccion] [varchar](250) NULL,
	[iActivo] [int] NULL,
	[dFechaRegistro] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bancos] ON
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (1, N'BCP', N'Av. Centenario 156, La Molina 15026', 1, CAST(0x0000A9E501036368 AS DateTime))
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (2, N'BBVA', N'AV. REP DE PANAMA NRO. 3055 URB. EL PALOMAR - SAN ISIDRO', 1, CAST(0x0000A9E501036368 AS DateTime))
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (3, N'INTERBANK', N'Av. Javier Prado Este Nº 4921', 1, CAST(0x0000A9E501036368 AS DateTime))
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (4, N'SCOTIABANK', N'Av. Juan de Arona Nro. 809 - San Isidro', 1, CAST(0x0000A9E501036368 AS DateTime))
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (5, N'BANCO DE LA NACION', N'AV. JAVIER PRADO ESTE NRO. 2499 URB. SAN BORJA', 1, CAST(0x0000A9E501036368 AS DateTime))
INSERT [dbo].[Bancos] ([iBancoId], [vNombreBanco], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (6, N'BANCO AZTECA', N'Av. Pershing - Ex Faustino Sa Nro. 465 Int. 801 ', 1, CAST(0x0000A9E501036368 AS DateTime))
SET IDENTITY_INSERT [dbo].[Bancos] OFF
/****** Object:  Table [dbo].[Sucursales]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursales](
	[iSucursalId] [int] IDENTITY(1,1) NOT NULL,
	[iBancoId] [int] NULL,
	[vNombre] [varchar](100) NULL,
	[vDireccion] [varchar](250) NULL,
	[iActivo] [int] NULL,
	[dFechaRegistro] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (1, 1, N'PRIMAX MELGAREJO', N'Av. Universidad 1275', 1, CAST(0x0000A9D601036372 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (2, 1, N'MEXICO', N'Av. Mexico 906', 1, CAST(0x0000A9D8011900ED AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (3, 2, N'NICOLAS ARRIOLA', N'AV. NICOLAS ARRIOLA 607', 1, CAST(0x0000A9D80119F17F AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (4, 2, N'LAS BEGONIAS', N'LAS BEGONIAS 425-429', 1, CAST(0x0000A9D8012155C2 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (5, 3, N'SAN LUIS', N'Av Circunvalación 1878', 1, CAST(0x0000A9D80121E6F8 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (6, 3, N'ATE', N'Av. Nicolás Ayllón 420', 1, CAST(0x0000A9D8015E51B7 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (7, 4, N'CAQUETA', N'Jr. Tomás Moya 401', 1, CAST(0x0000A9D801629A0B AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (8, 4, N'RIMAC', N'La Colonial 101 Esq.Av.Alcázar', 1, CAST(0x0000A9D80167CF27 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (9, 5, N'CENTRO CIVICO', N'Avenida Uruguay N° 172-198', 1, CAST(0x0000A9D8016E0530 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (10, 5, N'28 DE JULIO', N'Avenida 28 de Julio N° 932', 1, CAST(0x0000A9D80170474E AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (11, 6, N'BARRANCO', N'Av. Almirante Grau 608', 1, CAST(0x0000A9D801224489 AS DateTime))
INSERT [dbo].[Sucursales] ([iSucursalId], [iBancoId], [vNombre], [vDireccion], [iActivo], [dFechaRegistro]) VALUES (12, 6, N'BREÑA', N'Av. Venezuela 792 Breña', 1, CAST(0x0000A9D8014A505E AS DateTime))
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
/****** Object:  StoredProcedure [dbo].[sp_updateSucursal]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateSucursal](
	@iSucursalId		INT,
	@vNombreSucursal	VARCHAR(250),
	@vDireccion			VARCHAR(250)
)
AS
	UPDATE dbo.Sucursales
	SET vNombre = @vNombreSucursal,
		vDireccion = @vDireccion
	WHERE iSucursalId = @iSucursalId
	SELECT @iSucursalId
GO
/****** Object:  StoredProcedure [dbo].[sp_updateBanco]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateBanco](
	@iBancoId			INT,
	@vNombreBanco	VARCHAR(250),
	@vDireccion		VARCHAR(250)
)
AS
	UPDATE dbo.Bancos
		SET vNombreBanco = @vNombreBanco,
			vDireccion = @vDireccion
	WHERE iBancoId = @iBancoId
	SELECT @iBancoId
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerSucursalesPorId]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerSucursalesPorId](
	@iSucursalId	INT
)as
	SELECT s.iSucursalId, b.iBancoId, b.vNombreBanco, s.vNombre, s.vDireccion, CONVERT(VARCHAR, s.dFechaRegistro, 103) dFechaRegistro
	FROM dbo.Sucursales s
	INNER JOIN dbo.Bancos b ON b.iBancoId = s.iBancoId
	WHERE s.iSucursalId = @iSucursalId
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerSucursalesPorBanco]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------

CREATE PROCEDURE [dbo].[sp_ObtenerSucursalesPorBanco](
	@iBancoId	INT
)as
	SELECT s.iSucursalId, b.iBancoId, b.vNombreBanco, s.vNombre, s.vDireccion, CONVERT(VARCHAR, s.dFechaRegistro, 103) dFechaRegistro
	FROM dbo.Sucursales s
	INNER JOIN dbo.Bancos b ON b.iBancoId = s.iBancoId
	WHERE s.iBancoId = @iBancoId
	AND s.iActivo = 1
	ORDER BY 1 desc
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerOrdenPagoPorId]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_obtenerOrdenPagoPorId](
	@iOrdenId	int
)as
	SELECT o.iOrdenId, o.iSucursalId, o.fMonto, o.iTipoMoneda, 
	      (CASE o.iTipoMoneda WHEN 1 THEN 'Soles' ELSE 'Dólares' end) vNombreMoneda,
		   o.iEstadoId, CONVERT(VARCHAR, o.dFechaPago, 103) dFechaPago, e.vDescripcionEstado
    FROM dbo.OrdenesPago o
	INNER JOIN dbo.Estados e ON o.iEstadoId = e.iEstadoId
	WHERE iOrdenId = @iOrdenId
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerOrdenesPagoPorSucursalTipoMoneda]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_obtenerOrdenesPagoPorSucursalTipoMoneda](
	@iSucursalId	INT,
	@iTipoMoneda	INT
)as
	SELECT o.iOrdenId, o.iSucursalId, s.vNombre, o.fMonto, o.iTipoMoneda, 
	      (CASE o.iTipoMoneda WHEN 1 THEN 'Soles' ELSE 'Dólares' end) vNombreMoneda,
	o.iEstadoId, CONVERT(VARCHAR, o.dFechaPago, 103) dFechaPago, e.vDescripcionEstado
    FROM dbo.OrdenesPago o
		INNER JOIN dbo.Estados e ON o.iEstadoId = e.iEstadoId	
		INNER JOIN dbo.Sucursales s ON s.iSucursalId = o.iSucursalId
	WHERE iTipoMoneda = @iTipoMoneda
	AND o.iSucursalId = @iSucursalId
	ORDER BY 1 DESC
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerOrdenesPago]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------

CREATE PROCEDURE [dbo].[sp_obtenerOrdenesPago](
	@iSucursalId	int
)as
	SELECT o.iOrdenId, o.iSucursalId, o.fMonto, o.iTipoMoneda, 
		  (CASE o.iTipoMoneda WHEN 1 THEN 'Soles' ELSE 'Dólares' end) vNombreMoneda,
		   o.iEstadoId, CONVERT(VARCHAR, o.dFechaPago, 103)dFechaPago, isnull(e.vDescripcionEstado,'') vDescripcionEstado
    FROM dbo.OrdenesPago o
	inner JOIN dbo.Estados e ON o.iEstadoId = e.iEstadoId and o.iEstadoId <> 0
	WHERE o.iSucursalId = @iSucursalId
	ORDER BY 1 DESC
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerBanco]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerBanco]
	@iBancoId	INT
AS
	SELECT iBancoId, vNombreBanco, vDireccion, CONVERT(VARCHAR, dFechaRegistro, 103) dFechaRegistro
	FROM dbo.Bancos
	WHERE iBancoId = @iBancoId
GO
/****** Object:  StoredProcedure [dbo].[sp_modificarOrdenPago]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_modificarOrdenPago](
	@iOrdenId		INT,
	@fMonto			FLOAT,
	@iTipoMoneda	INT,
	@iEstadoId		INT
)AS

	UPDATE dbo.OrdenesPago
		SET fMonto = @fMonto,
			iTipoMoneda = @iTipoMoneda,
			iEstadoId = @iEstadoId
	WHERE iOrdenId = @iOrdenId
	SELECT @iOrdenId
GO
/****** Object:  StoredProcedure [dbo].[sp_listarMonedas]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listarMonedas]
AS
SELECT iMonedaId, vNombreMoneda FROM dbo.Monedas
GO
/****** Object:  StoredProcedure [dbo].[sp_listarEstados]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listarEstados]
AS
SELECT iEstadoId, vDescripcionEstado FROM dbo.Estados
GO
/****** Object:  StoredProcedure [dbo].[sp_listarBancos]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------
CREATE PROCEDURE [dbo].[sp_listarBancos]
AS
	SELECT iBancoId, vNombreBanco, vDireccion, CONVERT(VARCHAR, dFechaRegistro, 103) dFechaRegistro
	FROM dbo.Bancos
	WHERE iActivo = 1
	ORDER BY ibancoId desc
GO
/****** Object:  StoredProcedure [dbo].[sp_insertSucursal]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertSucursal](
	@iBancoId			INT,
	@vNombreSucursal	VARCHAR(250),
	@vDireccion			VARCHAR(250)
)
AS
	INSERT INTO dbo.Sucursales(iBancoId,vNombre, vDireccion, dFechaRegistro, iActivo)
	VALUES (@iBancoId, @vNombreSucursal, @vDireccion, GETDATE(), 1)
	SELECT @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_insertOrdenPago]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_insertOrdenPago](
	@iSucursalId		INT,
	@fMonto			FLOAT,
	@iTipoMoneda	INT
)AS
	INSERT INTO dbo.OrdenesPago(iSucursalId, fMonto, iTipoMoneda, iEstadoId, dFechaPago)
	VALUES (@iSucursalId, @fMonto, @iTipoMoneda, 1, GETDATE())
	SELECT @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_insertBanco]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insertBanco](
	@vNombreBanco	VARCHAR(100),
	@vDireccion		VARCHAR(250)
)
AS
	INSERT INTO dbo.Bancos(vNombreBanco, vDireccion, iActivo, dFechaRegistro)
	VALUES (@vNombreBanco, @vDireccion, 1, GETDATE())
	SELECT @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteSucursal]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteSucursal](
	@isucursalId			INT
)
AS
	UPDATE dbo.Sucursales
			SET iActivo = 0
		WHERE iSucursalId = @isucursalId
		SELECT @isucursalId
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteOrderPago]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteOrderPago](
	@iOrdenId			INT
)
AS
	UPDATE dbo.OrdenesPago
			SET iEstadoId = 0
		WHERE iOrdenId = @iOrdenId
		SELECT @iOrdenId
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteBanco]    Script Date: 01/31/2019 16:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteBanco](
	@iBancoId			INT
)
AS
	UPDATE dbo.Bancos
			SET iActivo= 0
		WHERE iBancoId = @iBancoId
		SELECT @iBancoId
GO

USE [GestionH]
GO
/****** Object:  Table [dbo].[HistorialMedico]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialMedico](
	[idH] [int] IDENTITY(1,1) NOT NULL,
	[idPaciente] [int] NULL,
	[Motivo] [varchar](50) NULL,
	[fecha] [date] NULL,
	[sintomas] [varchar](50) NULL,
	[tratamiento] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[idP] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](40) NULL,
	[TipoSangre] [nvarchar](10) NULL,
	[Correo] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[contactoEmergencia] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[idP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HistorialMedico]  WITH CHECK ADD FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Pacientes] ([idP])
GO
/****** Object:  StoredProcedure [dbo].[Buscar]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Buscar]
@idp INT
AS 
SELECT * FROM HistorialMedico WHERE idPaciente = @idp
GO
/****** Object:  StoredProcedure [dbo].[BuscarPacientes]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarPacientes]
@idp INT
AS 
SELECT * FROM Pacientes WHERE idP = @idp
GO
/****** Object:  StoredProcedure [dbo].[EditarPaciente]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarPaciente] 
@idp INT,
@nombre VARCHAR(50),  
@apellido VARCHAR(50),
@tiposangre nvarchar(50),
@correo varchar(100),
@telefono varchar(10),
@contactoemergencia varchar (10)
AS 
UPDATE Pacientes SET  
       [Nombre] = @nombre,
       [Apellidos] = @apellido,
	   [TipoSangre] = @tiposangre,
	   [Correo] = @correo,
	   [telefono] = @telefono,
	   [contactoEmergencia] = @contactoemergencia
       WHERE idP= @idp
GO
/****** Object:  StoredProcedure [dbo].[EliminarPaciente]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPaciente]
@idp INT
AS 
DELETE FROM Pacientes WHERE idP = @idp
GO
/****** Object:  StoredProcedure [dbo].[InsertarHistorial]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarHistorial]
@idP int,
@motivo VARCHAR(100), 
@fecha date,
@sintomas varchar(50),
@tratamiento varchar(50)
AS 
INSERT INTO HistorialMedico([idPaciente],[Motivo],[fecha],[sintomas],[tratamiento])
VALUES (@idP,@motivo, @fecha,@sintomas,@tratamiento)  
GO
/****** Object:  StoredProcedure [dbo].[InsertarPacientes]    Script Date: 22/04/2022 8:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPacientes]
@nombre VARCHAR(50), 
@apellido VARCHAR(50),
@tiposangre nvarchar(50),
@correo varchar(100),
@telefono varchar(10),
@contactoemergencia varchar (10)

AS 
INSERT INTO Pacientes([Nombre],[Apellidos],[TipoSangre],[Correo],[telefono],[contactoEmergencia])
VALUES (@nombre, @apellido,@tiposangre,@correo,@telefono,@contactoemergencia) 
GO

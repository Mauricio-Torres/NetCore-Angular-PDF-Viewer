USE [prueba]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2020 11:12:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartaGenerada]    Script Date: 10/02/2020 11:12:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartaGenerada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Titulo] [nvarchar](max) NULL,
	[Cargo] [nvarchar](max) NULL,
	[Organizacion] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Ciudad] [nvarchar](max) NULL,
	[Pais] [nvarchar](max) NULL,
	[UsuariosId] [int] NULL,
	[IdiomasId] [int] NULL,
	[namePdf] [nvarchar](max) NULL,
	[urlPdf] [nvarchar](max) NULL,
 CONSTRAINT [PK_CartaGenerada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 10/02/2020 11:12:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCarta]    Script Date: 10/02/2020 11:12:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCarta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[IdiomasId] [int] NULL,
 CONSTRAINT [PK_TipoCarta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/02/2020 11:12:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Cedula] [int] NOT NULL,
	[Profesion] [nvarchar](max) NULL,
	[Titulo] [nvarchar](max) NULL,
	[Universidad] [nvarchar](max) NULL,
	[Trabajo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207061235_Inicial', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207061739_Inicial2', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207065525_Inicial3', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207065909_Inicial4', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207084248_Inicial5', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200207100529_Inicial6', N'3.1.1')
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([Id], [Nombre]) VALUES (1, N'Espanol')
INSERT [dbo].[Idioma] ([Id], [Nombre]) VALUES (2, N'English')
INSERT [dbo].[Idioma] ([Id], [Nombre]) VALUES (3, N'Frances')
INSERT [dbo].[Idioma] ([Id], [Nombre]) VALUES (4, N'Mandarin')
INSERT [dbo].[Idioma] ([Id], [Nombre]) VALUES (5, N'Aleman')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
SET IDENTITY_INSERT [dbo].[TipoCarta] ON 

INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (1, N'Espanol c1', 1)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (2, N'Espanol c2', 1)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (3, N'English 1', 2)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (4, N'English 2', 2)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (5, N'Frances 1', 3)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (6, N'Frances 2', 3)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (7, N'Mandarin 1', 4)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (8, N'Mandarin 2', 4)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (9, N'Aleman 1', 5)
INSERT [dbo].[TipoCarta] ([Id], [Nombre], [IdiomasId]) VALUES (10, N'Aleman', 5)
SET IDENTITY_INSERT [dbo].[TipoCarta] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Cedula], [Profesion], [Titulo], [Universidad], [Trabajo]) VALUES (1, N'Prueba', 900809898, N'Prueba', N'Prueba', N'Prueba', N'Prueba')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[CartaGenerada]  WITH CHECK ADD  CONSTRAINT [FK_CartaGenerada_Idioma_IdiomasId] FOREIGN KEY([IdiomasId])
REFERENCES [dbo].[Idioma] ([Id])
GO
ALTER TABLE [dbo].[CartaGenerada] CHECK CONSTRAINT [FK_CartaGenerada_Idioma_IdiomasId]
GO
ALTER TABLE [dbo].[CartaGenerada]  WITH CHECK ADD  CONSTRAINT [FK_CartaGenerada_Usuario_UsuariosId] FOREIGN KEY([UsuariosId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[CartaGenerada] CHECK CONSTRAINT [FK_CartaGenerada_Usuario_UsuariosId]
GO
ALTER TABLE [dbo].[TipoCarta]  WITH CHECK ADD  CONSTRAINT [FK_TipoCarta_Idioma_IdiomasId] FOREIGN KEY([IdiomasId])
REFERENCES [dbo].[Idioma] ([Id])
GO
ALTER TABLE [dbo].[TipoCarta] CHECK CONSTRAINT [FK_TipoCarta_Idioma_IdiomasId]
GO

USE [master]
GO

/****** Object:  Database [CoursesDB]    Script Date: 23/10/2023 12:08:18 p. m. ******/
CREATE DATABASE [CoursesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoursesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CoursesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoursesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CoursesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [CoursesDB]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 23/10/2023 12:11:32 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Courses] ADD  DEFAULT (N'') FOR [Name]
GO


/****** Object:  Table [dbo].[Students]    Script Date: 23/10/2023 12:11:53 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CourseStudent]    Script Date: 23/10/2023 12:07:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CourseStudent](
	[CoursesId] [int] NOT NULL,
	[StudentsId] [int] NOT NULL,
 CONSTRAINT [PK_CourseStudent] PRIMARY KEY CLUSTERED 
(
	[CoursesId] ASC,
	[StudentsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudent_Courses_CoursesId] FOREIGN KEY([CoursesId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK_CourseStudent_Courses_CoursesId]
GO

ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudent_Students_StudentsId] FOREIGN KEY([StudentsId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK_CourseStudent_Students_StudentsId]
GO


INSERT INTO [dbo].[Courses] ([Name])
     VALUES ('Matemáticas'),
			('Español'),			
			('Inglés'),
			('Arte'),
			('Historia')

INSERT INTO [dbo].[Students]
           ([Identification]
           ,[Name]
           ,[LastName]
           ,[Email])
     VALUES
           ('1234','Pedro','Pérez','pepe@mail.com'),
		   ('2345','Gabriel','García','gabo@mail.com'),
		   ('3456','Martín','Díaz','martin@mail.com'),
		   ('4567','Sergio','Ramos','sergio@mail.com'),
		   ('1234','James','Fernandez','james@mail.com')
GO
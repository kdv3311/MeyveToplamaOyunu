USE [meyvetoplamaoyunu]
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 3.07.2023 20:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullanıcıAdi] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[sifre] [nvarchar](50) NOT NULL,
	[erisim] [int] NOT NULL,
 CONSTRAINT [PK_kullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[skorlar]    Script Date: 3.07.2023 20:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[skorlar](
	[kıd] [int] NOT NULL,
	[skor] [int] NOT NULL,
	[tarih] [nchar](15) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kullanici] ON 
GO
INSERT [dbo].[kullanici] ([id], [kullanıcıAdi], [email], [sifre], [erisim]) VALUES (1, N'admin', N'admin@gmail.com', N'admin', 1)
GO
SET IDENTITY_INSERT [dbo].[kullanici] OFF
GO

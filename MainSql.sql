USE [Avtokreditovanie]
GO
/****** Object:  User [Admin]    Script Date: 10.12.2023 15:04:02 ******/
CREATE USER [Admin] FOR LOGIN [Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [User]    Script Date: 10.12.2023 15:04:02 ******/
CREATE USER [User] FOR LOGIN [User] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](50) NOT NULL,
	[Price] [nvarchar](50) NOT NULL,
	[YearOfIssue] [nvarchar](50) NOT NULL,
	[Engine] [nvarchar](50) NOT NULL,
	[VehicleType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[Trustworthiness] [nvarchar](50) NOT NULL,
	[LoanStatus] [nvarchar](50) NOT NULL,
	[Car] [nvarchar](50) NOT NULL,
	[CarId] [int] NOT NULL,
	[AmountOfCredit] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientTrustworthiness]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTrustworthiness](
	[Id] [int] NOT NULL,
	[Trustworthiness] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClientTrustworthiness] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanApplications]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[ClientId] [int] NULL,
	[ApplicationDate] [date] NOT NULL,
	[AmountOfCredit] [nvarchar](100) NOT NULL,
	[TCPNumber] [nvarchar](10) NOT NULL,
	[Income] [nvarchar](50) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Car] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoanApplications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.12.2023 15:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (1, N'Nissan Teana', N'1 100 000 ₽', N'2009', N'2.5 л / 182 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (2, N'Nissan Skyline X (R34)', N'2 600 000 ₽', N'1998', N'2.5 л / 200 л.с. / Бензин', N'Купе')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (3, N'Nissan X-Trail (III)', N'1 750 000 ₽', N'2000', N'2.0 л / 144 л.с. / Бензин', N'Внедорожник 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (4, N'Nissan Juke', N'970 000 ₽', N'2010', N'1.6 л / 190 л.с. / Бензин', N'Внедорожник 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (5, N'Nissan Cima', N'700 000 ₽', N'2000', N'4.1 л / 270 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (6, N'Lada 2107+', N'250 000 000 ₽', N'1982', N'99999999.9 л / 500000 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (7, N'Lada Priora', N'305 000 ₽', N'2007', N'1.6 л / 98 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (8, N'Lada XRAY', N'1 190 000 ₽', N'2015', N'1.6 л / 106 л.с. / бензин', N'Хэтчбек 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (9, N'Lada Kalina Sport (II)', N'735 000 ₽', N'2016', N'1.6 л / 114 л.с. / Бензин', N'Хэтчбек 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (10, N'Mercedes-Benz Maybach S-Класс 500', N'3 875 000 ₽', N'2015', N'4.7 л / 455 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (11, N'Mercedes-Benz CLS AMG 63', N'3 000 000 ₽', N'1999', N'5.5 л / 525 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (12, N'Mercedes-Benz GLE AMG 43', N'3 999 000 ₽', N'2008', N'3.0 л / 390 л.с. / Бензин', N'Внедорожник 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (13, N'Mercedes-Benz R-Класс 350 Long', N'2 200 000 ₽', N'2007', N'3.0 л / 224 л.с. / Дизель', N'Минивэн')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (14, N'Toyota Supra (A80)', N'3 000 000 ₽', N'1996', N'3.0 л / 280 л.с. / бензин', N'Купе')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (15, N'Toyota Crown', N'3 000 000 ₽', N'1999', N'2.5 л / 184 л.с. / Гибрид', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (16, N'Toyota Mark II', N'700 000 ₽', N'2000', N'2.5 л / 180 л.с. / Бензин', N'Cедан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (17, N'Toyota Camry', N'2 273 000 ₽', N'2011', N'2.5 л / 181 л.с. / Бензин', N'Cедан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (18, N'Toyota Chaser', N'1 300 000 ₽', N'1997', N'2.5 л / 200 л.с. / Бензин', N'Cедан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (19, N'Audi A4', N'1 310 000 ₽', N'2011', N'1.4 л / 150 л.с. / Бензин', N'Универсал 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (20, N'Audi A6', N'2 050 000 ₽', N'2014', N'2.8 л / 220 л.с. / Бензин', N'Cедан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (21, N'Audi RS 4', N'3 200 000 ₽', N'1999', N'4.2 л / 450 л.с. / Бензин', N'Универсал 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (22, N'Audi TT', N'3 399 999 ₽', N'2006', N'2.0 л / 230 л.с. / Бензин', N'Родстер')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (23, N'Renault Sandero Stepway', N'1 099 000 ₽', N'2012', N'1.6 л / 113 л.с. / бензин', N'Хэтчбек 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (24, N'Renault Duster', N'2 049 000 ₽', N'2020', N'1.3 л / 150 л.с. / Бензин', N'Внедорожник 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (25, N'Renault Logan', N'400 000 ₽', N'2014', N'1.6 л / 82 л.с. / Бензин', N'Седан')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (26, N'Renault Clio RS', N'1 290 000 ₽', N'2016', N'1.6 л / 200 л.с. / Бензин', N'Хэтчбек 5 дв.')
INSERT [dbo].[Cars] ([Id], [ModelName], [Price], [YearOfIssue], [Engine], [VehicleType]) VALUES (28, N'Renault Arkana', N'1 550 000 ₽', N'2018', N'1.6 л / 114 л.с. / Бензин', N'Внедорожник 5 дв.')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (1, N'Скрипак Сергей Сергеевич', CAST(N'2023-04-08' AS Date), N'Благонадежный', N'Выплачен', N'Nissan Skyline X (R34)', 2, N'2 600 000 ₽', N'Выплаты по срокам. Кредит оплачен.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (2, N'Петухов Алексей Николаевич', CAST(N'2023-04-02' AS Date), N'Благонадежный', N'2 875 000 ₽', N'Mercedes-Benz Maybach S-Класс 500', 10, N'3 875 000 ₽', N'Выплаты по срокам. ')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (3, N'Тиманский Максим Андреевич', CAST(N'2023-04-01' AS Date), N'Благонадежный', N'Выплачен', N'Audi TT', 22, N'3 399 999 ₽', N'Выплаты по срокам. Кредит выплачен.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (4, N'Данилов Илья Александрович', CAST(N'2023-01-21' AS Date), N'Неблагонадежный', N'35 000 ₽', N'Lada 2107', 6, N'250 000 ₽', N'Имеется просроченные выплаты. Уведомить клиента об оплате.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (5, N'Григорьев Никита Платонович', CAST(N'2022-09-16' AS Date), N'Неблагонадежный', N'Расторгнут', N'Renault Sandero Stepway', 23, N'1 099 000 ₽', N'Кредит не выплачивался несколько месяцев. Автомобиль был изъят.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (6, N'Степанов Фёдор Михайлович', CAST(N'2023-04-03' AS Date), N'Благонадежный', N'Выплачен', N'Nissan Teana', 1, N'1 100 000 ₽', N'Выплаты по срокам. Кредит был выплачен.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (7, N'Прохорова Дана Германновна', CAST(N'2023-04-03' AS Date), N'Благонадежный', N'Выплачен', N'Nissan Cima', 5, N'700 000 ₽', N'Выплаты по срокам. Кредит оплачен.')
INSERT [dbo].[Clients] ([Id], [FIO], [PaymentDate], [Trustworthiness], [LoanStatus], [Car], [CarId], [AmountOfCredit], [Comment]) VALUES (8, N'123', CAST(N'0001-01-01' AS Date), N'Неблагонадежный', N'123', N'Toyota Camry', 0, N'123', N'asd')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
INSERT [dbo].[ClientTrustworthiness] ([Id], [Trustworthiness]) VALUES (1, N'Благонадежный')
INSERT [dbo].[ClientTrustworthiness] ([Id], [Trustworthiness]) VALUES (2, N'Неблагонадежный')
INSERT [dbo].[ClientTrustworthiness] ([Id], [Trustworthiness]) VALUES (3, N'Новый клиент')
GO
SET IDENTITY_INSERT [dbo].[LoanApplications] ON 

INSERT [dbo].[LoanApplications] ([Id], [CarId], [ClientId], [ApplicationDate], [AmountOfCredit], [TCPNumber], [Income], [FIO], [DateOfBirth], [Car]) VALUES (1, 16, NULL, CAST(N'2023-04-08' AS Date), N'700 000 ₽', N'77TM181468', N'80 000 ₽', N'Кузьмин Владислав Владиславович', CAST(N'1992-05-29' AS Date), N'Toyota Mark II')
INSERT [dbo].[LoanApplications] ([Id], [CarId], [ClientId], [ApplicationDate], [AmountOfCredit], [TCPNumber], [Income], [FIO], [DateOfBirth], [Car]) VALUES (2, 25, NULL, CAST(N'2023-03-31' AS Date), N'400 000 ₽', N'24LS194268', N'38 000 ₽', N'Сергеева Елизавета Мирославовна', CAST(N'1981-12-08' AS Date), N'Renault Logan')
INSERT [dbo].[LoanApplications] ([Id], [CarId], [ClientId], [ApplicationDate], [AmountOfCredit], [TCPNumber], [Income], [FIO], [DateOfBirth], [Car]) VALUES (3, 14, NULL, CAST(N'2023-04-05' AS Date), N'3 000 000 ₽', N'93WD916372', N'280 000 ₽', N'Павлов Даниил Антонович', CAST(N'2004-06-01' AS Date), N'Toyota Supra (A80)')
INSERT [dbo].[LoanApplications] ([Id], [CarId], [ClientId], [ApplicationDate], [AmountOfCredit], [TCPNumber], [Income], [FIO], [DateOfBirth], [Car]) VALUES (5, 12, NULL, CAST(N'2023-04-08' AS Date), N'3 999 000 ₽', N'92YK082193', N'490 000 ₽', N'Комаров Мирон Егорович', CAST(N'1987-12-13' AS Date), N'Mercedes-Benz GLE AMG 43')
INSERT [dbo].[LoanApplications] ([Id], [CarId], [ClientId], [ApplicationDate], [AmountOfCredit], [TCPNumber], [Income], [FIO], [DateOfBirth], [Car]) VALUES (6, 7, NULL, CAST(N'2023-03-10' AS Date), N'305 000 ₽', N'18AS01781', N'50 600 ₽', N'Егорова Азалия Николаевна', CAST(N'1993-03-12' AS Date), N'Lada Priora')
SET IDENTITY_INSERT [dbo].[LoanApplications] OFF
GO
INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'Manager')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'Sotrudnik')
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (1, N'7815696ECBF1C96E6894B779456D330E', N'7815696ECBF1C96E6894B779456D330E', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (2, N'5FA72358F0B4FB4F2C5D7DE8C9A41846', N'5FA72358F0B4FB4F2C5D7DE8C9A41846', 2)
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (3, N'6E1BC147D025BEDCEDF8E9C823F28342', N'EEF06FAAEE792F4B2FC4A79592A22A7A', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (4, N'E6FD6209696A1BC7BDDE8C6C215BA27B', N'70AA7D75FE6263D7BD028E77CF06E6A2', 2)
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD  CONSTRAINT [FK_LoanApplications_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[LoanApplications] CHECK CONSTRAINT [FK_LoanApplications_Cars]
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD  CONSTRAINT [FK_LoanApplications_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[LoanApplications] CHECK CONSTRAINT [FK_LoanApplications_Clients]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO

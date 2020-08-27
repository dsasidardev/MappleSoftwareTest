USE [TESTDB]
GO
/****** Object:  Table [dbo].[CoveragePlandata]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoveragePlandata](
	[Id] [int] NULL,
	[CoveragePlanName] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[CustomerAddress] [varchar](150) NULL,
	[Gender] [varchar](10) NULL,
	[Country] [varchar](10) NULL,
	[Dob] [datetime] NULL,
	[SaleDate] [datetime] NULL,
	[CoveragePlanId] [int] NULL,
	[NetPrice] [money] NULL,
	[DataInserteddatetime] [datetime] NULL,
 CONSTRAINT [PK_customerdata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCoverage]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCoverage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoverageplanID] [int] NULL,
	[EligibleDataFrom] [datetime] NULL,
	[EligibleDataTo] [datetime] NULL,
	[EligibleCountry] [varchar](50) NULL,
 CONSTRAINT [PK_plancoverage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RateChartData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateChartData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CoveragePlanId] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Age] [bit] NULL,
	[NetPrice] [varchar](50) NULL,
 CONSTRAINT [PK_ratechartdata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CoveragePlandata] ([Id], [CoveragePlanName]) VALUES (1, N'Gold')
GO
INSERT [dbo].[CoveragePlandata] ([Id], [CoveragePlanName]) VALUES (2, N'Platinum')
GO
INSERT [dbo].[CoveragePlandata] ([Id], [CoveragePlanName]) VALUES (3, N'Silver')
GO
SET IDENTITY_INSERT [dbo].[CustomerData] ON 
GO
INSERT [dbo].[CustomerData] ([id], [CustomerName], [CustomerAddress], [Gender], [Country], [Dob], [SaleDate], [CoveragePlanId], [NetPrice], [DataInserteddatetime]) VALUES (18, N'ssssnow', N'london', N'M', N'can', CAST(N'1965-08-31T00:00:00.000' AS DateTime), CAST(N'2020-08-27T15:06:23.000' AS DateTime), 2, 2900.0000, CAST(N'2020-08-27T15:06:23.000' AS DateTime))
GO
INSERT [dbo].[CustomerData] ([id], [CustomerName], [CustomerAddress], [Gender], [Country], [Dob], [SaleDate], [CoveragePlanId], [NetPrice], [DataInserteddatetime]) VALUES (19, N'unitest', N'london', N'M', N'usa', CAST(N'1965-08-31T00:00:00.000' AS DateTime), CAST(N'2020-08-27T15:06:48.347' AS DateTime), 1, 2000.0000, CAST(N'2020-08-27T15:06:48.347' AS DateTime))
GO
INSERT [dbo].[CustomerData] ([id], [CustomerName], [CustomerAddress], [Gender], [Country], [Dob], [SaleDate], [CoveragePlanId], [NetPrice], [DataInserteddatetime]) VALUES (20, N'unitest77', N'TPTY', N'M', N'all', CAST(N'1992-08-31T00:00:00.000' AS DateTime), CAST(N'2020-08-27T15:07:18.780' AS DateTime), 3, 1500.0000, CAST(N'2020-08-27T15:07:18.780' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CustomerData] OFF
GO
SET IDENTITY_INSERT [dbo].[PlanCoverage] ON 
GO
INSERT [dbo].[PlanCoverage] ([ID], [CoverageplanID], [EligibleDataFrom], [EligibleDataTo], [EligibleCountry]) VALUES (1, 1, CAST(N'2009-01-01T00:00:00.000' AS DateTime), CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'USA')
GO
INSERT [dbo].[PlanCoverage] ([ID], [CoverageplanID], [EligibleDataFrom], [EligibleDataTo], [EligibleCountry]) VALUES (2, 2, CAST(N'2005-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T00:00:00.000' AS DateTime), N'CAN')
GO
INSERT [dbo].[PlanCoverage] ([ID], [CoverageplanID], [EligibleDataFrom], [EligibleDataTo], [EligibleCountry]) VALUES (3, 3, CAST(N'2001-01-01T00:00:00.000' AS DateTime), CAST(N'2026-01-01T00:00:00.000' AS DateTime), N'ALL')
GO
SET IDENTITY_INSERT [dbo].[PlanCoverage] OFF
GO
SET IDENTITY_INSERT [dbo].[RateChartData] ON 
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (1, N'1', N'M', 1, N'1000')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (2, N'1', N'M', 0, N'2000')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (3, N'1', N'F', 1, N'1200')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (4, N'1', N'F', 0, N'2500')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (5, N'2', N'M', 1, N'1900')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (6, N'2', N'M', 0, N'2900')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (7, N'2', N'F', 1, N'2100')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (8, N'2', N'F', 0, N'3200')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (9, N'3', N'M', 1, N'1500')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (10, N'3', N'M', 0, N'2600')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (11, N'3', N'F', 1, N'1900')
GO
INSERT [dbo].[RateChartData] ([id], [CoveragePlanId], [Gender], [Age], [NetPrice]) VALUES (12, N'3', N'F', 0, N'2800')
GO
SET IDENTITY_INSERT [dbo].[RateChartData] OFF
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomerData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will delete customer data
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCustomerData]-- 'all','m','1'
	-- Add the parameters for the stored procedure here
		@customerName varchar(50),
		@dob datetime		

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

				-- Insert statements for procedure here
				DELETE CustomerData WHERE CustomerName=@customerName AND Dob=@dob
			
END
GO
/****** Object:  StoredProcedure [dbo].[GetCoveragePlanId]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will check the customer data and saves data back
-- =============================================
CREATE PROCEDURE [dbo].[GetCoveragePlanId] 
	-- Add the parameters for the stored procedure here
		@country varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

				-- Insert statements for procedure here
			SELECT CoverageplanID FROM PlanCoverage 
			WHERE EligibleCountry=@country AND 
			GETDATE() BETWEEN EligibleDataFrom AND EligibleDataTo
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will GET customer data
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerData]-- 'all','m','1'
	-- Add the parameters for the stored procedure here


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

				-- Insert statements for procedure here
				SELECT CustomerName, CustomerAddress, Country, CoveragePlanName FROM CustomerData C 
				INNER JOIN CoveragePlandata CP ON C.CoveragePlanId = CP.ID
			
END
GO
/****** Object:  StoredProcedure [dbo].[GetNetPrice]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will check the customer data and saves data back
-- =============================================
CREATE PROCEDURE [dbo].[GetNetPrice]-- 'all','m','1'
	-- Add the parameters for the stored procedure here
		@country varchar(50),
		@gender varchar(10),
		@age bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

				-- Insert statements for procedure here
				SELECT  R.NetPrice FROM RateChartData R 
				INNER JOIN PlanCoverage p ON P.CoverageplanID =R.CoveragePlanId
				WHERE GETDATE() BETWEEN p.EligibleDataFrom AND P.EligibleDataTo
				AND r.Age=@age --or r.Age >@age
				and r.Gender=@gender and p.EligibleCountry=@country
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomerData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will check the customer data and saves data back
-- =============================================
CREATE PROCEDURE [dbo].[InsertCustomerData] 
	-- Add the parameters for the stored procedure here
		@customerName varchar(100),
		@customerAddress varchar(100),
		@country varchar(50),
		@gender varchar(10),
		@dob datetime,
		@coveragePlanId varchar(50),
		@netprice varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

			INSERT INTO [dbo].CustomerData(
			CustomerName,
			CustomerAddress,
			Gender,
			Country,
			Dob,
			SaleDate,
			CoveragePlanId,
			NetPrice,
			DataInserteddatetime
			)

			Values(
			@customerName,
			@customerAddress,
			@gender ,
			@country,
			@dob,
			Getdate(),
			@coveragePlanId,
			@netprice,
			GETDATE()
			)
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATECustomerData]    Script Date: 8/27/2020 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sasidhar D
-- Create date:Aug 27
-- Description:This will updates customer data
-- =============================================
CREATE PROCEDURE [dbo].[UPDATECustomerData]-- 'all','m','1'
	-- Add the parameters for the stored procedure here
		@customerName varchar(100),		
		@country varchar(50),
		@gender varchar(10),
		@dob datetime,
		@coveragePlanId varchar(50),
		@netprice varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
					-- Insert statements for procedure here
				UPDATE CustomerData 				
				SET CustomerName=@customerName, Dob=@dob, Gender=@gender, 
				Country=@country, CoveragePlanId=@coveragePlanId, NetPrice=@netprice
			
END
GO

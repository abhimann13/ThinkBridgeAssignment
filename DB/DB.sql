CREATE DATABASE [ShopBridge]
GO
USE [ShopBridge]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](500) NULL,
	[StackTrace] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetItems]
@search NVARCHAR(50) = '',
@pageIndex INT = 1,
@pageSize INT = 0,
@totalRecordCount INT OUTPUT 
AS
BEGIN
	SELECT @totalRecordCount = COUNT(1) FROM [dbo].[Item] WITH (NOLOCK) WHERE [Item].[IsActive] = 1 AND ([Item].[Name] LIKE @search + '%' OR [Item].[Description] LIKE @search + '%')
	
	IF (ISNULL(@pageIndex,0) <= 0)
	BEGIN 
		SET @pageIndex = 1
	END

	IF (ISNULL(@pageSize,0) <= 0)
	BEGIN SET 
		@pageSize = CASE WHEN ISNULL(@totalRecordCount,0) > 0 THEN @totalRecordCount ELSE 5 END
	END

	SELECT 
		[Item].[ItemID] As [ItemID], 
		[Item].[Name] AS [Name],
		[Item].[Description] AS [Description],
		[Item].[Price] AS [Price],
		[Item].[CreatedDate] AS [CreatedDate],
		[Item].[ModifiedDate] AS [ModifiedDate],
		[Item].[IsActive] AS [IsActive]
	FROM [dbo].[Item] WITH (NOLOCK)
	WHERE [Item].[IsActive] = 1 AND ([Item].[Name] LIKE @search + '%' OR [Item].[Description] LIKE @search + '%')
	ORDER BY [Item].[Name]
	OFFSET (@pageIndex - 1) * @pageSize ROWS 
	FETCH NEXT @pageSize ROWS ONLY
END
GO
USE [master]
GO
ALTER DATABASE [ShopBridge] SET  READ_WRITE 
GO

CREATE DATABASE AFDataAccessorSampleDB

USE [AFDataAccessorSampleDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 13-04-2023 10:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 13-04-2023 10:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployee]
	-- Add the parameters for the stored procedure here
	@EmpID nvarchar(50)

AS
BEGIN
	DELETE FROM Employee WHERE EmployeeID=@EmpID
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployee]    Script Date: 13-04-2023 10:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployee]

AS
BEGIN
	SELECT EmployeeID,[Name],[Address],EMail,Phone FROM Employee
END
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 13-04-2023 10:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertEmployee]
	-- Add the parameters for the stored procedure here
	@EmpID nvarchar(50),
	@Name nvarchar(50),
	@Address nvarchar(50),
	@EMail nvarchar(50),
	@Phone nvarchar(50)
AS
BEGIN
	INSERT INTO DBO.Employee([EmployeeID],[Name],[Address],[EMail],[Phone]) VALUES(@EmpID,@Name,@Address,@EMail,@Phone)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 13-04-2023 10:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
	-- Add the parameters for the stored procedure here
	@EmpID nvarchar(50),
	@Address nvarchar(50),
	@EMail nvarchar(50),
	@Phone nvarchar(50)
AS
BEGIN
	UPDATE DBO.Employee SET [Address]=@Address,[EMail]=@EMail,[Phone]=@Phone WHERE EmployeeID=@EmpID
END
GO

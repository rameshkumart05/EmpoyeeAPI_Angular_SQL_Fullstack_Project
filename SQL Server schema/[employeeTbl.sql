USE [EmployeesDb]
GO

/****** Object:  Table [dbo].[employeeTbl]    Script Date: 24-10-2026 12:45:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[employeeTbl](
	[employeeid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[contactNo] [varchar](10) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[sate] [varchar](50) NOT NULL,
	[pincode] [varchar](6) NOT NULL,
	[altContactno] [varchar](10) NULL,
	[address] [varchar](2000) NOT NULL,
	[designationid] [int] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[modifiedDate] [datetime] NULL,
	[role] [varchar](35) NULL,
 CONSTRAINT [PK_employeeTbl] PRIMARY KEY CLUSTERED 
(
	[employeeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[employeeTbl]  WITH CHECK ADD  CONSTRAINT [FK_employeeTbl_designationTbl] FOREIGN KEY([designationid])
REFERENCES [dbo].[designationTbl] ([designationid])
GO

ALTER TABLE [dbo].[employeeTbl] CHECK CONSTRAINT [FK_employeeTbl_designationTbl]
GO



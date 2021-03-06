USE [LeaveRequest]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2020/3/18 1:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[Title] [varchar](255) NULL,
 CONSTRAINT [PK_Department_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2020/3/18 1:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Gender] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2020/3/18 1:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[Id] [int] NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Type] [varchar](255) NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[Duration] [float] NULL,
	[Description] [varchar](255) NULL,
	[EmployeeId] [int] NULL,
	[LeaveTypeId] [int] NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 2020/3/18 1:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[Id] [int] NOT NULL,
	[Name] [varchar](255) NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_LeaveType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([Id], [Title]) VALUES (1, N'Marketing')
INSERT [dbo].[Department] ([Id], [Title]) VALUES (2, N'Development')
INSERT [dbo].[Department] ([Id], [Title]) VALUES (3, N'Management')
INSERT [dbo].[Department] ([Id], [Title]) VALUES (4, N'Human Resource')
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Gender], [Email], [DepartmentId]) VALUES (1, N'Jason', N'Li', N'Male', N'j.li@random.com', 2)
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Gender], [Email], [DepartmentId]) VALUES (2, N'Mary', N'Lee', N'Female', N'ml666@gmail.com', 1)
INSERT [dbo].[Leave] ([Id], [Title], [Type], [StartDate], [EndDate], [LastUpdated], [Duration], [Description], [EmployeeId], [LeaveTypeId]) VALUES (1, N'Sick leave one day', N'Sick Leave', NULL, NULL, NULL, 1, N'Jason is sick and needs one day off.', 1, NULL)
INSERT [dbo].[Leave] ([Id], [Title], [Type], [StartDate], [EndDate], [LastUpdated], [Duration], [Description], [EmployeeId], [LeaveTypeId]) VALUES (2, N'Parental leave Mary Lee', N'Parental Leave', NULL, NULL, NULL, 1, N'Mary needs to take care of her sick daughter to the GP', 2, NULL)
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (1, N'Annual Leave', N'Annual Leave')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (2, N'Sick Leave', N'Sick Leave')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (3, N'Parental Leave', N'Parental Leave')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (4, N'Public Holiday', N'Public Holiday')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (5, N'Maternity Leave', N'Maternity Leave')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (6, N'Unpaid Leave', N'Unpaid Leave')
INSERT [dbo].[LeaveType] ([Id], [Name], [Description]) VALUES (7, N'Other Special Leave', N'Other Special Leave')
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_Employee]
GO
ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_LeaveType] FOREIGN KEY([LeaveTypeId])
REFERENCES [dbo].[LeaveType] ([Id])
GO
ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_LeaveType]
GO

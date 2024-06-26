USE [master]
GO
/****** Object:  Database [Library_Management_System]    Script Date: 4/30/2024 11:04:01 AM ******/
CREATE DATABASE [Library_Management_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library_Management_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Library_Management_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_Management_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Library_Management_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Library_Management_System] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library_Management_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library_Management_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library_Management_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library_Management_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library_Management_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library_Management_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library_Management_System] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library_Management_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library_Management_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library_Management_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library_Management_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library_Management_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library_Management_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library_Management_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library_Management_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library_Management_System] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library_Management_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library_Management_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library_Management_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library_Management_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library_Management_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library_Management_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library_Management_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library_Management_System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library_Management_System] SET  MULTI_USER 
GO
ALTER DATABASE [Library_Management_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library_Management_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library_Management_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library_Management_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library_Management_System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library_Management_System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Library_Management_System] SET QUERY_STORE = ON
GO
ALTER DATABASE [Library_Management_System] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Library_Management_System]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 4/30/2024 11:04:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(101,1) NOT NULL,
	[AuthorName] [varchar](50) NOT NULL,
	[AuthorBio] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/30/2024 11:04:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(201,1) NOT NULL,
	[PublishedDate] [date] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[AvailableCopies] [int] NOT NULL,
	[ISBN] [varchar](50) NULL,
	[TotalCopies] [int] NOT NULL,
	[AuthorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowedBooks]    Script Date: 4/30/2024 11:04:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowedBooks](
	[BorrowId] [int] IDENTITY(401,1) NOT NULL,
	[BorrowDate] [date] NOT NULL,
	[ReturnDate] [date] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[MemberId] [int] NULL,
	[BookId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BorrowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 4/30/2024 11:04:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[Id] [int] IDENTITY(11,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[LoginPassword] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 4/30/2024 11:04:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(301,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[RegistrationDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (101, N'Jane Austen', N'Jane Austen was an English novelist known primarily for her six major novels, which interpret, critique and comment upon the British landed gentry at the end of the 18th century.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (102, N'Charles Dickens', N'Charles Dickens was an English writer and social critic. He created some of the world''s best-known fictional characters and is regarded by many as the greatest novelist of the Victorian era.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (103, N'J.K. Rowling', N'J.K. Rowling is a British author, philanthropist, film producer, television producer, and screenwriter. She is best known for writing the Harry Potter fantasy series, which has won multiple awards and sold more than 500 million copies, becoming the best-selling book series in history.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (104, N'Ernest Hemingway', N'Ernest Hemingway was an American novelist, short-story writer, and journalist. His economical and understated style had a strong influence on 20th-century fiction, while his adventurous lifestyle and his public image brought him admiration from later generations.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (105, N'Agatha Christie', N'Agatha Christie was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (106, N'Toni Morrison', N'Toni Morrison was an American novelist, essayist, editor, and professor. Her novels are known for their epic themes, vivid dialogue, and richly detailed characters.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (107, N'sadikur rahman', N'he is an famous author.he is a bangladeshi soldier. he faught for the nation at the last time of his life.')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (110, N'saiful islam', N'famous poet in the middle east asia pacific.')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (202, CAST(N'2023-05-15' AS Date), N'To Kill a Mockingbird', 15, N'9780061120084', 30, 101)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (203, CAST(N'2020-09-10' AS Date), N'1984', 15, N'9780451524935', 60, 102)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (204, CAST(N'2019-07-03' AS Date), N'The Great Gatsby', 30, N'9780743273565', 66, 103)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (205, CAST(N'2022-11-20' AS Date), N'Pride and Prejudice', 80, N'9780141439518', 100, 104)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (206, CAST(N'2021-03-25' AS Date), N'The Catcher in the Rye', 60, N'9780316769488', 70, 105)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (210, CAST(N'2024-01-02' AS Date), N'Beauty of Bangladesh', 100, NULL, 150, 102)
INSERT [dbo].[Books] ([BookId], [PublishedDate], [Title], [AvailableCopies], [ISBN], [TotalCopies], [AuthorID]) VALUES (212, CAST(N'2023-06-06' AS Date), N'arabic books', 60, NULL, 100, 103)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowedBooks] ON 

INSERT [dbo].[BorrowedBooks] ([BorrowId], [BorrowDate], [ReturnDate], [Status], [MemberId], [BookId]) VALUES (402, CAST(N'2023-01-15' AS Date), CAST(N'2023-02-15' AS Date), N'Returned', 301, 206)
INSERT [dbo].[BorrowedBooks] ([BorrowId], [BorrowDate], [ReturnDate], [Status], [MemberId], [BookId]) VALUES (403, CAST(N'2022-11-20' AS Date), CAST(N'1900-01-01' AS Date), N'Borrowed', 302, 202)
INSERT [dbo].[BorrowedBooks] ([BorrowId], [BorrowDate], [ReturnDate], [Status], [MemberId], [BookId]) VALUES (404, CAST(N'2023-02-10' AS Date), CAST(N'2023-03-10' AS Date), N'Returned', 303, 203)
INSERT [dbo].[BorrowedBooks] ([BorrowId], [BorrowDate], [ReturnDate], [Status], [MemberId], [BookId]) VALUES (405, CAST(N'2022-12-05' AS Date), CAST(N'1900-01-01' AS Date), N'Borrowed', 304, 204)
INSERT [dbo].[BorrowedBooks] ([BorrowId], [BorrowDate], [ReturnDate], [Status], [MemberId], [BookId]) VALUES (406, CAST(N'2023-03-18' AS Date), CAST(N'2023-04-18' AS Date), N'Returned', 305, 205)
SET IDENTITY_INSERT [dbo].[BorrowedBooks] OFF
GO
SET IDENTITY_INSERT [dbo].[LoginUser] ON 

INSERT [dbo].[LoginUser] ([Id], [UserName], [LoginPassword]) VALUES (11, N'admin', N'12345')
SET IDENTITY_INSERT [dbo].[LoginUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (301, N'John', N'Doe', N'johndoe@example.com', N'123-456-7890', CAST(N'2023-01-16' AS Date))
INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (302, N'Alice', N'Smith', N'alicesmith@example.com', N'987-654-3210', CAST(N'2022-11-20' AS Date))
INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (303, N'Bob', N'Johnson', N'bjohnson@example.com', NULL, CAST(N'2023-02-10' AS Date))
INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (304, N'Emily', N'Brown', NULL, N'555-123-4567', CAST(N'2022-12-05' AS Date))
INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (305, N'Michael', N'Davis', N'mdavis@example.com', N'111-222-3333', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[Members] ([MemberId], [FirstName], [LastName], [Email], [PhoneNumber], [RegistrationDate]) VALUES (307, N'saiful', N'islam akash', N'saiful@gmail.com', N'01721302882', CAST(N'2022-07-20' AS Date))
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
USE [master]
GO
ALTER DATABASE [Library_Management_System] SET  READ_WRITE 
GO

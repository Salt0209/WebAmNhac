GO
USE MASTER
GO
IF EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME='WebAmNhac')
DROP DATABASE [WebAmNhac]
GO
CREATE DATABASE [WebAmNhac];
GO
USE [WebAmNhac]

GO
CREATE TABLE [dbo].[Playlist] (
    [ID]   INT IDENTITY(1, 1) NOT NULL,
    [Name] NCHAR (30) NULL,
	[Detail] NCHAR (150) NULL,
	[Thumbnail] NCHAR (50) NULL,
	[UserID] INT NULL,
	[ViewCount] INT DEFAULT 0,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO
CREATE TABLE [dbo].[Genre] (
    [ID]   INT  IDENTITY (1, 1) NOT NULL,
    [Name] NCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);



GO
CREATE TABLE [dbo].[User] (
    [ID]       INT        IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (30) NULL,
    [Email]    NCHAR (40) NULL,
    [Password] NCHAR (20) NULL,
    [Age]      INT        NULL,
    [Role]     NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO
CREATE TABLE [dbo].[Artist] (
    [ID] INT  NOT NULL IDENTITY (1,1),
    [Name]  NCHAR (30) NULL,
    [Birthday]  NCHAR (10) NULL,
    [Country]  NCHAR (20) NULL,
    [Image]  NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO
CREATE TABLE [dbo].[Song] (
    [ID]        INT         IDENTITY (1, 1) NOT NULL,
    [Name]      NCHAR (30)  NULL,
    [ArtistID]  INT  NULL,
    [Lyric]     NCHAR (500) NULL,
    [Thumbnail] NCHAR (50)  NULL,
    [Url]       NCHAR (50)  NULL,
    [GenreID]   INT         NOT NULL,
	[ViewCount] INT DEFAULT(0),
    CONSTRAINT [PK_Song] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Song_Artist] FOREIGN KEY (ArtistID) REFERENCES Artist(ID),
	CONSTRAINT [FK_Song_Genre] FOREIGN KEY (GenreID) REFERENCES Genre(ID)
);

GO

CREATE TABLE [dbo].[PlaylistDetail] (
    [PlaylistID] INT  NOT NULL,
	[SongID] INT  NOT NULL,
	CONSTRAINT [PK_PlaylistDetail] PRIMARY KEY([PlaylistID],[SongID]),
	CONSTRAINT [FK_PlaylistDetail_Playlist] FOREIGN KEY (PlaylistID) REFERENCES Playlist(ID),
	CONSTRAINT [FK_PlaylistDetail_Song] FOREIGN KEY (SongID) REFERENCES Song(ID)
);
GO
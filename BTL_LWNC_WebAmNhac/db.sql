
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
CREATE TABLE [dbo].[Playlist] (
    [ID]   INT IDENTITY(1, 1) NOT NULL,
    [Name] NCHAR (30) NULL,
	[Detail] NCHAR (150) NULL,
	[Thumbnail] NCHAR (50) NULL,
	[UserID] INT NULL,
	[ViewCount] INT DEFAULT 0,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Playlist_User] FOREIGN KEY (UserID) REFERENCES [User](ID)
);
GO
CREATE TABLE [dbo].[Genre] (
    [ID]   INT  IDENTITY (1, 1) NOT NULL,
    [Name] NCHAR (20) NULL,
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
INSERT INTO [User]([Name],[Email],[Password],[Role]) VALUES(N'admin','admin@gmail.com','admin','Admin')
INSERT INTO [User]([Name],[Email],[Password],[Role]) VALUES(N'user','user@gmail.com','user','User')
INSERT INTO [User]([Name],[Email],[Password],[Role]) VALUES(N'user1','user1@gmail.com','user1','User')
INSERT INTO [User]([Name],[Email],[Password],[Role]) VALUES(N'user2','user2@gmail.com','user1','User')
GO
INSERT INTO [Playlist]([Name],[Detail],[Thumbnail],[UserID]) VALUES(N'Chill Hits',N'Quay trở lại với những bản hit thư giãn mới và hay nhất gần đây','/image/album_chill_hits.jpg',1)
INSERT INTO [Playlist]([Name],[Detail],[Thumbnail],[UserID]) VALUES(N'Rock Việt',N'Tất cả về cảm xúc và năng lượng đích thực của rock được thể hiện qua Playlist này','/image/album_rockviet.jpg',1)
INSERT INTO [Playlist]([Name],[Detail],[Thumbnail],[UserID]) VALUES(N'Ngày Mới Nhạc Mới',N'Bắt đầu mỗi ngày với tâm trạng lạc quan','/image/album_ngaymoinhacmoi.jpg',1)
INSERT INTO [Playlist]([Name],[Detail],[Thumbnail],[UserID]) VALUES(N'Tiệc Tùng Thôi',N'Thả mình và thư giãn trong âm nhạc vui nhộn và năng động','/image/album_tiectungthoi.jpg',1)
INSERT INTO [Playlist]([Name],[Detail],[Thumbnail],[UserID]) VALUES(N'Quốc Tế Thịnh Hành',N'Sự kết hợp độc đáo của các bản nhạc quốc tế đỉnh cao','/image/album_quoctethinhhanh.jpg',2)

GO
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Tuấn Hưng','1978',N'Việt Nam','/image/artist_tuanhung.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Sơn Tùng','1994',N'Việt Nam','/image/artist_sontung.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Ngô Kiến Huy','1988',N'Việt Nam','/image/artist_ngokienhuy.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Tăng Duy Tân','1995',N'Việt Nam','/image/artist_tangduytan.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Keyo','1997',N'Việt Nam','/image/artist_keyo.jpg')

INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Phong Max','1995',N'Việt Nam','/image/artist_phongmax.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Nal','1997',N'Việt Nam','/image/artist_nal.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Taylor Swift','1989',N'Mỹ','/image/artist_taylor.jpg')
INSERT INTO [Artist]([Name],[Birthday],[Country],[Image]) VALUES(N'Post Malone','1995',N'Mỹ','/image/artist_postmalone.jpg')
GO
INSERT INTO [Genre]([Name]) VALUES(N'Nhạc Pop')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc Rock')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc đồng quê')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc Ballad')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc Dance')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc Acoustic')
INSERT INTO [Genre]([Name]) VALUES (N'Nhạc Rap')
GO
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Gấp Đôi Yêu Thương',N'1',N'Chưa có','/image/gapdoiyeuthuong.jpg','/media/gapdoiyeuthuong.mp3','1')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Bên Trên Tầng Lầu',N'4',N'Chưa có','/image/bentrentanglau.jpg','/media/bentrentanglau.mp3','4')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Blank Space',N'8',N'Chưa có','/image/blankspace.jpg','/media/blankspace.mp3','1')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Cắt Đôi Nỗi Sầu',N'4',N'Chưa có','/image/catdoinoisau.jpg','/media/catdoinoisau.mp3','5')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Em Là Ai',N'5',N'Chưa có','/image/emlaai.jpg','/media/emlaai.mp3','5')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Hoa Cỏ Lau',N'6',N'Chưa có','/image/hoacolau.jpg','/media/hoacolau.mp3','3')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Ngây Thơ',N'4',N'Chưa có','/image/ngaytho.jpg','/media/ngaytho.mp3','6')
INSERT INTO [Song]([Name],[ArtistID],[Lyric],[Thumbnail],[Url],[GenreID]) VALUES(N'Sunflower',N'9',N'Chưa có','/image/sunflower.jpg','/media/sunflower.mp3','5')

GO
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(1,2)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(1,3)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(1,4)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(1,5)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(1,6)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(2,3)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(2,4)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(3,1)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(3,2)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(4,1)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(4,4)
INSERT INTO [PlaylistDetail]([PlaylistID],[SongID]) VALUES(5,1)
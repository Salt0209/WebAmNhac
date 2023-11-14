/* Reset lại thứ tự identity về 0
DBCC CHECKIDENT ('[TableName]', RESEED, 0);
*/

GO
USE [WebAmNhac]
GO
INSERT INTO [User]([Name]) VALUES(N'Tiến')
INSERT INTO [User]([Name]) VALUES(N'Tùng')
INSERT INTO [User]([Name]) VALUES(N'Tân')
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


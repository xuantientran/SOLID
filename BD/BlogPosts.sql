CREATE TABLE [dbo].[BlogPosts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [DatePosted] DATETIME NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Body] NVARCHAR(MAX) NOT NULL
)

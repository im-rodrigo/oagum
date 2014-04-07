--insert into dbo.T_Author (Name,InsertDate,CreatedBy) 
--select distinct x.Author, GETDATE(), 'Rodrigo' 
--from T_AuthorSmallMeDa_02 x;  

--insert into dbo.T_Article (Title,PublishDate,Description,Source,InsertDate,CreatedBy)
--select x.Title,x.PubDate,x.Description,x.Relation,GETDATE(),'Rodrigo' 
--from T_ArticleVeryFullMeDa_02 x;

--DROP TABLE T_Article;
--CREATE TABLE [dbo].[T_Article] (
--    [ID]          INT            IDENTITY (1, 1) NOT NULL,
--    [Title]       NVARCHAR (400) NULL,
--    [PublishDate] DATETIME       NULL,
--    [Description] TEXT           NULL,
--    [Source]      NVARCHAR (400) NULL,
--    [InsertDate]  DATETIME       NULL,
--    [CreatedBy]   NVARCHAR (20)  NULL,
--    PRIMARY KEY CLUSTERED ([ID] ASC)
--);

--select count( Title) from T_ArticleVeryFullMeDa_02;
--select count( Name) from T_Author;
--select x.Name,y.Title from T_Author x join T_AuthorSmallMeDa_02 y on x.Name = y.Author;

--insert into dbo.T_ArticleAuthor (ArticleId,AuthorId,InsertDate,CreatedBy)
--select  z.ID,x.ID,GETDATE(),'Rodrigo' from T_Author x
--join T_AuthorSmallMeDa_02 y on x.Name = y.Author
--join T_Article z on z.Title = y.Title;

select x.* from T_Author x join T_ArticleAuthor y on y.AuthorId = x.ID  where y.ArticleId = 12;

--select  x.ID,x.Name,z.ID,y.Title from T_Author x 
--join T_AuthorSmallMeDa_02 y on x.Name = y.Author
--join T_Article z on z.Title = y.Title;

--select count(*) from T_Author;
--select count(*) from T_AuthorSmallMeDa_02;
--select count(*) from T_Author x join T_AuthorSmallMeDa_02 y on x.Name = y.Author;
--select count(*) from T_AuthorSmallMeDa_02;
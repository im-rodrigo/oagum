drop table T_ArticleSmallMeDa_02; 
CREATE TABLE [dbo].[T_ArticleSmallMeDa_02] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
	[KeyTitle] NVARCHAR (40) NOT NULL,
    [Title]   NVARCHAR (400) NULL,
    [PubDate] DATETIME       NULL,
    [Link]    NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [U_KeyTitle] UNIQUE NONCLUSTERED ([KeyTitle] ASC)
);
select * from T_ArticleVeryFullMeDa_02 where Title like '%An anthology of%';
insert into dbo.T_ArticleSmallMeDa_02 (KeyTitle,Title,PubDate,Link) select distinct SUBSTRING(x.Title,0,39),x.Title,x.PubDate,x.Relation from T_ArticleVeryFullMeDa_02 x; 
--insert into dbo.T_ArticleSmallMeDa (Title,PubDate,Link) select Title, PubDate, Relation from T_ArticleVeryFullMeDa;
--alter table dbo.T_ArticleSmallMeDa drop column Author;
--select * from T_ArticleSmallMeDa;
--select * from T_AuthorSmallMeDa;
--alter table dbo.T_AuthorSmallMeDa drop constraint UC_TA;
--select distinct Author from T_AuthorSmallMeDa;

--DROP TABLE T_AuthorSmallestMeDa; 

--CREATE TABLE [dbo].[T_AuthorSmallestMeDa] (
--    [Author]  NVARCHAR (50)  NULL,
--    [ID]      INT            IDENTITY (1, 1) NOT NULL,
--    PRIMARY KEY CLUSTERED ([ID] ASC)
--);

--select y.Title,y.Creator,x.Author from T_AuthorSmallMeDa x join T_ArticleVeryFullMeDa y on (x.Author = y.Creator) where x.Title <> y.Title;

--delete from  T_AuthorSmallMeDa where Author = '';
--select * from T_AuthorSmallMeDa where Author = '';

--insert into T_AuthorSmallestMeDa (Author) select distinct Author from T_AuthorSmallMeDa_02;

--select * from T_AuthorSmallestMeDa;

--select x.Title, x.Author,z.ID 
--from T_AuthorSmallMeDa x 
--join T_ArticleSmallMeDa y
--on x.Title = y.Title
--join T_AuthorSmallestMeDa z
--on x.Author = z.Author;
--where x.Author like '%Odedede%';
--select * from T_ArticleVeryFullMeDa_02 where Creator like '%Scaron%';
--select count(*) from T_AuthorSmallestMeDa; 
--select * from T_AuthorSmallestMeDa where Author like '%Odedede%';
--select * from T_ArticleVeryFullMeDa; 
--select SUBSTRING(Title,0,19) as ShortTitle from T_ArticleSmallMeDa;
--select * from T_ArticleSmallMeDa;
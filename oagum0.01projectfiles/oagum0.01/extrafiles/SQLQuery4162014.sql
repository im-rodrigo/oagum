--insert into dbo.T_Article (Title,PublishDate,Description,Source,InsertDate,CreatedBy)
--(
--select distinct x.Title,NULL,NULL,x.Source,GETDATE(),'Rodrigo' 
--from T_IOP_4162014_DATA_02 x )
--select count(distinct Title) from T_Article;

--drop table T_MiddleMan01;
--drop table T_MiddleMan02;
--select z.n, i, c into T_MiddleMan02 from (
--select distinct Name as n ,InsertDate as i,CreatedBy as c from T_Author x 
--union 
--select distinct q.Name as n,GETDATE() i,'Rodrigo' as c from (
--select Name from T_IOP_4162014_DATA_02 intersect
--select distinct Name from T_IOP_4162014_DATA_02
--) as q) as z intersect

--select q.n, getdate() as i, 'Rodrigo' as c into T_MiddleMan02 from (
--select x.n from T_MiddleMan01 x intersect
--select distinct y.n from T_MiddleMan01 y) as q;

--select count(n) from T_MiddleMan02;
--select Name from T_Author;
--select count(distinct Name) from T_Author;

--insert into T_Author(Name,InsertDate,CreatedBy)
--select z.na, GETDATE(), 'Rodrigo' from (
--select x.n as na from T_MiddleMan02  x except 
----select y.Name from T_Author y) as z;
--select count(Name) from T_Author;

--select count(distinct Name) from T_Author;

--select count(*) from T_Article;
--insert into dbo.T_ArticleAuthor (ArticleId,AuthorId,InsertDate,CreatedBy)
--select  z.ID,x.ID,GETDATE(),'Rodrigo' from T_Author x
--join T_AuthorSmallMeDa_02 y on x.Name = y.Author
--join T_Article z on z.Title = y.Title;
select count(*) from T_ArticleAuthor;
--select Title from T_IOP_4162014_DATA_02 intersect
--select distinct Title from T_IOP_4162014_DATA_02;

--insert into dbo.T_Author (Name,InsertDate,CreatedBy)
--select z.Name, GETDATE(), 'Rodrigo'
--from (
--select Name from T_IOP_4162014_DATA_02 intersect
--select distinct Name from T_IOP_4162014_DATA_02 as z;
--select count(Name) from T_IOP_4162014_DATA_02;
--select	count(distinct Name) from T_IOP_4162014_DATA_02;
--select count( n) from T_MiddleMan01;
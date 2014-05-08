alter table dbo.[UserArticles] 
add constraint fk_ArticleId_ArticleId
foreign key (ArticleId)
references PublisherMetadataEntity.T_Article(Id)
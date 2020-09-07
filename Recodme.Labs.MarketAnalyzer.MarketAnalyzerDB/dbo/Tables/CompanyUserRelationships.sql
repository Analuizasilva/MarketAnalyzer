CREATE TABLE [dbo].[CompanyUserRelationships] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]    UNIQUEIDENTIFIER NULL,
    [AspNetUserId] NVARCHAR (450)   NULL,
    CONSTRAINT [PK_CompanyUserRelationships] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);


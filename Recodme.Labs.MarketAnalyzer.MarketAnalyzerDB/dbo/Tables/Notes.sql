CREATE TABLE [dbo].[Notes] (
    [Description]  NVARCHAR (MAX)   NULL,
    [CompanyId]    UNIQUEIDENTIFIER NULL,
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [AspNetUserId] NVARCHAR (450)   NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);


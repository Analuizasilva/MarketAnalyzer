CREATE TABLE [dbo].[Notes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Description]  NVARCHAR (MAX)   NULL,
    [CompanyId]    UNIQUEIDENTIFIER NULL,
    [AspNetUserId] NVARCHAR (450)   NULL,
    [DateCreated]  DATETIME2 (3)    NULL,
    [DateUpdated]  DATETIME2 (3)    NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Notes__AspNetUse__5CD6CB2B] FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK__Notes__CompanyId__5DCAEF64] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);










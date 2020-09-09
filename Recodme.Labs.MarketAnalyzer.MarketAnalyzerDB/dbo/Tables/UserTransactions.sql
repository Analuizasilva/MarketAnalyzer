CREATE TABLE [dbo].[UserTransactions] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [NumberOfShares]          FLOAT (53)       NULL,
    [ValueOfShares]           MONEY            NULL,
    [NumberOfSharesWithdrawn] FLOAT (53)       NULL,
    [ValueOfSharesWithdrawn]  MONEY            NULL,
    [DateOfMovement]          DATETIME2 (3)    NULL,
    [DateCreated]             DATETIME2 (3)    NULL,
    [DateUpdated]             DATETIME2 (3)    NULL,
    [CompanyId]               UNIQUEIDENTIFIER NULL,
    [AspNetUserId]            NVARCHAR (450)   NULL,
    CONSTRAINT [PK_UserTransactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__UserTrans__AspNe__6FE99F9F] FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK__UserTrans__Compa__70DDC3D8] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);
















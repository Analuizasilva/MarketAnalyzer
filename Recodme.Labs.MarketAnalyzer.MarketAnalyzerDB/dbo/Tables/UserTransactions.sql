CREATE TABLE [dbo].[UserTransactions] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [NumberOfShares]          FLOAT (53)       NULL,
    [ValueOfShares]           MONEY            NULL,
    [NumberOfSharesWithdrawn] FLOAT (53)       NULL,
    [ValueOfSharesWithdrawn]  MONEY            NULL,
    [DateOfMovement]          DATETIME2 (3)    NULL,
    [DateCreated]             DATETIME2 (3)    NOT NULL,
    [DateUpdated]             DATETIME2 (3)    NOT NULL,
    [IsDeleted]               BIT              NULL,
    CONSTRAINT [PK_UserTransactions] PRIMARY KEY CLUSTERED ([Id] ASC)
);










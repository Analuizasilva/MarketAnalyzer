CREATE TABLE [dbo].[Portfolios] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [NumberOfShares]          FLOAT (53)       NULL,
    [ValueOfShares]           FLOAT (53)       NULL,
    [NumberOfSharesWithdrawn] FLOAT (53)       NULL,
    [ValueOfSharesWithdrawn]  FLOAT (53)       NULL,
    [DateOfMovement]          DATETIME         NULL,
    [CreatedAt]               DATETIME         NOT NULL,
    [UpdatedAt]               DATETIME         NOT NULL,
    [IsDeleted]               BIT              NOT NULL
);


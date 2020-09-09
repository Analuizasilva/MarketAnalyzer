CREATE TABLE [dbo].[WeightMultipliers] (
    [Id]                              NCHAR (10)     NOT NULL,
    [AspNetUserId]                    NVARCHAR (450) NULL,
    [WeightNumberRoic]                FLOAT (53)     NULL,
    [WeightNumberEquity]              FLOAT (53)     NULL,
    [WeightNumberEPS]                 FLOAT (53)     NULL,
    [WeightNumberRevenue]             FLOAT (53)     NULL,
    [WeightNumberPERatio]             FLOAT (53)     NULL,
    [WeightNumberDebtToEquity]        FLOAT (53)     NULL,
    [WeightNumberAssetsToLiabilities] FLOAT (53)     NULL,
    [DateCreated]                     DATETIME2 (3)  NULL,
    [DateUpdated]                     DATETIME2 (3)  NULL,
    CONSTRAINT [PK_WeightMultipliers] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


CREATE TABLE [dbo].[Companies] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (100)   NOT NULL,
    [Ticker]         VARCHAR (10)     NOT NULL,
    [StockPrice]     MONEY            NOT NULL,
    [Country]        VARCHAR (5)      NULL,
    [BuyR]           BIT              NULL,
    [BuyL]           BIT              NULL,
    [Notes]          NVARCHAR (MAX)   NULL,
    [SAndPRank]      INT              NULL,
    [Forbes2000Rank] INT              NULL,
    [IndustryId]     UNIQUEIDENTIFIER NULL,
    [DateCreated]    DATETIME2 (3)    NOT NULL,
    [DateUpdated]    DATETIME2 (3)    NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Companies_Industries] FOREIGN KEY ([IndustryId]) REFERENCES [dbo].[Industries] ([Id])
);


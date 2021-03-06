﻿CREATE TABLE [dbo].[ExtractedIncomeStatementTTMs] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [DataSourceId]            UNIQUEIDENTIFIER NOT NULL,
    [Revenue]                 MONEY            NULL,
    [CostOfGoodsSold]         MONEY            NULL,
    [GrossProfit]             MONEY            NULL,
    [Sales]                   MONEY            NULL,
    [RD]                      MONEY            NULL,
    [SpecialCharges]          MONEY            NULL,
    [OtherExpenses]           MONEY            NULL,
    [TotalOperatingExpenses]  MONEY            NULL,
    [OperatingProfit]         MONEY            NULL,
    [NetInterestIncome]       MONEY            NULL,
    [OtherNonOperatingIncome] MONEY            NULL,
    [PreTaxIncome]            MONEY            NULL,
    [IncomeTax]               MONEY            NULL,
    [NetIncome]               MONEY            NULL,
    [EpsBasic]                MONEY            NULL,
    [EpsDiluted]              MONEY            NULL,
    [SharesBasic]             MONEY            NULL,
    [SharesDiluted]           MONEY            NULL,
    [CompanyId]               UNIQUEIDENTIFIER NOT NULL,
    [DateCreated]             DATETIME2 (3)    NOT NULL,
    [DateUpdated]             DATETIME2 (3)    NOT NULL,
    CONSTRAINT [PK_ExtractedIncomeStatementTTMs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExtractedIncomeStatementTTMs_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    CONSTRAINT [FK_ExtractedIncomeStatementTTMs_DataSources] FOREIGN KEY ([DataSourceId]) REFERENCES [dbo].[DataSources] ([Id])
);


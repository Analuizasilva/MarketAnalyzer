CREATE TABLE [dbo].[Profiles] (
    [FirstName]   NVARCHAR (50)    NOT NULL,
    [LastName]    NVARCHAR (50)    NOT NULL,
    [BirthDate]   DATETIME         NOT NULL,
    [Email]       NVARCHAR (50)    NOT NULL,
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [DateUpdated] DATETIME         NOT NULL,
    [DateCreated] DATETIME         NOT NULL,
    [IsDeleted]   BIT              NOT NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED ([Id] ASC)
);


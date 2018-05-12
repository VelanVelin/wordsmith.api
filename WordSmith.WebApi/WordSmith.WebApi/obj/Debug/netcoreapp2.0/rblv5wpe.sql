IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Sentences] (
    [Id] int NOT NULL IDENTITY,
    [Normal] nvarchar(max) NULL,
    [Reversed] nvarchar(max) NULL,
    [SessionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Sentences] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180501224716_InitialCreate', N'2.0.2-rtm-10011');

GO

EXEC sp_rename N'Sentences.Normal', N'Text', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180502224047_renamedProp', N'2.0.2-rtm-10011');

GO


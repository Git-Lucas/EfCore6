IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categoria] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] NVARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tarefa] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] NVARCHAR(160) NOT NULL DEFAULT (GETDATE()),
    [CriadoEm] datetime2 NOT NULL,
    [Feito] BIT NOT NULL,
    [CategoriaId] int NOT NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CategoriaTarefa] (
    [CategoriaId] int NOT NULL,
    [TarefaId] int NOT NULL,
    CONSTRAINT [PK_CategoriaTarefa] PRIMARY KEY ([CategoriaId], [TarefaId]),
    CONSTRAINT [FK_CategoriaTarefa_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CategoriaTarefa_TarefaId] FOREIGN KEY ([TarefaId]) REFERENCES [Tarefa] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CategoriaTarefa_TarefaId] ON [CategoriaTarefa] ([TarefaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221020014737_Inicio', N'6.0.10');
GO

COMMIT;
GO


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [tbl_motor] (
    [motor_id] varchar(50) NOT NULL,
    [nome] varchar(150) NOT NULL,
    [cnh] varchar(10) NOT NULL,
    [validadeCNH] datetime NOT NULL,
    [ativo] bit NOT NULL,
    CONSTRAINT [PK_tbl_motor] PRIMARY KEY ([motor_id])
);

GO

CREATE TABLE [tbl_veicl] (
    [veicl_id] varchar(50) NOT NULL,
    [modelo] varchar(100) NULL,
    [placa] varchar(20) NULL,
    [ano] int NOT NULL,
    CONSTRAINT [PK_tbl_veicl] PRIMARY KEY ([veicl_id])
);

GO

CREATE TABLE [tbl_motr_veicl] (
    [motor_id] varchar(50) NOT NULL,
    [veicl_id] varchar(50) NOT NULL,
    CONSTRAINT [PK_tbl_motr_veicl] PRIMARY KEY ([motor_id], [veicl_id]),
    CONSTRAINT [FK_tbl_motr_veicl_tbl_motor_motor_id] FOREIGN KEY ([motor_id]) REFERENCES [tbl_motor] ([motor_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_motr_veicl_tbl_veicl_veicl_id] FOREIGN KEY ([veicl_id]) REFERENCES [tbl_veicl] ([veicl_id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_tbl_motr_veicl_veicl_id] ON [tbl_motr_veicl] ([veicl_id]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418000124_CriacaoDoBanco', N'3.1.23');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_motor]') AND [c].[name] = N'cnh');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [tbl_motor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [tbl_motor] ALTER COLUMN [cnh] varchar(30) NOT NULL;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'ativo', N'cnh', N'nome', N'validadeCNH') AND [object_id] = OBJECT_ID(N'[tbl_motor]'))
    SET IDENTITY_INSERT [tbl_motor] ON;
INSERT INTO [tbl_motor] ([motor_id], [ativo], [cnh], [nome], [validadeCNH])
VALUES ('f50449ce-eecb-4a9b-9a60-55f28e75f231', CAST(1 AS bit), '12345678', 'Wesley Santos', '2025-03-25T00:00:00.000'),
('0f683f4f-4474-43b2-a97f-4788c068cc71', CAST(1 AS bit), '87654321', 'Victoria São Felippe', '2026-01-15T00:00:00.000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'ativo', N'cnh', N'nome', N'validadeCNH') AND [object_id] = OBJECT_ID(N'[tbl_motor]'))
    SET IDENTITY_INSERT [tbl_motor] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'veicl_id', N'ano', N'modelo', N'placa') AND [object_id] = OBJECT_ID(N'[tbl_veicl]'))
    SET IDENTITY_INSERT [tbl_veicl] ON;
INSERT INTO [tbl_veicl] ([veicl_id], [ano], [modelo], [placa])
VALUES ('13e9aab5-7e2a-471a-bbd7-44082774216a', 2020, 'Onix', 'QQD-2D51'),
('d01f14be-e33f-49fb-a11d-5edba7a8de84', 2022, 'Prima', 'VIC-5K31');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'veicl_id', N'ano', N'modelo', N'placa') AND [object_id] = OBJECT_ID(N'[tbl_veicl]'))
    SET IDENTITY_INSERT [tbl_veicl] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] ON;
INSERT INTO [tbl_motr_veicl] ([motor_id], [veicl_id])
VALUES ('f50449ce-eecb-4a9b-9a60-55f28e75f231', '13e9aab5-7e2a-471a-bbd7-44082774216a');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] ON;
INSERT INTO [tbl_motr_veicl] ([motor_id], [veicl_id])
VALUES ('0f683f4f-4474-43b2-a97f-4788c068cc71', 'd01f14be-e33f-49fb-a11d-5edba7a8de84');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418003652_InsertDeDados', N'3.1.23');

GO


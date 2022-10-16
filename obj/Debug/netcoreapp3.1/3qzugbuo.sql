CREATE TABLE [tbl_motor] (
    [motor_id] varchar(50) NOT NULL,
    [nome] varchar(150) NOT NULL,
    [cnh] varchar(30) NOT NULL,
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


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'ativo', N'cnh', N'nome', N'validadeCNH') AND [object_id] = OBJECT_ID(N'[tbl_motor]'))
    SET IDENTITY_INSERT [tbl_motor] ON;
INSERT INTO [tbl_motor] ([motor_id], [ativo], [cnh], [nome], [validadeCNH])
VALUES ('9142226f-ff9f-4bc0-81ea-b2f4a60b989e', CAST(1 AS bit), '12345678', 'Wesley Santos', '2025-03-25T00:00:00.000'),
('03b69d46-6ebd-4876-b409-4b720fd1ce77', CAST(1 AS bit), '87654321', 'Victoria São Felippe', '2026-01-15T00:00:00.000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'ativo', N'cnh', N'nome', N'validadeCNH') AND [object_id] = OBJECT_ID(N'[tbl_motor]'))
    SET IDENTITY_INSERT [tbl_motor] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'veicl_id', N'ano', N'modelo', N'placa') AND [object_id] = OBJECT_ID(N'[tbl_veicl]'))
    SET IDENTITY_INSERT [tbl_veicl] ON;
INSERT INTO [tbl_veicl] ([veicl_id], [ano], [modelo], [placa])
VALUES ('961f0297-5ccd-465c-9d0b-c903bc0989b0', 2020, 'Onix', 'QQD-2D51'),
('561c1878-0423-42c3-b869-e850dac83d9e', 2022, 'Prima', 'VIC-5K31');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'veicl_id', N'ano', N'modelo', N'placa') AND [object_id] = OBJECT_ID(N'[tbl_veicl]'))
    SET IDENTITY_INSERT [tbl_veicl] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] ON;
INSERT INTO [tbl_motr_veicl] ([motor_id], [veicl_id])
VALUES ('9142226f-ff9f-4bc0-81ea-b2f4a60b989e', '961f0297-5ccd-465c-9d0b-c903bc0989b0');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] ON;
INSERT INTO [tbl_motr_veicl] ([motor_id], [veicl_id])
VALUES ('03b69d46-6ebd-4876-b409-4b720fd1ce77', '561c1878-0423-42c3-b869-e850dac83d9e');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'motor_id', N'veicl_id') AND [object_id] = OBJECT_ID(N'[tbl_motr_veicl]'))
    SET IDENTITY_INSERT [tbl_motr_veicl] OFF;
GO


CREATE INDEX [IX_tbl_motr_veicl_veicl_id] ON [tbl_motr_veicl] ([veicl_id]);
GO



CREATE TABLE [Manufacturers] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Manufacturers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Username] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(255) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Username])
);
GO


CREATE TABLE [Models] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ToolType] int NOT NULL,
    [ManufacturerId] bigint NOT NULL,
    CONSTRAINT [PK_Models] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Models_Manufacturers_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Tools] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [ModelId] bigint NOT NULL,
    [NominalValue] int NOT NULL,
    CONSTRAINT [PK_Tools] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tools_Models_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [Models] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [TestPoints] (
    [Id] bigint NOT NULL IDENTITY,
    [TargetTorque] decimal(18,2) NOT NULL,
    [TargetAngle] decimal(18,2) NOT NULL,
    [ToolId] bigint NOT NULL,
    CONSTRAINT [PK_TestPoints] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TestPoints_Tools_ToolId] FOREIGN KEY ([ToolId]) REFERENCES [Tools] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Models_ManufacturerId] ON [Models] ([ManufacturerId]);
GO


CREATE INDEX [IX_TestPoints_ToolId] ON [TestPoints] ([ToolId]);
GO


CREATE INDEX [IX_Tools_ModelId] ON [Tools] ([ModelId]);
GO



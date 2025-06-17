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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AIModelResults] (
        [Id] int NOT NULL IDENTITY,
        [ImageId] uniqueidentifier NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AIModelResults] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [OTPCode] nvarchar(max) NULL,
        [OTPExpiration] datetime2 NULL,
        [Provider] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [ChatHistories] (
        [Id] int NOT NULL IDENTITY,
        [UserMessage] nvarchar(max) NOT NULL,
        [BotResponse] nvarchar(max) NOT NULL,
        [Timestamp] datetime2 NOT NULL,
        CONSTRAINT [PK_ChatHistories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [EmergencyAlerts] (
        [Id] int NOT NULL IDENTITY,
        [EmergencyType] int NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        [Severity] int NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        [LocationDescription] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_EmergencyAlerts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Equipments] (
        [Id] int NOT NULL IDENTITY,
        [EquipmentId] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Status] int NOT NULL,
        [LastMaintenance] datetime2 NOT NULL,
        [HoursUsed] float NOT NULL,
        [Battery] float NOT NULL,
        [Connectivity] int NOT NULL,
        CONSTRAINT [PK_Equipments] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Fields] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Size] float NOT NULL,
        [Crop] nvarchar(max) NOT NULL,
        [PlantingDate] datetime2 NOT NULL,
        [HarvestDate] datetime2 NOT NULL,
        [Irrigation] int NOT NULL,
        [Status] int NOT NULL,
        CONSTRAINT [PK_Fields] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [WeatherDatas] (
        [Id] int NOT NULL IDENTITY,
        [Temperature] float NOT NULL,
        [Humidity] float NOT NULL,
        [WindSpeed] float NOT NULL,
        [Condition] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        [LastUpdated] datetime2 NOT NULL,
        [UvIndex] float NOT NULL,
        [Pressure] float NOT NULL,
        CONSTRAINT [PK_WeatherDatas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [WeatherForecasts] (
        [Id] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [Condition] nvarchar(max) NOT NULL,
        [High] float NOT NULL,
        [Low] float NOT NULL,
        [Precipitation] float NOT NULL,
        [Wind] float NOT NULL,
        [Day] nvarchar(max) NOT NULL,
        [Humidity] int NOT NULL,
        [Pressure] int NOT NULL,
        [Icon] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_WeatherForecasts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [FeedbackEntries] (
        [Id] int NOT NULL IDENTITY,
        [Disease] nvarchar(max) NOT NULL,
        [Solution] nvarchar(max) NOT NULL,
        [ModelResultId] int NOT NULL,
        CONSTRAINT [PK_FeedbackEntries] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FeedbackEntries_AIModelResults_ModelResultId] FOREIGN KEY ([ModelResultId]) REFERENCES [AIModelResults] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Carts] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Carts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Carts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Cupons] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(50) NOT NULL,
        [Discount_Type] nvarchar(max) NOT NULL,
        [Discount_Value] decimal(18,3) NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NULL,
        [UsageLimit] int NOT NULL,
        [UsageCount] int NOT NULL DEFAULT 0,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Cupons] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Cupon_Discount_Value] CHECK (Discount_Value > 0),
        CONSTRAINT [ck_Cupon_ExpirationDate] CHECK (ExpirationDate > GetDate()),
        CONSTRAINT [CK_Cupon_UsageLimit] CHECK (UsageLimit > 0),
        CONSTRAINT [FK_Cupons_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ShippingAddress] nvarchar(200) NOT NULL,
        [Status] int NOT NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [Title] nvarchar(255) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [VoteCount] int NOT NULL DEFAULT 0,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Posts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [RefreshTokens] (
        [Id] int NOT NULL IDENTITY,
        [Token] nvarchar(max) NOT NULL,
        [ExpiresOn] datetime2 NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [RevokedOn] datetime2 NULL,
        [UserId] nvarchar(450) NOT NULL,
        [JwtTokenId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_RefreshTokens] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RefreshTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Votes] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [TargetId] int NOT NULL,
        [TargetType] nvarchar(50) NOT NULL,
        [VoteType] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        CONSTRAINT [PK_Votes] PRIMARY KEY ([Id]),
        CONSTRAINT [CK_Vote_TargetType] CHECK ([TargetType] IN ('post', 'comment')),
        CONSTRAINT [CK_Vote_VoteType] CHECK ([VoteType] IN (1, -1)),
        CONSTRAINT [FK_Votes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Wishlists] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Wishlists] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Wishlists_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [SoilMoistures] (
        [Id] int NOT NULL IDENTITY,
        [FieldName] nvarchar(max) NOT NULL,
        [Moisture] int NOT NULL,
        [Optimal] int NOT NULL,
        [PH] real NOT NULL,
        [FieldId] int NOT NULL,
        CONSTRAINT [PK_SoilMoistures] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SoilMoistures_Fields_FieldId] FOREIGN KEY ([FieldId]) REFERENCES [Fields] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        [Price] decimal(18,4) NOT NULL,
        [Availability] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        [CategoryId] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [CuponId] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Products_Cupons_CuponId] FOREIGN KEY ([CuponId]) REFERENCES [Cupons] ([Id]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [OrderItems] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitPrice] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Comments] (
        [Id] int NOT NULL IDENTITY,
        [PostId] int NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        [ParentCommentId] int NULL,
        [Content] nvarchar(max) NOT NULL,
        [VoteCount] int NOT NULL DEFAULT 0,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Comments_Comments_ParentCommentId] FOREIGN KEY ([ParentCommentId]) REFERENCES [Comments] ([Id]),
        CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [CartItems] (
        [Id] int NOT NULL IDENTITY,
        [CartId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL DEFAULT 1,
        CONSTRAINT [PK_CartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY ([CartId]) REFERENCES [Carts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Leasings] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [StartingDate] datetime2 NOT NULL,
        [LeasingDetails] nvarchar(max) NOT NULL,
        [EndDate] datetime2 NULL,
        CONSTRAINT [PK_Leasings] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Leasings_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [ProductImages] (
        [Id] int NOT NULL IDENTITY,
        [ImageUrl] nvarchar(max) NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [Reviews] (
        [ReviewID] int NOT NULL IDENTITY,
        [UserID] nvarchar(450) NOT NULL,
        [ProductID] int NOT NULL,
        [Headline] nvarchar(255) NOT NULL,
        [Rating] int NOT NULL,
        [ReviewText] nvarchar(max) NULL,
        [ReviewDate] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([ReviewID]),
        CONSTRAINT [CK_Review_Rating] CHECK ([Rating] BETWEEN 1 AND 5),
        CONSTRAINT [FK_Reviews_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Reviews_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE TABLE [WishlistItems] (
        [Id] int NOT NULL IDENTITY,
        [WishlistId] int NOT NULL,
        [ProductId] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
        [UpdatedAt] datetime2 NULL,
        CONSTRAINT [PK_WishlistItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WishlistItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WishlistItems_Wishlists_WishlistId] FOREIGN KEY ([WishlistId]) REFERENCES [Wishlists] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_CartItems_CartId] ON [CartItems] ([CartId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_CartItems_ProductId] ON [CartItems] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Carts_UserId] ON [Carts] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Comments_ParentCommentId] ON [Comments] ([ParentCommentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Comments_PostId] ON [Comments] ([PostId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Cupons_Code] ON [Cupons] ([Code]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Cupons_UserId] ON [Cupons] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_FeedbackEntries_ModelResultId] ON [FeedbackEntries] ([ModelResultId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Leasings_ProductId] ON [Leasings] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Posts_UserId] ON [Posts] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_ProductImages_ProductId] ON [ProductImages] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Products_CuponId] ON [Products] ([CuponId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Products_UserId] ON [Products] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_RefreshTokens_UserId] ON [RefreshTokens] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Reviews_ProductID] ON [Reviews] ([ProductID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_Reviews_UserID] ON [Reviews] ([UserID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_SoilMoistures_FieldId] ON [SoilMoistures] ([FieldId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Votes_UserId_TargetId_TargetType] ON [Votes] ([UserId], [TargetId], [TargetType]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_WishlistItems_ProductId] ON [WishlistItems] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE INDEX [IX_WishlistItems_WishlistId] ON [WishlistItems] ([WishlistId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Wishlists_UserId] ON [Wishlists] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429213844_initial-new-database'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250429213844_initial-new-database', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ImageUrl', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [ImageUrl], [Name])
    VALUES (1, N''Daily harvested organic vegetables'', N''https://graduationprojetct.blob.core.windows.net/category-images/0bdbd4c8-2503-427c-b4fe-ffa6e5c57a23_Fresh Vegetables.jpg'', N''Fresh Vegetables''),
    (2, N''Naturally grown fruits with authentic flavors'', N''https://graduationprojetct.blob.core.windows.net/category-images/5caaf20a-3510-4d38-b2b4-b16e79cf45ab_Seasonal Fruits.jpg'', N''Seasonal Fruits''),
    (3, N''Fresh cheese and milk from our farm'', N''https://graduationprojetct.blob.core.windows.net/category-images/61cd1282-c3c4-4ef3-9b2c-ae7d5beb482c_Dairy Products.jpg'', N''Dairy Products''),
    (4, N''Free-range chicken eggs'', N''https://graduationprojetct.blob.core.windows.net/category-images/b7f5884a-6833-43f0-bb78-367c371a37fb_Organic Eggs.jpg'', N''Organic Eggs''),
    (5, N''Home garden flowers and decorative plants'', N''https://graduationprojetct.blob.core.windows.net/category-images/9aa3dfb7-12b7-4631-908c-eb11fa0c64f9_Ornamental Plants.jpg'', N''Ornamental Plants''),
    (6, N''Vegetable and fruit starters for home gardening'', N''https://graduationprojetct.blob.core.windows.net/category-images/28773f2f-5619-406e-8c74-1cd82b296d3f_Seedlings.jpg'', N''Seedlings''),
    (7, N''Natural feed for livestock and poultry'', N''https://graduationprojetct.blob.core.windows.net/category-images/a5a834c1-736c-4858-95df-673e21014525_Organic Animal Feed.jpg'', N''Organic Animal Feed''),
    (8, N''Essential agricultural equipment'', N''https://graduationprojetct.blob.core.windows.net/category-images/c10224a6-0625-41a3-8332-73433f96f39e_Farming Tools.jpg'', N''Farming Tools''),
    (9, N''Certified high-yield seeds'', N''https://graduationprojetct.blob.core.windows.net/category-images/6c4bef01-1181-4fde-8bc4-78331a8c82d2_Premium Seeds.jpg'', N''Premium Seeds''),
    (10, N''Natural soil enhancers'', N''https://graduationprojetct.blob.core.windows.net/category-images/242d456f-5b41-4d3a-8744-cd18ec583aae_Organic Fertilizers.jpg'', N''Organic Fertilizers'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'ImageUrl', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'EmergencyType', N'Latitude', N'LocationDescription', N'Longitude', N'Message', N'Severity') AND [object_id] = OBJECT_ID(N'[EmergencyAlerts]'))
        SET IDENTITY_INSERT [EmergencyAlerts] ON;
    EXEC(N'INSERT INTO [EmergencyAlerts] ([Id], [CreatedAt], [EmergencyType], [Latitude], [LocationDescription], [Longitude], [Message], [Severity])
    VALUES (1, ''2025-04-29T21:18:56.6572434Z'', 5, 26.820553E0, N''Farm Field #1'', 30.802498E0, N''Low moisture detected in Field A'', 2),
    (2, ''2025-04-29T21:03:56.6572436Z'', 4, 27.820553E0, N''Farm Field #2'', 31.802498E0, N''Pest activity reported in Wheat field'', 1),
    (3, ''2025-04-29T20:48:56.6572438Z'', 0, 28.820553E0, N''Farm Field #3'', 32.802498E0, N''Tractor requires maintenance'', 0),
    (4, ''2025-04-29T21:33:56.6572452Z'', 3, 29.820553E0, N''Farm Field #4'', 33.802498E0, N''Storm warning for tonight'', 2),
    (5, ''2025-04-29T21:28:56.6572454Z'', 6, 30.820553E0, N''Farm Field #5'', 34.802498E0, N''High pH level detected in Field B'', 1),
    (6, ''2025-04-29T21:43:56.6572455Z'', 5, 31.820553E0, N''Farm Field #6'', 35.802498E0, N''Low moisture detected in Field C'', 2),
    (7, ''2025-04-29T21:38:56.6572457Z'', 4, 32.820552999999997E0, N''Farm Field #7'', 36.802498E0, N''Pest activity reported in Corn field'', 1),
    (8, ''2025-04-29T21:45:56.6572458Z'', 1, 26.820553E0, N''Farm Field #1'', 30.802498E0, N''Medical emergency: Worker injured in Field A'', 2),
    (9, ''2025-04-29T21:46:56.6572460Z'', 7, 27.820553E0, N''Farm Entrance'', 31.802498E0, N''Unusual activity reported near the farm entrance'', 0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'EmergencyType', N'Latitude', N'LocationDescription', N'Longitude', N'Message', N'Severity') AND [object_id] = OBJECT_ID(N'[EmergencyAlerts]'))
        SET IDENTITY_INSERT [EmergencyAlerts] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Battery', N'Connectivity', N'EquipmentId', N'HoursUsed', N'LastMaintenance', N'Name', N'Status') AND [object_id] = OBJECT_ID(N'[Equipments]'))
        SET IDENTITY_INSERT [Equipments] ON;
    EXEC(N'INSERT INTO [Equipments] ([Id], [Battery], [Connectivity], [EquipmentId], [HoursUsed], [LastMaintenance], [Name], [Status])
    VALUES (1, 85.0E0, 0, N''EQ-001'', 120.0E0, ''2025-03-30T21:48:56.6572297Z'', N''Tractor A'', 0),
    (2, 60.0E0, 1, N''EQ-002'', 50.0E0, ''2025-04-14T21:48:56.6572313Z'', N''Drone B'', 2),
    (3, 95.0E0, 0, N''EQ-003'', 30.0E0, ''2025-04-19T21:48:56.6572315Z'', N''Sprinkler C'', 1),
    (4, 75.0E0, 0, N''EQ-004'', 200.0E0, ''2025-03-15T21:48:56.6572316Z'', N''Harvester D'', 0),
    (5, 100.0E0, 1, N''EQ-005'', 20.0E0, ''2025-04-24T21:48:56.6572318Z'', N''Seeder E'', 2),
    (6, 50.0E0, 0, N''EQ-006'', 90.0E0, ''2025-04-09T21:48:56.6572320Z'', N''Plow F'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Battery', N'Connectivity', N'EquipmentId', N'HoursUsed', N'LastMaintenance', N'Name', N'Status') AND [object_id] = OBJECT_ID(N'[Equipments]'))
        SET IDENTITY_INSERT [Equipments] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Crop', N'HarvestDate', N'Irrigation', N'Name', N'PlantingDate', N'Size', N'Status') AND [object_id] = OBJECT_ID(N'[Fields]'))
        SET IDENTITY_INSERT [Fields] ON;
    EXEC(N'INSERT INTO [Fields] ([Id], [Crop], [HarvestDate], [Irrigation], [Name], [PlantingDate], [Size], [Status])
    VALUES (1, N''Wheat'', ''2025-06-29T21:48:56.6572357Z'', 1, N''Field Alpha'', ''2025-01-29T21:48:56.6572350Z'', 10.5E0, 2),
    (2, N''Corn'', ''2025-07-29T21:48:56.6572361Z'', 2, N''Field Beta'', ''2025-02-28T21:48:56.6572360Z'', 15.199999999999999E0, 2),
    (3, N''Rice'', ''2025-05-29T21:48:56.6572364Z'', 3, N''Field Gamma'', ''2024-12-29T21:48:56.6572362Z'', 8.0E0, 2),
    (4, N''Soybeans'', ''2025-09-29T21:48:56.6572366Z'', 1, N''Field Delta'', ''2025-03-29T21:48:56.6572365Z'', 12.699999999999999E0, 4),
    (5, N''Barley'', ''2025-07-29T21:48:56.6572368Z'', 5, N''Field Epsilon'', ''2024-11-29T21:48:56.6572367Z'', 20.300000000000001E0, 2),
    (6, N''Oats'', ''2025-08-29T21:48:56.6572370Z'', 4, N''Field Zeta'', ''2024-10-29T21:48:56.6572369Z'', 9.5E0, 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Crop', N'HarvestDate', N'Irrigation', N'Name', N'PlantingDate', N'Size', N'Status') AND [object_id] = OBJECT_ID(N'[Fields]'))
        SET IDENTITY_INSERT [Fields] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Availability', N'CategoryId', N'CreatedAt', N'CuponId', N'Description', N'Name', N'Price', N'UpdatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [Availability], [CategoryId], [CreatedAt], [CuponId], [Description], [Name], [Price], [UpdatedAt], [UserId])
    VALUES (1, 0, 1, ''2025-04-29T21:48:56.6572080Z'', NULL, N''Fresh vine-ripened tomatoes'', N''Organic Tomatoes'', 19.99, ''2025-04-29T21:48:56.6572081Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (2, 0, 1, ''2025-04-29T21:48:56.6572083Z'', NULL, N''Crisp and refreshing cucumbers'', N''Cucumbers'', 12.5, ''2025-04-29T21:48:56.6572084Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (3, 1, 1, ''2025-04-29T21:48:56.6572086Z'', NULL, N''Mixed color sweet peppers'', N''Bell Peppers'', 18.75, ''2025-04-29T21:48:56.6572086Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (4, 0, 2, ''2025-04-29T21:48:56.6572089Z'', NULL, N''Sweet and juicy strawberries'', N''Strawberries'', 25.99, ''2025-04-29T21:48:56.6572089Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (5, 0, 2, ''2025-04-29T21:48:56.6572092Z'', NULL, N''Premium imported mangoes'', N''Mangoes'', 30.5, ''2025-04-29T21:48:56.6572092Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (6, 0, 2, ''2025-04-29T21:48:56.6572094Z'', NULL, N''Large sweet watermelons'', N''Watermelons'', 45.0, ''2025-04-29T21:48:56.6572095Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (7, 0, 3, ''2025-04-29T21:48:56.6572097Z'', NULL, N''Whole milk 1L bottle'', N''Farm Fresh Milk'', 20.0, ''2025-04-29T21:48:56.6572097Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (8, 0, 3, ''2025-04-29T21:48:56.6572099Z'', NULL, N''Aged cheddar cheese 200g'', N''Artisan Cheese'', 35.75, ''2025-04-29T21:48:56.6572099Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (9, 0, 3, ''2025-04-29T21:48:56.6572102Z'', NULL, N''Natural Yogurt'', N''Natural Yogurt'', 18.5, ''2025-04-29T21:48:56.6572102Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (10, 0, 4, ''2025-04-29T21:48:56.6572104Z'', NULL, N''Large brown eggs'', N''Free-Range Eggs (12pk)'', 30.0, ''2025-04-29T21:48:56.6572104Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (11, 0, 5, ''2025-04-29T21:48:56.6572106Z'', NULL, N''Red rose plant in 12" pot'', N''Rose Bush'', 120.0, ''2025-04-29T21:48:56.6572107Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (12, 0, 5, ''2025-04-29T21:48:56.6572109Z'', NULL, N''Fragrant lavender for gardens'', N''Lavender Plant'', 85.5, ''2025-04-29T21:48:56.6572109Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (13, 0, 6, ''2025-04-29T21:48:56.6572112Z'', NULL, N''Early girl tomato plants'', N''Tomato Seedlings'', 15.0, ''2025-04-29T21:48:56.6572112Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (14, 0, 6, ''2025-04-29T21:48:56.6572114Z'', NULL, N''Burpless cucumber plants, disease-resistant'', N''Cucumber Seedlings'', 13.25, ''2025-04-29T21:48:56.6572115Z'', N''642b8bd1-a65f-4598-95bc-29b833dcb84e''),
    (15, 0, 7, ''2025-04-29T21:48:56.6572117Z'', NULL, N''Organic chicken feed'', N''Poultry Feed 20kg'', 150.0, ''2025-04-29T21:48:56.6572117Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c''),
    (16, 0, 7, ''2025-04-29T21:48:56.6572119Z'', NULL, N''Nutritional cattle mix'', N''Cattle Feed 25kg'', 220.0, ''2025-04-29T21:48:56.6572120Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c''),
    (17, 0, 8, ''2025-04-29T21:48:56.6572122Z'', NULL, N''Professional grade shears'', N''Pruning Shears'', 65.0, ''2025-04-29T21:48:56.6572122Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c''),
    (18, 0, 8, ''2025-04-29T21:48:56.6572124Z'', NULL, N''Sturdy steel garden hoe'', N''Garden Hoe'', 45.0, ''2025-04-29T21:48:56.6572124Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c''),
    (19, 0, 10, ''2025-04-29T21:48:56.6572126Z'', NULL, N''Nutrient-rich compost'', N''Compost 10kg'', 40.0, ''2025-04-29T21:48:56.6572127Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c''),
    (20, 0, 10, ''2025-04-29T21:48:56.6572129Z'', NULL, N''Organic soil amendment'', N''Worm Castings'', 55.0, ''2025-04-29T21:48:56.6572129Z'', N''655501be-8ca7-434d-9cbe-6e8d23b3d92c'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Availability', N'CategoryId', N'CreatedAt', N'CuponId', N'Description', N'Name', N'Price', N'UpdatedAt', N'UserId') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FieldId', N'FieldName', N'Moisture', N'Optimal', N'PH') AND [object_id] = OBJECT_ID(N'[SoilMoistures]'))
        SET IDENTITY_INSERT [SoilMoistures] ON;
    EXEC(N'INSERT INTO [SoilMoistures] ([Id], [FieldId], [FieldName], [Moisture], [Optimal], [PH])
    VALUES (1, 1, N''Field Alpha'', 58, 65, CAST(6.2 AS real)),
    (2, 2, N''Field Beta'', 62, 60, CAST(6.5 AS real)),
    (3, 3, N''Field Gamma'', 70, 68, CAST(6.8 AS real)),
    (4, 4, N''Field Delta'', 45, 60, CAST(5.9 AS real)),
    (5, 5, N''Field Epsilon'', 67, 70, CAST(6.3 AS real)),
    (6, 6, N''Field Zeta'', 52, 60, CAST(6 AS real))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FieldId', N'FieldName', N'Moisture', N'Optimal', N'PH') AND [object_id] = OBJECT_ID(N'[SoilMoistures]'))
        SET IDENTITY_INSERT [SoilMoistures] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImageUrl', N'ProductId') AND [object_id] = OBJECT_ID(N'[ProductImages]'))
        SET IDENTITY_INSERT [ProductImages] ON;
    EXEC(N'INSERT INTO [ProductImages] ([Id], [ImageUrl], [ProductId])
    VALUES (1, N''https://graduationprojetct.blob.core.windows.net/product-images/Organic Tomatoes_2520f86d-8700-4b06-bed5-e9e317e71d95_R %283%29.jpg'', 1),
    (2, N''https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_d29f0202-cbf9-4f0e-ae62-344521eec15c_R %284%29.jpg'', 2),
    (3, N''https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_771c182f-18c0-43b4-af95-281406ed89fe_OIP.jpg'', 2),
    (4, N''https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_765ca4be-6179-4ce9-bed6-57613481d475_OIP %281%29.jpg'', 3),
    (5, N''https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_7d5babea-020f-4e79-8552-9450f997853e_primary-430.jpg'', 3),
    (6, N''https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_d561a4c3-5e47-4ec4-9a40-dccc6b7157bc_Bell-Peppers.jpg'', 3),
    (7, N''https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_b66be9e1-5421-4592-9038-a546c2c49bd6_R %285%29.jpg'', 7),
    (8, N''https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_affe0646-14b5-4440-9373-823c0aab4132_R %286%29.jpg'', 7),
    (9, N''https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_5d1f9c4f-444c-49d3-8cb0-eb4e1ff19d40_R %287%29.jpg'', 7),
    (10, N''https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_eefc35b5-e857-4cf5-a5a3-b09fa75f3c6f_R %288%29.jpg'', 4),
    (11, N''https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_779eca40-dfb3-4c51-9ae4-f6d022bdea1a_R %289%29.jpg'', 4),
    (12, N''https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_d0c89732-4204-4804-ba7c-d0ef0a822573_download.jpg'', 5),
    (13, N''https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_0aa7f942-c40f-4f0f-a2d0-f960d599a9d2_OIP %282%29.jpg'', 5),
    (14, N''https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_f13f305a-8f7d-4bdd-ad67-08982d51bd88_OIP %283%29.jpg'', 6),
    (15, N''https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_5a90c66a-c7c8-4de4-8ae3-c5d763f63955_OIP %284%29.jpg'', 6),
    (16, N''https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_a1d3e7ec-afba-4883-812d-30216c3cb4e7_R %2810%29.jpg'', 8),
    (17, N''https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_26e0102e-b43e-4124-b3af-9d87e6ad5ce5_OIP %285%29.jpg'', 8),
    (18, N''https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_c5f98e11-0931-43e2-9d9a-fd70f42a5dbd_OIP %286%29.jpg'', 9),
    (19, N''https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_7337ee02-8893-4ab2-aec7-cb1414df80dd_R %2811%29.jpg'', 9),
    (20, N''https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_2d35c5fc-6d4c-4f8e-aa13-1c16ed674601_OIP %287%29.jpg'', 10),
    (21, N''https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_33b205d9-91da-40ef-9a96-c9a0337b3fe4_OIP %288%29.jpg'', 10),
    (22, N''https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_c7bff713-4c6c-4352-869e-c85f673baf1f_R %2812%29.jpg'', 11),
    (23, N''https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_edb3d662-5727-4c71-93a5-bb460cddd3c3_OIP %289%29.jpg'', 11),
    (24, N''https://graduationprojetct.blob.core.windows.net/product-images/Lavender Plant_53ef2c19-0a3b-4114-b178-32c1a6110069_OIP %2810%29.jpg'', 12),
    (25, N''https://graduationprojetct.blob.core.windows.net/product-images/Tomato Seedlings_e6e9622b-bbc1-4aa6-96b2-297ebb8257f4_IMG_9275.jpg'', 13),
    (26, N''https://graduationprojetct.blob.core.windows.net/product-images/Cucumber Seedlings_89f422cb-7093-4814-bd2f-0d4ad099cc6e_R %2813%29.jpg'', 14),
    (27, N''https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_e9e91afb-1a50-4726-bd37-e162ec9ed15a_OIP %2811%29.jpg'', 15),
    (28, N''https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_2a70c24b-9b7a-4905-af6e-796ab5566709_OIP %2812%29.jpg'', 15),
    (29, N''https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_c8ec9374-4839-4004-96c1-0054ad698925_OIP %2813%29.jpg'', 16),
    (30, N''https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_b441f3a3-b774-4efb-bf75-543fa2700a4e_OIP %2814%29.jpg'', 16),
    (31, N''https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_e40f5237-442d-4452-8f32-2883bcfbe8bf_OIP %2815%29.jpg'', 17),
    (32, N''https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_54af077d-62db-4fe4-9bcb-ad0fbf184d15_OIP %2816%29.jpg'', 17),
    (33, N''https://graduationprojetct.blob.core.windows.net/product-images/Garden Hoe_477a31d4-f9c0-4ec2-bd8f-bc81c5aaeaac_OIP %2817%29.jpg'', 18),
    (34, N''https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_d8e29f75-83a8-4968-992f-343303f0404b_61gvcvZgosL._AC_SL1500_.jpg'', 19),
    (35, N''https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_a02227ba-a1a8-4053-9f95-7c354402c179_R %2814%29.jpg'', 19),
    (36, N''https://graduationprojetct.blob.core.windows.net/product-images/Worm Castings_e1155a6c-3ce2-4d69-979f-a8840c282f02_OIP %2818%29.jpg'', 20)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImageUrl', N'ProductId') AND [object_id] = OBJECT_ID(N'[ProductImages]'))
        SET IDENTITY_INSERT [ProductImages] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429214857_seeding-data'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250429214857_seeding-data', N'8.0.11');
END;
GO

COMMIT;
GO
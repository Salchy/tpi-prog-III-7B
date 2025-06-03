CREATE TABLE [Usuarios] (
	[id_Usuario] TINYINT NOT NULL IDENTITY UNIQUE,
	[DNI] VARCHAR NOT NULL UNIQUE,
	[Nombre] VARCHAR NOT NULL UNIQUE,
	[Usuario] VARCHAR NOT NULL UNIQUE,
	[Contraseña] VARCHAR NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Permisos] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Usuario])
);
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description', @value=N'Los gerentes no pueden tener asignada una mesa',
    @level0type=N'SCHEMA',@level0name=N'dbo',
    @level1type=N'TABLE',@level1name=N'Usuarios';
GO

CREATE INDEX [USUARIOS_index_0]
ON [Usuarios] ();
GO

CREATE TABLE [Categoria_Menu] (
	[id_Categoria] TINYINT NOT NULL IDENTITY UNIQUE,
	[Nombre_Categoria] VARCHAR NOT NULL UNIQUE,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Categoria])
);
GO

CREATE TABLE [Menu] (
	[id_Menu_Item] TINYINT NOT NULL IDENTITY UNIQUE,
	[Nombre_Menu] VARCHAR NOT NULL UNIQUE,
	[id_Categoria] TINYINT NOT NULL,
	[Precio] MONEY NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Descripcion] VARCHAR NOT NULL,
	PRIMARY KEY([id_Menu_Item])
);
GO

CREATE TABLE [Ordenes] (
	[id_Orden] INTEGER NOT NULL IDENTITY UNIQUE,
	[id_Menu] TINYINT NOT NULL,
	[Cantidad] CHAR NOT NULL DEFAULT '1',
	[Estado] BIT NOT NULL DEFAULT 1,
	[id_Mesa] TINYINT NOT NULL,
	[Id_Pedido] INTEGER NOT NULL,
	PRIMARY KEY([id_Orden], [Id_Pedido])
);
GO

CREATE TABLE [Mesas] (
	[id_Mesa] TINYINT NOT NULL IDENTITY UNIQUE,
	[Numero] VARCHAR NOT NULL UNIQUE,
	[Id_Usuario] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 01,
	[Numero_Comensales] VARCHAR NOT NULL,
	PRIMARY KEY([id_Mesa])
);
GO

CREATE TABLE [Pedidos] (
	[id_Pedido] INTEGER NOT NULL IDENTITY UNIQUE,
	[id_Mesa] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Importe] MONEY NOT NULL,
	PRIMARY KEY([id_Pedido])
);
GO


ALTER TABLE [Usuarios]
ADD FOREIGN KEY([id_Usuario])
REFERENCES [Mesas]([Id_Usuario])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Mesas]
ADD FOREIGN KEY([id_Mesa])
REFERENCES [Pedidos]([id_Mesa])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Menu]
ADD FOREIGN KEY([id_Menu_Item])
REFERENCES [Ordenes]([id_Menu])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Categoria_Menu]
ADD FOREIGN KEY([id_Categoria])
REFERENCES [Menu]([id_Categoria])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Pedidos]
ADD FOREIGN KEY([id_Pedido])
REFERENCES [Ordenes]([Id_Pedido])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
CREATE DATABASE RestoBar
GO
USE RestoBar
GO

CREATE TABLE [Usuarios] (
	[id_Usuario] TINYINT NOT NULL IDENTITY(1, 1) UNIQUE,
	[DNI] VARCHAR(10) NOT NULL UNIQUE,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(30) NOT NULL,
	[Contraseña] CHAR(64) NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Permisos] INT NOT NULL DEFAULT 0,
	PRIMARY KEY([id_Usuario])
);
GO

CREATE INDEX [USUARIOS_index_0]
ON [Usuarios] (DNI);
GO

CREATE TABLE [Categoria_Menu] (
	[id_Categoria] TINYINT NOT NULL IDENTITY(1, 1) UNIQUE,
	[Nombre_Categoria] VARCHAR(100) NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Categoria])
);
GO

CREATE TABLE [SubCategoriaMenu] (
	[idSubCategoria] TINYINT NOT NULL IDENTITY(1, 1) UNIQUE,
	[NombreSubCategoria] VARCHAR(100) NOT NULL,
	[idCategoriaPrincipal] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([idSubCategoria])
);
GO

CREATE TABLE [Menu] (
	[id_Menu_Item] INT NOT NULL IDENTITY(1, 1) UNIQUE,
	[Nombre_Menu] VARCHAR(100) NOT NULL,
	[idSubCategoria] TINYINT NOT NULL,
	[Precio] MONEY NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Descripcion] VARCHAR(250),
	PRIMARY KEY([id_Menu_Item])
);
GO

CREATE TABLE [Ordenes] (
	[id_Orden] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
	[id_Menu] INT NOT NULL,
	[Cantidad] TINYINT NOT NULL DEFAULT 1,
	[Estado] BIT NOT NULL DEFAULT 1,
	[id_Mesa] TINYINT NOT NULL,
	[id_Pedido] INTEGER NOT NULL,
	PRIMARY KEY([id_Orden], [id_Pedido])
);
GO

CREATE TABLE [Mesas] (
	[id_Mesa] TINYINT NOT NULL IDENTITY(1, 1) UNIQUE,
	[Numero] TINYINT NOT NULL UNIQUE,
	[id_Usuario] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Numero_Comensales] TINYINT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Mesa])
);
GO

CREATE TABLE [Pedidos] (
	[id_Pedido] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
	[id_Mesa] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Importe] MONEY NOT NULL,
	PRIMARY KEY([id_Pedido])
);
GO

ALTER TABLE [Mesas]
ADD FOREIGN KEY([id_Usuario])
REFERENCES [Usuarios]([id_Usuario])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

ALTER TABLE [Menu]
ADD FOREIGN KEY([idSubCategoria])
REFERENCES [SubCategoriaMenu]([idSubCategoria])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

ALTER TABLE [subCategoriaMenu]
ADD FOREIGN KEY([idCategoriaPrincipal])
REFERENCES [Categoria_Menu]([id_Categoria])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

ALTER TABLE [Ordenes]
ADD FOREIGN KEY([id_Menu])
REFERENCES [Menu]([id_Menu_Item])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

ALTER TABLE [Ordenes]
ADD FOREIGN KEY([id_Pedido])
REFERENCES [Pedidos]([id_Pedido])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

ALTER TABLE [Pedidos]
ADD FOREIGN KEY([id_Mesa])
REFERENCES [Mesas]([id_Mesa])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

-- PROCEDIMIENTOS:

CREATE PROCEDURE SP_GETALLMENU
AS
	SELECT id_Menu_Item, Nombre_Menu, Descripcion, Precio, CM.Nombre_Categoria, CM.id_Categoria, SCM.NombreSubCategoria, M.idSubCategoria, M.Estado
	FROM Menu AS M
	INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria
	INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria;
GO

SELECT * FROM SubCategoriaMenu;
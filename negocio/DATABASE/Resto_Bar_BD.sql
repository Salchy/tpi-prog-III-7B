CREATE DATABASE RestoBar
GO
USE RestoBar
GO

CREATE TABLE [Usuarios] (
	[id_Usuario] TINYINT NOT NULL IDENTITY(1, 1),
	[DNI] VARCHAR(10) NOT NULL UNIQUE,
	[Nombre] VARCHAR(30) NOT NULL,
	[Apellido] VARCHAR(30) NOT NULL,
	[Contraseña] CHAR(64) NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Permisos] TINYINT NOT NULL DEFAULT 0,
	PRIMARY KEY([id_Usuario])
);
GO

CREATE TABLE [Categoria_Menu] (
	[id_Categoria] TINYINT NOT NULL IDENTITY(1, 1),
	[Nombre_Categoria] VARCHAR(100) NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Categoria])
);
GO

CREATE TABLE [SubCategoriaMenu] (
	[idSubCategoria] TINYINT NOT NULL IDENTITY(1, 1),
	[NombreSubCategoria] VARCHAR(100) NOT NULL,
	[idCategoriaPrincipal] TINYINT NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([idSubCategoria])
);
GO

CREATE TABLE [Menu] (
	[id_Menu_Item] INT NOT NULL IDENTITY(1, 1),
	[Nombre_Menu] VARCHAR(100) NOT NULL,
	[idSubCategoria] TINYINT NOT NULL,
	[Precio] MONEY NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	[Descripcion] VARCHAR(250),
	[Stock] TINYINT NOT NULL DEFAULT 0,
	PRIMARY KEY([id_Menu_Item])
);
GO

CREATE TABLE [Ordenes] (
	[id_Orden] INTEGER NOT NULL IDENTITY(1, 1),
	[id_Pedido] INTEGER NOT NULL,
	[id_Menu] INT NOT NULL,
	[Cantidad] TINYINT NOT NULL DEFAULT 1,
	[Estado] BIT NOT NULL DEFAULT 1,
	
	PRIMARY KEY([id_Orden], [id_Pedido])
);
GO

CREATE TABLE [Mesas] (
	[id_Mesa] TINYINT NOT NULL IDENTITY(1, 1),
	[numeroMesa] varchar(30) NOT NULL,
	[id_Usuario] TINYINT NOT NULL, -- ID Usuario asignado a la mesa
	[Numero_Comensales] TINYINT NOT NULL DEFAULT 0, -- Clientes usando la mesa
	[Estado] BIT NOT NULL DEFAULT 1, -- Mesa habilitada / Deshabilitada al público
	PRIMARY KEY([id_Mesa])
);
GO

CREATE TABLE [Pedidos] (
	[id_Pedido] INTEGER NOT NULL IDENTITY(1, 1),
	[id_Mesa] TINYINT NOT NULL,
	[Importe] MONEY NOT NULL,
	[Estado] BIT NOT NULL DEFAULT 1,
	PRIMARY KEY([id_Pedido])
);
GO

CREATE INDEX [USUARIOS_index_0]
ON [Usuarios] (DNI);
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

CREATE PROCEDURE SP_GetAllMenu
AS
	SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio, M.Stock ,CM.Nombre_Categoria, CM.id_Categoria, SCM.NombreSubCategoria, M.idSubCategoria, M.Estado
	FROM Menu AS M
	INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria
	INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria
	ORDER BY CM.Nombre_Categoria ASC, SCM.NombreSubCategoria ASC, M.Nombre_Menu ASC;
GO

CREATE PROCEDURE SP_GetMenuItemsFromCategory(
	@idCategoriaPrincipal INT
)
AS
	SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio, C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria, M.Estado
	FROM Menu AS M
	INNER JOIN SubCategoriaMenu AS S ON M.idSubCategoria = S.idSubCategoria
	INNER JOIN Categoria_Menu AS C ON S.idCategoriaPrincipal = C.id_Categoria
	WHERE M.idSubCategoria = @idCategoriaPrincipal
	ORDER BY S.NombreSubCategoria ASC;
GO

CREATE PROCEDURE SP_GetCategories
AS
	SELECT S.idSubCategoria, S.nombreSubCategoria, S.idCategoriaPrincipal, C.Nombre_Categoria, S.Estado
	FROM SubCategoriaMenu AS S
	INNER JOIN Categoria_Menu AS C ON S.idCategoriaPrincipal = C.id_Categoria
	ORDER BY S.NombreSubCategoria ASC;
GO

CREATE PROCEDURE SP_CrearUsuario
	@dni varchar(10),
	@nombre varchar(30),
	@apellido varchar(30),
	@contraseña char(64),
	@permisos int
AS
	INSERT INTO Usuarios (DNI, Nombre, Apellido, Contraseña, Permisos) OUTPUT inserted.id_Usuario VALUES (@dni, @nombre, @apellido, @contraseña, @permisos)
GO

CREATE PROCEDURE SP_ModificarUsuario
	@id tinyint,
	@nombre varchar(30),
	@apellido varchar(30),
	@permisos int
AS
	UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, Permisos = @permisos WHERE id_Usuario = @id;
GO

CREATE PROCEDURE SP_ActivarDesactivarUsuario
	@id int,
	@state bit
AS
	UPDATE Usuarios SET Estado = @state WHERE id_Usuario = @id;
GO

CREATE PROCEDURE SP_SetPassword
	@id int,
	@password char(64)
AS
	UPDATE Usuarios SET Contraseña = @password WHERE id_Usuario = @id;
GO

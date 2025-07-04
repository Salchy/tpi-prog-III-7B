CREATE DATABASE RestoBar
COLLATE Latin1_General_CI_AI;
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
	[Fecha] DATETIME NOT NULL DEFAULT GETdate(),
	[id_Usuario] TINYINT NOT NULL,
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

ALTER TABLE [Pedidos]
ADD FOREIGN KEY([id_Usuario])
REFERENCES [Usuarios]([id_Usuario])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

-- PROCEDIMIENTOS:

CREATE PROCEDURE SP_GetAllMenu
AS
BEGIN
	SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio, M.Stock ,CM.Nombre_Categoria, CM.id_Categoria, SCM.NombreSubCategoria, M.idSubCategoria, M.Estado
	FROM Menu AS M
	INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria
	INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria
	ORDER BY CM.Nombre_Categoria ASC, SCM.NombreSubCategoria ASC, M.Nombre_Menu ASC;
END
GO

CREATE PROCEDURE SP_GetMenuItemsFromCategory(
	@idCategoriaPrincipal INT
)
AS
BEGIN
	SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio,M.Stock, C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria, M.Estado
	FROM Menu AS M
	INNER JOIN SubCategoriaMenu AS S ON M.idSubCategoria = S.idSubCategoria
	INNER JOIN Categoria_Menu AS C ON S.idCategoriaPrincipal = C.id_Categoria
	WHERE M.idSubCategoria = @idCategoriaPrincipal
	ORDER BY S.NombreSubCategoria ASC;
END
GO

CREATE PROCEDURE SP_GetCategories
AS
BEGIN
	SELECT S.idSubCategoria, S.nombreSubCategoria, S.idCategoriaPrincipal, C.Nombre_Categoria, S.Estado
	FROM SubCategoriaMenu AS S
	INNER JOIN Categoria_Menu AS C ON S.idCategoriaPrincipal = C.id_Categoria
	ORDER BY S.NombreSubCategoria ASC;
END
GO

CREATE PROCEDURE SP_CrearUsuario(
	@dni varchar(10),
	@nombre varchar(30),
	@apellido varchar(30),
	@contraseña char(64),
	@permisos int
)
AS
BEGIN
	INSERT INTO Usuarios (DNI, Nombre, Apellido, Contraseña, Permisos) OUTPUT inserted.id_Usuario VALUES (@dni, @nombre, @apellido, @contraseña, @permisos)
END
GO

CREATE PROCEDURE SP_ModificarUsuario
	@id tinyint,
	@nombre varchar(30),
	@apellido varchar(30),
	@permisos int
AS
BEGIN
	UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, Permisos = @permisos WHERE id_Usuario = @id;
END
GO

CREATE PROCEDURE SP_ActivarDesactivarUsuario(
	@id int,
	@state biT
)
AS
BEGIN
	UPDATE Usuarios SET Estado = @state WHERE id_Usuario = @id;
END
GO

CREATE PROCEDURE SP_SetPassword(
	@id int,
	@password char(64)
)
AS
BEGIN
	UPDATE Usuarios SET Contraseña = @password WHERE id_Usuario = @id;
END
GO

CREATE PROCEDURE SP_ActivarDesactivarMesa(
	@idMesa tinyint,
	@state bit
)
AS
BEGIN
	UPDATE Mesas SET Estado = @state WHERE id_Mesa = @idMesa;
END
GO

CREATE PROCEDURE SP_CrearMesa(
	@nombreMesa varchar(30),
	@idMeseroAsignado tinyint
)
AS
BEGIN
	INSERT INTO Mesas (numeroMesa, id_Usuario) VALUES (@nombreMesa, @idMeseroAsignado);
END
GO

-- TRIGGER:;

CREATE TRIGGER trg_AGREGAR_ORDEN ON Ordenes
INSTEAD OF INSERT
AS 
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @idMenu int;
			Declare @idPedido int;
			Declare @stockactual TINYINT;
			Declare @catidadnueva TINYINT;
			Declare @catidadprevia TINYINT;

			set @idMenu =(SELECT id_Menu FROM inserted);
			set @idPedido =(SELECT id_Pedido FROM inserted);
			set @stockactual =(SELECT  Stock FROM Menu where id_Menu_Item=@idMenu);
			set @catidadnueva=(SELECT Cantidad FROM inserted);
			set @catidadprevia=0;

			IF (@stockactual<@catidadnueva )
			BEGIN 
				RAISERROR ('STOCK INSUFICIENTE PARA TOMAR ORDEN', 16, 1);
				RETURN; 
			END

			IF EXISTS (SELECT * FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu)
				BEGIN 
					set @catidadprevia=(SELECT Cantidad FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu );
					UPDATE Ordenes SET Cantidad = (@catidadprevia + @catidadnueva) WHERE id_Orden= (SELECT id_Orden FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu);
				END
			ELSE
			BEGIN 
				INSERT INTO Ordenes (id_Menu,Cantidad,id_Pedido) VALUES (@idMenu,@catidadnueva,@idPedido);
			END
  
			UPDATE Menu  SET Stock= (@stockactual - @catidadnueva) WHERE id_Menu_Item=@idMenu;
		COMMIT TRANSACTION;
	END TRY 
	BEGIN CATCH 
		PRINT ERROR_MESSAGE() 
		ROLLBACK TRANSACTION;
	END CATCH 
END
Go

CREATE TRIGGER trg_MODIFICAR_ORDEN ON Ordenes
INSTEAD OF Update
AS 
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @idOrden int;
			Declare @idMenu int;
			Declare @idPedido int;
			Declare @stockactual TINYINT;
			Declare @catidadnueva TINYINT;
			Declare @catidadprevia TINYINT;
			Declare @diferencia TINYINT;

			set @idMenu =(SELECT id_Menu FROM inserted);
			set @idPedido =(SELECT id_Pedido FROM inserted);
			
			set @catidadnueva=(SELECT Cantidad FROM inserted);
			set @catidadprevia=(SELECT Cantidad FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu );
			set @idOrden =(SELECT id_Orden FROM inserted);
			
			IF (@catidadnueva<>@catidadprevia)
			  BEGIN
			    IF (@catidadprevia>@catidadnueva )
			      BEGIN 
				    SET @diferencia =(@catidadprevia-@catidadnueva);
				    set @stockactual =(SELECT  Stock FROM Menu where id_Menu_Item=@idMenu)+ @diferencia ;
				    UPDATE Menu  SET Stock= (@stockactual) WHERE id_Menu_Item=@idMenu;
			     END
		        ELSE
			      BEGIN 
				    SET @diferencia =(@catidadnueva-@catidadprevia);
				    set @stockactual =(SELECT  Stock FROM Menu where id_Menu_Item=@idMenu);
				    IF (@stockactual<@diferencia)
			          BEGIN 
				        RAISERROR ('STOCK INSUFICIENTE PARA MODIFICAR ORDEN', 16, 1);
				        RETURN; 
			          END
				    ELSE
			          BEGIN 
				        UPDATE Menu  SET Stock= (@stockactual-@diferencia) WHERE id_Menu_Item=@idMenu;
				      END
			      END
			  UPDATE Ordenes SET Cantidad = (@catidadnueva) WHERE id_Orden=@idOrden;
			END
	       ELSE
			BEGIN 
				 UPDATE Ordenes SET Estado = (SELECT Estado FROM inserted) WHERE id_Orden=@idOrden;
			END
		COMMIT TRANSACTION;
	END TRY 
	BEGIN CATCH 
		PRINT ERROR_MESSAGE() 
		ROLLBACK TRANSACTION;
	END CATCH 
END
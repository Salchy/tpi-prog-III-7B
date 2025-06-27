CREATE TRIGGER trg_AGREGAR_ORDEN ON Ordenes
INSTEAD OF INSERT
AS 
BEGIN 
BEGIN TRY 
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
	      ROLLBACK TRANSACTION; 
		  RAISERROR ('STOCK INSUFICIENTE PARA TOMAR ORDEN', 16, 1);
		  RETURN; 
	   END

  IF EXISTS (SELECT * FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu)
   BEGIN 
     set @catidadprevia=(SELECT Cantidad FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu );
	 UPDATE Ordenes SET Cantidad = (@catidadprevia + @catidadnueva) WHERE id_Orden= (SELECT id_Orden FROM Ordenes WHERE id_Pedido=@idPedido and id_Menu=@idMenu);
   END
  Else
   BEGIN 
     	 INSERT INTO Ordenes (id_Menu,Cantidad,id_Pedido) VALUES (@idMenu,@catidadnueva,@idPedido);
   END
  
  UPDATE Menu  SET Stock= (@stockactual - @catidadnueva) WHERE id_Menu_Item=@idMenu;
 END TRY 
 BEGIN CATCH 
  PRINT ERROR_MESSAGE() 
 END CATCH 
END
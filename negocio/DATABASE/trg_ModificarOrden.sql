-- USE RestoBar;

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
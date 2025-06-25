-- Insert de datos
USE RestoBar;

-- Crear usuario adminsitrador (Gen�rico, para Empleados de Sistemas)
EXEC SP_CrearUsuario 'Admin', 'Admin', 'Admin', '3EB3FE66B31E3B4D10FA70B5CAD49C7112294AF6AE4E476A1C405155D45AA121', 0;

EXEC SP_CrearUsuario '123456', 'Gerencia', 'Gerente', '68E059127789EA920AD39F186B60EAA3ACFEF029A4C8808D2D271E500C992D4A', 1;
-- Crear usuario Mesero
EXEC SP_CrearUsuario '654321', 'Empleado', 'Mesero', 'EF9BD64654BB3D8826C9892CFCC3B01FA73774247DBFB1E7AA09A6271E76D80D',�2;

-- Por defecto, se asignan las mesas al user Admin
INSERT INTO Mesas (numeroMesa, id_Usuario) VALUES
	('Mesa 01', 1),
	('Mesa 02', 1),
	('Mesa 03', 1),
	('Mesa 04', 1),
	('Mesa 05', 1),
	('Mesa 06', 1),
	('Mesa 07', 1),
	('Mesa 08', 1),
	('Mesa 09', 1),
	('Mesa 10', 1);
GO

-- Insert de Categor�as
INSERT INTO Categoria_Menu (Nombre_Categoria) VALUES 
	('Entradas'),
	('Ensaladas'),
	('Platos principales'),
	('Men� infantil'),
	('Pastas caseras'),
	('Pescados y mariscos'),
	('Woks'),
	('Risottos'),
	('Pizzas'),
	('Postres'),
	('Bebidas sin alcohol'),
	('Bebidas con alcohol'),
	('Cafeter�a');
GO
--SELECT * FROM Categoria_Menu

-- Insert de SubCategor�as
INSERT INTO SubCategoriaMenu(NombreSubCategoria, idCategoriaPrincipal) VALUES 
	-- Categor�a 1: Entradas
	('Picadas', 1),
	('Empanadas', 1),
	('Sopas', 1),

	-- Categor�a 2: Ensaladas
	('Verdes', 2),
	('Con prote�nas', 2),

	-- Categor�a 3: Platos principales
	('Carnes', 3),
	('Pastas', 3),
	('Pescados', 3),

	-- Categor�a 4: Men� infantil
	('Platos', 4),
	('Postres', 4),

	-- Categor�a 5: Pastas caseras
	('Rellenas', 5),
	('Sin relleno', 5),

	-- Categor�a 6: Pescados y mariscos
	('Grillados', 6),
	('Fritos', 6),
	('Guisos', 6),

	-- Categor�a 7: Woks
	('Vegetarianos', 7),
	('Con Pollo', 7),
	('Con Camarones', 7),

	-- Categor�a 8: Risottos
	('Cl�sicos', 8),
	('De mar', 8),

	-- Categor�a 9: Pizzas
	('Cl�sicas', 9),
	('Especiales', 9),

	-- Categor�a 10: Postres
	('Tortas', 10),
	('Helados', 10),
	('Otros', 10),

	-- Categor�a 11: Bebidas sin alcohol
	('Aguas', 11),
	('Gaseosas', 11),
	('Jugos', 11),

	-- Categor�a 12: Bebidas con alcohol
	('Cervezas', 12),
	('Vinos', 12),
	('Tragos', 12),

	-- Categor�a 13: Cafeter�a
	('Caf�s', 13),
	('T�s', 13),
	('Especiales', 13);
GO
--SELECT * FROM SubCategoriaMenu;

--SELECT Nombre_Categoria, NombreSubCategoria FROM SubCategoriaMenu AS SCM
--INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria;

-- Insert de ItemsMenu:
INSERT INTO Menu(Nombre_Menu, idSubCategoria, Descripcion, Precio, Stock) VALUES
	-- Categor�a 1: Entradas
		-- Subcategor�a 1: Entradas
		('Picada Cl�sica', 1, 'Variedad de fiambres, quesos y pan', 5500.00, 12),
		('Picada Vegetariana', 1, 'Quesos, aceitunas, hummus y vegetales', 5200.00, 12),
		('Picada de Mar', 1, 'Mariscos, rabas y salsas para compartir', 6000.00, 12),

		-- Subcategor�a 2: Empanadas
		('Empanada de Carne', 2, 'Carne cortada a cuchillo, cebolla y especias', 800.00, 48),
		('Empanada de Pollo', 2, 'Pollo desmenuzado con cebolla y morr�n', 750.00, 96),
		('Empanada de Queso', 2, 'Queso cremoso con cebolla salteada', 700.00, 24),

		-- Subcategor�a 3: Sopas
		('Sopa de Calabaza', 3, 'Cremosa sopa de calabaza con croutons', 1200.00, 0),
		('Sopa de Cebolla', 3, 'Tradicional sopa francesa gratinada', 1300.00, 0),
		('Sopa de Verduras', 3, 'Variedad de vegetales en caldo suave', 1100.00, 0),

	-- Categor�a 2: Ensaladas
		-- Subcategor�a 4: Verdes
		('Ensalada Mixta', 4, 'Lechuga, tomate y cebolla', 1500.00, 5),
		('Ensalada C�sar', 4, 'Lechuga, croutons, queso y aderezo C�sar', 2200.00, 8),
		('Ensalada Primavera', 4, 'Mix de hojas verdes con zanahoria rallada', 1800.00, 4),
		('Ensalada Mediterr�nea', 4, 'Tomate cherry, aceitunas y r�cula', 2000.00, 8),

		-- Subcategor�a 5: Con prote�nas
		('Ensalada con Pollo', 5, 'Lechuga, pollo grillado y huevo', 2400.00, 5),
		('Ensalada con At�n', 5, 'Hojas verdes, at�n y choclo', 2300.00, 7),
		('Ensalada con Huevo', 5, 'Lechuga, huevo duro y tomate', 1900.00, 12),
		('Ensalada con Lentejas', 5, 'Lentejas, cebolla morada y zanahoria', 2100.00, 6),

	-- Categor�a 3: Platos principales
		-- Subcategor�a 6: Carnes
		('Bife de Chorizo', 6, 'Bife de chorizo con papas r�sticas', 4500.00, 15),
		('Milanesa con Papas', 6, 'Milanesa de carne con papas fritas', 4000.00, 10),
		('Lomo a la Pimienta', 6, 'Lomo con salsa a la pimienta y pur�', 4700.00, 12),
		('Asado con Ensalada', 6, 'Tira de asado con ensalada mixta', 4600.00, 18),
		('Pollo a la Parrilla', 6, 'Pechuga grillada con guarnici�n', 3900.00, 6),

		-- Subcategor�a 7: Pastas
		('Fideos con Tuco', 7, 'Fideos caseros con salsa de tomate', 3000.00, 12),
		('�oquis con Salsa', 7, '�oquis de papa con salsa a elecci�n', 3200.00, 15),
		('Ravioles de Ricota', 7, 'Rellenos de ricota y nuez con crema', 3300.00, 8),
		('Spaghetti Bolognesa', 7, 'Spaghetti con salsa de carne', 3400.00, 4),
		('Fusilli al Pesto', 7, 'Fusilli con salsa de albahaca y nueces', 3100.00, 9),

		-- Subcategor�a 8: Pescados
		('Merluza al Horno', 8, 'Filet de merluza con papas al vapor', 4200.00, 5),
		('Salm�n con Guarnici�n', 8, 'Salm�n grillado con vegetales', 5500.00, 0),
		('Lenguado al Lim�n', 8, 'Lenguado con salsa de lim�n', 5000.00, 2),
		('Trucha a las Finas Hierbas', 8, 'Trucha con manteca y hierbas', 5300.00, 3),

	-- Categor�a 4: Men� infantil
		-- Subcategor�a 9: Platos
		('Nuggets con Papas', 9, 'Nuggets de pollo con papas fritas', 2500.00, 12),
		('Hamburguesa Kids', 9, 'Mini hamburguesa con queso y papas', 2700.00, 3),
		('Mini Pizza', 9, 'Pizza individual con muzzarella', 2300.00, 16),
		('Tallarines con Salsa', 9, 'Tallarines con salsa suave de tomate', 2400.00, 9),
		('Salchichas con Pur�', 9, 'Salchichas con pur� de papa cremoso', 2200.00, 0),

		-- Subcategor�a 10: Postres
		('Helado Simple', 10, '1 bocha de helado a elecci�n', 1000.00, 11),
		('Flan con Dulce', 10, 'Flan casero con dulce de leche', 1200.00, 7),
		('Gelatina con Crema', 10, 'Gelatina sabor frutilla con crema', 1000.00, 2),
		('Banana con Dulce', 10, 'Banana cortada con dulce de leche', 1100.00, 15),

	-- Categor�a 5: Pastas caseras
		-- Subcategor�a 11: Rellenas
		('Sorrentinos Jam�n y Queso', 11, 'Sorrentinos caseros con salsa mixta', 3500.00, 6),
		('Ravioles de Verdura', 11, 'Ravioles rellenos de espinaca y ricota', 3300.00, 14),
		('Capeletis de Pollo', 11, 'Capeletis con salsa blanca', 3400.00, 1),
		('Agnolotis de Calabaza', 11, 'Agnolotis con crema de queso', 3600.00, 8),

		-- Subcategor�a 12: Sin relleno
		('Fetuccini al Pesto', 12, 'Fetuccini con salsa de albahaca', 3200.00, 10),
		('Spaghetti a la Bolognesa', 12, 'Spaghetti con salsa de carne', 3400.00, 4),
		('Tallarines a la Manteca', 12, 'Tallarines frescos con manteca y queso', 3100.00, 12),
		('Mostacholes con Tuco', 12, 'Mostacholes con salsa roja tradicional', 3000.00, 0),
		('Cintas a la Carbonara', 12, 'Cintas con panceta, huevo y crema', 3500.00, 9),

	-- Categor�a 6: Pescados y mariscos
		-- Subcategor�a 13: Grillados
		('Salm�n a la Parrilla', 13, 'Salm�n fresco grillado con hierbas', 5600.00, 15),
		('At�n Sellado', 13, 'At�n a la plancha con salsa c�trica', 5300.00, 5),
		('Trucha a las Finas Hierbas', 13, 'Trucha con manteca y especias', 5300.00, 2),
		('Merluza a la Parrilla', 13, 'Filete de merluza grillado con lim�n', 4200.00, 11),
		('Langostinos Grillados', 13, 'Langostinos a la parrilla con ajo', 5800.00, 7),

		-- Subcategor�a 14: Fritos
		('Rabas', 14, 'Calamares fritos crocantes', 4000.00, 13),
		('Cornalitos', 14, 'Pescaditos fritos peque�os', 3700.00, 7),
		('Pescado Rebozado', 14, 'Filete de merluza rebozado y frito', 3900.00, 3),
		('Calamares a la Romana', 14, 'Aros de calamar fritos', 4200.00, 9),

		-- Subcategor�a 15: Guisos
		('Cazuela de Mariscos', 15, 'Variedad de mariscos en caldo especiado', 5800.00, 11),
		('Paella', 15, 'Arroz con mariscos y azafr�n', 6000.00, 2),
		('Guiso de Pescado', 15, 'Pescado cocido con vegetales y especias', 5500.00, 8),
		('Mariscos al Curry', 15, 'Mariscos cocidos en salsa curry suave', 5900.00, 0),

	-- Categor�a 7: Woks
		-- Subcategor�a 16: Vegetarianos
		('Wok de Verduras', 16, 'Salteado de vegetales frescos con salsa de soja', 3100.00, 14),
		('Wok con Tofu', 16, 'Tofu marinado con vegetales y jengibre', 3300.00, 4),
		('Wok Thai Vegetariano', 16, 'Vegetales con leche de coco y curry suave', 3400.00, 12),
		('Wok de Brotes y Setas', 16, 'Brotes de soja y setas salteados', 3200.00, 17),

		-- Subcategor�a 17: Con Pollo
		('Wok de Pollo y Vegetales', 17, 'Tiras de pollo con vegetales salteados', 3600.00, 10),
		('Wok Picante de Pollo', 17, 'Pollo con salsa picante y verduras', 3700.00, 5),
		('Wok de Pollo Teriyaki', 17, 'Pollo con salsa teriyaki y arroz', 3800.00, 1),
		('Wok con Pollo y Anan�', 17, 'Pollo salteado con pi�a y verduras', 3650.00, 16),

		-- Subcategor�a 18: Con Camarones
		('Wok de Camarones', 18, 'Camarones salteados con vegetales y soja', 4200.00, 15),
		('Wok de Camarones Picante', 18, 'Camarones con salsa picante y arroz', 4300.00, 6),
		('Wok de Camarones al Curry', 18, 'Camarones con salsa curry y leche de coco', 4400.00, 3),
		('Wok de Camarones y Verduras', 18, 'Camarones con mezcla de vegetales frescos', 4250.00, 9),

	-- Categor�a 8: Risottos
		-- Subcategor�a 19: Cl�sicos
		('Risotto de Calabaza', 19, 'Risotto cremoso con calabaza asada', 3800.00, 7),
		('Risotto de Hongos', 19, 'Risotto con mezcla de hongos y queso parmesano', 3900.00, 1),
		('Risotto de Verduras', 19, 'Risotto con verduras frescas y hierbas', 3700.00, 13),
		('Risotto de Queso Azul', 19, 'Risotto con queso azul y nueces', 4000.00, 11),

		-- Subcategor�a 20: De mar
		('Risotto de Mariscos', 20, 'Arroz cremoso con mariscos frescos', 5200.00, 2),
		('Risotto de Camarones', 20, 'Risotto con camarones y salsa de crema', 5100.00, 9),
		('Risotto de Langostinos', 20, 'Risotto con langostinos y azafr�n', 5300.00, 15),

	-- Categor�a 9: Pizzas
		-- Subcategor�a 21: Cl�sicas
		('Muzzarella', 21, 'Pizza con salsa de tomate y muzzarella', 2800.00, 4),
		('Napolitana', 21, 'Pizza con tomate, muzzarella y ajo', 2900.00, 0),
		('Jam�n y Morrones', 21, 'Pizza con jam�n y pimientos', 3200.00, 14),
		('Fugazzeta', 21, 'Pizza con cebolla y muzzarella', 3000.00, 3),
		('Calabresa', 21, 'Pizza con salame y salsa picante', 3300.00, 8),

		-- Subcategor�a 22: Especiales
		('Pizza Cuatro Quesos', 22, 'Mozzarella, roquefort, parmesano y fontina', 3600.00, 16),
		('Pizza de Provolone', 22, 'Provolone fundido con or�gano', 3500.00, 6),
		('Pizza Vegetariana', 22, 'Verduras asadas y muzzarella', 3400.00, 10),
		('Pizza de Pollo BBQ', 22, 'Pollo con salsa barbacoa y cebolla', 3700.00, 12),
		('Pizza Caprese', 22, 'Tomate, mozzarella y albahaca fresca', 3550.00, 5),

	-- Categor�a 10: Postres
		-- Subcategor�a 23: Tortas
		('Torta Selva Negra', 23, 'Bizcochuelo con crema y chocolate', 2200.00, 17),
		('Torta de Ricota', 23, 'Torta casera con relleno de ricota', 2100.00, 4),
		('Torta de Manzana', 23, 'Torta con manzana y canela', 2000.00, 13),
		('Torta de Chocolate', 23, 'Torta h�meda de chocolate', 2300.00, 9),
		('Torta de Zanahoria', 23, 'Torta con zanahoria y nueces', 2150.00, 7),

		-- Subcategor�a 24: Helados
		('Helado Vainilla', 24, 'Helado cremoso de vainilla', 900.00, 1),
		('Helado Chocolate', 24, 'Helado intenso de chocolate', 900.00, 14),
		('Helado Dulce de Leche', 24, 'Helado sabor dulce de leche', 950.00, 11),
		('Helado Frutilla', 24, 'Helado sabor frutilla natural', 900.00, 0),
		('Helado Lim�n', 24, 'Helado refrescante de lim�n', 900.00, 6),

		-- Subcategor�a 25: Otros
		('Panqueques con Dulce', 25, 'Panqueques rellenos con dulce de leche', 1100.00, 6),
		('Brownie con Helado', 25, 'Brownie de chocolate con helado vainilla', 1300.00, 12),
		('Mousse de Chocolate', 25, 'Mousse suave y cremoso de chocolate', 1200.00, 1),
		('Frutas Frescas', 25, 'Ensalada de frutas de estaci�n', 1000.00, 9),

	-- Categor�a 11: Bebidas sin alcohol
		-- Subcategor�a 26: Aguas
		('Agua Mineral', 26, 'Agua sin gas botella 500ml', 600.00, 7),
		('Agua con Gas', 26, 'Agua mineral con gas botella 500ml', 650.00, 2),
		('Agua Saborizada', 26, 'Agua con sabor a lim�n o durazno', 700.00, 13),

		-- Subcategor�a 27: Gaseosas
		('Coca-Cola', 27, 'Gaseosa cl�sica 500ml', 800.00, 9),
		('Sprite', 27, 'Gaseosa lim�n 500ml', 800.00, 0),
		('Fanta', 27, 'Gaseosa naranja 500ml', 800.00, 15),
		('Pepsi', 27, 'Gaseosa cola 500ml', 800.00, 6),
		('Seven Up', 27, 'Gaseosa lim�n 500ml', 800.00, 4),

		-- Subcategor�a 28: Jugos
		('Jugo de Naranja', 28, 'Jugo natural exprimido', 900.00, 11),
		('Jugo de Manzana', 28, 'Jugo natural de manzana', 900.00, 5),
		('Jugo de Durazno', 28, 'Jugo natural de durazno', 900.00, 1),
		('Jugo de Pomelo', 28, 'Jugo natural de pomelo', 900.00, 8),

	-- Categor�a 12: Bebidas con alcohol
		-- Subcategor�a 29: Cervezas
		('Cerveza Rubia', 29, 'Cerveza rubia nacional 500ml', 1200.00, 3),
		('Cerveza Negra', 29, 'Cerveza negra artesanal', 1400.00, 17),
		('Cerveza Roja', 29, 'Cerveza roja con sabor a malta', 1300.00, 10),
		('Cerveza IPA', 29, 'Cerveza IPA con notas c�tricas', 1500.00, 14),

		-- Subcategor�a 30: Vinos
		('Vino Tinto Malbec', 30, 'Vino malbec argentino 750ml', 3200.00, 16),
		('Vino Blanco Chardonnay', 30, 'Vino chardonnay fresco y frutal', 3100.00, 12),
		('Vino Rosado', 30, 'Vino rosado suave y afrutado', 3000.00, 4),
		('Vino Espumante', 30, 'Vino espumante dulce', 3500.00, 7),

		-- Subcategor�a 31: Tragos
		('Fernet con Coca', 31, 'Cl�sico trago argentino con cola', 1800.00, 2),
		('Caipirinha', 31, 'Cacha�a, lima y az�car sobre hielo', 2000.00, 9),
		('Mojito', 31, 'Ron, menta, lima, az�car y soda', 2100.00, 0),
		('Cuba Libre', 31, 'Ron con cola y lim�n', 1900.00, 6),
		('Gin Tonic', 31, 'Gin con t�nica y rodajas de pepino o lim�n', 2200.00, 13),
		('Campari con Naranja', 31, 'Bitter Campari con jugo de naranja natural', 2000.00, 1),

	-- Categor�a 31: Cafeter�a
		-- Subcategor�a 32: Caf�s
		('Caf� Solo', 32, 'Caf� negro servido en taza peque�a', 800.00, 8),
		('Caf� con Leche', 32, 'Caf� con leche caliente espumosa', 1000.00, 5),
		('Caf� Cortado', 32, 'Caf� negro con un toque de leche', 850.00, 14),
		('Caf� Doble', 32, 'Doble carga de caf� para m�s intensidad', 900.00, 11),

		-- Subcategor�a 33: T�s
		('T� Negro', 33, 'Infusi�n cl�sica con saquito', 700.00, 3),
		('T� Verde', 33, 'T� con propiedades antioxidantes', 750.00, 10),
		('T� de Hierbas', 33, 'Mezcla de hierbas naturales', 700.00, 12),
		('T� Frutado', 33, 'Infusi�n con sabor a frutos rojos', 750.00, 15),

		-- Subcategor�a 34: Especiales
		('Capuccino', 34, 'Caf� con leche espumosa y cacao', 1200.00, 17),
		('Submarino', 34, 'Leche caliente con barra de chocolate', 1300.00, 16),
		('Mocaccino', 34, 'Caf�, leche, chocolate y espuma', 1250.00, 7),
		('Latte Vainilla', 34, 'Caf� con leche saborizado con vainilla', 1300.00, 1),
		('Caf� Helado', 34, 'Caf� fr�o con crema y hielo', 1350.00, 13);
GO
-- UPDATE Menu SET Descripcion = 'Hongos, cherry, cebolla morada, zucchini, zanahoria, morr�n bicolor.' WHERE id_Menu_Item = 6;

-- SELECT * FROM SubCategoriaMenu WHERE NombreSubCategoria LIKE '%aperitivos%';

-- UPDATE SubCategoriaMenu SET NombreSubCategoria = 'Alta Cocina.' WHERE id_Menu_Item = 6;

--SELECT * FROM Menu;

-- Consulta para obtener el men�, con sus categor�as
--SELECT Nombre_Menu, SCM.NombreSubCategoria, CM.Nombre_Categoria FROM Menu AS M
--INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria
--INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria;
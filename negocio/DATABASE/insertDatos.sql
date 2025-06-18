-- Insert de datos
USE RestoBar;

-- Crear usuario adminsitrador (Genérico, para Empleados de Sistemas)
EXEC SP_CrearUsuario 'Admin', 'Admin', 'Admin', '3EB3FE66B31E3B4D10FA70B5CAD49C7112294AF6AE4E476A1C405155D45AA121', 0;

-- Crear usuario Gerente
EXEC SP_CrearUsuario '123456', 'Gerencia', 'Gerente', '95980CC32FCB13BFAEDF96D13F5E850AE93583994CE68264AC73C2084D5E0069', 1;

-- Crear usuario Mesero
EXEC SP_CrearUsuario '654321', 'Empleado', 'Mesero', '55DCEC5B6DE9023E541D5E308FC8BA2D3C7FF50D23F2E9FD6E99A92EE7DD272C', 2;

-- Insert de Categorías
INSERT INTO Categoria_Menu (Nombre_Categoria) VALUES 
	('Entradas'),
	('Ensaladas'),
	('Platos principales'),
	('Menú infantil'),
	('Pastas caseras'),
	('Pescados y mariscos'),
	('Woks'),
	('Risottos'),
	('Pizzas'),
	('Postres'),
	('Bebidas sin alcohol'),
	('Bebidas con alcohol'),
	('Cafetería');

SELECT * FROM Categoria_Menu

-- Insert de SubCategorías
INSERT INTO SubCategoriaMenu(NombreSubCategoria, idCategoriaPrincipal) VALUES 
	-- Categoría 1: Entradas
	('Picadas', 1),
	('Empanadas', 1),
	('Sopas', 1),

	-- Categoría 2: Ensaladas
	('Verdes', 2),
	('Con proteínas', 2),

	-- Categoría 3: Platos principales
	('Carnes', 3),
	('Pastas', 3),
	('Pescados', 3),

	-- Categoría 4: Menú infantil
	('Platos', 4),
	('Postres', 4),

	-- Categoría 5: Pastas caseras
	('Rellenas', 5),
	('Sin relleno', 5),

	-- Categoría 6: Pescados y mariscos
	('Grillados', 6),
	('Fritos', 6),
	('Guisos', 6),

	-- Categoría 7: Woks
	('Vegetarianos', 7),
	('Con Pollo', 7),
	('Con Camarones', 7),

	-- Categoría 8: Risottos
	('Clásicos', 8),
	('De mar', 8),

	-- Categoría 9: Pizzas
	('Clásicas', 9),
	('Especiales', 9),

	-- Categoría 10: Postres
	('Tortas', 10),
	('Helados', 10),
	('Otros', 10),

	-- Categoría 11: Bebidas sin alcohol
	('Aguas', 11),
	('Gaseosas', 11),
	('Jugos', 11),

	-- Categoría 12: Bebidas con alcohol
	('Cervezas', 12),
	('Vinos', 12),
	('Tragos', 12),

	-- Categoría 13: Cafetería
	('Cafés', 13),
	('Tés', 13),
	('Especiales', 13);

SELECT * FROM SubCategoriaMenu;

SELECT Nombre_Categoria, NombreSubCategoria FROM SubCategoriaMenu AS SCM
INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria;

-- Insert de ItemsMenu:
INSERT INTO Menu(Nombre_Menu, idSubCategoria, Descripcion, Precio) VALUES
	-- Subcategoría 1: Entradas
	('Picada Clásica', 1, 'Variedad de fiambres, quesos y pan', 5500.00),
	('Picada Vegetariana', 1, 'Quesos, aceitunas, hummus y vegetales', 5200.00),
	('Picada de Mar', 1, 'Mariscos, rabas y salsas para compartir', 6000.00),

	-- Subcategoría 2: Ensaladas
	('Empanada de Carne', 2, 'Carne cortada a cuchillo, cebolla y especias', 800.00),
	('Empanada de Pollo', 2, 'Pollo desmenuzado con cebolla y morrón', 750.00),
	('Empanada de Queso', 2, 'Queso cremoso con cebolla salteada', 700.00),

	-- Subcategoría 3: Platos principales
	('Sopa de Calabaza', 3, 'Cremosa sopa de calabaza con croutons', 1200.00),
	('Sopa de Cebolla', 3, 'Tradicional sopa francesa gratinada', 1300.00),
	('Sopa de Verduras', 3, 'Variedad de vegetales en caldo suave', 1100.00),

	-- Subcategoría 4: Verdes
	('Ensalada Mixta', 4, 'Lechuga, tomate y cebolla', 1500.00),
	('Ensalada César', 4, 'Lechuga, croutons, queso y aderezo César', 2200.00),
	('Ensalada Primavera', 4, 'Mix de hojas verdes con zanahoria rallada', 1800.00),
	('Ensalada Mediterránea', 4, 'Tomate cherry, aceitunas y rúcula', 2000.00),

	-- Subcategoría 5: Con proteínas
	('Ensalada con Pollo', 5, 'Lechuga, pollo grillado y huevo', 2400.00),
	('Ensalada con Atún', 5, 'Hojas verdes, atún y choclo', 2300.00),
	('Ensalada con Huevo', 5, 'Lechuga, huevo duro y tomate', 1900.00),
	('Ensalada con Lentejas', 5, 'Lentejas, cebolla morada y zanahoria', 2100.00),

	-- Subcategoría 6: Carnes
	('Bife de Chorizo', 6, 'Bife de chorizo con papas rústicas', 4500.00),
	('Milanesa con Papas', 6, 'Milanesa de carne con papas fritas', 4000.00),
	('Lomo a la Pimienta', 6, 'Lomo con salsa a la pimienta y puré', 4700.00),
	('Asado con Ensalada', 6, 'Tira de asado con ensalada mixta', 4600.00),
	('Pollo a la Parrilla', 6, 'Pechuga grillada con guarnición', 3900.00),

	-- Subcategoría 7: Pastas
	('Fideos con Tuco', 7, 'Fideos caseros con salsa de tomate', 3000.00),
	('Ñoquis con Salsa', 7, 'Ñoquis de papa con salsa a elección', 3200.00),
	('Ravioles de Ricota', 7, 'Rellenos de ricota y nuez con crema', 3300.00),
	('Spaghetti Bolognesa', 7, 'Spaghetti con salsa de carne', 3400.00),
	('Fusilli al Pesto', 7, 'Fusilli con salsa de albahaca y nueces', 3100.00),

	-- Subcategoría 8: Pescados
	('Merluza al Horno', 8, 'Filet de merluza con papas al vapor', 4200.00),
	('Salmón con Guarnición', 8, 'Salmón grillado con vegetales', 5500.00),
	('Lenguado al Limón', 8, 'Lenguado con salsa de limón', 5000.00),
	('Trucha a las Finas Hierbas', 8, 'Trucha con manteca y hierbas', 5300.00),

	-- Subcategoría 9: Platos (Menú infantil)
	('Nuggets con Papas', 9, 'Nuggets de pollo con papas fritas', 2500.00),
	('Hamburguesa Kids', 9, 'Mini hamburguesa con queso y papas', 2700.00),
	('Mini Pizza', 9, 'Pizza individual con muzzarella', 2300.00),
	('Tallarines con Salsa', 9, 'Tallarines con salsa suave de tomate', 2400.00),
	('Salchichas con Puré', 9, 'Salchichas con puré de papa cremoso', 2200.00),

	-- Subcategoría 10: Postres (Menú infantil)
	('Helado Simple', 10, '1 bocha de helado a elección', 1000.00),
	('Flan con Dulce', 10, 'Flan casero con dulce de leche', 1200.00),
	('Gelatina con Crema', 10, 'Gelatina sabor frutilla con crema', 1000.00),
	('Banana con Dulce', 10, 'Banana cortada con dulce de leche', 1100.00),

	-- Subcategoría 11: Rellenas (Pastas caseras)
	('Sorrentinos Jamón y Queso', 11, 'Sorrentinos caseros con salsa mixta', 3500.00),
	('Ravioles de Verdura', 11, 'Ravioles rellenos de espinaca y ricota', 3300.00),
	('Capeletis de Pollo', 11, 'Capeletis con salsa blanca', 3400.00),
	('Agnolotis de Calabaza', 11, 'Agnolotis con crema de queso', 3600.00),

	-- Subcategoría 12: Sin relleno (Pastas caseras)
	('Fetuccini al Pesto', 12, 'Fetuccini con salsa de albahaca', 3200.00),
	('Spaghetti a la Bolognesa', 12, 'Spaghetti con salsa de carne', 3400.00),
	('Tallarines a la Manteca', 12, 'Tallarines frescos con manteca y queso', 3100.00),
	('Mostacholes con Tuco', 12, 'Mostacholes con salsa roja tradicional', 3000.00),
	('Cintas a la Carbonara', 12, 'Cintas con panceta, huevo y crema', 3500.00),

	-- Subcategoría 13: 
	('Salmón a la Parrilla', 13, 'Salmón fresco grillado con hierbas', 5600.00),
	('Atún Sellado', 13, 'Atún a la plancha con salsa cítrica', 5300.00),
	('Trucha a las Finas Hierbas', 13, 'Trucha con manteca y especias', 5300.00),
	('Merluza a la Parrilla', 13, 'Filete de merluza grillado con limón', 4200.00),
	('Langostinos Grillados', 13, 'Langostinos a la parrilla con ajo', 5800.00),

	-- Categoría 6: Pescados y mariscos
	-- Subcategoría 13: Grillados
	('Salmón a la Parrilla', 13, 'Salmón fresco grillado con hierbas', 5600.00),
	('Atún Sellado', 13, 'Atún a la plancha con salsa cítrica', 5300.00),
	('Trucha a las Finas Hierbas', 13, 'Trucha con manteca y especias', 5300.00),
	('Merluza a la Parrilla', 13, 'Filete de merluza grillado con limón', 4200.00),
	('Langostinos Grillados', 13, 'Langostinos a la parrilla con ajo', 5800.00),

	-- Subcategoría 14: Fritos
	('Rabas', 14, 'Calamares fritos crocantes', 4000.00),
	('Cornalitos', 14, 'Pescaditos fritos pequeños', 3700.00),
	('Pescado Rebozado', 14, 'Filete de merluza rebozado y frito', 3900.00),
	('Calamares a la Romana', 14, 'Aros de calamar fritos', 4200.00),

	-- Subcategoría 15: Guisos
	('Cazuela de Mariscos', 15, 'Variedad de mariscos en caldo especiado', 5800.00),
	('Paella', 15, 'Arroz con mariscos y azafrán', 6000.00),
	('Guiso de Pescado', 15, 'Pescado cocido con vegetales y especias', 5500.00),
	('Mariscos al Curry', 15, 'Mariscos cocidos en salsa curry suave', 5900.00),

	-- Categoría 7: Woks
	-- Subcategoría 16: Vegetarianos
	('Wok de Verduras', 16, 'Salteado de vegetales frescos con salsa de soja', 3100.00),
	('Wok con Tofu', 16, 'Tofu marinado con vegetales y jengibre', 3300.00),
	('Wok Thai Vegetariano', 16, 'Vegetales con leche de coco y curry suave', 3400.00),
	('Wok de Brotes y Setas', 16, 'Brotes de soja y setas salteados', 3200.00),

	-- Subcategoría 17: Con Pollo
	('Wok de Pollo y Vegetales', 17, 'Tiras de pollo con vegetales salteados', 3600.00),
	('Wok Picante de Pollo', 17, 'Pollo con salsa picante y verduras', 3700.00),
	('Wok de Pollo Teriyaki', 17, 'Pollo con salsa teriyaki y arroz', 3800.00),
	('Wok con Pollo y Ananá', 17, 'Pollo salteado con piña y verduras', 3650.00),

	-- Subcategoría 18: Con Camarones
	('Wok de Camarones', 18, 'Camarones salteados con vegetales y soja', 4200.00),
	('Wok de Camarones Picante', 18, 'Camarones con salsa picante y arroz', 4300.00),
	('Wok de Camarones al Curry', 18, 'Camarones con salsa curry y leche de coco', 4400.00),
	('Wok de Camarones y Verduras', 18, 'Camarones con mezcla de vegetales frescos', 4250.00),

	-- Categoría 8: Risottos

	-- Subcategoría 19: Clásicos
	('Risotto de Calabaza', 19, 'Risotto cremoso con calabaza asada', 3800.00),
	('Risotto de Hongos', 19, 'Risotto con mezcla de hongos y queso parmesano', 3900.00),
	('Risotto de Verduras', 19, 'Risotto con verduras frescas y hierbas', 3700.00),
	('Risotto de Queso Azul', 19, 'Risotto con queso azul y nueces', 4000.00),

	-- Subcategoría 20: De mar
	('Risotto de Mariscos', 20, 'Arroz cremoso con mariscos frescos', 5200.00),
	('Risotto de Camarones', 20, 'Risotto con camarones y salsa de crema', 5100.00),
	('Risotto de Langostinos', 20, 'Risotto con langostinos y azafrán', 5300.00),

	-- Categoría 9: Pizzas

	-- Subcategoría 21: Clásicas
	('Muzzarella', 21, 'Pizza con salsa de tomate y muzzarella', 2800.00),
	('Napolitana', 21, 'Pizza con tomate, muzzarella y ajo', 2900.00),
	('Jamón y Morrones', 21, 'Pizza con jamón y pimientos', 3200.00),
	('Fugazzeta', 21, 'Pizza con cebolla y muzzarella', 3000.00),
	('Calabresa', 21, 'Pizza con salame y salsa picante', 3300.00),

	-- Categoría 9: Pizzas

	-- Subcategoría 22: Especiales
	('Pizza Cuatro Quesos', 22, 'Mozzarella, roquefort, parmesano y fontina', 3600.00),
	('Pizza de Provolone', 22, 'Provolone fundido con orégano', 3500.00),
	('Pizza Vegetariana', 22, 'Verduras asadas y muzzarella', 3400.00),
	('Pizza de Pollo BBQ', 22, 'Pollo con salsa barbacoa y cebolla', 3700.00),
	('Pizza Caprese', 22, 'Tomate, mozzarella y albahaca fresca', 3550.00),

	-- Categoría 10: Postres

	-- Subcategoría 23: Tortas
	('Torta Selva Negra', 23, 'Bizcochuelo con crema y chocolate', 2200.00),
	('Torta de Ricota', 23, 'Torta casera con relleno de ricota', 2100.00),
	('Torta de Manzana', 23, 'Torta con manzana y canela', 2000.00),
	('Torta de Chocolate', 23, 'Torta húmeda de chocolate', 2300.00),
	('Torta de Zanahoria', 23, 'Torta con zanahoria y nueces', 2150.00),

	-- Subcategoría 24: Helados
	('Helado Vainilla', 24, 'Helado cremoso de vainilla', 900.00),
	('Helado Chocolate', 24, 'Helado intenso de chocolate', 900.00),
	('Helado Dulce de Leche', 24, 'Helado sabor dulce de leche', 950.00),
	('Helado Frutilla', 24, 'Helado sabor frutilla natural', 900.00),
	('Helado Limón', 24, 'Helado refrescante de limón', 900.00),

	-- Categoría 10: Postres

	-- Subcategoría 25: Otros
	('Panqueques con Dulce', 25, 'Panqueques rellenos con dulce de leche', 1100.00),
	('Brownie con Helado', 25, 'Brownie de chocolate con helado vainilla', 1300.00),
	('Mousse de Chocolate', 25, 'Mousse suave y cremoso de chocolate', 1200.00),
	('Frutas Frescas', 25, 'Ensalada de frutas de estación', 1000.00),

	-- Categoría 11: Bebidas sin alcohol

	-- Subcategoría 26: Aguas
	('Agua Mineral', 26, 'Agua sin gas botella 500ml', 600.00),
	('Agua con Gas', 26, 'Agua mineral con gas botella 500ml', 650.00),
	('Agua Saborizada', 26, 'Agua con sabor a limón o durazno', 700.00),

	-- Subcategoría 27: Gaseosas
	('Coca-Cola', 27, 'Gaseosa clásica 500ml', 800.00),
	('Sprite', 27, 'Gaseosa limón 500ml', 800.00),
	('Fanta', 27, 'Gaseosa naranja 500ml', 800.00),
	('Pepsi', 27, 'Gaseosa cola 500ml', 800.00),
	('Seven Up', 27, 'Gaseosa limón 500ml', 800.00),

	-- Categoría 11: Bebidas sin alcohol

	-- Subcategoría 28: Jugos
	('Jugo de Naranja', 28, 'Jugo natural exprimido', 900.00),
	('Jugo de Manzana', 28, 'Jugo natural de manzana', 900.00),
	('Jugo de Durazno', 28, 'Jugo natural de durazno', 900.00),
	('Jugo de Pomelo', 28, 'Jugo natural de pomelo', 900.00),

	-- Categoría 12: Bebidas con alcohol

	-- Subcategoría 29: Cervezas
	('Cerveza Rubia', 29, 'Cerveza rubia nacional 500ml', 1200.00),
	('Cerveza Negra', 29, 'Cerveza negra artesanal', 1400.00),
	('Cerveza Roja', 29, 'Cerveza roja con sabor a malta', 1300.00),
	('Cerveza IPA', 29, 'Cerveza IPA con notas cítricas', 1500.00),

	-- Subcategoría 30: Vinos
	('Vino Tinto Malbec', 30, 'Vino malbec argentino 750ml', 3200.00),
	('Vino Blanco Chardonnay', 30, 'Vino chardonnay fresco y frutal', 3100.00),
	('Vino Rosado', 30, 'Vino rosado suave y afrutado', 3000.00),
	('Vino Espumante', 30, 'Vino espumante dulce', 3500.00),

	-- Categoría 12: Bebidas con alcohol

	-- Subcategoría 31: Licores
	('Licor de Naranja', 31, 'Licor dulce con sabor a naranja', 2800.00),
	('Licor de Café', 31, 'Licor con aroma y sabor a café', 3000.00),
	('Licor de Hierbas', 31, 'Licor tradicional de hierbas', 2900.00),
	('Licor de Menta', 31, 'Licor refrescante de menta', 2700.00)

-- UPDATE Menu SET Descripcion = 'Hongos, cherry, cebolla morada, zucchini, zanahoria, morrón bicolor.' WHERE id_Menu_Item = 6;

-- SELECT * FROM SubCategoriaMenu WHERE NombreSubCategoria LIKE '%aperitivos%';

-- UPDATE SubCategoriaMenu SET NombreSubCategoria = 'Alta Cocina.' WHERE id_Menu_Item = 6;

SELECT * FROM Menu;

SELECT Nombre_Menu, SCM.NombreSubCategoria, CM.Nombre_Categoria FROM Menu AS M
INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria
INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria;
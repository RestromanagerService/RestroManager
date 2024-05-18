SET IDENTITY_INSERT [dbo].[Units] ON 
INSERT INTO [dbo].[Units] ([Id], [Name], [Symbol]) VALUES (1, N'Kilogramo', N'Kg')
INSERT INTO [dbo].[Units] ([Id], [Name], [Symbol]) VALUES (2, N'Gramo', N'g')
INSERT INTO [dbo].[Units] ([Id], [Name], [Symbol]) VALUES (3, N'Unidad', N'U')
SET IDENTITY_INSERT [dbo].[Units] OFF

SET IDENTITY_INSERT [dbo].[Categories] ON 
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Almuerzos')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Bebidas')
INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Entradas')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[RawMaterials] ON 
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (1, N'Arroz', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (2, N'Frijol', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (3, N'Chicharron de cerdo', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (4, N'Tomate', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (5, N'Cebolla', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (6, N'Ajo', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (7, N'Ajies ', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (8, N'Sal', NULL)
INSERT INTO [dbo].[RawMaterials] ([Id], [Name], [Photo]) VALUES (9, N'Pimienta', NULL)
SET IDENTITY_INSERT [dbo].[RawMaterials] OFF

SET IDENTITY_INSERT [dbo].[StockRawMaterials] ON
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (1, 1, 1000, 2, 20)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (2, 2, 1000, 2, 30)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (3, 3, 1000, 2, 20)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (4, 4, 1000, 2, 10)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (5, 5, 1000, 2, 10)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (6, 6, 20, 1, 3000)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (7, 7, 3000, 2, 100)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (8, 8, 20, 1, 2000)
INSERT INTO [dbo].[StockRawMaterials] ([Id], [RawMaterialId], [Aumount], [UnitsId], [UnitCost]) VALUES (9, 9, 1000, 2, 20)
SET IDENTITY_INSERT [dbo].[StockRawMaterials] OFF

SET IDENTITY_INSERT [dbo].[Foods] ON
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (1, N'Porcion de arroz cocido', NULL, 500)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (2, N'Porcion de frijoles', NULL, 600)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (3, N'Porcion de chicharrón', NULL, 300.5)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (4, N'Cortes de carne de res', N'https://orderssebas20241.blob.core.windows.net/foods/d17734b1-d7bf-4368-aef1-84184b349bda.jpg', 500)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (5, N'Cortes de carne de cerdo', N'https://orderssebas20241.blob.core.windows.net/foods/b4e73bc8-6d82-48bb-951c-07988b58c894.jpg', 500)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (6, N'Cortes de pollo', N'https://orderssebas20241.blob.core.windows.net/foods/e753f9d7-372a-4533-a2c4-537637bd5b93.jpg', 500)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (7, N'Porción de plátano verde frito', N'https://orderssebas20241.blob.core.windows.net/foods/8c1616e0-af46-4e66-aa62-cb9dd19e95f3.jpg', 200)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (8, N'Porción de yuca cocida', N'https://orderssebas20241.blob.core.windows.net/foods/b0f552de-f335-4c5f-ae8f-5db3d1caaab9.jpg', 200)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (9, N'Porción de papa cocida', N'https://orderssebas20241.blob.core.windows.net/foods/0827413c-32ef-45bb-9a96-40c7764e472d.jpg', 200)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (10, N'Pizca de sal', N'https://orderssebas20241.blob.core.windows.net/foods/6d029db0-e19f-4448-bca1-bc56269f0d0b.jpg', 0.01)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (11, N'Pizca de pimienta', N'https://orderssebas20241.blob.core.windows.net/foods/02bcc4bf-7011-4b94-9a73-05fb98a21510.jpg', 0.01)
INSERT INTO [dbo].[Foods] ([Id], [Name], [Photo], [ProductionCost]) VALUES (12, N'Vegetales', N'https://orderssebas20241.blob.core.windows.net/foods/1de56236-ca85-4505-8378-421ebd4a5bc6.jpg', 0.01)
SET IDENTITY_INSERT [dbo].[Foods] OFF

SET IDENTITY_INSERT [dbo].[FoodRawMaterials] ON
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (1, 300, 2, 1, 1)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (2, 20, 2, 1, 4)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (3, 20, 2, 1, 5)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (4, 300, 2, 2, 2)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (5, 20, 2, 2, 4)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (6, 20, 2, 2, 5)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (7, 300, 2, 3, 3)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (8, 20, 2, 12, 4)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (9, 20, 2, 12, 5)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (10, 10, 2, 12, 6)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (11, 5, 2, 12, 7)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (12, 50, 2, 10, 8)
INSERT INTO [dbo].[FoodRawMaterials] ([Id], [Amount], [UnitsId], [FoodId], [RawMaterialId]) VALUES (13, 20, 2, 11, 9)
SET IDENTITY_INSERT [dbo].[FoodRawMaterials] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Name], [ProductType], [ProductionCost]) VALUES (1, N'Bandeja paisa', 1, 5000)
INSERT INTO [dbo].[Products] ([Id], [Name], [ProductType], [ProductionCost]) VALUES (2, N'Gaseosa de manzana 300ml', 0, 0)
INSERT INTO [dbo].[Products] ([Id], [Name], [ProductType], [ProductionCost]) VALUES (3, N'Gaseosa de mandarina 300ml', 0, 0)
INSERT INTO [dbo].[Products] ([Id], [Name], [ProductType], [ProductionCost]) VALUES (4, N'Gaseosa de uva 300ml', 0, 0)
INSERT INTO [dbo].[Products] ([Id], [Name], [ProductType], [ProductionCost]) VALUES (5, N'Sancocho Antioqueño', 1, 2000)
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[ProductFoods] ON
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (1, 1, 3, 1, 1)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (2, 1, 3, 1, 2)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (3, 1, 3, 1, 3)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (4, 1, 3, 5, 4)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (5, 1, 3, 5, 5)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (6, 1, 3, 5, 6)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (7, 1, 3, 5, 7)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (8, 1, 3, 5, 8)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (9, 1, 3, 5, 9)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (10, 1, 3, 5, 10)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (11, 1, 3, 5, 11)
INSERT INTO [dbo].[ProductFoods] ([Id], [Amount], [UnitsId], [ProductId], [FoodId]) VALUES (12, 1, 3, 5, 12)
SET IDENTITY_INSERT [dbo].[ProductFoods] OFF

SET IDENTITY_INSERT [dbo].[StockCommercialProducts] ON
INSERT INTO [dbo].[StockCommercialProducts] ([Id], [ProductId], [Aumount], [UnitsId], [UnitCost]) VALUES (1, 2, 10, 3, 3000.5)
INSERT INTO [dbo].[StockCommercialProducts] ([Id], [ProductId], [Aumount], [UnitsId], [UnitCost]) VALUES (2, 3, 10, 3, 3000.5)
INSERT INTO [dbo].[StockCommercialProducts] ([Id], [ProductId], [Aumount], [UnitsId], [UnitCost]) VALUES (3, 4, 10, 3, 3000.5)
SET IDENTITY_INSERT [dbo].[StockCommercialProducts] OFF
GO
ALTER DATABASE SewingStudio SET RECOVERY SIMPLE
GO

USE SewingStudio
--CREATE TABLE dbo.materials (
--  idMaterials INT NOT NULL identity(1,1),
--  Name VARCHAR(45) NOT NULL,
--  Type VARCHAR(45) NOT NULL,
--  Quantity INT NOT NULL,
--  PRIMARY KEY (idMaterials));

--CREATE TABLE dbo.supply (
--  idSupply INT NOT NULL identity(1,1),
--  Supplier VARCHAR(45) NOT NULL,
--  Price VARCHAR(45) NOT NULL,
--  Delivery_prise VARCHAR(45) NOT NULL,
--  idMaterials INT NOT NULL,
--  PRIMARY KEY (idSupply),
--  INDEX idMaterials_idx (idMaterials ASC),
--  CONSTRAINT idMaterials
--    FOREIGN KEY (idMaterials)
--    REFERENCES dbo.materials (idMaterials)
--    ON DELETE CASCADE
--    ON UPDATE CASCADE);

	--CREATE TABLE dbo.orders (
 -- idOrders INT NOT NULL identity(1,1),
 -- idProduct INT NOT NULL,
 -- Price DECIMAL NOT NULL,
 -- Quantity INT NOT NULL,
 -- Date_of_order DATE NOT NULL,
 -- Date_of_sale DECIMAL NOT NULL,
 -- PRIMARY KEY (idOrders));

  --CREATE TABLE dbo.employers (
  --idEmployees INT NOT NULL identity(1,1),
  --Name VARCHAR(45) NOT NULL,
  --Surname VARCHAR(45) NOT NULL,
  --Patronymic VARCHAR(45) NULL,
  --idOrder INT NOT NULL,
  --Execution_start_date DATE NOT NULL,
  --Date_of_delivery DATE NOT NULL,
  --PRIMARY KEY (idEmployees));

  --CREATE TABLE dbo.products (
  --idProducts int NOT NULL identity(1,1),
  --Name varchar(45) NOT NULL,
  --Price decimal(10,0) NOT NULL DEFAULT '0',
  --PRIMARY KEY (idProducts)); 

  CREATE TABLE dbo.productcomposition (
  idProductComposition int NOT NULL identity(1,1),
  idProduct int NOT NULL,
  idMaterial int NOT NULL,
  Quantity int NOT NULL DEFAULT '0',
  PRIMARY KEY (idProductComposition),
  --KEY idProduct_idx (idProduct),
  --KEY idMaterial_idx (idMaterial),
  CONSTRAINT MatelialId FOREIGN KEY (idMaterial) REFERENCES materials (idMaterials) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ProductId FOREIGN KEY (idProduct) REFERENCES products (idProducts) ON DELETE CASCADE ON UPDATE CASCADE
) 

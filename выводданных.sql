CREATE VIEW [dbo].[View_AllProductComposition]
AS
SELECT        dbo.productcomposition.idProductComposition, dbo.productcomposition.idProduct, dbo.productcomposition.idMaterial,
dbo.productcomposition.Quantity,  dbo.materials.Type, dbo.products.Name, dbo.products.Price
FROM            dbo.materials INNER JOIN
                         dbo.productcomposition ON dbo.materials.idMaterials = dbo.productcomposition.idMaterial INNER JOIN
                         dbo.products ON dbo.productcomposition.idProduct = dbo.products.idProducts
GO
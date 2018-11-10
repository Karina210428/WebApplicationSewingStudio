CREATE PROC my_proc1

  @m INT,

  @s FLOAT OUTPUT

AS

SELECT @s=Sum(dbo.supply.Price*dbo.supply.QuantityMaterials)

  FROM dbo.supply
  

  GROUP BY Year(dbo.supply.Delivery_date)

  Having year (dbo.supply.Delivery_date) = @m
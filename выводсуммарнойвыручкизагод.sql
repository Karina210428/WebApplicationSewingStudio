CREATE PROC my_proc6

  @m INT,

  @s FLOAT OUTPUT

AS

SELECT @s=Sum(dbo.supply.*dbo.orders.Quantity)

  FROM dbo.orders 
  

  GROUP BY Year(dbo.orders.Date_of_sale)

  Having year (dbo.orders.Date_of_sale) = @m


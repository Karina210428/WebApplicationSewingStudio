declare @Symbol char(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int, 
        @i int,
        @NameLimit int,
        @MaterialName varchar(45),
		@MaterialType varchar(45),
        @MaterialQuantity int,
        @RowCount int,
        @NumberProducts int,
		@NumberOperations int,
		@SupplierName varchar(45),
		@odate date,
		@odate1 date

set @NumberOperations = 10000
set @NumberProducts = 1000

BEGIN TRAN

SELECT @i=0 FROM dbo.orders WITH (TABLOCKX) WHERE 1=0
	
	SET @RowCount=1
	WHILE @RowCount<=@NumberOperations
	BEGIN

	SET @SupplierName=''
	SET @NameLimit=5+RAND()*15 
    SET @i=1

		WHILE @i<=@NameLimit
		BEGIN
			SET @Position=RAND()*52
			SET @SupplierName =@SupplierName  + SUBSTRING(@Symbol, @Position, 1)
			SET @i=@i+1
		END

		SET @odate=dateadd(day,-RAND()*15000,GETDATE())
		SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
		
		INSERT INTO dbo.orders(idProduct, Quantity, Price, Date_of_order, Date_of_sale)
		SELECT CAST( (1+RAND()*(@NumberProducts-1)) as int),
		(1+RAND()*500), (1+RAND()*500),
		@odate, @odate1
		
		SET @RowCount +=1
	END
COMMIT TRAN
	




declare @Symbol char(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int, 
        @i int,
        @NameLimit int,
        @ProductName varchar(45),
        @ProductPrice decimal(10,1),
        @RowCount int,
        @NumberProducts int

set @NumberProducts = 1000


begin tran

select @i=0 from dbo.products with (tablockx) where 1=0

	set @RowCount =1

	while @RowCount <= @NumberProducts

	begin 
    
		set @ProductName =''
        set @NameLimit = 5+RAND()*45
        set @i=1
        
        while @i<= @NameLimit
		begin
			set @Position=RAND()*52
            set @ProductName = @ProductName + SUBSTRING(@Symbol, @Position,1)
            set @i = @i+1
		end
        
        insert into dbo.products (Name, Price) select @ProductName, (1+RAND())  

		--delete from dbo.products
        
        set @RowCount +=1
	end

	




declare @Symbol char(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int, 
        @i int,
        @NameLimit int,
        @MaterialName varchar(45),
		@MaterialType varchar(45),
        @MaterialQuantity int,
        @RowCount int,
        @NumberProducts int, @j int

set @NumberProducts = 1000


begin tran

select @i=0 from dbo.materials with (tablockx) where 1=0

	set @RowCount =1
	

	while @RowCount <= @NumberProducts

	begin 
    
		SET @MaterialName=''
		SET @MaterialType=''
        set @NameLimit = 5+RAND()*45

        set @i=1
        
        while @i<= @NameLimit
		begin
			set @MaterialName = @MaterialName + SUBSTRING(@Symbol, @Position,1)
			set @Position=RAND()*52
			set @MaterialType = @MaterialType + SUBSTRING(@Symbol, @Position,1)
            set @i = @i+1
		end

		
        
		INSERT INTO dbo.materials(Name, Type)
		SELECT @MaterialName, @MaterialType
		
		
        
        set @RowCount +=1
	end

	




declare @Symbol char(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@Position int, 
        @i int,
        @NameLimit int,
        @Name varchar(45),
		@Surname varchar(45),
		@Patronymic varchar(45),
        @MaterialQuantity int,
        @RowCount int,
        @NumberEmployers int,
		@odate date, 
		@odate1 date

set @NumberEmployers = 1000

begin tran

select @i=0 from dbo.employers with (tablockx) where 1=0

	set @RowCount =1
	

	while @RowCount <= @NumberEmployers

	begin 
    
		SET @Name=''
		SET @Surname=''
		set @Patronymic=''
        set @NameLimit = 5+RAND()*45

        set @i=1
        
        while @i<= @NameLimit
		begin
			set @Name = @Name + SUBSTRING(@Symbol, @Position,1)
			set @Position=RAND()*52
			set @Surname = @Surname + SUBSTRING(@Symbol, @Position,1)
			set @Patronymic = @Patronymic + SUBSTRING(@Symbol, @Position,1)
            set @i = @i+1
		end
        
		SET @odate=dateadd(day,-RAND()*15000,GETDATE())
		SET @odate1=dateadd(day,-RAND()*15000,GETDATE())
		INSERT INTO dbo.employers(Name, Surname, Patronymic,idOrder,Execution_start_date,Date_of_delivery)
		SELECT @Name, @Surname, @Patronymic,CAST( (1+RAND()*(@NumberEmployers-1)) as int),
		@odate, @odate1

        
        set @RowCount +=1
	end

	



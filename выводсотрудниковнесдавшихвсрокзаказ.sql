CREATE PROC my_proc2
  @date nvarchar(45)
AS
SELECT employers.Surname, employers.Name, employers.Patronymic
 FROM dbo.employers where employers.Date_of_delivery < CONVERT(DATETIME,@date,104)
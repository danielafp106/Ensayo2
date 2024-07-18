	CREATE DATABASE ensayo;
	use ensayo;

	CREATE TABLE prueba (
	idPrueba INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	cmpTexto NVARCHAR(50),
	cmpNumero DECIMAL(7,2),
	cmpFecha DateTime)

	CREATE VIEW vistaprueba as SELECT p.cmpTexto FROM prueba p
	go

	Select cmptexto from vistaprueba

	create function iva (@num decimal(7,2))
	returns decimal(7,2)
	as 
	begin
	set @num = @num*(1+0.13)
	return @num
	end;

	select dbo.iva(10);

	create procedure procalma6(@n1 nvarchar(50),@r nvarchar(50) out)
	as begin
	declare @n2  nvarchar(50)
	select @n2=cmptexto from prueba where idPrueba = 1
	select @r = @n2
	end
	

	declare @r nvarchar(50)
	exec dbo.procalma6 'h', @r output
	select @r

	select cmptexto from prueba where idPrueba = 1
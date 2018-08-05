CREATE TABLE CuadresVendedores (
	CuadreId int primary key identity,	
	VendedorId int,	
	Fecha datetime,
	Concepto varchar(100),
	Monto float)
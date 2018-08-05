CREATE TABLE Vendedores (
	VendedorId int primary key identity,	
	Nombres varchar(40),
        Descripcion varchar(100),
        MensajeInicial varchar(100),
        MensajeFinal varchar(100),
        Pct1 int,
        Pct2 int,
        Pct3 int, 
        Pct4 int,
        Pct5 int,
        LimiteVentas int)
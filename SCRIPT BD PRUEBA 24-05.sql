create database BD_PRUEBA;

create table Usuario(
	idCliente int identity(1,1) primary key not null,
	nombre varchar(50) not null,
	apellido varchar(60) not null,
	correo varchar(150) not null,
	clave varchar(30) not null
)

create table Categoria(
	idCategoria int identity(1,1) primary key,
	nombreCategoria varchar(50) not null
)

create table Producto(
	idProducto int identity(1,1) primary key,
	nombreProducto varchar(50) not null,
	precio float,
	cantidad int,
	idCategoria int references Categoria(idCategoria)
)


CREATE TABLE OrdenCompra (
    idOrden INT PRIMARY KEY IDENTITY(1,1),
    total DECIMAL(18, 2) NOT NULL,
    fechaRegistro DATETIME NOT NULL
);


CREATE TABLE OrdenCompraDetalle (
    IdOrdenDetalle INT PRIMARY KEY IDENTITY(1,1),
    IdOrden INT NOT NULL,
    IdProducto INT NOT NULL,
    CONSTRAINT FK_OrdenCompraDetalle_OrdenCompra FOREIGN KEY (IdOrden)
        REFERENCES OrdenCompra(idOrden),
    CONSTRAINT FK_OrdenCompraDetalle_Producto FOREIGN KEY (IdProducto)
        REFERENCES Producto(idProducto)
);


INSERT INTO Categoria ( nombreCategoria) VALUES ('Electr�nica');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Ropa');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Hogar');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Alimentaci�n');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Libros');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Juguetes');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Deportes');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Belleza');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Autom�viles');
INSERT INTO Categoria ( nombreCategoria) VALUES ('Electrodom�sticos');

/*PRODUCTO CATEGORIA ELECTRONICA*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Tel�fono m�vil', 499.99,5 ,1);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Tablet', 299.99, 7,1);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Smartwatch', 199.99,10 ,1);

/*PRODUCTO CATEGORIA ROPA*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Pantalon de tela', 24.99,5 ,2);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Camiseta Polo', 39.99, 7,2);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Camisa', 29.99,10 ,2);

/*PRODUCTO CATEGORIA HOGAR*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Juego de sabanas', 24.99,5 ,3);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Set de toallas', 19.99, 10,3);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Cortinas', 39.99,10 ,3);

/*PRODUCTO CATEGORIA ALIMENTACION*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Arroz 25Kg', 24.99,5 ,4);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Leche entera 1Lt', 0.85, 15,4);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Cubeta huevos', 3.99, 15 ,4);

/*PRODUCTO CATEGORIA LIBROS*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('La Odiasea', 24.99,5 ,5);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('La divina comedia', 39.99, 7,5);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('The Moon', 29.99,10 ,5);

/*PRODUCTO CATEGORIA JUGUETES*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Helicoptero', 24.99,5 ,6);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Carro', 4.23, 7,6);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Mu�eco', 11.99,10 ,6);

/*PRODUCTO CATEGORIA DEPORTES*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Balon Mundial', 40.99,8 ,7);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Balon Copa America', 40.50, 23,7);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Raqueta tennis', 11.99,6 ,7);

/*PRODUCTO CATEGORIA BELLEZA*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Labial', 5.99,5 ,8);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Espejo', 4.23, 7,8);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Tinte de cabello', 11.99,10 ,8);

/*PRODUCTO CATEGORIA AUTOMOVILES*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('SUV', 4499.99,5 ,9);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Camioneta', 11500.64, 7,9);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Coche Compacto', 8597.99,10 ,9);

/*PRODUCTO CATEGORIA ELECTRODOMESTICO*/
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Nevera', 349.99,5 ,10);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Cocina', 249.99, 7,10);
INSERT INTO Producto ( nombreProducto, precio,cantidad, idCategoria) VALUES ('Cafetera', 49.99,10 ,10);

/*PROCEDIMIENTO*/
CREATE PROCEDURE ValidarUsuario
	@Correo AS VARCHAR(150),
	@Clave  AS VARCHAR(30)
	
	AS
		BEGIN
			SELECT Correo, Clave
			FROM Usuario
			Where Correo = @Correo
		END
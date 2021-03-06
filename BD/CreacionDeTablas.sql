
create database BienvenidosUY

go
use BienvenidosUY

CREATE TABLE REGISTRADO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(30) not null,
	apellido varchar (40) not null,
	mail varchar(50) UNIQUE not null,
	password varchar (20) not null,
	direccion varchar (50) not null,
	celular varchar (20),
	foto varbinary(max),
	descripcion varchar(250)
)

CREATE TABLE CATEGORIA(
id int PRIMARY KEY IDENTITY,
nombre varchar(30) CHECK(nombre IN ('Apartamento', 'Casa', 'Hotel', 'Hostel', 'Posada', 'Bungalow', 'Cabania', 'Casa rodante', 'Rancho'))
)

CREATE TABLE ALOJAMIENTO(
	id int PRIMARY KEY IDENTITY,
	idCategoria int REFERENCES CATEGORIA not null,
	tipoHabitacion varchar(20) CHECK(tipoHabitacion IN ('Todo', 'Habitacion privada', 'Habitacion compartida')),
	banioPrivado bit,
	cantHuespedes int,
	ciudad varchar(20) not null,
	barrio varchar(20),
	calificacion int
)

go

CREATE TABLE ANUNCIO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(30) not null,
	idAlojamiento int REFERENCES ALOJAMIENTO not null,
	descripcion varchar(250),
	direccion1 varchar(40) not null,
	direccion2 varchar(40),
	fotos varbinary(max),
	precioBase decimal(12,2) not null,
	idRegistrado int REFERENCES REGISTRADO not null

)

CREATE TABLE RESERVA(
	id int PRIMARY KEY IDENTITY,
	idAnuncio int REFERENCES ANUNCIO not null,
	fechaInicio datetime not null,
	fechaFin datetime not null,
	idRegistrado int REFERENCES REGISTRADO not null
)



CREATE TABLE RANGOFECHAS(
	id int PRIMARY KEY IDENTITY,
	fechaInicio datetime,
	fechaFin datetime,
	precio decimal(12,2),
	idAnuncio int REFERENCES ANUNCIO not null
)


CREATE TABLE SERVICIO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(20) not null,
	descripcion varchar(250)
)


go

CREATE TABLE ALOJAMIENTO_SERVICIO(
	idAlojamiento int REFERENCES ALOJAMIENTO not null,
	idServicio int REFERENCES SERVICIO not null,
	PRIMARY KEY(idAlojamiento, idServicio)
)






CREATE TABLE REGISTRADO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(30) not null,
	apellido varchar (40) not null,
	mail varchar(50) UNIQUE not null,
	password varchar (20) not null,
	direccion varchar (50) not null,
	celular varchar (20),
	foto varbinary(max),
	descripcion varchar(250),
	idRegistrado_Anuncio int REFERENCES REGISTRADO_ANUNCIO,
	idRegistrado_Reserva int REFERENCES REGISTRADO_RESERVA
)

CREATE TABLE ANUNCIO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(30) not null,
	idAlojamiento int REFERENCES ALOJAMIENTO not null,
	descripcion varchar(250),
	direccion1 varchar(40) not null,
	direccion2 varchar(40),
	fotos varbinary(max),
	precioBase decimal(12,2) not null,
	idAnuncio_RangoFechas int REFERENCES ANUNCIO_RANGOFECHAS
)

CREATE TABLE RESERVA(
	id int PRIMARY KEY IDENTITY,
	idAnuncio int REFERENCES ANUNCIO not null,
	fechaInicio datetime not null,
	fechaFin datetime not null
)

CREATE TABLE ALOJAMIENTO(
	id int PRIMARY KEY IDENTITY,
	categoria varchar(20) CHECK(categoria IN ('Apartamento', 'Casa', 'Hotel', 'Hostel', 'Posada', 'Bungalow', 'Cabania', 'Casa rodante', 'Rancho')),
	tipoHabitacion varchar(20) CHECK(tipoHabitacion IN ('Todo', 'Habitacion privada', 'Habitacion compartida')),
	banioPrivado boolean,
	cantHuespedes int,
	ciudad varchar(20) not null,
	barrio varchar(20),
	idAlojamiento_Servicio int REFERENCES ALOJAMIENTO_SERVICIO,
	calificacion int
)

CREATE TABLE RANGOFECHAS(
	id int PRIMARY KEY IDENTITY,
	fechaInicio datetime,
	fechaFin datetime,
	precio decimal(12,2)
)


CREATE TABLE SERVICIO(
	id int PRIMARY KEY IDENTITY,
	nombre varchar(20) not null,
	descripcion varchar(250)
)


CREATE TABLE REGISTRADO_ANUNCIO(
	id int PRIMARY KEY IDENTITY,
	idRegistrado int REFERENCES REGISTRADO not null,
	idAnuncio int REFERENCES ANUNCIO not null
)

CREATE TABLE REGISTRADO_RESERVA(
	id int PRIMARY KEY IDENTITY,
	idRegistrado int REFERENCES REGISTRADO not null,
	idReserva int REFERENCES RESERVA not null
)

CREATE TABLE ANUNCIO_RANGOFECHAS(
	id int PRIMARY KEY IDENTITY,
	idAnuncio int REFERENCES ANUNCIO not null,
	idRangoFechas int REFERENCES RANGOFECHAS not null
)

CREATE TABLE ALOJAMIENTO_SERVICIO(
	id int PRIMARY KEY IDENTITY,
	idAlojamiento int REFERENCES ALOJAMIENTO not null,
	idServicio int REFERENCES SERVICIO not null
)





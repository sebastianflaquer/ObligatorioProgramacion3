create database EventosUY2;

use EventosUY2;

--Roles (IdRol, NombreRol, DetalleRol)

create table Roles(
	IdRol int IDENTITY(1,1) primary key, 
	NombreRol varchar(30), 
	DetalleRol varchar(50)
)

insert into Roles (NombreRol, DetalleRol) values
	('Admin','Usuarios administradores de EventosUY'),
	('Empresa','Empresas o promotores')

select *
from Roles

--Usuarios (idUsuario, MailUsuario, PassUsuario, IdRol)

Create table Usuarios(
	idUsuario int identity(1,1) primary key, 
	MailUsuario varchar(30) unique, 
	PassUsuario varchar(30), 
	IdRol int
)

insert into Usuarios (MailUsuario, PassUsuario, IdRol) values
	('mail@megaeventos.com','123456//', 2),
	('info@tufiesta.com','123456//', 2),
	('hola@pop.com','123456//', 2),
	('fiesta@electro.com','123456//', 2),
	('admin1@mail.com','123456//', 1),
	('admin2@mail.com','123456//', 1)

select *
from Usuarios

select *
from Empresas

--Empresas ( IdEmpresa, Nombre, Telefono, Mails, Url, idUsuario)

create table Empresas(
	IdEmpresa int identity(1,1) primary key, 
	Nombre varchar(30), 
	Telefono varchar(50), 
	Mails varchar(300), 
	Url varchar(50), 
	idUsuario int
)

insert into Empresas(Nombre,Telefono,Mails,Url,idUsuario) values
	('MegaEventos','099123123','megaeventos@megaeventos.com;contacto@megaeventos.com','http://www.megaevento.com',25),
	('tufiesta','099123123','contacto@tufiesta.com;','http://www.tufiesta.com',26),
	('Pop','099123123','estemail@pop.com','http://www.pop.com',27),
	('Electro','099123123','estemail@electro.com;estemail@electro.com','http://www.electro.com',28)



--Administradores (idAdmin, NroFuncionario, Nombre, Apellido, Telefono, Cargo, idUsuario)

create table Administradores(
	idAdmin int identity(1,1) primary key, 
	Nombre varchar(30), 	
	Apellido varchar(30),	
	NroFuncionario varchar(30), 
	Telefono varchar(30), 
	Cargo varchar(30), 
	idUsuario int
)

insert into Administradores (Nombre,Apellido,NroFuncionario,Telefono,Cargo,idUsuario) values
	('Juan','Perez', 123,'0990123456','Empleado', 29),
	('Pedro','Picpiedra', 321,'0990123456','Empleado', 30)


select *
from Administradores
--Eventos (IdEmpresa, Titulo,Descripcion, NombreArtistas, Fecha, Hora, NombreLugar, DireccionLugar, BarrioLugar, CapasidadMaxima, Imagen, Precio, Estado)

create table Eventos(
	idEvento int identity(1,1) primary key,
	Titulo varchar(150),
	Descripcion varchar(300), 
	NombreArtistas varchar(150), 
	Fecha date, 
	Hora time, 
	NombreLugar varchar(30), 
	DireccionLugar varchar(30), 
	BarrioLugar varchar(30), 
	CapasidadMaxima varchar(30), 
	Imagen varbinary(MAX), 
	Precio varchar(300), 
	Estado char(1),
	IdEmpresa int, 
	constraint fk_IdEmpresa Foreign key (IdEmpresa) references Empresas,
	constraint ck_estado check (Estado in('C', 'D', 'A'))
)

insert into Eventos(Titulo, Descripcion, NombreArtistas, Fecha, Hora, NombreLugar, DireccionLugar, BarrioLugar, CapasidadMaxima, Imagen, Precio, Estado, IdEmpresa) values	
	('Samba','Evento de Samba','Pedro','15/12/2015','21:00:00','Lugar2','Calle 2','Barrio1',500,000000,'500','A', 1),
	('Rock','Evento de Rock','Juan','15/12/2015','21:00:00','Lugar2','Calle 2','Barrio1',500,000000,'500','A', 2),
	('Pop','Evento de Pop','Mario','15/12/2015','21:00:00','Lugar2','Calle 2','Barrio1',500,000000,'500','A', 1),
	('Tango','Evento de Tango','Ale','15/12/2015','21:00:00','Lugar2','Calle 2','Barrio1',500,000000,'500','A', 3)

select *
from Eventos
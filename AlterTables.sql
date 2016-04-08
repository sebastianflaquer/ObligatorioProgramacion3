


Alter table Registrado
add idRegistrado_Anuncio int not Null

Alter table Registrado
add idRegistrado_Reserva int not Null


Alter table Anuncio
add idAlojamiento int not Null

Alter table Anuncio
add idAnuncio_RangoFechas int not Null


Alter table Alojamiento
add idAlojamiento_Servicio int not Null




alter table Registrado
Add Constraint fk_idRegistrado_Anuncio foreign Key (Id) references Registrado_Anuncio

alter table Registrado
Add Constraint fk_idRegistrado_Reserva foreign Key (Id) references Registrado_Reserva

alter table Anuncio
Add Constraint fk_idAlojamiento foreign Key (Id) references Alojamiento

alter table Anuncio
Add Constraint fk_idAnuncio_RangoFechas foreign Key (Id) references Anuncio_RangoFechas

alter table Alojamiento
Add Constraint fk_idAlojamiento_Servicio foreign Key (Id) references Alojamiento_Servicio
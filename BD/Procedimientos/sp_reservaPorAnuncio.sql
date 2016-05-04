create procedure ReservaPorAnuncio
	@idAnuncio int 
	AS BEGIN

	select *
	from Reserva
	Where idAnuncio = @idAnuncio

	End
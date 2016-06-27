using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        public virtual Registrado Registrado { get; set; }
        [Display(Name = "Cantidad de Huéspedes")]
        public int CantHuespedes { get; set; }
        [Display(Name = "Consultas")]
        public string TextoConsultas { get; set; }
        public virtual Anuncio Anuncio { get; set; }


        public bool funciontest()
        {
            return true;
        }


        public bool ValidarFechaParaCancelar()
        {
            bool ret = false;
            if (this.FechaInicio > DateTime.Now.Date)
            {
                ret = true;
            }
            return ret;
        }


        public bool ValidarFechaParaCalificar()
        {
            bool ret = false;
            if (this.FechaFin < DateTime.Now.Date)
            {
                ret = true;
            }
            return ret;
        }

        // Valida si la Reserva ya fue calificada por el Usuario logueado
        public static bool ReservaYaCalificadaPorUsuario(Reserva reserva, int idRegistrado)
        {
            bool ret = true;

            BienvenidosUyContext db = new BienvenidosUyContext();

            var calif = from c in db.Calificaciones
                        where c.Registrado.Id == idRegistrado && c.Alojamiento.Id == reserva.Anuncio.Alojamiento.Id
                        select c;

            if (calif != null)
            {
                ret = false;
            }
            return ret;
        }



        public decimal anuncioTieneFechas(List<RangoFechas> rangosAnuncio, Reserva reserva)
        {
            //VAR
            decimal ret = -1;
            DateTime FechaInicio = reserva.FechaInicio;
            DateTime FechaFin = reserva.FechaFin;
            int i = 0;
            bool encontrado = false;
            decimal costoReserva = 0;
            DateTime fecha = FechaInicio;
            int cantidadDiasRango = (int)(FechaFin - FechaInicio).TotalDays;
            int cantidadDiasEnco = 0;

            while (fecha < FechaFin)
            {
                encontrado = false;
                i = 0;
                while (i < rangosAnuncio.Count && encontrado == false)
                {
                    if (rangosAnuncio[i].FechaInicio <= fecha && rangosAnuncio[i].FechaFin >= fecha)
                    {
                        costoReserva += rangosAnuncio[i].Precio;
                        encontrado = true;
                        cantidadDiasEnco += 1;
                    }
                    else
                    {
                        i++;
                    }
                }
                fecha = fecha.AddDays(1);
            }

            if (cantidadDiasRango == cantidadDiasEnco)
            {
                ret = costoReserva;
            }
            else {
                ret = -1;
            }

            return ret;
        }

        
        public bool otraValidacion(List<RangoFechas> rangosAnuncio, Reserva reserva)
        {
            bool ret = false;
            int cantidadHReserva = reserva.CantHuespedes;
            BienvenidosUyContext db = new BienvenidosUyContext();
            List<Reserva> reservasDelAnuncio = new List<Reserva>();


            if (cantidadHReserva <= reserva.Anuncio.Alojamiento.CantHuespedes)
            {
                var listadoReservas = db.Reservas.ToList();
                foreach (Reserva r in listadoReservas)
                {
                    if (r.Anuncio.Id == reserva.Anuncio.Id)
                    {
                        reservasDelAnuncio.Add(r);
                    }
                }

                if (reserva.Anuncio.Alojamiento.TipoHabitacion == "Completo" || reserva.Anuncio.Alojamiento.TipoHabitacion == "Privado")
                {
                    int i = 0;
                    //bool sePisan = false;
                    while (i < reservasDelAnuncio.Count && ret == false)
                    {
                        //enntra si hay alguna reserva para esa fecha
                        if (reservasDelAnuncio[i].FechaInicio <= reserva.FechaInicio && reservasDelAnuncio[i].FechaFin >= reserva.FechaInicio || reservasDelAnuncio[i].FechaInicio <= reserva.FechaFin && reservasDelAnuncio[i].FechaInicio >= reserva.FechaFin)
                        {
                            ret = true;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                // cuando es Compartido
                else
                {
                    int i = 0;
                    //bool sePisan = false;
                    while (i < reservasDelAnuncio.Count && ret == false)
                    {
                        //enntra si hay alguna reserva para esa fecha
                        if (reservasDelAnuncio[i].FechaInicio <= reserva.FechaInicio && reservasDelAnuncio[i].FechaFin >= reserva.FechaInicio || reservasDelAnuncio[i].FechaInicio <= reserva.FechaFin && reservasDelAnuncio[i].FechaInicio >= reserva.FechaFin)
                        {
                            //cuanta la cantidad de huespedes
                            if (reserva.Anuncio.Alojamiento.CantHuespedes <= CantHuespReservasEnAnuncio(rangosAnuncio, reserva))
                            {
                                ret = true;
                            }
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            else {
                ret = true;
            }

            return ret;
        }





        public int CantHuespReservasEnAnuncio(List<RangoFechas> rangosAnuncio, Reserva reserva)
        {
            int cant = 0;

            BienvenidosUyContext db = new BienvenidosUyContext();
            List<Reserva> reservasDelAnuncio = new List<Reserva>();
            foreach (Reserva r in db.Reservas)
            {
                if (r.Anuncio.Id == reserva.Anuncio.Id)
                {
                    reservasDelAnuncio.Add(r);
                }
            }

            int i = 0;
            while (i < reservasDelAnuncio.Count)
            {
                if (reservasDelAnuncio[i].FechaInicio <= reserva.FechaInicio && reservasDelAnuncio[i].FechaFin >= reserva.FechaInicio
                      || reservasDelAnuncio[i].FechaInicio <= reserva.FechaFin && reservasDelAnuncio[i].FechaInicio >= reserva.FechaFin)
                {
                    cant += reservasDelAnuncio[i].CantHuespedes;
                }
                else
                {
                    i++;
                }
            }
            return cant;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual Alojamiento Alojamiento { get; set; }
        public string Descripcion { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Fotos { get; set; }
        public decimal PrecioBase { get; set; }
        public virtual List<RangoFechas> RangosFechas { get; set; }


        public Anuncio buscarFechas(Anuncio unA)
        {
            Anuncio retorno = new Anuncio();
            return retorno;
        }

        //TRAER TODOS LOS ANUNCIOS
        public static IQueryable<Anuncio> traerAnunciosXFecha(IQueryable<Anuncio> anuncios, DateTime searchFechaI, DateTime searchFechaFin)
        {
            //VAR
            DateTime fecha = searchFechaI;
            List<Anuncio> AResult = new List<Anuncio>();
            List<Anuncio> ListaResultado = new List<Anuncio>();

            bool encontrado = false;
            int a = 0;
            int r = 0;
            AResult = anuncios.ToList();
            int cantidadDiasRango = (int)(searchFechaFin - searchFechaI).TotalDays;
            int cantidadDiasEnco = 0;

            while (a < AResult.Count) 
            {
                fecha = searchFechaI;
                cantidadDiasEnco = 0;
                while (fecha < searchFechaFin)
                {
                    encontrado = false;
                    while (r < AResult[a].RangosFechas.Count && encontrado == false)
                    {
                        if(AResult[a].RangosFechas[r].FechaInicio <= fecha && AResult[a].RangosFechas[r].FechaFin >= fecha)
                        {   
                            encontrado = true;
                            cantidadDiasEnco += 1;
                        }
                        else
                        {
                            r++;
                        }
                        
                    }
                    fecha = fecha.AddDays(1);
                }
                if (cantidadDiasRango == cantidadDiasEnco)
                {
                    ListaResultado.Add(AResult[a]);
                }
                a++;

            }
            
            return ListaResultado.AsQueryable();
        }
    }
}
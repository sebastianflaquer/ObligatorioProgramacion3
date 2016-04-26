using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Anuncio : Persistente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Alojamiento alojamiento { get; set; }
        public string descripcion { get; set; }
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }
        public string fotos { get; set; }
        public decimal precioBase { get; set; }
        public List<RangoFechas> rangosFechas { get; set; }

        //LEER
        public override bool Leer()
        {
            throw new NotImplementedException();
        }

        //GUARDAR
        public override bool Guardar()
        {
            throw new NotImplementedException();
        }

        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR
        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}

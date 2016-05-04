using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DTOs
{
    [DataContract]
    public class DTOanuncio
    {
        private int id;
        private DTOalojamiento alojamiento;
        private string descripcion;
        private string direccion1;
        private decimal precioBase;
        private DTOregistrado registrado;

        [DataMember]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public DTOregistrado Registrado
        {
            get { return this.registrado; }
            set { this.registrado = value; }
        }

        [DataMember]
        public decimal PrecioBase
        {
            get { return this.precioBase; }
            set { this.precioBase = value; }
        }

        [DataMember]
        public DTOalojamiento Alojamiento
        {
            get { return this.alojamiento; }
            set { this.alojamiento = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        [DataMember]
        public string Direccion1
        {
            get { return this.direccion1; }
            set { this.direccion1 = value; }
        }

    }
}

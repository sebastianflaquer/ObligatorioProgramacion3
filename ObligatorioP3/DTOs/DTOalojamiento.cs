using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DTOs
{
    [DataContract]
    public class DTOalojamiento
    {
        private int id;
        private string nombre;

        [DataMember]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
    }
}

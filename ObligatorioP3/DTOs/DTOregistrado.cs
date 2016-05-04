using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DTOs
{
    [DataContract]
    public class DTOregistrado
    {
        private int id;
        private string nombre;
        private string apellido;
        private string mail;


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

        [DataMember]
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        [DataMember]
        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
    }
}

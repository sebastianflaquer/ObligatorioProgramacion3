using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public abstract class Persistente
    {
        private static string stringConexion = "";

        public static string StringConexion
        {
            get
            {
                return stringConexion;
            }

            set
            {
                stringConexion = value;
            }
        }

        public abstract bool Leer();
        public abstract bool Guardar();
        public abstract IEnumerable<Object> TraerTodo();
        public abstract bool Modificar();
        public abstract bool Eliminar();
    }
}

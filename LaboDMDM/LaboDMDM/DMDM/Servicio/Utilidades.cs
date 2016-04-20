using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Pesistencia;

namespace Auxiliar
{
    public static class Utilidades
    {
        public static void SetConnectionString(string conStr)
        {
            DataMapper.StringConexion = conStr;
        }
        public static IProductoMapper MapperProducto()
        {
            //Aquí iría la lógica de cuál mapper para productos crear si existieran varias posibilidades
            //por ejemplo uno para sql server y otro para otro proveedor, etc.
            return new ProductoMapper();
        }
    }
}

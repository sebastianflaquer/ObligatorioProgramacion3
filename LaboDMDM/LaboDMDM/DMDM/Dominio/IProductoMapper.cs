using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IProductoMapper : IMapper<Producto>
    {
        //LO ADICIONAL Y ESPECÍFICO DE PRODUCTOS SI TIENEN
        //POR EJEMPLO CONSULTAS CON FILTROS, ETC.
        List<Producto> ProductosPrecioMayorA(decimal precio);
    }
}

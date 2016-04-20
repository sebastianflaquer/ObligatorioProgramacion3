using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IMapper<T>
    {
        bool Leer(T obj);
        bool Guardar(T obj);
        bool Eliminar(T obj);
        bool Actualizar(T obj);
        List<T> Todos();
        //...
        //...
        //ETC. LO COMÚN A TODOS LOS MAPPERS CONCRETOS
    }
}

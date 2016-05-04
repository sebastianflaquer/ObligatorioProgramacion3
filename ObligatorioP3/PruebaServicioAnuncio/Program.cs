using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaServicioAnuncio.ServiceReference1;

namespace PruebaServicioAnuncio
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client proxy = new Service1Client("BasicHttpBinding_IService1");          ;
            proxy.Open();
            DTOanuncio[] anuncios = proxy.ObtenerAnuncios();
            proxy.Close();

            foreach (DTOanuncio a in anuncios)
            {
                Console.WriteLine("ID ANUNCIO: " + a.Id + " " + "DESCRIPCION: " + a.Descripcion 
                    + " " + "DIRECCION: " + a.Direccion1 + " " + "PRECIO: " + a.PrecioBase + " " + "ALOJAMIENTO: " + a.Alojamiento.Nombre
                    + " " + "USUARIO: " + a.Registrado.Nombre);
            }

            Console.ReadLine();
        }
    }
}

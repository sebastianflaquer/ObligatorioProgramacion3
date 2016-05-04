using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOs;
using DAL;

namespace WcfServicioAnuncio
{
   
    public class Service1 : IServicioAnuncios
    {
        public List<DTOanuncio> ObtenerAnuncios()
        {
            return Datos.Anuncios();
        }
    }
}

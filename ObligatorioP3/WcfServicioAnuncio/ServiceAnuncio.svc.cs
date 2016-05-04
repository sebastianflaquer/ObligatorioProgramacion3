using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTOs;

namespace WcfServicioAnuncio
{
    
    public class ServiceAnuncio : IServiceAnuncio
    {
        [OperationContract]
        List<DTOanuncio> ObtenerAnuncios();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOs;

namespace WcfService2
{
   
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<DTOanuncio> ObtenerAnuncios();
    }
}

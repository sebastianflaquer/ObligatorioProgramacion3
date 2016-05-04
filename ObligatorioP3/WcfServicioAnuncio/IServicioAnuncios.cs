﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOs;

namespace WcfServicioAnuncio
{
    
    [ServiceContract]
    public interface IServicioAnuncios
    {

        [OperationContract]
        List<DTOanuncio> ObtenerAnuncios();

    }
}

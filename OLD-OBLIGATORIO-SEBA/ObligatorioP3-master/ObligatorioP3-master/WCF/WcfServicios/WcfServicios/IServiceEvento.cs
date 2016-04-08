using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceEvento
    {




        //[OperationContract]
        //string GetData(int value);

        [OperationContract]
        List<WSEvento> ListarEventos();

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class WSEvento
    {
        int idEvento = -1;
        String titulo = String.Empty;

        //bool boolValue = true;
        //string stringValue = "Hello ";

        [DataMember]
        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        [DataMember]    
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
    }
}

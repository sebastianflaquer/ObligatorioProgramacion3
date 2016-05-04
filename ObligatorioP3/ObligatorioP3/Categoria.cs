using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public class Categoria : Persistente
    {

        #region atributos

        public int id { get; set; }
        public string nombre { get; set; }

        #endregion
        
        //CARGAR CATEGORIAS
        public List<Categoria> CargarCategorias(){

            List<Categoria> L1 = new List<Categoria>();

            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CargarCategorias";
                //cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
                while (drResults.Read())
                {
                    Categoria cat = new Categoria();
                    cat.id = Convert.ToInt32(drResults["Id"]);
                    cat.nombre = Convert.ToString(drResults["Nombre"]);
                    L1.Add(cat);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
                //if (reader != null) reader.Close();
            }

            return L1;
        }

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        //GUARDAR
        public override bool Guardar()
        {
            throw new NotImplementedException();
        }

        //LEER
        public override bool Leer()
        {
            bool retorno = false;

            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeerCategoria";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    this.id = Convert.ToInt32(drResults["id"]);
                    this.nombre = drResults["nombre"].ToString();

                    retorno = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }

            return retorno;
        }

        //MODIFICAR
        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }
        
    }
}

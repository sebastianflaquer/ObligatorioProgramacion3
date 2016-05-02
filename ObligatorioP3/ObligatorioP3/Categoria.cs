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
        
        public List<Categoria> CargarCategorias(){

            List<Categoria> L1 = new List<Categoria>();

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

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
                //if (con != null && con.State == ConnectionState.Open) con.Close();
                //if (reader != null) reader.Close();
            }

            return L1;
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Guardar()
        {
            throw new NotImplementedException();
        }

        public override bool Leer()
        {
            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;


                int id = this.id;
                string nombre = this.nombre;

                if (nombre != null)
                {
                    cmd.CommandText = "LeerCategoria";
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));   
                }
                else
                {
                    cmd.CommandText = "LeerCategoriaXId";
                    cmd.Parameters.Add(new SqlParameter("@id", this.id));
                }

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    id = Convert.ToInt32(drResults["id"]);
                    nombre = drResults["nombre"].ToString();

                    retorno = true;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //if (con != null && con.State == ConnectionState.Open) con.Close();
                //if (reader != null) reader.Close();
            }

            return retorno;
        }

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

        public bool LeerPorId(){

            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeerCategoriaXId";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    id = Convert.ToInt32(drResults["id"]);
                    nombre = drResults["nombre"].ToString();

                    retorno = true;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //if (con != null && con.State == ConnectionState.Open) con.Close();
                //if (reader != null) reader.Close();
            }

            return retorno;
        }

    }
}

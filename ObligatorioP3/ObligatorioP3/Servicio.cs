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
    public class Servicio : Persistente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        
        //Carga las lista de Servicios desde la DB
        public List<Servicio> CargarServicios()
        {
            List<Servicio> L1 = new List<Servicio>();

            //creamos la conexion
            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CargarServicios";

            SqlDataReader drResults;


            try
            {

                cmd.Connection = cn;
                cn.Open();
                //todo lo que lee queda en drResults 
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (drResults.Read())
                {
                    Servicio serv = new Servicio();
                    serv.id = Convert.ToInt32(drResults["id"]);
                    serv.nombre = drResults["nombre"].ToString();
                    serv.descripcion = drResults["descripcion"].ToString();
                    L1.Add(serv);

                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
                //if (drResults != null) drResults.Close();
            }
            return L1;

        }
        
        //LEER 
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
                cmd.CommandText = "LeerServicio";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    id = Convert.ToInt32(drResults["id"]);
                    nombre = drResults["nombre"].ToString();
                    descripcion = drResults["descripcion"].ToString();

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
        
        //GUARDAR
        public override bool Guardar()
        {

            SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            bool ok = false;
            int afectadas = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "NuevoServicio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));  
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                if (afectadas != -1)
                {
                    ok = false;
                }
                else {
                    ok = true;
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

            return ok;


            //bool retorno = false;

            //try
            //{
            //    List<SqlParameter> pars = new List<SqlParameter>();

            //    SqlParameter par = new SqlParameter();

            //    //esto se utiliza si queremos retornar el ID
            //    //par.ParameterName = "@NuevoId";
            //    //par.SqlDbType = SqlDbType.Int;
            //    //par.Direction = ParameterDirection.Output;

            //    pars.Add(par);

            //    int afectadas = this.EjecutarNoQuery("RegistroUsuario", CommandType.StoredProcedure, pars);
            //    retorno = afectadas == 1;

            //    //esto se utiliza si queremos retornar el ID
            //    //if (retorno) this.Id = (int)par.Value;
            //}
            //catch
            //{
            //    throw;
            //}
            //
        }
        
        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR
        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        public List<Servicio> CargarServiciosPorAlojamiento(int idAloj)
        {
            List<Servicio> lista = new List<Servicio>();

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ServiciosPorAlojamiento";
                cmd.Parameters.Add(new SqlParameter("@idAlojamiento", idAloj));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
                while (drResults.Read())
                {
                    Servicio serv = new Servicio();
                    serv.id = Convert.ToInt32(drResults["Id"]);
                    serv.nombre = Convert.ToString(drResults["Nombre"]);
                    lista.Add(serv);
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

            return lista;
        }

    }
}

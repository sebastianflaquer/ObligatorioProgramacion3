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
    public class Registrado : Persistente
    {

        #region atributos

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        //public List<Alojamiento> alojamientos { get; set; }
        //public static object Instancia { get; set; }

        #endregion

        //LEER USUARIO
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
                cmd.CommandText = "LeerUsuario";
                cmd.Parameters.Add(new SqlParameter("@mail", this.mail));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    id =  Convert.ToInt32(drResults["id"]);
                    nombre = drResults["nombre"].ToString();
                    apellido = drResults["apellido"].ToString();
                    mail = drResults["mail"].ToString();
                    password = drResults["password"].ToString();
                    salt = password = drResults["salt"].ToString();
                    foto = drResults["foto"].ToString();
                    direccion = drResults["direccion"].ToString();
                    celular = drResults["celular"].ToString();
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
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            
            return retorno;
        }

        //GUARDAR
        public override bool Guardar()
        {
            //creamos un nuevo objeto SqlConnection
            SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
            //creamos una variable de tipo string que guarda la cadena de conexion
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            //le pasamos a la SqlConnection la cadena de conexion (ConnectionString)
            cn.ConnectionString = cadenaConexion;


            //Variables
            bool ok = false;
            int afectadas = 0;


            try{
                using (SqlCommand cmd = new SqlCommand()) {
                    cmd.Connection = cn;
                    cmd.CommandText = "RegistroUsuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", this.apellido));
                    cmd.Parameters.Add(new SqlParameter("@mail", this.mail));
                    cmd.Parameters.Add(new SqlParameter("@password", this.password));
                    cmd.Parameters.Add(new SqlParameter("@salt", this.salt.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@direccion", this.direccion));
                    cmd.Parameters.Add(new SqlParameter("@celular", this.celular));
                    cmd.Parameters.Add(new SqlParameter("@foto", this.foto));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                if (afectadas != -1){
                    ok = false;
                }
                else{
                    ok = true;
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

            return ok;
        }

        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR
        public override bool Modificar()
        {
            bool retorno = false;

            SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {                
                int afectadas = 0;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "ModificarUsuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", this.id));
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", this.apellido));
                    cmd.Parameters.Add(new SqlParameter("@mail", this.mail));
                    cmd.Parameters.Add(new SqlParameter("@direccion", this.direccion));
                    cmd.Parameters.Add(new SqlParameter("@foto", this.foto));
                    cmd.Parameters.Add(new SqlParameter("@celular", this.celular));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();
                    cn.Close();

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

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        //COMPROBAR CONTRASEÑA
        public string ComprobarPass()
        {
            string retorno = "";

            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ComprobarPassword";
                cmd.Parameters.Add(new SqlParameter("@mail", this.mail));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    retorno = drResults["password"].ToString();
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

        //SE FIJA SI EXISTE EL USUARIO
        public bool ExisteUsuario(string UserName, string Password)
        {
            bool retorno = false;

            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeerUsuario";
                cmd.Parameters.Add(new SqlParameter("@mail", this.mail));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    string mail = drResults["mail"].ToString();
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
        
    }
}

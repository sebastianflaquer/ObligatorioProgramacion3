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
        public string direccion { get; set; }
        public string celular { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        public List<Anuncio> anuncios { get; set; }
        public List<Reserva> reservas { get; set; }
        //public static object Instancia { get; set; }

        #endregion

        //Lo instanciamos para poder usarlo
        public static Registrado mInstancia;
        public static Registrado Instancia
        {
            get
            {
                if (Registrado.mInstancia == null)
                {
                    Registrado.mInstancia = new Registrado();
                }
                return Registrado.mInstancia;
            }
        }

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
                //if (reader != null) reader.Close();
            }
            
            return retorno;

            //bool retorno = false;
            //SqlConnection con = null;
            //SqlDataReader reader = null;

            //try
            //{
            //    con = new SqlConnection(Persistente.StringConexion);
            //    List<SqlParameter> pars = new List<SqlParameter>();
            //    pars.Add(new SqlParameter("@Id", this.id));

            //    con.Open();
            //    reader = this.EjecutarQuery(con, "ProductoPorId", CommandType.StoredProcedure, pars);

            //    if (reader.Read())
            //    {
            //        this.nombre = reader["Nombre"].ToString();
            //        retorno = true;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (con != null && con.State == ConnectionState.Open) con.Close();
            //    if (reader != null) reader.Close();
            //}

        }

        //GUARDAR
        public override bool Guardar()
        {

            SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

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

        //MODIFICAR
        public override bool Modificar()
        {
            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;
                
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

            try
            {
                SqlConnection cn = new SqlConnection();
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

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
            return retorno;
        }

        //SE FIJA SI EXISTE EL USUARIO
        public bool ExisteUsuario(string UserName, string Password)
        {
            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection();
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

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
                //if (con != null && con.State == ConnectionState.Open) con.Close();
                //if (reader != null) reader.Close();
            }

            return retorno;


            //    int retorno = -1;
            //    SqlConnection con = null;
            //    SqlDataReader reader = null;

            //    try
            //    {
            //        con = new SqlConnection(Persistente.StringConexion);
            //        List<SqlParameter> pars = new List<SqlParameter>();
            //        //pars.Add(new SqlParameter("@Id", this.id));
            //        pars.Add(new SqlParameter("@mail", this.mail));

            //        con.Open();
            //        //reader = this.EjecutarQuery(con, "Registrado_BuscarRegistrado", CommandType.StoredProcedure, pars);
            //        //reader = this.EjecutarQuery(con, "Login", CommandType.StoredProcedure, pars);

            //        if (reader.Read())
            //        {
            //            //this.nombre = reader["Nombre"].ToString();
            //            this.mail = reader["Mail"].ToString();
            //            retorno = this.id;
            //        }
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            //    finally
            //    {
            //        if (con != null && con.State == ConnectionState.Open) con.Close();
            //        if (reader != null) reader.Close();
            //    }

            //    return retorno;

            //}


        }




    }
}

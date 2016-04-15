using System;
using System.Collections.Generic;
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
            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(Persistente.StringConexion);
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@Id", this.id));

                con.Open();
                reader = this.EjecutarQuery(con, "ProductoPorId", CommandType.StoredProcedure, pars);

                if (reader.Read())
                {
                    this.nombre = reader["Nombre"].ToString();
                    retorno = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (reader != null) reader.Close();
            }

            return retorno;
        }
        
        //GUARDAR
        public override bool Guardar()
        {
            //bool retorno = false;

            //try
            //{
            //    List<SqlParameter> pars = new List<SqlParameter>();
            //    pars.Add(new SqlParameter("@Nombre", this.Nombre));
            //    pars.Add(new SqlParameter("@Precio", this.Precio));
            //    SqlParameter par = new SqlParameter();
            //    par.ParameterName = "@NuevoId";
            //    par.SqlDbType = SqlDbType.Int;
            //    par.Direction = ParameterDirection.Output;
            //    pars.Add(par);

            //    int afectadas = this.EjecutarNoQuery("NuevoProducto", CommandType.StoredProcedure, pars);
            //    retorno = afectadas == 1;

            //    if (retorno) this.Id = (int)par.Value;
            //}
            //catch
            //{
            //    throw;
            //}
            bool retorno = true;
            return retorno;
        }

        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR
        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        //SE FIJA SI EXISTE EL USUARIO - ESTO ES ESTATICO PORQUE ES UN METODO DE CLASE
        public static int ExisteUsuario( string UserName , string Password) {

            int retorno = -1;
            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(Persistente.StringConexion);
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@Id", this.id));

                con.Open();
                reader = this.EjecutarQuery(con, "Registrado_BuscarRegistrado", CommandType.StoredProcedure, pars);

                if (reader.Read())
                {
                    this.nombre = reader["Nombre"].ToString();
                    retorno = this.id;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (reader != null) reader.Close();
            }

            return retorno;

        }
    }
}

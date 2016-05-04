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
    public class RangoFechas : Persistente
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal precio { get; set; }

        public string Listado
        {

            get { return "Fecha Inicio: " + this.fechaInicio.Date.ToString("dd/mm/yyyy") + ", Fecha Fin: " + this.fechaFin.Date.ToString("dd/mm/yyyy") + " - Precio: " + this.precio.ToString(); }
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
                cmd.CommandText = "LeerRangoFecha";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    id = Convert.ToInt32(drResults["id"]);
                    precio = Convert.ToDecimal(drResults["precio"]);
                    fechaInicio = Convert.ToDateTime(drResults["fechaIni"]);
                    fechaFin = Convert.ToDateTime(drResults["fechaFin"]);

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
                    cmd.CommandText = "NuevoRangoFechas";//FALTA ID DEL ANUNCIO EN EL SP !!!!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", this.fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", this.fechaFin));
                    cmd.Parameters.Add(new SqlParameter("@precio", this.precio));
                    //cmd.Parameters.Add(new SqlParameter("@idAnuncio", this.Anuncio.id));
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
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }

            return ok;
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

        //CARGAR RANGO FECHA DE ANUNCIO
        public List<RangoFechas> CargarRangosFechaDeAnuncio(int idAnuncio)
        {
            List<RangoFechas> lista = new List<RangoFechas>();

            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RangoFechasPorAnuncio";
                cmd.Parameters.Add(new SqlParameter("@idAnuncio", idAnuncio));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
                while (drResults.Read())
                {
                    RangoFechas rf = new RangoFechas();
                    rf.id = Convert.ToInt32(drResults["id"]);
                    rf.fechaInicio = Convert.ToDateTime(drResults["fechaInicio"]);
                    rf.fechaFin = Convert.ToDateTime(drResults["fechaFin"]);
                    rf.precio = Convert.ToDecimal(drResults["precio"]);
                    lista.Add(rf);
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

            return lista;
        }

        //AGREGAR UN RANGO FECHA A UN ANUNCIO
        public bool AgregarRangoFechaAlAnuncio(int idAnuncio)
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
                    cmd.CommandText = "INSERT INTO RANGOFECHAS VALUES (@fechaIni, @fechaFin, @precio, @idAnuncio)";
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", this.fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", this.fechaFin));
                    cmd.Parameters.Add(new SqlParameter("@precio", this.precio));
                    cmd.Parameters.Add(new SqlParameter("@idAnuncio", idAnuncio));
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                if (afectadas != -1)
                {
                    ok = true;
                }
                else {
                    ok = false;
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


        //QUITA UN RANGO FECHA DE UN ANUNCIO
        public bool QuitarRangoFechaDeAnuncio()
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
                    cmd.CommandText = "DELETE FROM RANGOFECHAS WHERE id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", this.id));
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                if (afectadas != -1)
                {
                    ok = true;
                }
                else {
                    ok = false;
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
    }
}

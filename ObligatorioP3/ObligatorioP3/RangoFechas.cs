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
                    cmd.CommandText = "NuevoRangoFechas";                        //FALTA ID DEL ANUNCIO EN EL SP !!!!
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaIni", this.fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", this.fechaFin));
                    cmd.Parameters.Add(new SqlParameter("@precio", this.precio));
                    //  cmd.Parameters.Add(new SqlParameter("@idAnuncio", this.Anuncio.id));
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

    }
}

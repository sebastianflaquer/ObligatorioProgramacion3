using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienvenidosUY
{
    public abstract class Persistente
    {
        private static string stringConexion = "";

        public static string StringConexion
        {
            get
            {
                return stringConexion;
            }

            set
            {
                stringConexion = value;
            }
        }

        public abstract bool Leer();
        public abstract bool Guardar();
        public abstract IEnumerable<Object> TraerTodo();
        public abstract bool Modificar();
        public abstract bool Eliminar();


        //METODO GENERAL EJECUTA EL QUERY.
        public SqlDataReader EjecutarQuery(SqlConnection con, string text, CommandType tipo, List<SqlParameter> parametros)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand comando = new SqlCommand(text, con);
                comando.CommandType = tipo;
                //AddRange copia las referencias de la lista. Recibe un array de sqlParameter
                comando.Parameters.AddRange(parametros.ToArray());
                reader = comando.ExecuteReader();
            }
            catch
            {
                throw;
            }

            return reader;
        }

        //METODO GENERAL QUE EJECUTA EL NOQUERY
        public int EjecutarNoQuery(string text, CommandType tipo, List<SqlParameter> parametros)
        {
            int afectadas = -1;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(Persistente.stringConexion);
                SqlCommand comando = new SqlCommand(text, con);
                comando.CommandType = tipo;
                //AddRange copia las referencias de la lista. Recibe un array de sqlParameter
                comando.Parameters.AddRange(parametros.ToArray());
                con.Open();
                afectadas = comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }

            return afectadas;
        }
        
    }
}

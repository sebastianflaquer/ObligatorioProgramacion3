using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Pesistencia
{
    public abstract class DataMapper
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

        public virtual bool Leer(object obj)
        {
            bool retorno = false;

            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(DataMapper.StringConexion);
                SqlCommand com = new SqlCommand(this.SPBuscarPorId(), con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", this.ObtenerId(obj));
                con.Open();
                reader = com.ExecuteReader();
                this.CargarDatos(obj, reader);
                retorno = true;
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

        public virtual bool Guardar(object obj)
        {
            bool retorno = false;
            SqlConnection con = null;            

            try
            {
                con = new SqlConnection(DataMapper.StringConexion);
                con.Open();
                SqlCommand com = new SqlCommand(this.SPNuevo(), con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddRange(this.ParametrosNuevo(obj).ToArray());

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@NuevoId";
                parId.SqlDbType = SqlDbType.Int;
                parId.Direction = ParameterDirection.Output;

                com.Parameters.Add(parId);

                int afectadas = com.ExecuteNonQuery();
                retorno = afectadas == 1;


                if (retorno) this.CargarId(obj, (int)parId.Value);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }

            return retorno;            
        }

        public virtual bool Eliminar(Object obj)
        {
            bool retorno = false;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(DataMapper.StringConexion);
                con.Open();
                SqlCommand com = new SqlCommand(this.SPElimina(), con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", this.ObtenerId(obj));

                int afectadas = com.ExecuteNonQuery();
                retorno = (afectadas == 1);

                //com.Parameters.Add("@id", ObtenerId(obj));
                //com.Parameters.AddRange(this.ParametrosNuevo(obj).ToArray());

                //SqlParameter parId = new SqlParameter();
                //parId.ParameterName = "@id";

            }
            catch
            {

            }
            finally
            {

            }

            return retorno;
            
        }

        public virtual bool Actualizar(Object obj)
        {
            bool retorno = false;
            SqlConnection con = null;

            try
            {
                con = new SqlConnection(DataMapper.StringConexion);
                con.Open();
                SqlCommand com = new SqlCommand(this.SPmodificar(), con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddRange(this.ParametrosActualizar(obj).ToArray());
                int afectadas = com.ExecuteNonQuery();
                retorno = (afectadas == 1);

            }
            catch
            {

            }
            finally
            {

            }

            return retorno;

        }

        public virtual IEnumerable<Object> Todos()
        {
            throw new NotImplementedException();
        }
               

        protected abstract void CargarDatos(Object obj, SqlDataReader reader);
        protected abstract string SPBuscarPorId();
        protected abstract string SPNuevo();
        protected abstract string SPTodos();

        protected abstract string SPElimina();

        protected abstract string SPmodificar();
        protected abstract List<SqlParameter> ParametrosNuevo(Object obj);

        protected abstract List<SqlParameter> ParametrosActualizar(Object obj);

        protected abstract void CargarId(Object obj, int Id);
        protected abstract int ObtenerId(Object obj);
    }
}

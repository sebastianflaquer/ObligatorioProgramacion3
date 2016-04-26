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
    public class Alojamiento : Persistente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Categoria categoria { get; set; }
        public string tipoHabitacion { get; set; }
        public bool banioPrivado { get; set; }
        public int cantHuespedes { get; set; }
        public Ciudad ciudad { get; set; }
        public string barrio { get; set; }
        public List<Servicio> servicios { get; set; }
        public int calificacion { get; set; }

        public override bool Leer()
        {
            throw new NotImplementedException();
        }

        public override bool Guardar()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }

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
                    cmd.CommandText = "ModificarAlojamiento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", this.id));
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@idCategoria", this.categoria.id));
                    cmd.Parameters.Add(new SqlParameter("@tipoHabitacion", this.tipoHabitacion));
                    cmd.Parameters.Add(new SqlParameter("@banioPrivado", this.banioPrivado));
                    cmd.Parameters.Add(new SqlParameter("@cantHuespedes", this.cantHuespedes));
                    cmd.Parameters.Add(new SqlParameter("@barrio", this.barrio));
                    cmd.Parameters.Add(new SqlParameter("@calificacion", this.calificacion));
                    cmd.Parameters.Add(new SqlParameter("@idCiudad", this.ciudad.id));
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

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }
    


    public List<Alojamiento> CargarAlojamientosPorUsuario(string MailRegistrado)
    {

        List<Alojamiento> L1 = new List<Alojamiento>();

        try
        {
            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AlojamientosPorUsuario";
            cmd.Parameters.Add(new SqlParameter("@mail", MailRegistrado));

            SqlDataReader drResults;

            cmd.Connection = cn;
            cn.Open();
            drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
            while (drResults.Read())
            {
                Alojamiento aloj = new Alojamiento();
                aloj.id = Convert.ToInt32(drResults["id"]);
                aloj.nombre = drResults["nombre"].ToString();
                //Categoria cat = new Categoria();
                //cat.id = Convert.ToInt32(drResults["IdCategiria"]);
                    //cat.Leer();
                //aloj.categoria = cat;
                //aloj.tipoHabitacion = drResults["tipoHabitacion"].ToString();
                //aloj.banioPrivado = Convert.ToBoolean(drResults["banioPrivado"]);
                //aloj.cantHuespedes = Convert.ToInt32(drResults["cantHuespedes"]);
                //Ciudad ciud = new Ciudad();
                //ciud.id = Convert.ToInt32(drResults["idCiudad"]);
                //    ciud.Leer();
                //aloj.ciudad = ciud;
                //aloj.barrio = drResults["barrio"].ToString();
                //aloj.calificacion = Convert.ToInt32(drResults["calificacion"]);
                L1.Add(aloj);
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

    }
}

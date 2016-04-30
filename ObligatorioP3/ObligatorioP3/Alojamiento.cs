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
        public Registrado registrado { get; set; }

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
                cmd.CommandText = "LeerAlojamiento";
                cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));    //NO SE PUEDE REPETIR EL NOMBRE DE ALOJAMIENTOS PARA UN MISMO USUARIO

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    this.id = Convert.ToInt32(drResults["id"]);
                    this.nombre = drResults["nombre"].ToString();
                    this.categoria = new Categoria() { id = Convert.ToInt32(drResults["idCategoria"]) };
                    this.tipoHabitacion = drResults["tipoHabitacion"].ToString();
                    this.banioPrivado = Convert.ToBoolean(drResults["banioPrivado"]);
                    this.cantHuespedes = Convert.ToInt32(drResults["cantHuespedes"]);
                    this.barrio = drResults["barrio"].ToString();
                    this.calificacion = Convert.ToInt32(drResults["calificacion"]);
                    this.ciudad = new Ciudad() { id = Convert.ToInt32(drResults["idCiudad"]) };
                    this.registrado = new Registrado() { id = Convert.ToInt32(drResults["idRegistrado"]) };


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
            SqlTransaction trans = null;

            bool retorno = false;
            int afectadas = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "NuevoAlojamiento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@idCategoria", this.categoria.id));
                    cmd.Parameters.Add(new SqlParameter("@tipoHabitacion", this.tipoHabitacion));
                    cmd.Parameters.Add(new SqlParameter("@banioPrivado", this.banioPrivado));
                    cmd.Parameters.Add(new SqlParameter("@cantHuespedes", this.cantHuespedes));
                    cmd.Parameters.Add(new SqlParameter("@idCiudad", this.ciudad.id));
                    cmd.Parameters.Add(new SqlParameter("@barrio", this.barrio));
                    //cmd.Parameters.Add(new SqlParameter("@servicios", this.servicios));
                    cmd.Parameters.Add(new SqlParameter("@calificacion", this.calificacion));
                    cmd.Parameters.Add(new SqlParameter("@idRegistrado", this.registrado.id));
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@NuevoId";
                    par.SqlDbType = SqlDbType.Int;
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();


                    if (afectadas == 1)
                    {
                        this.id = (int)par.Value;
                        cmd.CommandText = "NuevoServicio";
                        bool ok = true;
                        int i = 0;
                        while (i < this.servicios.Count && ok)
                        {
                            Servicio serv = this.servicios[i];

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IdAlojamiento", this.id);
                            cmd.Parameters.AddWithValue("@nombre", serv.nombre);
                            cmd.Parameters.AddWithValue("@descripcion", serv.descripcion);
                            ok = cmd.ExecuteNonQuery() == 1;
                            i++;
                        }

                        if (ok)
                        {
                            trans.Commit();
                            retorno = true;
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                }
            }
            catch
            {
                if (trans != null) trans.Rollback();
                throw;
            }
        
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
                //if (reader != null) reader.Close();
            }

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

        public List<Alojamiento> CargarAlojamientosPorUsuario(string mail)
        {
            List<Alojamiento> lista = new List<Alojamiento>();

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlojamientosPorUsuario";
                cmd.Parameters.Add(new SqlParameter("@mail", mail));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
                while (drResults.Read())
                {
                    Alojamiento aloj = new Alojamiento();
                    aloj.id = Convert.ToInt32(drResults["Id"]);
                    aloj.nombre = Convert.ToString(drResults["Nombre"]);
                    lista.Add(aloj);
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

        public bool ComprobarNombreAlojamiento(string nomAloj, int idRegistrado)
        {
            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection();
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeerAlojamientoPorUsuario";
                cmd.Parameters.Add(new SqlParameter("@nombre", nomAloj));
                cmd.Parameters.Add(new SqlParameter("@idRegistrado", idRegistrado));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    string nombreAlojamiento = drResults["nombre"].ToString();
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

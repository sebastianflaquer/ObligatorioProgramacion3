using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DTOs;




namespace DAL
{
    public class Datos
    {
        public static List<DTOanuncio> Anuncios()
        {
            List<DTOanuncio> anuncios = new List<DTOanuncio>();


            string sql_anuncios = "SELECT * FROM ANUNCIO";
            string sql_alojamientos = "SELECT A.* FROM ALOJAMIENTO A, ANUNCIO A2 WHERE A.id = A2.idAlojamiento AND A2.id = @idAnuncio";
            string sql_registrados = "SELECT R.* FROM REGISTRADO R, ANUNCIO A WHERE A.idRegistrado = R.id AND A.id = @idAnuncio";

            SqlConnection con = null;
            SqlConnection con2 = null;
            SqlConnection con3 = null;

            SqlDataReader reader_anuncios = null;
            SqlDataReader reader_alojamientos = null;
            SqlDataReader reader_registrados = null;

            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

                //ANUNCIOS
                con = new SqlConnection(conStr);
                SqlCommand com = new SqlCommand(sql_anuncios, con);
                con.Open();
                reader_anuncios = com.ExecuteReader();

                if (reader_anuncios != null)
                {
                    while (reader_anuncios.Read())
                    {
                        DTOanuncio a = new DTOanuncio();
                        a.Id = (int)reader_anuncios["id"];
                        a.Descripcion = reader_anuncios["descripcion"].ToString();
                        a.Direccion1 = reader_anuncios["direccion1"].ToString();
                        a.PrecioBase = (decimal)reader_anuncios["precioBase"];
                        
                        //ALOJAMIENTOS

                        con2 = new SqlConnection(conStr);
                        SqlCommand com2 = new SqlCommand(sql_alojamientos, con2);
                        com2.Parameters.AddWithValue("@IdAnuncio", a.Id);
                        con2.Open();
                        reader_alojamientos = com2.ExecuteReader();

                        if (reader_alojamientos.Read())
                        {
                            DTOalojamiento al = new DTOalojamiento();
                            //al.Id = a.Alojamiento.Id;
                            al.Nombre = reader_alojamientos["nombre"].ToString();

                            a.Alojamiento = al;
                        }


                        //REGISTRADO
                        con3 = new SqlConnection(conStr);
                        SqlCommand com3 = new SqlCommand(sql_registrados, con3);
                        com3.Parameters.AddWithValue("@IdAnuncio", a.Id);
                        con3.Open();
                        reader_registrados = com3.ExecuteReader();

                        if (reader_registrados.Read())
                        {
                            DTOregistrado r = new DTOregistrado();
                            //r.Id = a.Registrado.Id;
                            r.Nombre = reader_registrados["nombre"].ToString();
                            r.Apellido = reader_registrados["apellido"].ToString();
                            r.Mail = reader_registrados["mail"].ToString();

                            a.Registrado = r;
                        }

                        anuncios.Add(a);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (con2 != null && con2.State == ConnectionState.Open) con2.Close();
                if (con3 != null && con3.State == ConnectionState.Open) con3.Close();

                if (reader_anuncios != null && !reader_anuncios.IsClosed) reader_anuncios.Close();
                if (reader_alojamientos != null && !reader_alojamientos.IsClosed) reader_alojamientos.Close();
                if (reader_registrados != null && !reader_registrados.IsClosed) reader_registrados.Close();
            }

            return anuncios;
        }


    }
}

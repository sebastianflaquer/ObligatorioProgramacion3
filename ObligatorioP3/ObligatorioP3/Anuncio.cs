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
    public class Anuncio : Persistente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Alojamiento alojamiento { get; set; }
        public string descripcion { get; set; }
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }
        public string fotos { get; set; }
        public decimal precioBase { get; set; }
        public List<RangoFechas> rangosFechas { get; set; }
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
                cmd.CommandText = "LeerAnuncio";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));    
                
                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    this.id = Convert.ToInt32(drResults["id"]);
                    this.nombre = drResults["nombre"].ToString();
                    this.alojamiento = new Alojamiento() { id = Convert.ToInt32(drResults["idAlojamiento"]) };
                    this.descripcion = drResults["descripcion"].ToString();
                    this.direccion1 = drResults["direccion1"].ToString();
                    this.direccion2 = drResults["direccion2"].ToString();
                    //this.fotos = drResults ...
                    this.precioBase = Convert.ToDecimal(drResults["precioBase"]);
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
            //SqlTransaction trans = null;

            bool retorno = false;
            int afectadas = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "NuevoAnuncio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@idAlojamiento", this.alojamiento.id));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));
                    cmd.Parameters.Add(new SqlParameter("@direccion1", this.direccion1));
                    cmd.Parameters.Add(new SqlParameter("@direccion2", this.direccion2));
                    cmd.Parameters.Add(new SqlParameter("@fotos", this.fotos));
                    cmd.Parameters.Add(new SqlParameter("@preciobase", this.precioBase));
                    cmd.Parameters.Add(new SqlParameter("@idRegistrado", this.registrado.id));
                    //cmd.Parameters.Add(new SqlParameter("@rangoFechas", this.rangosFechas));

                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@nuevoId";
                    par.SqlDbType = SqlDbType.Int;
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);
                    cn.Open();

                    //creamos la transaction TR        
                    SqlTransaction tr = cn.BeginTransaction();
                    //Le pasamos al CMD la transaction
                    cmd.Transaction = tr;

                    afectadas = cmd.ExecuteNonQuery();


                    if (afectadas == 1)
                    {
                        this.id = (int)par.Value;
                        cmd.CommandText = "NuevoRangoFechas";
                        bool ok = true;
                        int i = 0;
                        while (i < this.rangosFechas.Count && ok)
                        {
                            RangoFechas rf = this.rangosFechas[i];

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IdAnuncio", this.id);
                            cmd.Parameters.AddWithValue("@fechaIni", rf.fechaInicio);
                            cmd.Parameters.AddWithValue("@fechaFin", rf.fechaFin);
                            cmd.Parameters.AddWithValue("@precio", rf.precio);
                            ok = cmd.ExecuteNonQuery() == 1;
                            i++;
                        }

                        if (ok)
                        {
                            tr.Commit();
                            retorno = true;
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
            }
            catch
            {
                //if (tr != null) tr.Rollback();
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
            bool retorno = false;
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(); //creamos y configuramos la conexion
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                int afectadas = 0;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "ModificarAnuncio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", this.id));
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@idAlojamiento", this.alojamiento.id));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));
                    cmd.Parameters.Add(new SqlParameter("@direccion1", this.direccion1));
                    cmd.Parameters.Add(new SqlParameter("@direccion2", this.direccion2));
                    cmd.Parameters.Add(new SqlParameter("@fotos", this.fotos));
                    cmd.Parameters.Add(new SqlParameter("@precioBase", this.precioBase));
                    //cmd.Parameters.Add(new SqlParameter("@idRegistrado", this.registrado.id));
                    //cmd.Parameters.Add(new SqlParameter("@rangoFechas", this.rangosFechas));
                    cn.Open();

                    //creamos la transaction TR        
                    SqlTransaction tr = cn.BeginTransaction();
                    //Le pasamos al CMD la transaction
                    cmd.Transaction = tr;

                    afectadas = cmd.ExecuteNonQuery();

                    if (afectadas == 1)
                    {
                        cmd.CommandText = "AsociarRangoFechasAlAlojamiento";  // IMPLEMENTAR ??
                        bool ok = true;
                        int i = 0;
                        while (i < this.rangosFechas.Count && ok)
                        {

                            cmd.Parameters.Clear();
                            RangoFechas rf = this.rangosFechas[i];

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IdAnuncio", this.id);
                            cmd.Parameters.AddWithValue("@fechaIni", rf.fechaInicio);
                            cmd.Parameters.AddWithValue("@fechaFin", rf.fechaFin);
                            cmd.Parameters.AddWithValue("@precio", rf.precio);
                            ok = cmd.ExecuteNonQuery() == 1;
                            i++;
                        }

                        if (ok)
                        {
                            tr.Commit();
                            retorno = true;
                        }
                        else
                        {
                            tr.Rollback();
                        }
                    }
                }
            }
            catch
            {
                //if (tr != null){
                //    tr.Rollback();
                //} 
                throw;
            }

            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
                //if (reader != null) reader.Close();
            }

            return retorno;
        }

        //ELIMINAR
        public override bool Eliminar()
        {
            bool retorno = false;

            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;
            
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "EliminarRangoFecha";//Consulta a ejecutar
                    cmd.CommandType = CommandType.StoredProcedure;//tipo de consulta
                    cmd.Parameters.Add(new SqlParameter("@idAnuncio", this.id));
                    cn.Open();//abrimos la conexion

                    SqlTransaction tr = cn.BeginTransaction();
                    cmd.Transaction = tr;
                    int afectadas = cmd.ExecuteNonQuery();

                    if (afectadas >= 0)
                    {
                        cmd.CommandText = "EliminarAnuncio";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@id", this.id));
                        cmd.ExecuteNonQuery();

                        retorno = true;
                    }

                    if (retorno)
                    {
                        tr.Commit();
                    }
                    else
                    {
                        tr.Rollback();
                    }
                }
            }
            catch
            {
                //if(tr != null) tr.Rollback();
                throw;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
                //if (reader != null) reader.Close();
            }

            return retorno;


            //try
            //{
            //    //Elimino rangofechas de un anuncio
            //    //cn = new SqlConnection(Persistente.StringConexion);
            //    SqlCommand cmd = new SqlCommand();                
            //    cn.Open();
            //    cmd.CommandText = "LeerCategoria";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@idAnuncio", this.id);

            //    //creamos la transaction TR        
            //    SqlTransaction tr = cn.BeginTransaction();
            //    //Le pasamos al CMD la transaction

            //    cmd.Transaction = tr;
            //    int afectadas = cmd.ExecuteNonQuery();

            //    //si elimino el rangofecha elimino el anuncio
            //    if (afectadas == 1)
            //    {
            //        cmd.CommandText = "EliminarAnuncio";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@id", this.id);
            //        //cmd.CommandType = CommandType.StoredProcedure;
            //        //cmd.Parameters.AddWithValue("@idAnuncio", this.id);

            //        bool ok = true;

            //        ok = cmd.ExecuteNonQuery() == 1;

            //        if (ok)
            //        {
            //            tr.Commit();
            //            retorno = true;
            //        }
            //        else
            //        {
            //            tr.Rollback();
            //        }
            //    }
            //}
            //catch
            //{
            //    //if (tr != null) tr.Rollback();

            //    throw;
            //}
            //finally
            //{
            //    if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            //    //if (reader != null) reader.Close();
            //}
            //return retorno;
        }

        public List<Anuncio> CargarAnunciosPorUsuario(string mail)
        {
            List<Anuncio> lista = new List<Anuncio>();

            try
            {
                SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AnunciosPorUsuario";
                cmd.Parameters.Add(new SqlParameter("@mail", mail));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //RECORRER LA TABLA OBTENIDA DE LA CONSULTA, IR AGREGANDO LOS VALORES A LA LIST                
                while (drResults.Read())
                {
                    Anuncio anu = new Anuncio();
                    anu.id = Convert.ToInt32(drResults["Id"]);
                    anu.nombre = Convert.ToString(drResults["Nombre"]);

                    Alojamiento aloj = new Alojamiento();
                    aloj.id = Convert.ToInt32(drResults["idAlojamiento"]);
                    aloj.Leer();

                    anu.alojamiento = aloj;


                    anu.descripcion = Convert.ToString(drResults["Descripcion"]);
                    anu.direccion1 = Convert.ToString(drResults["Direccion1"]);
                    anu.direccion2 = Convert.ToString(drResults["Direccion2"]);

                    //anu.fotos = ..;

                    anu.precioBase = Convert.ToDecimal(drResults["precioBase"]);


                    lista.Add(anu);
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

        public bool ComprobarNombreAnuncio(string nomAnu, int idRegistrado)
        {
            bool retorno = false;

            try
            {
                SqlConnection cn = new SqlConnection();
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LeerAnuncioPorUsuario";
                cmd.Parameters.Add(new SqlParameter("@nombre", nomAnu));
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

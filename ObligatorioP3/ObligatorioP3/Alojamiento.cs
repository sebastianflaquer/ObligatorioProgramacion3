﻿using System;
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
        public virtual Categoria categoria { get; set; }
        public string tipoHabitacion { get; set; }
        public bool banioPrivado { get; set; }
        public int cantHuespedes { get; set; }
        public virtual Ciudad ciudad { get; set; }
        public string barrio { get; set; }
        public List<Servicio> servicios {get; set;}
        public int calificacion { get; set; }
        public Registrado registrado { get; set; }

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
                cmd.CommandText = "LeerAlojamiento";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));    
                
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

            //definimos la transaction null para poder tenerla en el catch
            //SqlTransaction tr = null;
            
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

                    //creamos la transaction TR        
                    SqlTransaction tr = cn.BeginTransaction();
                    //Le pasamos al CMD la transaction
                    cmd.Transaction = tr;

                    afectadas = cmd.ExecuteNonQuery();
                    
                    if (afectadas == 1)
                    {
                        this.id = (int)par.Value;
                        cmd.CommandText = "AsociarServicioAlAlojamiento";
                        bool ok = true;
                        int i = 0;
                        while (i < this.servicios.Count && ok)
                        {
                            Servicio serv = this.servicios[i];

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IdAlojamiento", this.id);
                            cmd.Parameters.AddWithValue("@IdServicio", serv.id);
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
                throw;
            }
        
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
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
            
            SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
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
                    cmd.Parameters.Add(new SqlParameter("@idCiudad", this.ciudad.id));
                    cmd.Parameters.Add(new SqlParameter("@barrio", this.barrio));
                    //cmd.Parameters.Add(new SqlParameter("@servicios", this.servicios));
                    //cmd.Parameters.Add(new SqlParameter("@calificacion", this.calificacion));
                    //cmd.Parameters.Add(new SqlParameter("@idRegistrado", this.registrado.id));
                    cn.Open();
                    afectadas = cmd.ExecuteNonQuery();

                    if (afectadas == 1)
                    {
                        retorno = true;
                    }
                   
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

        //ELIMINAR
        public override bool Eliminar()
        {
            bool retorno = false;
            bool tieneReserva = false;

            Alojamiento Aloj = new Alojamiento();
            //carga los datos del alojamiento
            this.Leer();

            //cargar el anuncio por alojamiento
            Anuncio unA = new Anuncio();
            unA.alojamiento = this;
            unA.id = cargarAnuncioPorAlojamiento();
            unA.Leer();

            tieneReserva = unA.tieneReserva();

            if (tieneReserva)//si tiene reservas
            {
                retorno = false;
            }
            else //si no tiene reservas
            {
                SqlConnection cn = new SqlConnection();
                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                cn.ConnectionString = cadenaConexion;

                try
                {
                    using (SqlCommand cmd = new SqlCommand())//creamos y configuramos el comando
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "EliminarAlojamientoYDependencias";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idAlojamiento", this.id));
                        cmd.Parameters.Add(new SqlParameter("@idAnuncio", unA.id));

                        cn.Open();//abrimos conexion

                        SqlTransaction tr = cn.BeginTransaction();
                        cmd.Transaction = tr;
                        int afectadas = cmd.ExecuteNonQuery();

                        if (afectadas >= 0)
                        {   
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
                    throw;
                }
                finally
                {

                }
            }

            return retorno;
            //return retorno;
        }

        //CARGAR ANUNCIO POR ALOJAMIENTO
        private int cargarAnuncioPorAlojamiento()
        {
            int retorno = -1;

            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CargarAnuncioXAlojamiento";
                cmd.Parameters.Add(new SqlParameter("@idAlojamiento", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    retorno = Convert.ToInt32(drResults["id"]);
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

        //CARGAR ALOJAMIENTOS POR USUARIO
        public List<Alojamiento> CargarAlojamientosPorUsuario(string mail)
        {
            List<Alojamiento> lista = new List<Alojamiento>();

            SqlConnection cn = new SqlConnection();//Creamos y configuramos la concexion.
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {
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

                    #region categoria
                    Categoria cat = new Categoria();
                    cat.id = Convert.ToInt32(drResults["idCategoria"]);
                    cat.Leer();
                    aloj.categoria = cat;
                    #endregion

                    aloj.tipoHabitacion = drResults["tipoHabitacion"].ToString();

                    aloj.banioPrivado = Convert.ToBoolean(drResults["banioPrivado"]);
                    aloj.cantHuespedes = Convert.ToInt32(drResults["cantHuespedes"]);

                    #region ciudad
                    Ciudad ciud = new Ciudad();
                    ciud.id = Convert.ToInt32(drResults["idCiudad"]);
                    ciud.Leer();
                    aloj.ciudad = ciud;
                    #endregion

                    aloj.barrio = Convert.ToString(drResults["barrio"]);


                    List<Servicio> Lser = new List<Servicio>();
                    Servicio ser = new Servicio();
                    Lser = ser.CargarServiciosPorAlojamiento(aloj.id);
                    aloj.servicios = Lser;


                    aloj.calificacion = Convert.ToInt32(drResults["calificacion"]);

                    Registrado reg = new Registrado();
                    reg.id = Convert.ToInt32(drResults["idRegistrado"]);
                    aloj.registrado = reg;
                    lista.Add(aloj);
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

            return lista;
        }

        //COMPROBAR NOMBRE ALOJAMIENTO
        public bool ComprobarNombreAlojamiento(string nomAloj, int idRegistrado)
        {
            bool retorno = false;

            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            try
            {                
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
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();                
            }

            return retorno;
        }

    }

}

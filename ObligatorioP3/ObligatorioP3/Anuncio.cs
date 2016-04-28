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
            throw new NotImplementedException();
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
                    cmd.CommandText = "NuevoAnuncio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nombre", this.nombre));
                    cmd.Parameters.Add(new SqlParameter("@idAlojamiento", this.alojamiento.id));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", this.descripcion));
                    cmd.Parameters.Add(new SqlParameter("@direccion1", this.direccion1));
                    cmd.Parameters.Add(new SqlParameter("@direccion2", this.direccion2));
                    //cmd.Parameters.Add(new SqlParameter("@fotos", this.fotos));
                    cmd.Parameters.Add(new SqlParameter("@preciobase", this.precioBase));
                    cmd.Parameters.Add(new SqlParameter("@idRegistrado", this.registrado.id));
                    //cmd.Parameters.Add(new SqlParameter("@rangoFechas", this.rangosFechas));

                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@nuevoId";
                    par.SqlDbType = SqlDbType.Int;
                    par.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(par);
                    cn.Open();
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
    }
}

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
    public class Ciudad : Persistente
    {

        #region atributos

        public int id { get; set; }
        public string nombre { get; set; }

        #endregion

        //Carga las lista de Ciudades desde la DB
        public List<Ciudad> CargarCiudades()
        {
            List<Ciudad> L1 = new List<Ciudad>();

            //creamos la conexion
            SqlConnection cn = new SqlConnection();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
            cn.ConnectionString = cadenaConexion;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CargarCiudades";

            SqlDataReader drResults;

            try
            {
                cmd.Connection = cn;
                cn.Open();
                //todo lo que lee queda en drResults 
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (drResults.Read())
                {
                    Ciudad ciud = new Ciudad();
                    ciud.id = Convert.ToInt32(drResults["id"]);
                    ciud.nombre = drResults["nombre"].ToString();
                    L1.Add(ciud);

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
            return L1;

        }

        //ELIMINAR
        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        //GUARDAR
        public override bool Guardar()
        {
            throw new NotImplementedException();
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
                cmd.CommandText = "LeerCiudad";
                cmd.Parameters.Add(new SqlParameter("@id", this.id));

                SqlDataReader drResults;

                cmd.Connection = cn;
                cn.Open();
                drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (drResults.Read())
                {
                    this.id = Convert.ToInt32(drResults["id"]);
                    this.nombre = drResults["nombre"].ToString();

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

        //MODIFICAR
        public override bool Modificar()
        {
            throw new NotImplementedException();
        }

        //TRAER TODO
        public override IEnumerable<object> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Dominio
{
    public class Vendedor
    {
        public decimal Sueldo { get; set; }
        public decimal Comision { get; set; }        

        //MÉTODOS DE CUANDO ERA ACTIVE RECORD:

        //public override IEnumerable<Object> TraerTodo()
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool Leer()
        //{
        //    bool retorno = false;
        //    SqlConnection con = null;
        //    SqlDataReader reader = null;

        //    try
        //    {
        //        con= new SqlConnection(Persistente.StringConexion);
        //        SqlCommand com = new SqlCommand("VendedorPorId", con);
        //        com.Parameters.AddWithValue("@Id", this.Id);
        //        com.CommandType = CommandType.StoredProcedure;

        //        con.Open();
        //        reader = com.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            this.Nombre = reader["Nombre"].ToString();
        //            this.Apellido = reader["Apellido"].ToString();
        //            this.CI = reader["ci"].ToString();
        //            this.Sueldo = reader.GetDecimal(4);
        //            this.Comision = reader.GetDecimal(5);
        //            retorno = true;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con != null && con.State == ConnectionState.Open) con.Close();
        //        if (reader != null) reader.Close();
        //    }

        //    return retorno;
        //}

        //public override bool Guardar()
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool Modificar()
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool Eliminar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

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
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return "Id: " + this.Id + ", Nombre: " + this.Nombre + ", Precio: " + this.Precio;
        }

        //MÉTODOS DE CUANDO ERA DE ACTIVE RECORD:

        //public override IEnumerable<Object> TraerTodo()
        //{
        //    List<Producto> lista = new List<Producto>();

        //    SqlConnection con = null;
        //    SqlDataReader reader = null;

        //    try
        //    {
        //        con = new SqlConnection(Persistente.StringConexion);
        //        SqlCommand com = new SqlCommand("TodosProductos", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        reader = com.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Producto prod = new Producto();                    
        //            prod.Nombre = reader["Nombre"].ToString();
        //            prod.Id = reader.GetInt32(1);
        //            prod.Precio = reader.GetDecimal(2);
        //            lista.Add(prod);
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

        //    return lista;
        //}

        //public override bool Leer()
        //{
        //    bool retorno = false;            
        //    SqlConnection con = null;
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        con = new SqlConnection(Persistente.StringConexion);
        //        SqlCommand com = new SqlCommand("ProductoPorId", con);
        //        com.Parameters.AddWithValue("@Id", this.Id);
        //        com.CommandType = CommandType.StoredProcedure;

        //        con.Open();

        //        reader = com.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            this.Nombre = reader["Nombre"].ToString();
        //            this.Precio = reader.GetDecimal(2);
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
        //    bool retorno = false;
        //    SqlConnection con = null;

        //    try {
        //        con = new SqlConnection(Persistente.StringConexion);
        //        con.Open();               
        //        SqlCommand com = new SqlCommand("NuevoProducto", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Nombre", this.Nombre);
        //        com.Parameters.AddWithValue("@Precio", this.Precio);

        //        SqlParameter par = new SqlParameter();
        //        par.ParameterName = "@NuevoId";
        //        par.SqlDbType = SqlDbType.Int;
        //        par.Direction = ParameterDirection.Output;
        //        com.Parameters.Add(par);

        //        int afectadas = com.ExecuteNonQuery();
        //        retorno = afectadas == 1;

        //        if (retorno) this.Id = (int)par.Value;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con != null && con.State == ConnectionState.Open) con.Close();
        //    }

        //    return retorno;
        //}

        //public override bool Modificar()
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool Eliminar()
        //{
        //    bool retorno = false;
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = new SqlConnection(Persistente.StringConexion);
        //        con.Open();
        //        SqlCommand com = new SqlCommand("EliminarProducto", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Id", this.Id);                

        //        int afectadas = com.ExecuteNonQuery();
        //        retorno = afectadas == 1;                
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con != null && con.State == ConnectionState.Open) con.Close();
        //    }

        //    return retorno;
        //}
    }
}

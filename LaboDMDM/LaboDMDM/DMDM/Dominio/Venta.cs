using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<VentaProducto> Productos { get; set; }
        public Vendedor Vendedor { get; set; }

        public void AgregarProducto(int cant, Producto prod)
        {
            if (this.Productos == null) this.Productos = new List<VentaProducto>();

            VentaProducto vp = new VentaProducto() { Producto = prod, Cantidad = cant };
            this.Productos.Add(vp);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (VentaProducto vp in this.Productos)
            {
                total += vp.Producto.Precio * vp.Cantidad;
            }

            return total;
        }


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
        //        con = new SqlConnection(Persistente.StringConexion);
        //        SqlCommand com = new SqlCommand("VentaPorId", con);
        //        com.Parameters.AddWithValue("@Id", this.Id);
        //        com.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        reader = com.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            this.Fecha = reader.GetDateTime(1);
        //            this.Cliente = new Cliente() { Id = reader.GetInt32(2) };
        //            this.Vendedor = new Vendedor() { Id = reader.GetInt32(3) };

        //            if (this.Cliente.Leer() && this.Vendedor.Leer())
        //            {
        //                if (reader.NextResult())
        //                {
        //                    if (this.Productos == null) this.Productos = new List<VentaProducto>();
        //                    bool ok = true;

        //                    while (reader.Read() && ok)
        //                    {
        //                        VentaProducto vp = new VentaProducto();
        //                        vp.Cantidad = reader.GetInt32(0);
        //                        vp.Producto = new Producto();
        //                        vp.Producto.Id = reader.GetInt32(1);
        //                        ok = vp.Producto.Leer();
        //                        this.Productos.Add(vp);
        //                    }

        //                    retorno = ok;
        //                }
        //            }
        //        }

        //        reader.Close();
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
        //    SqlTransaction trans = null;
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = new SqlConnection(Persistente.StringConexion);
        //        con.Open();
        //        trans = con.BeginTransaction();
        //        SqlCommand com = new SqlCommand("NuevaVenta", con, trans);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Fecha", this.Fecha);
        //        com.Parameters.AddWithValue("@IdCliente", this.Cliente.Id);
        //        com.Parameters.AddWithValue("@IdVendedor", this.Vendedor.Id);
        //        SqlParameter par = new SqlParameter();
        //        par.ParameterName = "@NuevoId";
        //        par.SqlDbType = SqlDbType.Int;
        //        par.Direction = ParameterDirection.Output;
        //        com.Parameters.Add(par);

        //        int afectadas = com.ExecuteNonQuery();
                
        //        if (afectadas == 1)
        //        {
        //            this.Id = (int)par.Value;
        //            com.CommandText = "NuevaVentaProducto";
        //            bool ok = true;
        //            int i = 0;
        //            while (i < this.Productos.Count && ok)
        //            {
        //                VentaProducto vp = this.Productos[i];                   
                        
        //                com.Parameters.Clear();
        //                com.Parameters.AddWithValue("@IdVenta", this.Id);
        //                com.Parameters.AddWithValue("@Cantidad", vp.Cantidad);
        //                com.Parameters.AddWithValue("@IdProducto", vp.Producto.Id);
        //                ok = com.ExecuteNonQuery() == 1;                        
        //                i++;
        //            }

        //            if (ok)
        //            {
        //                trans.Commit();
        //                retorno = true;
        //            }
        //            else
        //            {
        //                trans.Rollback();
        //            }                    
        //        }
        //    }
        //    catch
        //    {
        //        if (trans != null) trans.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        if(con!=null && con.State == ConnectionState.Open) con.Close();               
        //    }           
                                   
        //    return retorno;
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

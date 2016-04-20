using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Pesistencia
{
    public class ProductoMapper : DataMapper, IProductoMapper
    {
        protected override void CargarDatos(Object obj, SqlDataReader reader)
        {
            Producto prod = (Producto)obj;
            if (reader.Read())
            {               
                prod.Nombre = reader["Nombre"].ToString();
                prod.Precio = reader.GetDecimal(2);
                prod.Id = reader.GetInt32(1);                
            }            
        }

        protected override List<SqlParameter> ParametrosNuevo(Object obj)
        {
            Producto prod = (Producto)obj;
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@Nombre", prod.Nombre));
            pars.Add(new SqlParameter("@Precio", prod.Precio));           

            return pars;
        }

        protected override List<SqlParameter> ParametrosActualizar(Object obj)
        {
            Producto prod = (Producto)obj;
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@Id", prod.Nombre));
            pars.Add(new SqlParameter("@Nombre", prod.Nombre));
            pars.Add(new SqlParameter("@Precio", prod.Precio));

            return pars;
        }

        protected override void CargarId(object obj, int Id)
        {
            ((Producto)obj).Id = Id;            
        }
        
        protected override string SPBuscarPorId()
        {
            return "ProductoPorId";
        }

        protected override string SPNuevo()
        {
            return "NuevoProducto";
        }

        protected override string SPElimina()
        {
            return "EliminarProducto";
        }

        protected override string SPmodificar()
        {
            return "ModificarProducto";
        }

        protected override int ObtenerId(object obj)
        {
            return ((Producto)obj).Id;
        }

        protected override string SPTodos()
        {
            throw new NotImplementedException();
        }
        
        bool IMapper<Producto>.Leer(Producto obj)
        {
            return base.Leer(obj);
        }

        bool IMapper<Producto>.Guardar(Producto obj)
        {
            return base.Guardar(obj);
        }

        bool IMapper<Producto>.Eliminar(Producto obj)
        {
            return base.Eliminar(obj);
        }

        bool IMapper<Producto>.Actualizar(Producto obj)
        {
            throw new NotImplementedException();
        }

        List<Producto> IMapper<Producto>.Todos()
        {
            throw new NotImplementedException();
        }

        List<Producto> IProductoMapper.ProductosPrecioMayorA(decimal precio)
        {
            List<Producto> productos = new List<Producto>();
            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(DataMapper.StringConexion);
                SqlCommand com = new SqlCommand("SELECT * FROM Productos WHERE Precio > @Precio", con);
                com.CommandType = CommandType.Text; //SE PUEDE HACER CON UN STORED PROCEDURE                
                com.Parameters.AddWithValue("@Precio", precio);
                con.Open();
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Producto p = new Producto();
                    this.CargarDatos(p, reader);
                    productos.Add(p);
                }                
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
                if (reader != null) reader.Close();
            }

            return productos;
        }

   
    }
}

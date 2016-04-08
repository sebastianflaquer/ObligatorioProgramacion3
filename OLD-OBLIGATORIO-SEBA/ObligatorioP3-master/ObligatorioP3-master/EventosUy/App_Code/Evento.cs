using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Evento
/// </summary>
public class Evento
{
    #region Atributos
    private int midEvento;    
    private int mIdEmpresa;
    private string mNombreEmpresa;
    private string mTitulo;
    private string mDescripcion;    
    private string mNombreArtistas;    
    private DateTime mFecha;    
    private string mHora;    
    private string mNombreLugar;    
    private string mDireccionLugar;
    private string mBarrioLugar;
    private System.IO.Stream mImagen;
    private string mCapasidadMaxima;    
    private string mPrecio;   
    private string mEstado;
    private int idEvento1;

        
    #endregion
    #region Propiedades
    public int idEvento
    {
        get { return midEvento; }
        set { midEvento = value; }
    }
    public int IdEmpresa
    {
        get { return mIdEmpresa; }
        set { mIdEmpresa = value; }
    }
    public string NombreEmpresa
    {
        get { return mNombreEmpresa; }
        set { mNombreEmpresa = value; }
    }
    public string Titulo
    {
        get { return mTitulo; }
        set { mTitulo = value; }
    }
    public string Descripcion
    {
        get { return mDescripcion; }
        set { mDescripcion = value; }
    }
    public string NombreArtistas
    {
        get { return mNombreArtistas; }
        set { mNombreArtistas = value; }
    }
    public DateTime Fecha
    {
        get { return mFecha; }
        set { mFecha = value; }
    }
    public string Hora
    {
        get { return mHora; }
        set { mHora = value; }
    }
    public string NombreLugar
    {
        get { return mNombreLugar; }
        set { mNombreLugar = value; }
    }
    public string DireccionLugar
    {
        get { return mDireccionLugar; }
        set { mDireccionLugar = value; }
    }
    public System.IO.Stream Imagen
    {
        get { return mImagen; }
        set { mImagen = value; }
    }
    public string BarrioLugar
    {
        get { return mBarrioLugar; }
        set { mBarrioLugar = value; }
    }
    public string CapasidadMaxima
    {
        get { return mCapasidadMaxima; }
        set { mCapasidadMaxima = value; }
    }
    public string Precio
    {
        get { return mPrecio; }
        set { mPrecio = value; }
    }
    public string Estado
    {
        get { return mEstado; }
        set { mEstado = value; }
    }
    #endregion

    //Lo instanciamos para poder usarlo
    //private static Evento mInstancia;
    //public static Evento Instancia
    //{
    //    get
    //    {
    //        if (Evento.mInstancia == null)
    //        {
    //            Evento.mInstancia = new Evento();
    //        }
    //        return Evento.mInstancia;
    //    }
    //}


    //-------------------------- ACTIVE RECORD ------------------------------------//
    #region ACTIVE RECORD
    
    //GUARDAR EVENTO
    public int guardar(){

        //string de conexion
        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        //int idEmpresa = unaEmpresa.idEmpresa; //aca va la referencia a la empresa que esta actualmente.
        int afectadas = 0;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Eventos_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@Titulo", this.Titulo));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@NombreArtistas", this.NombreArtistas));
                cmd.Parameters.Add(new SqlParameter("@Fecha", this.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Hora", this.Hora));
                cmd.Parameters.Add(new SqlParameter("@NombreLugar", this.NombreLugar));
                cmd.Parameters.Add(new SqlParameter("@DireccionLugar", this.DireccionLugar));
                cmd.Parameters.Add(new SqlParameter("@BarrioLugar", this.BarrioLugar));
                cmd.Parameters.Add(new SqlParameter("@CapasidadMaxima", this.CapasidadMaxima));
                cmd.Parameters.Add(new SqlParameter("@Imagen", this.Imagen));
                cmd.Parameters.Add(new SqlParameter("@Precio", this.Precio));
                cmd.Parameters.Add(new SqlParameter("@Estado", "A"));
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", this.IdEmpresa));

                // CREAR FOREACH PARA QUE EL PRECIO SEA UNA LISTADO
                //foreach (string unPrecio in this.mPrecio)
                //{
                //    retornoPrecios = retornoPrecios + " " +unPrecio;
                //}
                //cmd.Parameters.Add(new SqlParameter("@Precio", retornoPrecios));//aca va la lista
                //Falta guardar en la DBO quien es la empresa que lo guarda

                cn.Open();//abrimos conexion
                afectadas = cmd.ExecuteNonQuery();//ejecutamos la consulta y capturamos nro de filas afectadas
                cn.Close();//cerramos conexion
                return afectadas;
            }
        }
        catch (SqlException ex)
        {
            //loguear excepcion
        }
        finally
        {
        }
        return afectadas;
    }

    //BORRAR EVENTO
    public bool borrar(){

        bool retorno = false;

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Evento_EliminarPorIdEvento"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@idEvento", this.idEvento));//agregamos parametros para la consulta
                cn.Open();//abrimos conexion
                cmd.ExecuteNonQuery();
                retorno = true;
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            //loguear excepcion
        }
        finally
        {

        }
        return retorno;
    }


    public bool borrarTodos(){

        bool retorno = false;

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlTransaction trn = null;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.CommandText = "Eliminar_EventoxEmpresa"; //consulta a ejecutar
                cmd.Parameters.Clear();//Limpiamos los Parametros
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", this.IdEmpresa));//agregamos parametros para la consulta

                cn.Open();//abrimos conexion

                //CREAMOS LA TRANSACCION
                trn = cn.BeginTransaction();//iniciamos la transaccion 
                cmd.Transaction = trn;

                cmd.ExecuteNonQuery();

                retorno = true;
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            //loguear excepcion
            trn.Rollback();//Si hay un error Hace un RollBack para dejar sin efecto las consultas
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
                cn.Close(); //cerramos la conexion
        }
        return retorno;
    }

    #endregion ACTIVE RECORD
    //-------------------------- ACTIVE RECORD ------------------------------------//

    //Guargua el objeto Evento
    public static int GuardarEvento(string Titulo, string Descripcion, string NombreArtista, System.DateTime Fecha, string Hora, string NombreLugar, string DireccionLugar, string BarrioLugar, string CapasidadMaxima, System.IO.Stream Imagen, string Precio, string userEmail)
    {
        Empresa unaEmpresa = Empresa.cargarEmpresaMail(userEmail);
        Evento ev = new Evento(Titulo, Descripcion, NombreArtista, Fecha, Hora, NombreLugar, DireccionLugar, BarrioLugar, CapasidadMaxima, Imagen, Precio, unaEmpresa.idEmpresa);
        return ev.guardar();
    }

    //Baja de evento - Borrar Evento
    public static bool borrarEvento(int idEvento)
    {
        Evento ev = new Evento(idEvento);
        return ev.borrar();
    }

    public static bool borrarEventosXEmpresa(int idEmp, int idR)
    {
        Evento ev = new Evento(idEmp, idR);
        return ev.borrarTodos();
    }

    //-------------------------- CONSTRUCTORES ------------------------------------//
    #region CONSTRUCTORES

    public Evento(){}

    //Guardar Evento
    public Evento(string Tit, string Descri, string NArtista, DateTime Fec, string Hor, string NLugar, string DLugar, string BLugar, string CapMax, System.IO.Stream Img, string Pre, int userE)
    {
        // TODO: Complete member initialization
        this.Titulo = Tit;
        this.Descripcion = Descri;
        this.NombreArtistas = NArtista;
        this.Fecha = Fec;
        this.Hora = Hor;
        this.NombreLugar = NLugar;
        this.DireccionLugar = DLugar;
        this.BarrioLugar = BLugar;
        this.CapasidadMaxima = CapMax;
        this.Imagen = Img;
        this.Precio = Pre;
        this.IdEmpresa = userE;
    }

    //Borrar Evento
    public Evento(int idEvento1)
    {   
        this.idEvento = idEvento1;
    }

    public Evento(int idEmp, int id)
    {
        this.mIdEmpresa = idEmp;
    }

    #endregion CONSTRUCTORES
    //-------------------------- END CONSTRUCTORES --------------------------------//

}
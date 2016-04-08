using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UsuarioEventosUY
/// </summary>
public class UsuarioEventosUY
{
    #region Atributos

    private int midAdmin;    
    private string mNombre;    
    private string mApellido;    
    private string mEmail;    
    private string mPassword;
    private int midUsuario;
    private int mNroFuncionario;    
    private string mTelefono;    
    private string mCargo;
    private int midRol;
    private string mail;   
    
    #endregion
    #region Propiedades

    public int idAdmin
    {
        get { return midAdmin; }
        set { midAdmin = value; }
    }
    public string Nombre
    {
        get { return mNombre; }
        set { mNombre = value; }
    }
    public string Apellido
    {
        get { return mApellido; }
        set { mApellido = value; }
    }
    public string Email
    {
        get { return mEmail; }
        set { mEmail = value; }
    }
    public string Password
    {
        get { return mPassword; }
        set { mPassword = value; }
    }
    public int idUsuario
    {
        get { return midUsuario; }
        set { midUsuario = value; }
    }
    public int NroFuncionario
    {
        get { return mNroFuncionario; }
        set { mNroFuncionario = value; }
    }
    public string Telefono
    {
        get { return mTelefono; }
        set { mTelefono = value; }
    }
    public string Cargo
    {
        get { return mCargo; }
        set { mCargo = value; }
    }
    public int idRol
    {
        get { return midRol; }
        set { midRol = value; }
    }
    #endregion

    //Lo instanciamos para poder usarlo
    //public static UsuarioEventosUY mInstancia;
    //public static UsuarioEventosUY Instancia
    //{
    //    get
    //    {
    //        if (UsuarioEventosUY.mInstancia == null)
    //        {
    //            UsuarioEventosUY.mInstancia = new UsuarioEventosUY();
    //        }
    //        return UsuarioEventosUY.mInstancia;
    //    }
    //}

    //-------------------------- ACTIVE RECORD ------------------------------------//
    #region ACTIVE RECORD

    //Cargar Empresa
    public UsuarioEventosUY cargar() {

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            string MailPublicoLectura = drResults["MailUsuario"].ToString();
            string PasswordLectura = drResults["PassUsuario"].ToString();

            if (MailPublicoLectura == this.Email && PasswordLectura == this.Password)
            {
                this.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
                this.idRol = Convert.ToInt32(drResults["idRol"]);
                this.cargarDatosDeUsuario();
                return this;
            }
        }
        return this;
    }

    //Cargar Datos
    public UsuarioEventosUY cargarDatos()
    {
        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            string MailPublicoLectura = drResults["MailUsuario"].ToString();
            string PasswordLectura = drResults["PassUsuario"].ToString();

            if (MailPublicoLectura == this.Email)
            {
                this.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
                this.idRol = Convert.ToInt32(drResults["idRol"]);
                this.cargarDatosDeUsuario();
                return this;
            }
        }
        return this;
    }

    //public UsuarioEventosUY borrar(){
    
    
    //}

    #endregion ACTIVE RECORD
    //-------------------------- ACTIVE RECORD ------------------------------------//

    //CARGAR USUARIO
    public static UsuarioEventosUY CargarAdmin(string mail, string pass)
    {
        UsuarioEventosUY Euy = new UsuarioEventosUY(mail, pass);
        return Euy.cargar();
    }

    //CARGAR USUARIO
    public static UsuarioEventosUY CargarAdminMail(string mail)
    {
        UsuarioEventosUY Euy = new UsuarioEventosUY(mail);
        return Euy.cargarDatos();
    }

    //VALIDAR SI ES USUARIO O EMPRESA
    public static int validarSiesAdminOEmpresa(string mail, string pass)
    {

        int idRol = -1;//si devuelve -1 no encontro el usuario

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            string MailPublicoLectura = drResults["MailUsuario"].ToString();
            string PasswordLectura = drResults["PassUsuario"].ToString();
            
            if (MailPublicoLectura ==  mail && PasswordLectura == pass)
            {
                idRol = Convert.ToInt32(drResults["idRol"]);
                return idRol;
            }
        }
        return idRol;   
    }

    //CARGAR DATOS EMPRESA
    //public UsuarioEventosUY cargarDatosUsuario(string UserName)
    //{

    //    SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
    //    string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
    //    cn.ConnectionString = cadenaConexion;

    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
    //    cmd.CommandText = "Usuario_BuscarUsuario";//indico el nombre del procedimiento almacenado a ejecutar

    //    SqlDataReader drResults;

    //    cmd.Connection = cn;
    //    cn.Open();//abrimos la conexion
    //    drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
    //    //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

    //    UsuarioEventosUY unUsuario = new UsuarioEventosUY();

    //    while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
    //    {
    //        string MailPublicoLectura = drResults["MailUsuario"].ToString();
    //        string PasswordLectura = drResults["PassUsuario"].ToString();

    //        if (MailPublicoLectura == UserName)
    //        {
    //            UsuarioEventosUY r = new UsuarioEventosUY();
    //            r.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
    //            r.Email = drResults["MailUsuario"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
    //            r.Password = drResults["PassUsuario"].ToString();
    //            r.idRol = Convert.ToInt32(drResults["idRol"]);
    //            unUsuario = r;
    //            unUsuario = cargarDatosDeUsuario(unUsuario);
    //            return unUsuario;
    //        }

    //    }

    //    drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
    //    cn.Close(); //cerramos la conexion explicitamente
    //    return unUsuario;

    //}

    //CARGAR DATOS DE EMPRESA

    //CargarDatosDeUsuario
    public UsuarioEventosUY cargarDatosDeUsuario()
    {

        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Admin_CargarDatos";

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//Mientras tenga datos para leer
        { 
            int idUsuario = Convert.ToInt32(drResults["idUsuario"]);
            if (this.idUsuario == idUsuario)
            {
                this.idAdmin = Convert.ToInt32(drResults["idAdmin"]);
                this.Nombre = drResults["Nombre"].ToString();
                this.Apellido = drResults["Apellido"].ToString();
                this.NroFuncionario = Convert.ToInt32(drResults["NroFuncionario"]);
                this.Telefono = drResults["Telefono"].ToString();
                this.Cargo = drResults["Cargo"].ToString();
                return this;
            }
        }
        return this;
    }

    //Guardar Usuario Euy
    public int GuardarUsuarioEventosUY()
    {

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        int afectadas = 0;
        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "usuarioEventosUY_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@NroFuncionario", this.mNroFuncionario));//agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@NombreEuy", this.mNombre));
                cmd.Parameters.Add(new SqlParameter("@ApellidoEuy", this.mApellido));
                cmd.Parameters.Add(new SqlParameter("@EmailEuy", this.mEmail));
                cmd.Parameters.Add(new SqlParameter("@PasswordEuy", this.mPassword));
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.mTelefono));
                cmd.Parameters.Add(new SqlParameter("@Cargo", this.mCargo));
                cn.Open();//abrimos conexion
                afectadas = cmd.ExecuteNonQuery();//ejecutamos la consulta y capturamos nro de filas afectadas
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
        return afectadas;
    }


    //-------------------------- CONSTRUCTORES ------------------------------------//
    #region CONSTRUCTORES

    public UsuarioEventosUY()
	{}

    //Carga Datos
    public UsuarioEventosUY(string UName, string Pass)
    {
        Email = UName;
        Password = Pass;
    }

    //Cargar Datos Mail
    public UsuarioEventosUY(string mail)
    {
        // TODO: Complete member initialization
        this.Email = mail;
    }

    #endregion CONSTRUCTORES
    //-------------------------- END CONSTRUCTORES --------------------------------//

}
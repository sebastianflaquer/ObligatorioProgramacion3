using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Empresa
/// </summary>
public class Empresa
{
    #region Atributos
    private int midEmpresa;
    private string mNombre;
    private string mTelefono;
    private int midUsuario;
    private string mMailPublico;
    private string mPassword;
    private string mMailsAdicionales;
    private string mUrl;
    private int midRol;
    private string mail;
    private string pass;
    private string Nombre1;
    private string Apellido;
    private string Email;
    private string NroFuncionario;
    private string AdminCargo;
    

    #endregion
    #region Propiedades
    public int idEmpresa
    {
        get { return midEmpresa; }
        set { midEmpresa = value; }
    }
    public string Nombre
    {
        get { return mNombre; }
        set { mNombre = value; }
    }
    public string Telefono
    {
        get { return mTelefono; }
        set { mTelefono = value; }
    }
    public int idUsuario
    {
        get { return midUsuario; }
        set { midUsuario = value; }
    }
    public string MailPublico
    {
        get { return mMailPublico; }
        set { mMailPublico = value; }
    }
    public string Password
    {
        get { return mPassword; }
        set { mPassword = value; }
    }
    public string MailsAdicionales
    {
        get { return mMailsAdicionales; }
        set { mMailsAdicionales = value; }
    }
    public string Url
    {
        get { return mUrl; }
        set { mUrl = value; }
    }    public int idRol
    {
        get { return midRol; }
        set { midRol = value; }
    }
    #endregion
    

    //Lo instanciamos para poder usarlo
    //public static Empresa mInstancia;
    //private int idEmpresaNum1;

    //public static Empresa Instancia
    //{
    //    get
    //    {
    //        if (Empresa.mInstancia == null)
    //        {
    //            Empresa.mInstancia = new Empresa();
    //        }
    //        return Empresa.mInstancia;
    //    }
    //}

    //-------------------------- ACTIVE RECORD ------------------------------------//
    #region ACTIVE RECORD
    //Guardar General
    public int guardar()
    {
        //string de conexion
        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        int afectadas = 0;

        //declaramos  el Transaction
        SqlTransaction trn = null;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Usuarios_Insert"; //consulta a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
                cmd.Parameters.Add(new SqlParameter("@mailPrimario", this.MailPublico));
                cmd.Parameters.Add(new SqlParameter("@Password", this.Password));
                cn.Open(); //abrimos conexion

                //CREAMOS LA TRANSACCION
                trn = cn.BeginTransaction();//iniciamos la transaccion 
                cmd.Transaction = trn;

                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());//Usamos el ExecuteScalar para devolver el IdUsuario

                cmd.CommandText = "Empresa_Insert";//Pisamos el CommandText
                cmd.Parameters.Clear();//Limpiamos los Parametros
                cmd.Parameters.Add(new SqlParameter("@Nombre", this.Nombre)); //agregamos parametros para la consulta
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mails", this.MailsAdicionales));
                cmd.Parameters.Add(new SqlParameter("@Url", this.Url));
                cmd.Parameters.Add(new SqlParameter("@idUsuario", this.idUsuario));

                afectadas = cmd.ExecuteNonQuery(); //ejecutamos la consulta y capturamos nro de filas afectadas
                trn.Commit();//Si todo sale bien Ejecuta las consultas                
                cn.Close();//cerramos conexion
            }
        }
        catch (SqlException ex)
        {
            trn.Rollback();//Si hay un error Hace un RollBack para dejar sin efecto las consultas
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
                cn.Close(); //cerramos la conexion
        }
        return afectadas;
        //return afectadas;
    }

    //Borrar General
    public bool borrar(){

        bool retorno = false;


        //int idUsuario = Empresa.BuscarIdUsuarioPorIdEmpresa(idEmpresaNum);

        Evento.borrarEventosXEmpresa(this.idEmpresa, this.idRol);



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
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", this.idEmpresa));//agregamos parametros para la consulta

                cn.Open();//abrimos conexion

                //CREAMOS LA TRANSACCION
                trn = cn.BeginTransaction();//iniciamos la transaccion 
                cmd.Transaction = trn;

                cmd.ExecuteNonQuery();

                cmd.CommandText = "Empresa_EliminarPorId"; //consulta a ejecutar
                cmd.Parameters.Clear();//Limpiamos los Parametros
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", this.idEmpresa));//agregamos parametros para la consulta

                cmd.ExecuteNonQuery();

                cmd.CommandText = "Eliminar_UsuarioxEmpresa";//Pisamos el CommandText
                cmd.Parameters.Clear();//Limpiamos los Parametros
                cmd.Parameters.Add(new SqlParameter("@idUsuario", this.idUsuario));

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

    //Cargar Empresa
    public Empresa cargarEmpresa()
    {
        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
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

            if (MailPublicoLectura == this.MailPublico)
            {                
                this.idUsuario = Convert.ToInt32(drResults["idUsuario"]);
                this.MailPublico = drResults["MailUsuario"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
                this.Password = drResults["PassUsuario"].ToString();
                this.idRol = Convert.ToInt32(drResults["idRol"]);
                this.cargarDatosDeEmpresa();
                return this;
            }

        }

        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return this;
    }

    //Cargar datos de Empresa
    public Empresa cargarDatosDeEmpresa()
    {
        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresa_CargarDatos";

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read()) //Mientras tenga datos para leer
        {
            int idUser = Convert.ToInt32(drResults["idUsuario"]);

            if (this.idUsuario == idUser)
            {
                int id = Convert.ToInt32(drResults["idEmpresa"]);
                this.idEmpresa = id;
                this.Nombre = drResults["Nombre"].ToString();
                this.Telefono = drResults["Telefono"].ToString();
                this.MailsAdicionales = drResults["Mails"].ToString();
                this.Url = drResults["Url"].ToString();
                return this;
            }
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return this;
    }

    //Actualizar
    private int actualizar()
    {
        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;
        
        int afectadas = 0;

        try
        {
            using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
            {
                cmd.Connection = cn;
                cmd.CommandText = "Update_Empresa";//indico el nombre del procedimiento almacenado a ejecutar
                cmd.CommandType = CommandType.StoredProcedure;//indico que voy a ejecutar un procedimiento almacenado en la bd

                cmd.Parameters.Add(new SqlParameter("@Nombre", this.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mails", this.MailsAdicionales));
                cmd.Parameters.Add(new SqlParameter("@Url", this.Url));
                cmd.Parameters.Add(new SqlParameter("@idEmpresa", this.idEmpresa));

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

    #endregion ACTIVE RECORD
    //-------------------------- ACTIVE RECORD ------------------------------------//

    //GUARDAR EMPRESA
    public static int GuardarEmpresa(string Nombre, string Telefono, string MailPublico, string MailsAdicionales, string Url, string Password)
    {   
        Empresa em=new Empresa( Nombre,  Telefono,  MailPublico,  MailsAdicionales,  Url,  Password);
        return    em.guardar();
    }

    //BORRAR EMPRESA
    public static bool borrarEmpresa(int idEmpresa, int idUsuario)
    {
        Empresa em = new Empresa(idEmpresa, idUsuario);
        return em.borrar();
    }
    //CARGAR DATOS DE EMPRESA MAIL Y PASS
    public static Empresa cargarEmpresaDatos(string mail, string pass)
    {
        Empresa em = new Empresa(mail, pass);
        return em.cargarEmpresa();
    }
    //CARGAR DATOS DE EMPRESA MAIL
    public static Empresa cargarEmpresaMail(string mail)
    {
        Empresa em = new Empresa(mail);
        return em.cargarEmpresa();
    }
    //ACTUALIZAR DATOS - PERFIL
    public static int actualizarDatos(string Nombre, string Telefono, string MailsExtras, string Url, String EmailEmpresa)
    {
        Empresa unaEmpresa = Empresa.cargarEmpresaMail(EmailEmpresa);
        Empresa em = new Empresa(Nombre, Telefono, MailsExtras, Url, unaEmpresa.idEmpresa);
        return em.actualizar();
    }    

    //RESPALDO---------------------------------------------------------------------------------
    //public bool borrarEmpresa(int idEmpresa)
    //{
    //    bool retorno = false;

    //    //int idUsuario = Empresa.Instancia.BuscarIdUsuarioPorIdEmpresa(idEmpresaNum);

    //    SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
    //    string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
    //    cn.ConnectionString = cadenaConexion;

    //    try
    //    {
    //        using (SqlCommand cmd = new SqlCommand()) //creamos y configuramso el comando
    //        {

    //            SqlTransaction tr = cn.BeginTransaction();
    //            cmd.Transaction = tr;

    //            cmd.Connection = cn;
    //            cmd.CommandText = "Empresa_EliminarPorId"; //consulta a ejecutar
    //            cmd.CommandType = CommandType.StoredProcedure; //tipo de consulta
    //            cmd.Parameters.Add(new SqlParameter("@idEmpresa", idEmpresa));//agregamos parametros para la consulta
    //            cn.Open();//abrimos conexion
    //            cmd.ExecuteNonQuery();

    //            //cmd.CommandText = "Eliminar_UsuarioPorIdEmpresa"; //Elimina el usuario por el id de Empresa
    //            //cmd.Parameters.Clear();
    //            //cmd.Parameters.Add(new SqlParameter("@idUsuario", ))
    //            cmd.ExecuteNonQuery();

    //            retorno = true;
    //            cn.Close();//cerramos conexion

    //            /****************************************************************************/
    //            /* FALTA ELIMINAR EL USUARIO PARA NO GENERAR CONFLICTO AL CREAR UN EVENTO   */
    //            /****************************************************************************/
    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        //loguear excepcion
    //    }
    //    finally
    //    {

    //    }
    //    return retorno;
    //}

    //private int BuscarIdUsuarioPorIdEmpresa(object idEmpresaNum)
    //{
    //    //Aca agregar el codigo para buscar el usuario segun la empresa.
    //}

    //BUSCAR EMPRESA
    public List<Empresa> BuscarEmpresa(string txtbuscar)
    {
        List<Empresa> lst = new List<Empresa>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresa_CargarDatos";//indico el nombre del procedimiento almacenado a ejecutar

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            Empresa r = new Empresa();
            r.midEmpresa = Convert.ToInt32(drResults["idEmpresa"]);
            r.mNombre = drResults["Nombre"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
            r.mTelefono = drResults["Telefono"].ToString();
            r.mMailsAdicionales = drResults["Mails"].ToString();
            r.mUrl = drResults["Url"].ToString();

            if (r.mNombre == txtbuscar)
            {
                lst.Add(r);
            }
            
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }
    
    //LISTAR EMPRESAS
    public static List<Empresa> listarEmpresas()
    {
        List<Empresa> lst = new List<Empresa>();

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Empresa_CargarDatos";//indico el nombre del procedimiento almacenado a ejecutar

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);//ejecutamos la consulta de seleccion
        //CommandBehavior.CloseConnection da la capacidad al Reader de mantener la conexion viva hasta que este la cierre

        while (drResults.Read())//leemos el resultado mientras hay tuplas para traer
        {
            Empresa r = new Empresa();
            r.midEmpresa = Convert.ToInt32(drResults["idEmpresa"]);
            r.mNombre = drResults["Nombre"].ToString();//casteamos los datos del registro leido y cargamos las propiedades
            r.mTelefono = drResults["Telefono"].ToString();
            r.mMailsAdicionales = drResults["Mails"].ToString();
            r.mUrl = drResults["Url"].ToString();
            lst.Add(r);
        }

        //for (int i = 0; i < lst.Count; i++)
        //{
        //    List<Empresa> lstLoad = new List<Empresa>();
        //    Empresa e = new Empresa();
        //    e = lst.[i];

        //    lstLoad.Add(cargarDatosDeEmpresa(e));
            
        //}

        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }

    //LISTAR EVENTOS
    public static List<Evento> listarEvento(int idEmpresa)
    {   
        List<Evento> lst = new List<Evento>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //indico que voy a ejecutar un procedimiento almacenado en la bd
        cmd.CommandText = "Eventos_SelectAll";//indico el nombre del procedimiento almacenado a ejecutar

        SqlConnection cn = new SqlConnection(); //creamos y configuramos la conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        cn.ConnectionString = cadenaConexion;

        SqlDataReader drResults;

        cmd.Connection = cn;
        cn.Open();//abrimos la conexion
        drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (drResults.Read())
        {
            //string retornoPrecios = "";
            Evento r = new Evento();
            r.idEvento = Convert.ToInt32(drResults["idEvento"]);
            r.Titulo = drResults["Titulo"].ToString();
            r.Descripcion = drResults["Descripcion"].ToString();
            r.NombreArtistas = drResults["NombreArtistas"].ToString();
            //r.Fecha = drResults["Fecha"].ToString;
            r.Hora = drResults["Hora"].ToString();
            r.NombreLugar = drResults["NombreLugar"].ToString();
            r.DireccionLugar = drResults["DireccionLugar"].ToString();
            r.DireccionLugar = drResults["BarrioLugar"].ToString();
            r.DireccionLugar = drResults["CapasidadMaxima"].ToString();
            //r.Imagen =
            //r.Imagen = drResults["imagen"].ToString();
            r.Precio = drResults["precio"].ToString();
            r.Estado = drResults["estado"].ToString();
            //r.NombreEmpresa = drResults["nombreEmpresa"].ToString();
            if (idEmpresa == -1 || idEmpresa == 0)//Entra si es -1
            {
                lst.Add(r);
            }
            else if (idEmpresa == Convert.ToInt32(drResults["IdEmpresa"]))//Entra si es un idEmpresa
            {
                lst.Add(r);
            }
        }
        drResults.Close();//luego de leer todos los registros le indicamos al reader que cierre la conexion
        cn.Close(); //cerramos la conexion explicitamente
        return lst;
    }    
    //CARGAR DATOS DE EMPRESA
    

    //VALIDAR MAIL UNICO
    public static bool ValidarMailUnico(string mailPrincipal)
    {

       bool mailUnico =  true;

        SqlConnection cn = new SqlConnection();//Creamos y configuramos la conexion.
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

        while (drResults.Read())
        {
            string mailUsuario = drResults["MailUsuario"].ToString();
            if (mailUsuario == mailPrincipal)
            {
                mailUnico = false;
                return mailUnico;
            }
        }

        return mailUnico;
    }

    //BuscarEventosPorFecha
    public List<Evento> BuscarEventosPorFecha( DateTime FechaInicial, DateTime FechaFinal){

        List<Evento> unaLista = new List<Evento>();
        return unaLista;
    }

    //-------------------------- CONSTRUCTORES ------------------------------------//
    #region CONSTRUCTORES
    
    //EMPRESA
    public Empresa()
    { }

    //EMPRESA INT ID
    public Empresa(int id, int idus)
    {
        // TODO: Complete member initialization
        this.idEmpresa = id;
        this.idUsuario = idus;
    }

    //EMPRESA ALLDATA
    public Empresa(string Nom, string Tel, string Mail, string MailsA, string Uri, string Pass)
    {
        Nombre = Nom;
        Telefono = Tel;
        MailPublico = Mail;
        MailsAdicionales = MailsA;
        Url = Uri;
        Password = Pass;
    }

    public Empresa(string email)
    {
        this.MailPublico = email;
    }

    //cargar empresa
    public Empresa(string mail, string pass)
    {
        this.MailPublico = mail;
        this.Password = pass;
    }

    public Empresa(string N, string T, string MAdicionales, string Url, int idE)
    {
        this.Nombre = N;
        this.Telefono = T;
        this.MailsAdicionales = MAdicionales;
        this.Url = Url;
        this.idEmpresa = idE;
    }

    #endregion CONSTRUCTORES
    //-------------------------- END CONSTRUCTORES --------------------------------//

    
}
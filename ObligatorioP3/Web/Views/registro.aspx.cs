using BienvenidosUY;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;

namespace Web.Views
{
    public partial class registro2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Si es PostBack
            if(IsPostBack){
                
            }
            else {
               
            }
        }

        //BTN REGISTRO DE USUARIOS
        protected void btnRegistroUsuario(object sender, EventArgs e)
        {
            //VALIDA LA PAGINA
            Page.Validate();

            //SI ES VALIDA EJECUTA LA FUNCION
            if (Page.IsValid)
            {
                bool esUsuario = false;

                //VALIDA QUE LA PERSONA QUE SE ESTA REGISTRANDO NO ESTE LOGEADA YA
                Registrado reg = new Registrado();
                reg.mail = this.UsuarioMail.Text;
                //LEE USUARIO
                esUsuario = reg.Leer();

                if (esUsuario)//SI YA ES USUARIO
                {
                    //Usuario inexistente
                    this.errorField.Visible = true;
                    this.lblErrorMsj.InnerHtml = "<div class='alert alert-danger'><button data-dismiss='alert' class='close' type='button'>×</button><span>Ya existe un usuario con ese mail.</span></div>";
                }
                else//SI NO ES USUARIO LO CREA
                {
                    //variables
                    bool afectadas;
                    string ruta = Server.MapPath("~/imagenes/perfil/");
                    string nombrefoto = reg.mail + '-' + this.UsuarioFoto.FileName.Replace(" ", "_");
                    string pimienta = "p1m13n7a";

                    //Crea un nuevo objeto Registrado y le carga los campos del formulario
                    reg.nombre = this.UsuarioNombre.Text;
                    reg.apellido = this.UsuarioApellido.Text;
                    reg.mail = this.UsuarioMail.Text;
                    reg.salt = generarSalPass();
                    reg.password = generarPasshashSalt(this.UsuarioPassword.Text, reg.salt, pimienta);
                    reg.celular = this.UsuarioCelular.Text;
                    reg.foto = nombrefoto;
                    reg.descripcion = this.UsuarioDescripcion.Text;
                    reg.direccion = this.UsuarioDireccion.Text;

                    //Carga en afectadas el retorno de Guardar();
                    afectadas = reg.Guardar();

                    if (afectadas)
                    {
                        //Guarda la foto en el servidor
                        if (this.UsuarioFoto.HasFile)
                        {
                            // Se separa la extensión del nombre del archivo para validarla
                            string[] nomExt = this.UsuarioFoto.FileName.Split('.');
                            string tipoFile = nomExt[nomExt.Length - 1];
                            //Revisamos si el archivo cuenta con una extension valida, pudiendo agregar o quitar.
                            if ((tipoFile == "jpg") || (tipoFile == "png"))
                            {
                                this.UsuarioFoto.SaveAs(Server.MapPath("~/imagenes/perfil/") + nombrefoto);
                            }
                        }
                        else
                        {
                            //NO pudo guardar el usuario
                            this.errorField.Visible = true;
                            this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>Error al intentar guardar la imagen</span></div>";
                        }

                        //Si pudo guardar el usuario
                        this.errorField.Visible = true;
                        this.lblErrorMsj.InnerHtml = "<div class='alert alert-success'><button data-dismiss='alert' class='close' type='button'>×</button><span>El registro se completo con exito.</span></div>";

                        //LIMPIAR EL FORMULARIO
                        UsuarioNombre.Text = "";
                        UsuarioApellido.Text = "";
                        UsuarioMail.Text = "";
                        UsuarioPassword.Text = "";
                        UsuarioPassword.Text = "";
                        UsuarioCelular.Text = "";
                        //UsuarioFoto.FileContent = null;
                        UsuarioDescripcion.Text = "";
                        UsuarioDireccion.Text = "";
                    }
                    else
                    {
                        //Si NO pudo guardar el usuario
                        this.errorField.Visible = true;
                        this.lblErrorMsj.InnerHtml = "<div class='alert alert-warning'><button data-dismiss='alert' class='close' type='button'>×</button><span>El registro no se pudo completar.</span></div>";
                     }
                }
            }
        }
        // END 

        //GENERA LA SAL
        public string generarSalPass(){
            Random r = new Random();
            string retorno = r.Next().ToString();
            return retorno;
        }

        //GENERA EL HASH
        public string generarPasshashSalt(string passwordIngreso, string salt, string pimienta)
        {
            string hashresult = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordIngreso + salt + pimienta, "SHA1");
            return hashresult;
        }
    }
    
    //public enum Supported_HA {
    //    SHA256, SHA384, SHA512
    //}

    #region estaesotraopcion
    //public static string ComputeHash(string plainText, Supported_HA hash, byte[] salt)
    //{
    //    int minSaltLength = 4;
    //    int maxSaltLength = 16;

    //    byte[] SaltBytes = null;

    //    if (salt != null)
    //    {
    //        SaltBytes = salt;
    //    }
    //    else {
    //        Random r = new Random();
    //        int SaltLength = r.Next(minSaltLength, maxSaltLength);
    //        SaltBytes = new byte[SaltLength];
    //        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    //        rng.GetNonZeroBytes(SaltBytes);
    //        rng.Dispose();
    //    }

    //    byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
    //    byte[] plainDataAndSalt = new byte[plainData.Length + SaltBytes.Length];

    //    for (int x = 0; x < plainData.Length; x++)
    //        plainDataAndSalt[x] = plainData[x];
    //    for (int n = 0; n < SaltBytes.Length; n++)
    //        plainDataAndSalt[plainData.Length + n] = SaltBytes[n];

    //    byte[] hashValue = null;

    //    switch (hash)
    //    {
    //        case Supported_HA.SHA256:
    //            SHA256Managed sha = new SHA256Managed();
    //            hashValue = sha.ComputeHash(plainDataAndSalt);
    //            sha.Dispose();
    //            break;
    //        case Supported_HA.SHA384:
    //            SHA256Managed sha1 = new SHA256Managed();
    //            hashValue = sha1.ComputeHash(plainDataAndSalt);
    //            sha1.Dispose();
    //            break;
    //        case Supported_HA.SHA512:
    //            SHA256Managed sha2 = new SHA256Managed();
    //            hashValue = sha2.ComputeHash(plainDataAndSalt);
    //            sha2.Dispose();
    //            break;
    //    }

    //    byte[] result = new byte[hashValue.Length + SaltBytes.Length];

    //    for (int x = 0; x < hashValue.Length; x++)
    //        result[x] = hashValue[x];
    //    for (int n = 0; n < SaltBytes.Length; n++)
    //        result[hashValue.Length + n] = SaltBytes[n];

    //    return Convert.ToBase64String(result);
            
    //}

    //public static bool Confirm(string plainText, String hashValue, Supported_HA hash)
    //{
    //    byte[] hashBytes = Convert.FromBase64String(hashValue);
    //    return true;
    //}
    #endregion

    #region estaesunaopcion
    //CREAR SALT
    //public string CreateSalt(int size)
    //{
    //    var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
    //    var buff = new byte[size];
    //    rng.GetBytes(buff);
    //    return Convert.ToBase64String(buff);

    //}

    //GENERATE SHA256HASH
    //public String GenerateSHA256Hash(String input, String salt)
    //{
    //    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
    //    System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
    //    byte[] hash = sha256hashstring.ComputeHash(bytes);

    //    return ByteArrayTextString(hash);
    //}
    #endregion

    //}
}
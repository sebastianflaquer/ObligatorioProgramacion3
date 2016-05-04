<%@ Page Title="Registro" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Web.Views.registro2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2><%: Title %></h2>

    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error" >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="col-md-12">

        <div class="form-horizontal">
            <h4>Cree una cuenta nueva</h4>            
            <hr />        
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <!-- NOMBRE EMPRESA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioNombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioNombre" placeholder="Nombre" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioNombre" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
                </div>
            </div>
            <!-- END NOMBRE EMPRESA -->

            <!-- PASSWORD EMPRESA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioApellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioApellido" placeholder="Apellido" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioApellido" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
                </div>
            </div>
            <!-- EDN PASSWORD EMPRESA -->

            <!-- MAIL ADICIONAL EMPRESA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioMail" CssClass="col-md-2 control-label">Mail</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioMail" TextMode="Email" placeholder="mail@mail.com" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioMail" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
                </div>
            </div>
            <!-- END MAIL ADICIONAL EMPRESA -->

            <!-- PASSWORD EMPRESA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                <p></p>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioPassword" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                </div>
            </div>
            <!-- EDN PASSWORD EMPRESA -->

            <!-- CONFIRM PASSWORD -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioPasswordConfirm" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioPasswordConfirm" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioPasswordConfirm" CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                    <asp:CompareValidator runat="server" ControlToCompare="UsuarioPassword" ControlToValidate="UsuarioPasswordConfirm" CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
                </div>
            </div>
            <!-- END CONFIRM PASSWORD -->

            <!-- MAIL PUBLICO EMPRESA -->
            <div id="formMailPrincipal" runat="server" class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioDireccion" CssClass="col-md-2 control-label">Direccion</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioDireccion" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioDireccion" CssClass="text-danger" ErrorMessage="El campo de Direccion es obligatorio." />
                </div>
            </div>
            <!-- END MAIL PUBLICO EMPRESA-->

            <!-- MAIL ADICIONAL EMPRESA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioCelular" CssClass="col-md-2 control-label">Celular</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UsuarioCelular" TextMode="Phone" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioCelular" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
                </div>
            </div>
            <!-- END MAIL ADICIONAL EMPRESA -->

            <!-- FOTO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioDescripcion" CssClass="col-md-2 control-label">Foto</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="UsuarioFoto" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioFoto" CssClass="text-danger" ErrorMessage="Debe subir una foto de perfil." />
                </div>
            </div>
            <!-- END FOTO -->

            <!-- DESCRIPCION -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UsuarioDescripcion" CssClass="col-md-2 control-label">Descripcion</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox MaxLength="250" runat="server" ID="UsuarioDescripcion" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UsuarioDescripcion" CssClass="text-danger" ErrorMessage="El campo de Descripcion es obligatorio." />
                </div>
            </div>
            <!-- END DESCRIPCION -->

            <!-- BTN REGISTRO USUARIO -->
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="btnRegistroUsuario" Text="Registrarse" CssClass="btn btn-info" />
                </div>
            </div>
            <!-- END BTN REGISTRO USUARIO -->

        </div>

    </div>





</asp:Content>

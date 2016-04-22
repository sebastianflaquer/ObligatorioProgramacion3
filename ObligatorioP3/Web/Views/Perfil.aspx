<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Web.Views.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />

    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error" >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label runat="server"  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <h2><%: Title %>.</h2>            
            <asp:Button runat="server" OnClick="btnActualizarPerfil" Text="Actualizar" CssClass="btn btn-primary pull-right" />
        </div>
    </div>

    <div class="row">

        <div class="col-md-4">

            <div class="form-group">
                <div class="img">
                    <asp:Label runat="server" AssociatedControlID="ProfileFoto" CssClass="col-md-2 control-label">Foto</asp:Label>
                    <asp:Image ID="PerfilImagen" CssClass="img-circle" Width="200px" Height="200px" runat="server" />
                </div>
            </div>
                    
            <div class="form-group">
                <div class="col-md-10">
                    <asp:FileUpload ID="ProfileFoto" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileFoto" CssClass="text-danger" ErrorMessage="Debe subir una foto de perfil." />
                </div>
            </div>

        </div>

        <div class="col-md-4">
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ProfileNombre" CssClass="control-label">Nombre</asp:Label>
                <asp:TextBox ID="ProfileNombre" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileNombre" CssClass="text-danger" ErrorMessage="El campo de Nombre es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Apellido</label>
                <asp:TextBox ID="ProfileApellido" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileApellido" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>            

            <div class="form-group">
                <label for="exampleInputEmail1">E-mail</label>
                <asp:TextBox ID="ProfileMail" ReadOnly="true" CssClass="disabled form-control" runat="server" />
            </div>


        </div>

        <div class="col-md-4">
            

            <div class="form-group">
                <label for="exampleInputEmail1">Direccion</label>
                <asp:TextBox ID="ProfileDireccion" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileDireccion" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Celular</label>
                <asp:TextBox ID="ProfileCelular" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileCelular" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Descripcion</label>
                <asp:TextBox MaxLength="250" ID="ProfileDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />     
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileDescripcion" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />           
            </div>
        </div>
    </div>


</asp:Content>

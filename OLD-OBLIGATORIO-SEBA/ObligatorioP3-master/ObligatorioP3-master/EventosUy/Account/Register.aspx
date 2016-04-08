<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Cree una cuenta nueva para Empresas/Promotores.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <!-- NOMBRE EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaName" CssClass="col-md-2 control-label">Nombre Empresa</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaName" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
            </div>
        </div>
        <!-- END NOMBRE EMPRESA -->

        <!-- PASSWORD EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaPassword" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        <!-- EDN PASSWORD EMPRESA -->

        <!-- CONFIRM PASSWORD EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaConfirmPassword" CssClass="col-md-2 control-label">Confirmar contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                <asp:CompareValidator runat="server" ControlToCompare="EmpresaPassword" ControlToValidate="EmpresaConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
            </div>
        </div>
        <!-- END CONFIRM PASSWORD EMPRESA -->

        <!-- TELEFONO EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaTelefono" CssClass="col-md-2 control-label">Telefono</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaTelefono" TextMode="Phone" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaTelefono" CssClass="text-danger" ErrorMessage="El campo de telefono es obligatorio." />
            </div>
        </div>
        <!-- END TELEFONO EMPRESA -->
        
        <!-- MAIL PUBLICO EMPRESA -->
        <div id="formMailPrincipal" runat="server" class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaMailPublico" CssClass="col-md-2 control-label">Mail Principal</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaMailPublico" TextMode="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaMailPublico" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL PUBLICO EMPRESA-->

        <!-- MAIL ADICIONAL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaMailAdicional" CssClass="col-md-2 control-label">Mail Adicional</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaMailAdicional" TextMode="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaMailAdicional" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL ADICIONAL EMPRESA -->

        <!-- URL EMPRESA -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmpresaUrl" CssClass="col-md-2 control-label">URL</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmpresaUrl" TextMode="Url" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmpresaUrl" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END URL EMPRESA -->

        <!-- BTN REGISTRO EMPRESA -->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnAltaEmpresa" Text="Registrarse" CssClass="btn btn-default" />
            </div>
        </div>
        <!-- BTN REGISTRO EMPRESA -->


    </div>
</asp:Content>
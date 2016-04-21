<%@ Page Title="Crear Anuncio" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="crear-anuncio.aspx.cs" Inherits="Web.Views.crear_anuncio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nuevo Anuncio</h2>
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
        <div class="col-md-8">
                
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NombreAnuncio" CssClass="control-label">NombreAnuncio:</asp:Label>
                <asp:TextBox ID="NombreAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreAnuncio" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ElegirAloj" CssClass="control-label">Elegir Alojamiento:</asp:Label>
                <asp:TextBox ID="ElegirAloj" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ElegirAloj" CssClass="text-danger" ErrorMessage="El campo Elegir Alojamiento es obligatorio." />
            </div>
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DscAnuncio" CssClass="control-label">Descripción:</asp:Label>
                <asp:TextBox ID="DscAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DscAnuncio" CssClass="text-danger" ErrorMessage="El campo Descripción es obligatorio." />
            </div>   
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir1Anuncio" CssClass="control-label">Dirección 1:</asp:Label>
                <asp:TextBox ID="Dir1Anuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir1Anuncio" CssClass="text-danger" ErrorMessage="El campo Dirección 1 es obligatorio." />
            </div>  
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir2Anuncio" CssClass="control-label">Dirección 2:</asp:Label>
                <asp:TextBox ID="Dir2Anuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir2Anuncio" CssClass="text-danger" ErrorMessage="El campo Dirección 2 es obligatorio." />
            </div>  

             <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FotosAnuncio" CssClass="col-md-2 control-label">Foto</asp:Label>
                        <div class="col-md-10">
                            <asp:FileUpload ID="FotosAnuncio" runat="server" />                    
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FotosAnuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />
                        </div>
                    </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PrecioBaseAnuncio" CssClass="control-label">Precio Base:</asp:Label>
                <asp:TextBox ID="PrecioBaseAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioBaseAnuncio" CssClass="text-danger" ErrorMessage="El campo Precio Base es obligatorio." />
            </div>
            
            <div class="form-group">
                <h4>Rango de Fechas</h4>      
                </div>      

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fchaIniAnuncio" CssClass="control-label">Fecha Inicio:</asp:Label>
                <asp:TextBox ID="fchaIniAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaIniAnuncio" CssClass="text-danger" ErrorMessage="El campo Fecha Inicio es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fchaFinAnuncio" CssClass="control-label">Fecha Fin:</asp:Label>
                <asp:TextBox ID="fchaFinAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaFinAnuncio" CssClass="text-danger" ErrorMessage="El campo Fecha Fin es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PrecioRango" CssClass="control-label">Precio:</asp:Label>
                <asp:TextBox ID="PrecioRango" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioRango" CssClass="text-danger" ErrorMessage="El campo Precio del Rango es obligatorio." />
            </div>
            <div>
            <asp:Button runat="server" Text="Crear Rango" CssClass="btn btn-primary pull-right" OnClick="CrearYagregarRango_Click" />
            </div>
            <br />
            <br />
            <div>
            <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-primary pull-right" />
                 </div>
        </div>

    </div>
</asp:Content>

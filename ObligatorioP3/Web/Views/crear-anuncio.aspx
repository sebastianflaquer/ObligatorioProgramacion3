<%@ Page Title="Crear Anuncio" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="crear-anuncio.aspx.cs" Inherits="Web.Views.crear_anuncio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %></h2>
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
                
            <!-- NOMBRE ANUNCIO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NombreAnuncio" CssClass="control-label">NombreAnuncio:</asp:Label>
                <asp:TextBox ID="NombreAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." />
            </div>
            
            <!-- ELEGIR ALOJAMIENTO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DropDElegirAloj" CssClass="control-label">Seleccionar Alojamiento:</asp:Label>
                <asp:DropDownList ID="DropDElegirAloj" CssClass="form-control" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDElegirAloj" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>
            
            <!-- DESCRIPCION -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DscAnuncio" CssClass="control-label">Descripción:</asp:Label>
                <asp:TextBox ID="DscAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DscAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Descripción es obligatorio." />
            </div>   
            
            <!-- DIRECCION 1 -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir1Anuncio" CssClass="control-label">Dirección 1:</asp:Label>
                <asp:TextBox ID="Dir1Anuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir1Anuncio" ValidationGroup="anuncio"  CssClass="text-danger" ErrorMessage="El campo Dirección 1 es obligatorio." />
            </div>  
            
            <!-- DIRECCION 2 -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir2Anuncio" CssClass="control-label">Dirección 2:</asp:Label>
                <asp:TextBox ID="Dir2Anuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir2Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Dirección 2 es obligatorio." />
            </div>  

            <!-- FOTO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FotosAnuncio" CssClass="col-md-2 control-label">Foto</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="FotosAnuncio" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FotosAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />
                </div>
            </div>

            <!-- PRECIO BASE -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PrecioBaseAnuncio" CssClass="control-label">Precio Base:</asp:Label>
                <asp:TextBox ID="PrecioBaseAnuncio" CssClass="form-control" TextMode="Number" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioBaseAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Precio Base es obligatorio." />
            </div>
            
            <!-- RANGO FECHAS -->
            <div class="form-group">
                <h4>Rango de Fechas</h4>      
            </div>      

            <!-- FECHA INICIO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fchaIniAnuncio" CssClass="control-label">Fecha Inicio:</asp:Label>
                <asp:TextBox ID="fchaIniAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaIniAnuncio" ValidationGroup="rango" CssClass="text-danger" ErrorMessage="El campo Fecha Inicio es obligatorio." />
            </div>

            <!-- FECHA FIN -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fchaFinAnuncio" CssClass="control-label">Fecha Fin:</asp:Label>
                <asp:TextBox ID="fchaFinAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaFinAnuncio" ValidationGroup="rango" CssClass="text-danger" ErrorMessage="El campo Fecha Fin es obligatorio." />
            </div>

            <!-- PRECIO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PrecioRango" CssClass="control-label">Precio:</asp:Label>
                <asp:TextBox ID="PrecioRango" CssClass="form-control" TextMode="Number" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioRango" ValidationGroup="rango" CssClass="text-danger" ErrorMessage="El campo Precio del Rango es obligatorio." />
            </div>
            
            <!-- CREAR Y AGREGAR RANGO -->
            <div>
                <asp:Button runat="server" Text="Agregar Rango" ValidationGroup="rango" CssClass="btn btn-primary pull-right" OnClick="CrearYagregarRango_Click" />
            </div>
            
            <br />
            <br />
            
            <div>
                <asp:Button runat="server" Text="Confirmar" ValidationGroup="anuncio" CssClass="btn btn-primary pull-right" OnClick="ConfAnuncio_Click" />
            </div>
        </div>

    </div>
</asp:Content>

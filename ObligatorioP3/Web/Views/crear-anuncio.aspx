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
                <asp:Label runat="server" AssociatedControlID="NombreAnuncio" CssClass="control-label">Nombre del Anuncio:</asp:Label>
                <asp:TextBox ID="NombreAnuncio" CssClass="form-control" MaxLength="128" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." />
            </div>
            
            <!-- ELEGIR ALOJAMIENTO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DropDElegirAloj" CssClass="control-label">Seleccionar Alojamiento:</asp:Label>
                <asp:DropDownList ID="DropDElegirAloj" CssClass="form-control" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ValidationGroup="anuncio" ControlToValidate="DropDElegirAloj" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>
            
            <!-- DESCRIPCION -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DscAnuncio" CssClass="control-label">Descripción:</asp:Label>
                <asp:TextBox ID="DscAnuncio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DscAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Descripción es obligatorio." />
            </div>   
            
            <!-- DIRECCION 1 -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir1Anuncio" CssClass="control-label">Direccion linea 1:</asp:Label>
                <asp:TextBox ID="Dir1Anuncio" CssClass="form-control" placeholder="Nombre calle, Numero" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir1Anuncio" ValidationGroup="anuncio"  CssClass="text-danger" ErrorMessage="El campo Dirección 1 es obligatorio." />
            </div>  
            
            <!-- DIRECCION 2 -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Dir2Anuncio" CssClass="control-label">Dirección linea 2:</asp:Label>
                <asp:TextBox ID="Dir2Anuncio" CssClass="form-control" placeholder="Nombre Edificio, block, etc" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Dir2Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Dirección 2 es obligatorio." />
            </div>

            <!-- PRECIO BASE -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PrecioBaseAnuncio" CssClass="control-label">Precio Base:</asp:Label>
                <asp:TextBox ID="PrecioBaseAnuncio" CssClass="form-control" placeholder="U$S" TextMode="Number" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioBaseAnuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="El campo Precio Base es obligatorio." />
            </div>
            
            <!-- RANGO FECHAS -->
            <div class="form-group">
                <h4>Rango de Fechas</h4>      
            </div>

            <!-- CREAR Y AGREGAR RANGO -->
            <div>
                <asp:Button runat="server" Text="Nuevo Rango" CssClass="btn btn-primary pull-right" OnClick="mostrarFormRango_Click" />
            </div>


            

            <div runat="server" id="formRangoFechas" visible="false">

                <!-- FECHA INICIO -->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fchaIniAnuncio" CssClass="control-label">Fecha Inicio:</asp:Label>
                    <asp:TextBox ID="fchaIniAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaIniAnuncio" ValidationGroup="DatosRangoFch" CssClass="text-danger" ErrorMessage="El campo Fecha Inicio es obligatorio." />
                </div>

                <!-- FECHA FIN -->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fchaFinAnuncio" CssClass="control-label">Fecha Fin:</asp:Label>
                    <asp:TextBox ID="fchaFinAnuncio" CssClass="form-control" runat="server" TextMode="Date"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="fchaFinAnuncio" ValidationGroup="DatosRangoFch" CssClass="text-danger" ErrorMessage="El campo Fecha Fin es obligatorio." />
                </div>

                <!-- PRECIO -->
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PrecioRango" CssClass="control-label">Precio:</asp:Label>
                    <asp:TextBox ID="PrecioRango" CssClass="form-control" TextMode="Number" runat="server"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="PrecioRango" ValidationGroup="DatosRangoFch" CssClass="text-danger" ErrorMessage="El campo Precio del Rango es obligatorio." />
                </div>
            
                <!-- CREAR Y AGREGAR RANGO -->
                <div>
                    <asp:Button runat="server" Text="Agregar Rango" ValidationGroup="DatosRangoFch" CssClass="btn btn-primary pull-right" OnClick="CrearYagregarRango_Click" />
                </div>

            </div>

            
            <br />
            
            <!-- FOTO 1-->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Foto1Anuncio" CssClass="col-md-2 control-label">Fotos:</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="Foto1Anuncio" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Foto1Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />
                </div>
            </div>
            <!-- FOTO 2-->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Foto2Anuncio" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="Foto2Anuncio" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Foto2Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />
                </div>
            </div>
            <!-- FOTO 3-->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Foto3Anuncio" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="Foto3Anuncio" runat="server" />                    
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Foto3Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />
                </div>
            </div>
            <!-- FOTO 4-->
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="Foto4Anuncio" runat="server"/>                    
                    <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="Foto4Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />-->
                </div>
            </div>
            <br />
            <!-- FOTO 5-->
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload ID="Foto5Anuncio" runat="server"/>                    
                    <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="Foto5Anuncio" ValidationGroup="anuncio" CssClass="text-danger" ErrorMessage="Debe subir una foto de Anuncio." />-->
                </div>
            </div>

            <br />
            
            <div>
                <asp:Button runat="server" Text="Crear Anuncio" ValidationGroup="anuncio" CssClass="btn btn-primary pull-right" OnClick="ConfAnuncio_Click" />
            </div>
            <br />
            <br />
        </div>

    </div>
</asp:Content>

<%@ Page Title="Crear Alojamiento" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="crear-alojamiento.aspx.cs" Inherits="Web.Views.crear_alojamiento" %>
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

    <h2><%: Title %></h2> 

    <br />
    <div class="row">
        <div class="col-md-8">
            <!-- NOMBRE -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NombreAlojamiento" CssClass="control-label">Nombre:</asp:Label>
                <asp:TextBox ID="NombreAlojamiento" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreAlojamiento" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." />
            </div>
            
            <!-- CATEGORIA -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CategoriaDropD" CssClass="control-label">Categoría:</asp:Label>
                <asp:DropDownList ID="CategoriaDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoriaDropD" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>

            
            <!-- TIPO HABITACION -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="TipoHabitacionDropD" CssClass="control-label">Tipo de Habitación:</asp:Label>
                <asp:DropDownList ID="TipoHabitacionDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoHabitacionDropD" CssClass="text-danger" ErrorMessage="El campo Tipo Habitación es obligatorio." />
            </div>


            <!-- TIPO BAÑO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="TipoBanioDropD" CssClass="control-label">Tipo de Baño:</asp:Label>
                <asp:DropDownList ID="TipoBanioDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoBanioDropD" CssClass="text-danger" ErrorMessage="El campo Tipo de Baño es obligatorio." />
            </div>
            
            <!-- SERVICIOS -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ServiciosListBox" CssClass="control-label">Servicios</asp:Label>
                <p>Seleccione todo los servicios que tenga el alojamiento</p>
                <asp:ListBox ID="ServiciosListBox" ValidationGroup="Servicio" runat="server" SelectionMode="Multiple" Height="81px" Width="100%"></asp:ListBox>                
                <asp:Button runat="server" Text="Agregar" ValidationGroup="Servicio"  CssClass="btn btn-primary pull-right" OnClick="incluirServicio_Click" />
                <div ID="lblListaServicios" runat="server"></div>
            </div>

            <br />
            <br />

            <!-- CANTIDAD HUESPEDES -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CantHuespedes" CssClass="control-label">Cantidad Huéspedes:</asp:Label>
                <asp:TextBox ID="CantHuespedes" CssClass="form-control" TextMode="Number" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CantHuespedes" CssClass="text-danger" ErrorMessage="El campo Cantidad Huéspedes es obligatorio." />
            </div> 


            <!-- CIUDAD -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CiudadDropD" CssClass="control-label">Ciudad:</asp:Label>
                <asp:DropDownList ID="CiudadDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CiudadDropD" CssClass="text-danger" ErrorMessage="El campo Ciudad es obligatorio." />
            </div>


            <!-- BARRIO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="BarrioAloj" CssClass="control-label">Barrio:</asp:Label>
                <asp:TextBox ID="BarrioAloj" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BarrioAloj" CssClass="text-danger" ErrorMessage="El campo Barrio es obligatorio." />
            </div>
            
            
            <br />

            <!-- BTN  CREAR ALOJAMIENTO -->
            <div class="row">
                <asp:Button runat="server" OnClick="btnCrearNuevoAlojamiento" Text="Crear Alojamiento" CssClass="btn btn-primary pull-right" />
            </div>

        </div>
    </div>

</asp:Content>

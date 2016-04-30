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


            <!-- SERVICIOS -->
            <asp:Label runat="server" CssClass="text-success" ID="msjIncServ"></asp:Label>
            <div style="background-color:#808080; border:1px solid #808080; padding:15px;">
                <div class="form-group">
                    <h4>Servicios</h4>      
                    <p>Seleccione todo los servicios que tenga el alojamiento</p>
                    <asp:ListBox ID="ServiciosListBox" runat="server" SelectionMode="Multiple" Height="81px" Width="100%"></asp:ListBox>

                    <asp:Button runat="server" Text="Agregar" CssClass="btn btn-primary pull-right" OnClick="incluirServicio_Click" />
                    <br />
                    <asp:Button runat="server" Text="Crear Nuevo" CssClass="btn btn-primary pull-right" />
                </div>

                <div id="agregarservicios">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="NomServicio" CssClass="control-label" Visible ="false" ID="lblNomServ">Nombre del Servicio:</asp:Label>
                        <asp:TextBox ID="NomServicio" CssClass="form-control" runat="server" Visible ="false"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NomServicio" CssClass="text-danger" ErrorMessage="El campo Nombre del Servicio es obligatorio." />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DscServicio" CssClass="control-label" Visible ="false" ID="lblDscServ">Descripción:</asp:Label>
                        <asp:TextBox ID="DscServicio" CssClass="form-control" runat="server" Visible ="false"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DscServicio" CssClass="text-danger" ErrorMessage="El campo Descripción del Servicio es obligatorio." />
                    </div>
                    <asp:Button runat="server" Text="Agregar" CssClass="btn btn-primary pull-right" CausesValidation="false" Visible ="false" ID="btnAgrServ" OnClick="btnAgrServ_Click"/>
                </div>
                
            </div>

            <br />

            <!-- BTN  CREAR ALOJAMIENTO -->
            <div class="row">
                <asp:Button runat="server" OnClick="btnCrearNuevoAlojamiento" Text="Crear Alojamiento" CssClass="btn btn-primary pull-right" />
            </div>

        </div>
    </div>

</asp:Content>

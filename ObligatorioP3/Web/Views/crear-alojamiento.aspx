<%@ Page Title="Crear Alojamiento" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="crear-alojamiento.aspx.cs" Inherits="Web.Views.crear_alojamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2><%: Title %></h2> 
     <br />
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
                <asp:Label runat="server" AssociatedControlID="NombreAlojamiento" CssClass="control-label">Nombre:</asp:Label>
                <asp:TextBox ID="NombreAlojamiento" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreAlojamiento" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CategoriaDropD" CssClass="control-label">Categoría:</asp:Label>
                <asp:DropDownList ID="CategoriaDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoriaDropD" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="TipoHabitacion" CssClass="control-label">Tipo Habitación:</asp:Label>
                <asp:TextBox ID="TipoHabitacion" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoHabitacion" CssClass="text-danger" ErrorMessage="El campo Tipo Habitación es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="BanioP" CssClass="control-label">Baño Privado:</asp:Label>
                <input id="BanioP" type="checkbox" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoHabitacion" CssClass="text-danger" ErrorMessage="El campo Tipo Habitación es obligatorio." />
            </div>   
            <br />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CantHuespedes" CssClass="control-label">Cantidad Huéspedes:</asp:Label>
                <asp:TextBox ID="CantHuespedes" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CantHuespedes" CssClass="text-danger" ErrorMessage="El campo Cantidad Huéspedes es obligatorio." />
            </div>   
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CiudadAloj" CssClass="control-label">Ciudad:</asp:Label>
                <asp:TextBox ID="CiudadAloj" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CiudadAloj" CssClass="text-danger" ErrorMessage="El campo Cantidad Huéspedes es obligatorio." />
            </div>  
            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="BarrioAloj" CssClass="control-label">Barrio:</asp:Label>
                <asp:TextBox ID="BarrioAloj" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BarrioAloj" CssClass="text-danger" ErrorMessage="El campo Cantidad Huéspedes es obligatorio." />
            </div>
            
            <div class="form-group">
                <h4>Servicios</h4>      
                </div>      

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NomServicio" CssClass="control-label">Nombre del Servicio:</asp:Label>
                <asp:TextBox ID="NomServicio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NomServicio" CssClass="text-danger" ErrorMessage="El campo Nombre del Servicio es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DscServicio" CssClass="control-label">Descripción:</asp:Label>
                <asp:TextBox ID="DscServicio" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DscServicio" CssClass="text-danger" ErrorMessage="El campo Descripción del Servicio es obligatorio." />
            </div>
            <div>
            <asp:Button runat="server" Text="Agregar" CssClass="btn btn-primary pull-right" OnClick="AgregarServicio_Click" />
            </div>
            <br />
            <br />
            <div>
            <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-primary pull-right" />
                 </div>
        </div>

    </div>
</asp:Content>

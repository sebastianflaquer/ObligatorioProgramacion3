<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="modificar-alojamiento.aspx.cs" Inherits="Web.Views.modificar_alojamiento" %>
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
    <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ElejAlojamientoDropD" CssClass="control-label">Seleccionar Alojamiento:</asp:Label>
                <asp:DropDownList ID="ElejAlojamientoDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ElejAlojamientoDropD" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>
            <div>
            <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-primary pull-right" OnClick="MostrarFormAModificar_Click" />
            </div>


            <div class="form-group">
                <asp:Label runat="server" ID="lblModAlojamiento" AssociatedControlID="NombreModAlojamiento" CssClass="control-label" Visible="false">Nombre:</asp:Label>
                <asp:TextBox ID="NombreModAlojamiento" Visible ="false" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NombreModAlojamiento" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModCat" idAssociatedControlID="CategoriaDropD" CssClass="control-label">Categoría:</asp:Label>
                <asp:DropDownList ID="CategoriaDropD" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoriaDropD" CssClass="text-danger" ErrorMessage="El campo Categoría es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModTipoHab" AssociatedControlID="TipoHabitacionDropD" CssClass="control-label">Tipo de Habitación:</asp:Label>
                <asp:DropDownList ID="TipoHabitacionDropD" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoHabitacionDropD" CssClass="text-danger" ErrorMessage="El campo Tipo Habitación es obligatorio." />
            </div>

            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModTipoBano" AssociatedControlID="TipoBanioDropD" CssClass="control-label">Tipo de Baño:</asp:Label>
                <asp:DropDownList ID="TipoBanioDropD" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipoBanioDropD" CssClass="text-danger" ErrorMessage="El campo Tipo de Baño es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModCantHuesp" AssociatedControlID="CantHuespedes" CssClass="control-label">Cantidad Huéspedes:</asp:Label>
                <asp:TextBox ID="CantHuespedes" Visible="false" CssClass="form-control" TextMode="Number" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CantHuespedes" CssClass="text-danger" ErrorMessage="El campo Cantidad Huéspedes es obligatorio." />
            </div> 

            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModCiud" AssociatedControlID="CiudadDropD" CssClass="control-label">Ciudad:</asp:Label>
                <asp:DropDownList ID="CiudadDropD" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CiudadDropD" CssClass="text-danger" ErrorMessage="El campo Ciudad es obligatorio." />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModBarrio" AssociatedControlID="BarrioAloj" CssClass="control-label">Barrio:</asp:Label>
                <asp:TextBox ID="BarrioAloj" Visible="false" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BarrioAloj" CssClass="text-danger" ErrorMessage="El campo Barrio es obligatorio." />
            </div>
            
                <div class="form-group">   
                    <asp:Label runat="server" Visible="false" ID="lblModServ" CssClass="control-label">Servicios del Alojamiento:</asp:Label>
                    <asp:ListBox ID="ModServiciosListBox" Visible="false" runat="server" SelectionMode="Multiple" Height="81px" Width="100%"></asp:ListBox>
                </div>
                <asp:Button runat="server" Text="Actualizar" CssClass="btn btn-primary pull-right" CausesValidation="false" Visible ="false" ID="btnActAloj"/>
       
        </div>
</asp:Content>

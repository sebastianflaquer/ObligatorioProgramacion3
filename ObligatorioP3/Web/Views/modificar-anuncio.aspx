<%@ Page Title="Editar Anuncios" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="modificar-anuncio.aspx.cs" Inherits="Web.Views.modificar_anuncio" %>
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

        <!-- LISTA SIN ANUNCIO -->
        <div class="row" runat="server" id="listaSinAnuncios">
            <%--<div class="col-md-12">
                <h1>Upss!!!</h1>
                <h3>No tienes anuncios para eliminar</h3><br />
                <a class="btn btn-warning" href="home.aspx">Volver al home</a>
            </div>--%>
        </div>
        <!-- END -->

        <div class="col-md-8" id="formModificar" runat="server">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ElejAnuncioDropD" CssClass="control-label">Seleccionar Anuncio:</asp:Label>
                <asp:DropDownList ID="ElejAnuncioDropD" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ElejAnuncioDropD" CssClass="text-danger" ErrorMessage="El campo Seleccionar Anuncio es obligatorio." />
            </div>
            <div>
            <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-primary pull-right" OnClick="MostrarFormAnunModificar_Click" />
            </div>

            <div class="form-group">
                <asp:Label runat="server" ID="lblModAnuncio"  CssClass="control-label" Visible="false">Nombre Anuncio:</asp:Label>
                <asp:TextBox ID="NombreAnuncioMod" Visible ="false" CssClass="form-control" runat="server"/>
             </div>
             <div class="form-group">
                <asp:Label runat="server" Visible="false" ID="lblModCat"  CssClass="control-label">Alojamiento:</asp:Label>
                <asp:DropDownList ID="AlojamientoDropD" Visible="false" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        <div class="form-group">
                <asp:Label runat="server" ID="DscModAnu"  CssClass="control-label" Visible="false">Descripción:</asp:Label>
                <asp:TextBox ID="TextBoxDscModAnu" Visible ="false" CssClass="form-control" runat="server"/>
             </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblDir1ModAnu"  CssClass="control-label" Visible="false">Dirección 1:</asp:Label>
                <asp:TextBox ID="TextBoxDir1ModAnu" Visible ="false" CssClass="form-control" runat="server"/>
             </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblDir2ModAnu"  CssClass="control-label" Visible="false">Dirección 2:</asp:Label>
                <asp:TextBox ID="TextBoxDir2ModAnu" Visible ="false" CssClass="form-control" runat="server"/>
             </div>

            <div class="form-group">
                <asp:Label runat="server" ID="lblFotosModAnu"  CssClass="control-label" Visible="false">Fotos:</asp:Label>
             </div>

            <div class="form-group">
                <asp:Label runat="server" ID="lblPrecioBModAnu"  CssClass="control-label" Visible="false">Precio Base:</asp:Label>
                <asp:TextBox ID="TextBoxPrecioBase" Visible ="false" CssClass="form-control" runat="server"/>
             </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblRangoFechasMod"  CssClass="control-label" Visible="false">Rango de Fechas:</asp:Label>
                <asp:ListBox ID="ModRangoFechaListBox" Visible="false" runat="server"  Height="81px" Width="100%"></asp:ListBox>
             </div>
            <asp:Button runat="server" Text="Actualizar" CssClass="btn btn-primary pull-right" CausesValidation="false" Visible ="false" ID="btnActAnu"/>






            </div>
</asp:Content>

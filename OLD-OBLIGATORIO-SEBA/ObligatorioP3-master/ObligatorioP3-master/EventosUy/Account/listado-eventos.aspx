<%@ Page Title="Listado de Eventos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="listado-eventos.aspx.cs" Inherits="Account_listado_eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <hr />    

    <!-- Listado de Eventos -->
    <h2><%: Title %></h2>
        
    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <div class="md-content-tebale-empresa">
        <asp:GridView ID="gridListarEventos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowCommand="gridListarEventos_RowCommand" Width="100%">
            <Columns>
                <asp:BoundField DataField="idEvento" HeaderText="Id" />
                <asp:BoundField DataField="Titulo" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Nombreartistas" HeaderText="Nombre Artista" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                <asp:BoundField DataField="NombreLugar" HeaderText="Nombre Lugar" />
                <asp:BoundField DataField="direccionLugar" HeaderText="Direccion Lugar" />            
                <asp:BoundField DataField="imagen" HeaderText="Imagen" />
                <asp:ImageField DataImageUrlField="imagen" HeaderText="imagen"></asp:ImageField>
                <%--<asp:BoundField DataField="precio" HeaderText="Precio" />--%>
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <%--<asp:BoundField DataField="nombreEmpresa" HeaderText="Empresa" />--%>
                <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" ><ControlStyle CssClass="btn btn-danger"></ControlStyle></asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>
    <!-- END listado de empresa -->


</asp:Content>


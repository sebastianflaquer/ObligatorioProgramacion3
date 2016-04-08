<%@ Page Title="Listado de Empresas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="listado-empresas.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <hr />

    <!-- Listado de Empresa -->
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
        <asp:GridView ID="gridListarEmpresas" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowCommand="gridListarEmpresas_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="idEmpresa" HeaderText="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="MailsAdicionales" HeaderText="Mails Adicionales" />
            <asp:BoundField DataField="URL" HeaderText="URL" />
            <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" />
        </Columns>
        </asp:GridView>
    </div>
    <!-- END listado de empresa -->

</asp:Content>


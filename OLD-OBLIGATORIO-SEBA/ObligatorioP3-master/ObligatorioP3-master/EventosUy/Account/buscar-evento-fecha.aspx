<%@ Page Title="Buscar Eventos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="buscar-evento-fecha.aspx.cs" Inherits="Account_buscar_evento_fecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <hr />
    <!-- Buscar Eventos -->
    <h2><%: Title %></h2>

    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">
            <h4>Ingrese las fechas para las cuales quiere mostrar eventos</h4>
            <br />
            <br />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Fecha Inicio"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Fecha Fin"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button  runat="server" OnClick="BtnBuscarFecha" CssClass="btn btn-primary" Text="Buscar" />
            </div>
        </div>
    </div>


</asp:Content>


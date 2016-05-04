<%@ Page Title="Home" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%--<div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>--%>

    <div class="starter-template">
        <h2><%: Title %></h2>
        <br />
        <h3>BienvenidosUY</h3>
        <p class="lead">Sistema de gestion de Alojamientos y Anuncios</p>
    </div>

</asp:Content>

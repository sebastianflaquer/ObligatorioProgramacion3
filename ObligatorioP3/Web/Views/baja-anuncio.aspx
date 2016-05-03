﻿<%@ Page Title="Eliminar Anuncio" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="baja-anuncio.aspx.cs" Inherits="Web.Views.baja_anuncio" %>
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
                
            <!-- ELEGIR ANUNCIO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DropDElegirAnuncio" CssClass="control-label">Seleccionar Anuncio:</asp:Label>
                <asp:DropDownList ID="DropDElegirAnuncio" CssClass="form-control" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDElegirAnuncio" CssClass="text-danger" ErrorMessage="El campo Seleccionar Anuncio es obligatorio." />
            </div>
            <div>
                <asp:Button runat="server" Text="Eliminar"  CssClass="btn btn-primary pull-right" OnClick="ConfBajaAnuncio_Click" />
            </div>

            </div>
        </div>
</asp:Content>

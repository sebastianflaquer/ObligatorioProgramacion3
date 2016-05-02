<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="baja-alojamiento.aspx.cs" Inherits="Web.Views.baja_alojamiento" %>
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
                
            <!-- ELEGIR ALOJAMIENTO -->
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DropDElegirAlojamiento" CssClass="control-label">Seleccionar Alojamiento:</asp:Label>
                <asp:DropDownList ID="DropDElegirAlojamiento" CssClass="form-control" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDElegirAlojamiento" CssClass="text-danger" ErrorMessage="El campo Seleccionar Alojamiento es obligatorio." />
            </div>
            <div>
                <asp:Button runat="server" Text="Eliminar"  CssClass="btn btn-primary pull-right" OnClick="ConfBajaAlojamiento_Click"/>
            </div>

            </div>
        </div>
</asp:Content>

<%@ Page Title="Mis Alojamientos" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="alojamientos.aspx.cs" Inherits="Web.Views.alojamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2><%: Title %></h2>

    <div class="row">

        <div class="col-md-12">
            <asp:GridView ID="GridAlojamientos" CssClass="table table-bordered" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.nombre" />
                    <asp:BoundField HeaderText="Tipo de Habitacion" DataField="tipoHabitacion" />
                    <asp:BoundField HeaderText="Baño Privado" DataField="banioPrivado" />
                    <asp:BoundField HeaderText="Cant Huespedes" DataField="cantHuespedes" />
                    <asp:BoundField HeaderText="Ciudad" DataField="Ciudad.nombre" />
                    <asp:BoundField HeaderText="Barrio" DataField="barrio" />
                    <%--<asp:BoundField HeaderText="Servicios" DataField="Servicio.nombre" />--%>
                    <asp:BoundField HeaderText="Calificacion" DataField="calificacion" />
                </Columns>
            </asp:GridView>
        </div>
        


    </div>

</asp:Content>

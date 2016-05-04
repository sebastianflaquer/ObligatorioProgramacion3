<%@ Page Title="Mis Anuncios" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="anuncios.aspx.cs" Inherits="Web.Views.anuncios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %></h2>


    <div class="row">
        <div class="col-md-12">

            <!-- LISTA SIN ANUNCIO -->
            <div class="row" runat="server" id="listaSinAnuncios">
                <%--<div class="col-md-12">
                    <h1>Upss!!!</h1>
                    <h3>No tienes anuncios para eliminar</h3><br />
                    <a class="btn btn-warning" href="home.aspx">Volver al home</a>
                </div>--%>
            </div>
            <!-- END -->

            <asp:GridView ID="GridAnuncioss" CssClass="table table-bordered" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                    <asp:BoundField HeaderText="Alojamiento" DataField="Alojamiento.nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                    <asp:BoundField HeaderText="Direccion 1" DataField="direccion1" />
                    <asp:BoundField HeaderText="Direccion 2" DataField="direccion2" />
                    <%--<asp:BoundField HeaderText="Fotos" DataField="Ciudad.nombre" />--%>
                    <asp:BoundField HeaderText="PrecioBase" DataField="precioBase" />
                    <%--<asp:BoundField HeaderText="Rango" DataField="barrio" />--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

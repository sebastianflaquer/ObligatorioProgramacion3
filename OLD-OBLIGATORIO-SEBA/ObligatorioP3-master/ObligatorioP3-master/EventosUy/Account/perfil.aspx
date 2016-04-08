<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="perfil.aspx.cs" Inherits="Account_perfil_empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <!-- Listado de Empresa -->
    <h2><%: Title %>.</h2>
    
    <hr />
    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    <!-- EMPRESA -->
    <div id="empresaPerfil" visible=false runat="server">

        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div  class="md-content-perfil-empresa" >
                        <div class="bd">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Nombre</label>
                                <asp:TextBox type="text" id="empresaNombre" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Telefono</label>
                                <asp:TextBox type="tel" id="empresaTelefono" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Mail Principal</label>
                                <asp:TextBox type="email" id="empresaMailPrincipal" runat="server" CssClass="form-control" disabled/>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Mails Extras</label>
                                <asp:TextBox type="text" id="empresaMailsExtras" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">URL</label>
                                <asp:TextBox type="url" id="empresaURL" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button runat="server" OnClick="btnActualizarDatosEmp" Text="Actualizar" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" OnClick="btnEliminarCuenta" Text="Eliminar Cuenta" CssClass="btn btn-danger pull-right" />
                </div>
            </div>
        </div>
    </div>
    <!-- END EMPRESA -->

    
    <div id="adminPerfil" class="md-content-perfil-admin" visible=false runat="server">
        <div class="bd">
            <div class="form-group">
                <label for="AdminNombre">Nombre</label>
                <asp:TextBox type="text" runat="server" id="AdminNombre" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="AdminHola">Apellido</label>
                <asp:TextBox type="text" runat="server" id="AdminHola" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="AdminEmail">Email</label>
                <asp:TextBox type="email" runat="server" id="AdminEmail" CssClass="form-control" disabled/>
            </div>
            <div class="form-group">
                <label for="AdminTelefono">Telefono</label>
                <asp:TextBox type="tel" runat="server" id="AdminTelefono" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="AdminNroFuncionario">NroFuncionario</label>
                <asp:TextBox type="number" runat="server" id="AdminNroFuncionario" CssClass="form-control" disabled/>
            </div>
            <div class="form-group">
                <label for="AdminCargo">Cargo</label>
                <asp:TextBox type="text" runat="server" id="AdminCargo" CssClass="form-control" disabled/>
            </div>
            <asp:Button runat="server" OnClick="btnActualizarDatosAdmin" Text="Actualizar" CssClass="btn btn-primary" />
        </div>
    </div>
    <!-- END listado de empresa -->

</asp:Content>


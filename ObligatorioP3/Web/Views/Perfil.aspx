<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Web.Views.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
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
        <div class="col-md-12">
            <h2><%: Title %>.</h2>            
            <asp:Button runat="server" OnClick="btnActualizarPerfil" Text="Actualizar" CssClass="btn btn-primary pull-right" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
                
            <div class="row">
                <div class="col-md-4">

                    <div class="form-group">
                        <div class="img">
                            <img data-src="holder.js/140x140" class="img-circle" alt="140x140" style="width: 140px; height: 140px;" src="data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/PjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iMTQwIiBoZWlnaHQ9IjE0MCIgdmlld0JveD0iMCAwIDE0MCAxNDAiIHByZXNlcnZlQXNwZWN0UmF0aW89Im5vbmUiPjwhLS0KU291cmNlIFVSTDogaG9sZGVyLmpzLzE0MHgxNDAKQ3JlYXRlZCB3aXRoIEhvbGRlci5qcyAyLjYuMC4KTGVhcm4gbW9yZSBhdCBodHRwOi8vaG9sZGVyanMuY29tCihjKSAyMDEyLTIwMTUgSXZhbiBNYWxvcGluc2t5IC0gaHR0cDovL2ltc2t5LmNvCi0tPjxkZWZzPjxzdHlsZSB0eXBlPSJ0ZXh0L2NzcyI+PCFbQ0RBVEFbI2hvbGRlcl8xNTQwNjkxZTFmYyB0ZXh0IHsgZmlsbDojQUFBQUFBO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1mYW1pbHk6QXJpYWwsIEhlbHZldGljYSwgT3BlbiBTYW5zLCBzYW5zLXNlcmlmLCBtb25vc3BhY2U7Zm9udC1zaXplOjEwcHQgfSBdXT48L3N0eWxlPjwvZGVmcz48ZyBpZD0iaG9sZGVyXzE1NDA2OTFlMWZjIj48cmVjdCB3aWR0aD0iMTQwIiBoZWlnaHQ9IjE0MCIgZmlsbD0iI0VFRUVFRSIvPjxnPjx0ZXh0IHg9IjQ1LjUiIHk9Ijc0LjUiPjE0MHgxNDA8L3RleHQ+PC9nPjwvZz48L3N2Zz4=" data-holder-rendered="true">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputFile">Imagen</label>
                        <input type="file" id="exampleInputFile">
                    </div>

                </div>
               
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ProfileNombre" CssClass="control-label">Nombre</asp:Label>
                <asp:TextBox ID="ProfileNombre" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileNombre" CssClass="text-danger" ErrorMessage="El campo de Nombre es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Apellido</label>
                <asp:TextBox ID="ProfileApellido" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileApellido" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>
            
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label for="exampleInputEmail1">E-mail</label>
                <asp:TextBox ID="ProfileMail" ReadOnly="true" CssClass="disabled form-control" runat="server" />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Direccion</label>
                <asp:TextBox ID="ProfileDireccion" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileDireccion" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Celular</label>
                <asp:TextBox ID="ProfileCelular" CssClass="form-control" runat="server"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileCelular" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Descripcion</label>
                <asp:TextBox MaxLength="250" ID="ProfileDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />     
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProfileDescripcion" CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />           
            </div>
        </div>
    </div>


</asp:Content>

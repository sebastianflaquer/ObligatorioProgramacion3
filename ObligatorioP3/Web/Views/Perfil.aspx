<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Web.Views.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2><%: Title %>.</h2>

    <%--<div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error" >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label runat="server"  Text="Label"></asp:Label>
            </div>
        </div>
    </div>--%>

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
                        <p class="help-block">Example block-level help text here.</p>
                    </div>

                </div>
                <div class="col-md-8">

                    <div class="form-group">
                        <label for="exampleInputEmail1">Nombre de usuario</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
                    </div>

                </div>
            </div>


            <div class="form-group">
                <label for="exampleInputEmail1">Nombre</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Apellido</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>
            
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label for="exampleInputEmail1">E-mail</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Nombre de usuario</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Contraseña</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Repetir Contraseña</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Direccion</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Celular</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Descripcion</label>
                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
            </div>
        </div>
    </div>


</asp:Content>

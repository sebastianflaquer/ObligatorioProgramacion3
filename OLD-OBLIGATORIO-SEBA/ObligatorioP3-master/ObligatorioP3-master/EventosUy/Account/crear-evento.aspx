<%@ Page Title="Crear Evento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="crear-evento.aspx.cs" Inherits="Account_crear_evento" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row-fluid" id="errorField" runat="server" visible=false>
        <div class="span12" ID="lblErrorMsj" runat="server">
            <div class="alert alert-error"  >
                <button data-dismiss="alert" class="close" type="button">×</button>            
                <asp:Label  Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Complete el formulario para crear un nevo evento.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <!-- TITULO EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoTitulo" CssClass="col-md-2 control-label">Titulo Evento</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoTitulo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoTitulo" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
            </div>
        </div>
        <!-- END TITULO EVENTO -->

        <!-- PASSWORD EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoDescripcion" CssClass="col-md-2 control-label">Descripcion</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoDescripcion" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoDescripcion" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        <!-- EDN PASSWORD EVENTO -->

        <!-- CONFIRM PASSWORD EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoNombreArtista" CssClass="col-md-2 control-label">Nombre Artista/s</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoNombreArtista" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoNombreArtista" CssClass="text-danger" ErrorMessage="El campo de nombre de Empresa es obligatorio." />
            </div>
        </div>
        <!-- END CONFIRM PASSWORD EVENTO -->

        <!-- TELEFONO EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoFecha" CssClass="col-md-2 control-label">Fecha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoFecha" TextMode="Date" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoFecha" CssClass="text-danger" ErrorMessage="El campo de telefono es obligatorio." />
            </div>
        </div>
        <!-- END TELEFONO EVENTO -->
        
        <!-- MAIL PUBLICO EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoHora" CssClass="col-md-2 control-label">Hora</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoHora" TextMode="Time" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoHora" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL PUBLICO EVENTO-->

        <!-- MAIL ADICIONAL EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoNombreLugar" CssClass="col-md-2 control-label">Nombre Lugar</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoNombreLugar" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoNombreLugar" CssClass="text-danger" ErrorMessage="El campo de Mail Principal es obligatorio." />
            </div>
        </div>
        <!-- END MAIL ADICIONAL EVENTO -->

        <!-- DIRECCION LUGAR EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoDireccionLugar" CssClass="col-md-2 control-label">Direccion Lugar</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoDireccionLugar" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoDireccionLugar" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END DIRECCIONLUGAR EVENTO -->

        <!-- BARRIO LUGAR EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoBarrioLugar" CssClass="col-md-2 control-label">Barrio Lugar</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="EventoBarrioLugar" CssClass="form-control" runat="server">
                    <asp:ListItem Value="Pocitos"></asp:ListItem>
                    <asp:ListItem Value="Punta Carretas"></asp:ListItem>
                    <asp:ListItem>Parque Rodo</asp:ListItem>
                    <asp:ListItem>Prado</asp:ListItem>
                    <asp:ListItem Value="Centro"></asp:ListItem>
                    <asp:ListItem Value="Barrio Sur"></asp:ListItem>
                    <asp:ListItem Value="Palermo"></asp:ListItem>
                    <asp:ListItem Value="Ciudad Vieja"></asp:ListItem>
                    <asp:ListItem Value="La Blanqueada"></asp:ListItem>
                    <asp:ListItem Value="Malvin"></asp:ListItem>
                    <asp:ListItem>Buceo</asp:ListItem>
                    <asp:ListItem Value="Flor de Maroñas"></asp:ListItem>
                    <asp:ListItem>Itauzaingo</asp:ListItem>
                    <asp:ListItem>Cerro</asp:ListItem>
                    <asp:ListItem>Cerrito de la Victoria</asp:ListItem>
                    <asp:ListItem Value="Peñarol"></asp:ListItem>
                    <asp:ListItem Value="Casavalle"></asp:ListItem>
                    <asp:ListItem>Aires Puros</asp:ListItem>
                    <asp:ListItem>Piedras Blancas</asp:ListItem>
                    <asp:ListItem>Villa Española</asp:ListItem>
                    <asp:ListItem>Punta de Rieles</asp:ListItem>
                    <asp:ListItem>Unión</asp:ListItem>
                    <asp:ListItem>Casabó</asp:ListItem>
                    <asp:ListItem>La Teja</asp:ListItem>
                    <asp:ListItem>Aguada</asp:ListItem>
                    <asp:ListItem>Reducto</asp:ListItem>
                    <asp:ListItem>Jacinto Vera</asp:ListItem>
                    <asp:ListItem>La Figurita</asp:ListItem>
                    <asp:ListItem>Larrañaga</asp:ListItem>
                    <asp:ListItem>Villa Muñoz</asp:ListItem>
                    <asp:ListItem>La Comercial</asp:ListItem>
                    <asp:ListItem>Tres Cruces</asp:ListItem>
                    <asp:ListItem>Brazo Oriental</asp:ListItem>
                    <asp:ListItem>Sayago</asp:ListItem>
                    <asp:ListItem>Belvedere</asp:ListItem>
                    <asp:ListItem Value="Nuevo Paris"></asp:ListItem>
                    <asp:ListItem>Tres Ombues</asp:ListItem>
                    <asp:ListItem>Paso de la Arena</asp:ListItem>
                    <asp:ListItem>Colon</asp:ListItem>
                    <asp:ListItem Value="Lesica"></asp:ListItem>
                    <asp:ListItem Value="Villa Garcia"></asp:ListItem>
                    <asp:ListItem>Manga</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <!-- END BARRIO LUGAR EVENTO -->

        <!-- CAPASIDAD MAXIMA EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoCapasidadMaxima" CssClass="col-md-2 control-label">Capasidad Maxima</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoCapasidadMaxima" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoDireccionLugar" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END CAPASIDAD MAXIMA EVENTO -->

        <!-- IMAGEN EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoImagen" CssClass="col-md-2 control-label">Imagen</asp:Label>
            <div class="col-md-10">
                <asp:FileUpload ID="EventoImagen" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoImagen" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END IMAGEN EVENTO -->

        <!-- PRECIO EVENTO -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EventoPrecio" CssClass="col-md-2 control-label">Precio</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EventoPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EventoPrecio" CssClass="text-danger" ErrorMessage="El campo de URL es obligatorio." />
            </div>
        </div>
        <!-- END PRECIO EVENTO -->

        <!-- BTN ALTA EVENTO -->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnAltaEvento" Text="Crear Evento" CssClass="btn btn-default" />
            </div>
        </div>
        <!-- BTN ALTA EVENTO -->

    </div>
</asp:Content>
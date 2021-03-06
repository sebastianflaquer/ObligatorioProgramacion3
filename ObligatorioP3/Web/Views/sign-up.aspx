﻿<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="Web.Views.sign_up" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
        <h2><%: Title %></h2>

        <div class="row-fluid" id="errorField" runat="server" visible=false>
            <div class="span12" ID="lblErrorMsj" runat="server">
                <div class="alert alert-error" >
                    <button data-dismiss="alert" class="close" type="button">×</button>            
                    <asp:Label runat="server"  Text="Label"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8">
                <section id="loginForm">
                    <div class="form-horizontal">
                        <h4>Utilice su cuenta para iniciar sesión.</h4>
                        <hr />
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TxtMail" CssClass="col-md-2 control-label">Mail</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtMail" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtMail"
                                    CssClass="text-danger" ErrorMessage="El campo de mail es obligatorio." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TxtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtPassword" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">¿Recordar cuenta?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="BtnLogIn" Text="Iniciar sesión" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                    <p>
                        <asp:HyperLink href="/Views/registro.aspx" runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse</asp:HyperLink>
                        si no tiene una cuenta.
                    </p>
                </section>
            </div>
        
        </div>

    </asp:Content>

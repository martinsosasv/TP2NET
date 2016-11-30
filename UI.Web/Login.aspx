<%@ Page Title="Academia - Login" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="bs-example bs-navbar-top-example" data-example-id="navbar-fixed-to-top">
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="collapsed navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-6" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span> </button>
                    <a href="#" class="navbar-brand">Academia</a>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">Login</a></li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>

    <div class="container container-login">
        <div class="panel panel-default panel-login">
            <div class="panel-heading">Por favor ingrese sus datos</div>
            <div class="panel-body">
                <form>
                        <div class="form-group row">
                            <label for="txtUsuario" class="col-sm-2 col-form-label">Usuario</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtPassword" class="col-sm-2 col-form-label">Password</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="offset-sm-2 col-sm-10">
                            <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" class="btn btn-primary" Text="Ingresar" />
                            </div>
                        </div>
                        <div ID="lblErrorIngreso" runat="server" class="alert alert-danger" role="alert"></div>
                    </form>
                    <a href="#">
                        <asp:LinkButton ID="lbOlvidaPassword" runat="server" onclick="lbOlvidaPassword_Click">Olvidé mi contraseña</asp:LinkButton>
                    </a>
            </div>
        </div>

    
    
        
    </div>
                

</asp:Content>

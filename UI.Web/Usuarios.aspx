<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
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
                        <li class="active"><a href="#">Home</a></li>
                    </ul>
                    <ul class="nav navbar-nav">
                        <li><a href="#">Cuenta</a></li>
                    </ul>
                    <ul class="nav navbar-nav">
                        <li><a href="#" runat="server" id="btpHeaderSalir" onClick="btpHeaderSalir_Click">Salir</a></li>
                    </ul>

                </div>
            </div>
        </nav>
    </div>
    <div class="content">


        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">Usuarios</div>

            <!-- Table -->
            
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#D5EBCC" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="NombrePersona" />
                        <asp:BoundField HeaderText="Apellido" DataField="ApellidoPersona" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>

                </asp:GridView>
            
        </div>



        <asp:Panel ID="gridPanel" CssClass="gridPanelTable" runat="server">
            

        </asp:Panel>

        <asp:Panel ID="formPanel" CssClass="formPanelUser" Visible="false" runat="server">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Label ID="lblAsteriscoNombre" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:Label ID="lblAsteriscoApellido" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:Label ID="lblAsteriscoEmail" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="chkHabilitado" runat="server"></asp:CheckBox>
            <br />
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <asp:Label ID="lblAsteriscoUsuario"  CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblAsteriscoClave" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblClave2" runat="server" Text="Repetir clave"></asp:Label>
            <asp:TextBox ID="txtClave2" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:Label ID="lblAsteriscoClave2" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
            <br />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formValidationPanel" runat="server" Visible="false">
                <asp:BulletedList DisplayMode="Text" ID="listValidationPanel" runat="server" BulletStyle="Circle">
                
                </asp:BulletedList>
            </asp:Panel>
        </asp:Panel>

        <asp:Panel ID="gridActionsPanel" runat="server" >
            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </div>
    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span class="pull-right" style="color: #3366FF">Tecnologías de Desarrollo de Software IDE</span>
            <span style="color: #3366FF">© 2016</span>
        </div>
    </nav>
    
</asp:Content>

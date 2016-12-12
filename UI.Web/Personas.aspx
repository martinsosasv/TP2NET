<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
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
                    <a href="Home.aspx" class="navbar-brand">Academia</a>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="Home.aspx">Home</a></li>
                    </ul>
                    <ul class="nav navbar-nav">
                        <li><a href="Login.aspx" runat="server" id="btpHeaderSalir" onClick="btpHeaderSalir_Click">Salir</a></li>
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
            
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Fecha Nac." DataField="FechaNacimiento" />
                    <asp:BoundField HeaderText="Tipo" DataField="TipoPersona" />
                    <asp:BoundField HeaderText="Legajo" DataField="IdLegajo" />
                    <asp:BoundField HeaderText="Plan" DataField="PlanPersona" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
            



            <asp:Panel ID="gridActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
            </asp:Panel>


        </div>


        <div class="container container-login">
            <asp:Panel ID="formPanel" CssClass="formPanelUser" Visible="false" runat="server">
            <div class="panel panel-default panel-login">
                <div class="panel-heading">Usuario</div>
                <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblId" runat="server" Text="ID: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoNomber" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoApellido" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoDireccion"  CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoEmail" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoTelefono" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDiaNac" Width="36px" runat="server"></asp:TextBox><asp:Label ID="lblBarra1" runat="server" Text="/"></asp:Label>
                                    <asp:TextBox ID="txtMesNac" Width="36px" runat="server"></asp:TextBox><asp:Label ID="lblBarra2" runat="server" Text="/"></asp:Label>
                                    <asp:TextBox ID="txtAnioNac" Width="36px" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoFechaNacimiento" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlTipoPersona" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoPersona_Change"></asp:DropDownList>
                                    <asp:Label ID="lblAsteriscoTipoPersona" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoLegajo" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlPlan" runat="server" DataSourceID="ObjectDataSourcePlan" DataTextField="DescripcionEspPlan" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSourcePlan" runat="server" SelectMethod="GetAll" TypeName="Negocio.PlanLogic"></asp:ObjectDataSource>
                                    <asp:Label ID="lblAsteriscoPlan" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            
                            
                            <asp:Panel ID="formActionsPanel" runat="server">
                                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>
                                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton>
                            </asp:Panel>
                            <asp:Panel ID="formValidationPanel" runat="server" Visible="false">
                                <div runat="server" id="alertForm" class="alert alert-danger" role="alert"></div>
                            </asp:Panel>
                        
                    </div>
                </div>
            </div>
        </asp:Panel>
        
    </div>
    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span>© 2016</span>
            <span class="pull-right">Tecnologías de Desarrollo de Software IDE</span>
        </div>
    </nav>
</asp:Content>

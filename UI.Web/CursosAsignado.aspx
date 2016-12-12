<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="CursosAsignado.aspx.cs" Inherits="UI.Web.CursosAsignado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="content">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">Cursos Asignados</div>
            <!-- Table -->
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="id_curso" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id_curso" HeaderText="Id Curso" 
                    SortExpression="id_curso" />
                <asp:BoundField DataField="comision" HeaderText="Comisión" 
                    SortExpression="comision" />
                <asp:BoundField DataField="materia" HeaderText="Materia" 
                    SortExpression="materia" />
                <asp:BoundField DataField="rol" HeaderText="Rol" 
                    SortExpression="rol" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" 
                    ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Panel ID="gridViewActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnAlumnosInscriptos_Click">Ver alumnos inscriptos</asp:LinkButton>
            </asp:Panel>
            <div runat="server" id="cursosAsignadosEmpty">
                <p>No tienes cursos asignados</p>
            </div>
        </div>

        
            
        <div runat="server" id="divDetalleCurso" class="panel panel-default" visible="false">
            <div class="panel-heading">Detalle del curso</div>
            <asp:GridView ID="gridViewDetalleCurso" runat="server" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="id_inscripcion" OnSelectedIndexChanged="gridViewDetalleCurso_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id_inscripcion" HeaderText="ID Insc" 
                        SortExpression="id_inscripcion" />
                    <asp:BoundField DataField="legajo" HeaderText="Legajo" 
                        SortExpression="legajo" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" 
                        SortExpression="apellido" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                        SortExpression="nombre" />
                    <asp:BoundField DataField="nota" HeaderText="Nota" 
                        SortExpression="nota" />
                    <asp:BoundField DataField="condicion" HeaderText="Condición" 
                        SortExpression="condicion" />
                    <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" 
                        ShowSelectButton="True" />
                </Columns>
            
            </asp:GridView>
            <asp:Panel ID="gridViewDetalleCursoActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnAgregarNota" runat="server" OnClick="btnAgregarNota_Click">Modificar Nota</asp:LinkButton>
            </asp:Panel>
            <div runat="server" id="gridViewDetalleCursoEmpty" visible="false">
                <p>No existen alumnos inscriptos</p>
            </div>
        </div>

        


        <div class="container container-login">
            <asp:Panel ID="formPanelInscripcion" CssClass="formPanelUser" Visible="false" runat="server">
            <div class="panel panel-default panel-login">
                <div class="panel-heading">Modificar Nota</div>
                <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblIDInscripcion" runat="server" Text="ID Insc.: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtIDInscripcion" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblNota" runat="server" Text="Nota: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlNota" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblAsteriscoNota" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
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







    </div>


    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span>© 2016</span>
            <span class="pull-right">Tecnologías de Desarrollo de Software IDE</span>
        </div>
    </nav>
</asp:Content>

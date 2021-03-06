﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="DocenteCurso.aspx.cs" Inherits="UI.Web.DocenteCurso" %>
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
            <div class="panel-heading">Asignar cursos a docentes</div>
            <!-- Table -->
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID Docente" DataField="IdDocente" />
                    <asp:BoundField HeaderText="Docente" DataField="DescDocente" />
                    <asp:BoundField HeaderText="ID Curso" DataField="IdCurso" />
                    <asp:BoundField HeaderText="Curso" DataField="DescCurso" />
                    <asp:BoundField HeaderText="Cargo" DataField="Cargo" />                                       
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
            <asp:Panel ID="gridActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Asignar docente</asp:LinkButton>
                <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            </asp:Panel>
        </div>

        <div class="container container-login">
            <asp:Panel ID="formPanel" CssClass="formPanelUser" Visible="false" runat="server">
            <div class="panel panel-default panel-login">
                <div class="panel-heading">Curso</div>
                <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDocente" runat="server" Text="Docente: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlDocente" runat="server" DataSourceID="ObjectDataSourceDocente" DataTextField="ApellidoNombre" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSourceDocente" runat="server" SelectMethod="GetAllDocentes" TypeName="Negocio.PersonaLogic"></asp:ObjectDataSource>
                                    <asp:Label ID="lblAsteriscoDocente" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlCurso" runat="server" DataSourceID="ObjectDataSourceCurso" DataTextField="DescMateriaComision" DataValueField="ID" Enabled="false"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSourceCurso" runat="server" SelectMethod="GetAll" TypeName="Negocio.CursoLogic"></asp:ObjectDataSource>
                                    <asp:Label ID="lblAsteriscoCurso" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblCargo" runat="server" Text="Cargo: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>                                  
                                    <asp:Label ID="lblAsteriscoCargo" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
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

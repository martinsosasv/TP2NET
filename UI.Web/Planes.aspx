﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
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
            <div class="panel-heading">Planes</div>

            <!-- Table -->
            
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Descripcion Especialidad" DataField="DescripcionEspecialidad" />
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
                <div class="panel-heading">Plan</div>
                <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblID" runat="server" Text="ID: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblAsteriscoDescripcion" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDescripcionEspecialidad" runat="server" Text="Descripción Especialidad: "></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlDescripcionEspecialidad" runat="server" DataSourceID="ObjectDataSourceEspecilidades" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSourceEspecilidades" runat="server" SelectMethod="GetAll" TypeName="Negocio.EspecialidadLogic"></asp:ObjectDataSource>
                                    <asp:Label ID="lblAsteriscoDescripcionEspecialidad" CssClass="asteriscoValidation" runat="server" Visible="False" Text="*" ForeColor="Red"></asp:Label>
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

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="InscripcionAlumnoCurso.aspx.cs" Inherits="UI.Web.InscripcionAlumnoCurso" %>
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
            <div class="panel-heading">Inscripción a cursos</div>
            <!-- Table -->
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id Curso"/>
                    <asp:BoundField DataField="DescComision" HeaderText="Comisión"/>
                    <asp:BoundField DataField="DescMateria" HeaderText="Materia"/>
                    <asp:BoundField DataField="DescPlanEsp" HeaderText="Especialidad"/>
                    <asp:BoundField DataField="AnioCalendario" HeaderText="Año"/>
                    <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" 
                    ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Panel ID="gridActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnInscripcion_Click">Inscribirse</asp:LinkButton>
            </asp:Panel>

        </div>
            
            <div runat="server" id="divCursosInscriptos" class="panel panel-default" visible="true">
                <div class="panel-heading">Cursos inscriptos</div>
                <asp:GridView ID="gridViewCursosInscriptos" runat="server"
                    CssClass="table" SelectedRowStyle-BackColor="#000000"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" AutoGenerateColumns="False">
                    <Columns>
                       <asp:BoundField DataField="ID" HeaderText="Id Curso"/>
                       <asp:BoundField DataField="DescComision" HeaderText="Comisión"/>
                       <asp:BoundField DataField="DescMateria" HeaderText="Materia"/>
                       <asp:BoundField DataField="DescPlanEsp" HeaderText="Especialidad"/>
                       <asp:BoundField DataField="AnioCalendario" HeaderText="Año"/>
                    </Columns>
                </asp:GridView>
            </div>

    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span>© 2016</span>
            <span class="pull-right">Tecnologías de Desarrollo de Software IDE</span>
        </div>
    </nav>
</asp:Content>

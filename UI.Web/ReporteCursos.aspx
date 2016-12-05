<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteCursos.aspx.cs" Inherits="UI.Web.ReporteCursos" %>
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
                    <li><a href="Cuenta.aspx">Cuenta</a></li>
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
            <div class="panel-heading">Reporte Cursos</div>
            <!-- Table -->
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Comisión" DataField="DescComision" />
                    <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
                    <asp:BoundField HeaderText="Plan" DataField="DescPlanEsp" />                                       
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
            <asp:Panel ID="gridViewActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnReporte_Click">Generar Reporte</asp:LinkButton>
            </asp:Panel>
            <div runat="server" id="gridViewEmpty">
                <p>No existen cursos</p>
            </div>

        </div>
            
        <div runat="server" id="divReporteCurso" class="panel panel-default" visible="false">
            <div class="panel-heading">Listado de alumnos</div>
            <asp:GridView ID="gridViewReporteCursos" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="ID" >
                <Columns>
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                </Columns>
            </asp:GridView>
            <div runat="server" id="gridViewReporteCursosEmpty">
                <p>No existen alumnos asignados a este curso</p>
            </div>
        </div>

    </div>
    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span>© 2016</span>
            <span class="pull-right">Tecnologías de Desarrollo de Software IDE</span>
        </div>
    </nav>
</asp:Content>

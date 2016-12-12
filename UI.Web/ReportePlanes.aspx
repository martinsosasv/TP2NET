<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.ReportePlanes" %>
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
            <div class="panel-heading">Planes</div>
            <!-- Table -->
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" SelectedRowStyle-BackColor="#000000" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Plan" DataField="DescripcionEspPlan" />                         
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
            <asp:Panel ID="gridViewActionsPanel" CssClass="gridActionsPanelRight" runat="server" >
                <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnReporte_Click">Generar Reporte</asp:LinkButton>
            </asp:Panel>
            <div runat="server" id="gridViewEmpty">
                <p>No existen planes</p>
            </div>

        </div>
            
            <div runat="server" id="divReportePlan" class="panel panel-default" visible="false">
                <div class="panel-heading">Reporte Plan</div>
                <asp:GridView ID="gridViewReportePlan" runat="server" AutoGenerateColumns="false" CssClass="table" DataKeyNames="ID" >
                    <Columns>
                        <asp:BoundField HeaderText="Materia" DataField="Descripcion" />
                    </Columns>
                </asp:GridView>
                <div runat="server" id="gridViewReportePlanEmpty">
                    <p>No existen materias asignadas</p>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
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
                        <li class="active"><a href="#">Home</a></li>
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
    </div>
    <div class="content">
        
        <div class="header">

            <h1 class="page-title">Sistema de Gestión de Alumnos
                <br />
                <i class="icon-user"></i><asp:Label ID="lblBienvenido" runat="server" Font-Names="Lucida Fax" 
                    Font-Size="Small" ForeColor="#3366FF"></asp:Label>
                <br />
            </h1>
            
        </div>
        <div class="container container-mnu">
            <div runat="server" id="listMnuABM" class="list-group">
                <a href="#" class="list-group-item disabled">
                ABM
                </a>
                <a href="Especialidades.aspx" runat="server" id="aMnuEspecialidadesABM" class="list-group-item">Especialidades</a>
                <a href="Planes.aspx" runat="server" id="aMnuPlanesABM" class="list-group-item">Planes</a>
                <a href="Materias.aspx" runat="server" id="aMnuMateriasABM" class="list-group-item">Materias</a>
                <a href="Comisiones.aspx" runat="server" id="aMnuComisionesABM" class="list-group-item">Comisiones</a>
                <a href="Cursos.aspx" runat="server" id="aMnuCursosABM" class="list-group-item">Cursos</a>
                <a href="Personas.aspx" runat="server" id="aMnuPersonasABM" class="list-group-item">Personas</a>
                <a href="Usuarios.aspx" runat="server" ID="aMnuUsuariosABM" class="list-group-item">Usuarios</a>
                <a href="DocenteCurso.aspx" runat="server" ID="aMnuDocenteCursoAMB" class="list-group-item">Cursos Docentes</a>
            </div>
            <div runat="server" id="listMnuReportes" class="list-group">
                <a href="#" class="list-group-item disabled">
                Reportes
                </a>
                <a href="ReporteCursos.aspx" runat="server" id="aMnuCursosReportes" class="list-group-item">Cursos</a>
                <a href="ReportePlanes.aspx" runat="server" id="aMnuEspecialidadesReportes" class="list-group-item">Planes</a>
            </div>
            <div runat="server" id="listMnuDocentes" class="list-group">
                <a href="#" class="list-group-item disabled">
                Docentes
                </a>
                <a href="CursosAsignado.aspx" runat="server" id="aMnuCursosAsigandosDocentes" class="list-group-item">Ver cursos asignados</a>
            </div>
            <div runat="server" id="listMnuAlumnos" class="list-group">
                <a href="#" class="list-group-item disabled">
                Alumnos
                </a>
                <a href="InscripcionAlumnoCurso.aspx" runat="server" id="aMnuInscripcionAlumnos" class="list-group-item">Inscripción a cursado</a>
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

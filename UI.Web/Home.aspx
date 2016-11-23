<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="navbar">
        <div class="navbar-inner">
                <a class="brand" href="Home.aspx">UTN <span class="second">Academia</span></a>
        </div>
    </div>
    


    
    <div class="sidebar-nav">
        
        <a href="#dashboard-menu" class="nav-header" data-toggle="collapse">Menu</a>
        <ul id="dashboard-menu" class="nav nav-list collapse in">
            <li><a href="Home.aspx">Home</a></li>
            
        </ul>

        <a href="#accounts-menu" class="nav-header" data-toggle="collapse">Cuenta</a>
        <ul id="accounts-menu" class="nav nav-list collapse">
            <li ><a href="Login.aspx">Salir</a></li>
        </ul>

        <a href="#legal-menu" class="nav-header" data-toggle="collapse">Acerca de 
        nosotros</a>
        <ul id="legal-menu" class="nav nav-list collapse">
            <li ><a href="About.aspx">Quienes somos</a></li>
        </ul>

        <a href="Ayuda.aspx" class="nav-header" >Ayuda</a>&nbsp;
    </div>
    

    
    <div class="content">
        
        <div class="header">

            <h1 class="page-title">Sistema de Gestión de Alumnos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <i class="icon-user"></i><asp:Label ID="lblBienvenido" runat="server" Font-Names="Lucida Fax" 
                    Font-Size="Small" ForeColor="#3366FF"></asp:Label>
                <br />
            </h1>
            
        </div>
        
                <ul class="breadcrumb">
            <li><a href="Home.aspx">Home</a> <span class="divider">/Menu</span></li>
        </ul>

        <div class="container-fluid">
            <div class="row-fluid">
                    

<div class="row-fluid">
    <div class="block span6">
        <p class="block-heading" align="center">MENÚ</p>
        <div class="block-body" align="center" 
            style="background-color: #666666; color: #FFFFFF;">
            <asp:LinkButton ID="lbInscribirseACursado" runat="server" ForeColor="White" 
                onclick="lbInscribirseACursado_Click">Inscripción a cursado</asp:LinkButton>
            <asp:LinkButton ID="lbCursosAsignados" runat="server" ForeColor="White" 
                onclick="lbCursosAsignados_Click">Cursos asignados</asp:LinkButton>
            <asp:LinkButton ID="lbEspecialidades" runat="server" ForeColor="White" 
                onclick="lbEspecialidades_Click">Especialidades</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbEstadoAcademico" runat="server" ForeColor="White" 
                onclick="lbEstadoAcademico_Click">Estado Académico</asp:LinkButton>
            <asp:LinkButton ID="lbComisiones" runat="server" ForeColor="White" 
                onclick="lbComisiones_Click">Comisiones</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbCursos" runat="server" ForeColor="White" 
                onclick="lbCursos_Click">Cursos</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbMaterias" runat="server" ForeColor="White" 
                onclick="lbMaterias_Click">Materias</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbPlanes" runat="server" ForeColor="White" 
                onclick="lbPlanes_Click">Planes</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbDocentes_Curso" runat="server" ForeColor="White" 
                onclick="lbDocentes_Curso_Click">Asignar docentes a un curso</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbAlumnos_Inscripcion" runat="server" ForeColor="White" 
                onclick="lbAlumnos_Inscripcion_Click">Inscripción de Alumnos</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbPersonas" runat="server" ForeColor="White" 
                onclick="lbPersonas_Click">Personas</asp:LinkButton>
            <br />
        </div>
    </div>
    <div class="block span6">
        <p class="block-heading" align="center">REPORTES</p>
        <div class="block-body">
            <p align="center">
                <asp:Button ID="btnReportePlanes" runat="server" BackColor="#003366" 
                    Font-Names="Lucida Fax" ForeColor="White" Height="32px" 
                    onclick="btnReportePlanes_Click" Text="Ver reporte planes»" />
            </p>
                    

             <br />

             <p align="center">
                 <asp:Button ID="btnReporteCursos" runat="server" BackColor="#003366" 
                     Font-Names="Lucida Fax" ForeColor="White" Height="32px" 
                     onclick="btnReporteCursos_Click" Text="Ver reporte cursos»" />
            </p>
        </div>
    </div>
</div>


                    
                    <footer>
                        
                        <!-- Purchase a site license to remove this link from the footer: http://www.portnine.com/bootstrap-themes -->
                        <p class="pull-right" style="color: #3366FF">Tecnologías de Desarrollo de Software 
                            IDE</p>
                        

                        <p style="color: #3366FF">© 2014 Grupo 25</p>
                    </footer>
                    
            </div>
        </div>
    </div>

</asp:Content>

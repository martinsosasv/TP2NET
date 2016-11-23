using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Write("<script>window.alert('Bienvenido!');</script>");
                this.lblBienvenido.Text = Session["usuario"].ToString();
                int id_tipo_persona = Convert.ToInt32(Session["id_tipo_persona"]);
                switch (id_tipo_persona)
                {
                    //admin
                    case 0: this.lbEstadoAcademico.Visible = false;
                        this.lbInscribirseACursado.Visible = false;
                        this.lbCursosAsignados.Visible = false;

                        break;

                    //alumno
                    case 1: this.lbAlumnos_Inscripcion.Visible = false;
                        this.lbComisiones.Visible = false;
                        this.lbCursos.Visible = false;
                        this.lbCursosAsignados.Visible = false;
                        this.lbDocentes_Curso.Visible = false;
                        this.lbEspecialidades.Visible = false;
                        this.lbMaterias.Visible = false;
                        this.lbPlanes.Visible = false;
                        this.lbPersonas.Visible = false;
                        this.btnReporteCursos.Visible = false;

                        break;

                    //docente
                    case 2: this.lbAlumnos_Inscripcion.Visible = false;
                        this.lbComisiones.Visible = false;
                        this.lbCursos.Visible = false;
                        this.lbEstadoAcademico.Visible = false;
                        this.lbInscribirseACursado.Visible = false;
                        this.lbDocentes_Curso.Visible = false;
                        this.lbEspecialidades.Visible = false;
                        this.lbMaterias.Visible = false;
                        this.lbPlanes.Visible = false;
                        this.lbPersonas.Visible = false;
                        this.btnReporteCursos.Visible = false;
                        break;

                    default: Page.Response.Redirect("~/Error.aspx");
                        break;

                }


            }
        }


        protected void lbComisiones_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Comisiones.aspx");

        }

        protected void lbCursosAsignados_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("CursosAsignados.aspx");

        }

        protected void lbInscribirseACursado_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("InscribirseACursado.aspx");
        }

        protected void lbEspecialidades_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Especialidades.aspx");
        }

        protected void lbEstadoAcademico_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("EstadoAcademico.aspx");
        }

        protected void lbCursos_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Cursos.aspx");
        }

        protected void lbPlanes_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Planes.aspx");
        }

        protected void lbDocentes_Curso_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Docentes_Curso.aspx");
        }

        protected void lbAlumnos_Inscripcion_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Alumnos_Inscripcion.aspx");
        }

        protected void lbPersonas_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Personas.aspx");
        }

        protected void lbMaterias_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Materias.aspx");
        }

        protected void btnReporteCursos_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ReporteCursosGrid.aspx");
        }

        protected void btnReportePlanes_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ReportePlanes.aspx");
        }
    }
}
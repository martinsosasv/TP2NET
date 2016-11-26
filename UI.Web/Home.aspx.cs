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
                if (Session["usuario"] == null)
                {
                    //MessageBoxAlert("Su sesión ha expirado", "Home");
                    Page.Response.Redirect("Login.aspx");
                }
                else
                {
                    this.lblBienvenido.Text = Session["usuario"].ToString();
                    int id_tipo_persona = Convert.ToInt32(Session["id_tipo_persona"]);
                    switch (id_tipo_persona)
                    {
                        //admin
                        case 1: 
                            this.listMnuAlumnos.Visible = false;
                            this.listMnuDocentes.Visible = false;
                            break;
                        //docente
                        case 2:
                            this.listMnuABM.Visible = false;
                            this.listMnuReportes.Visible = false;
                            this.listMnuAlumnos.Visible = false;
                            break;
                        //alumno
                        case 3:
                            this.listMnuABM.Visible = false;
                            this.listMnuReportes.Visible = false;
                            this.listMnuDocentes.Visible = false;
                            break;
                        default: 
                            MessageBoxAlert("Tipo de usuario inválido. Intente ingresar nuevamente.", "Home");
                            Page.Response.Redirect("Login.aspx");
                            break;

                    }
                }
                


            }
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

        protected void btpHeaderSalir_Click(object sender, EventArgs e)
        {
            //Session.Abandon();
            Page.Response.Redirect("Login.aspx");
        }

        private void MessageBoxAlert(string message, string title = "title")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), title, "alert('" + message + "')'", true);
        }
    }
}
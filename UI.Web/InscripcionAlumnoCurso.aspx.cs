using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Util;

namespace UI.Web
{
    public partial class InscripcionAlumnoCurso : System.Web.UI.Page
    {
        AluInscLogic _logic;
        private AluInscLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AluInscLogic();
                }
                return _logic;
            }
        }

        private AlumnoInscripcion Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            List<Curso> listadoCursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();
            listadoCursos = curLog.GetAll();

            List<AlumnoInscripcion> listadoAlumno_Inscripciones = new List<AlumnoInscripcion>();
            AluInscLogic aluInscLog = new AluInscLogic();
            listadoAlumno_Inscripciones = aluInscLog.GetInscripcionesAlumno(Convert.ToInt32(Session["id_persona"]));

            List<Curso> listadoCursosAInscribir = new List<Curso>();

            for (int i = 0; i < listadoCursos.Count; i++)
            {
                bool bandera = false;

                for (int j = 0; j < listadoAlumno_Inscripciones.Count; j++)
                {
                    if (listadoAlumno_Inscripciones[j].Curso.ID == listadoCursos[i].ID)
                    {
                        bandera = true;
                    }
                }

                if (bandera == false)
                {
                    listadoCursosAInscribir.Add(listadoCursos[i]);
                }
            }

            this.gridView.DataSource = listadoCursosAInscribir;
            this.gridView.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    MessageBoxAlert("Su sesión ha expirado", "Reporte Planes", "Login.aspx");
                }
                else
                {
                    int id_tipo_persona = Convert.ToInt32(Session["id_tipo_persona"]);
                    switch (id_tipo_persona)
                    {
                        //Alumno
                        case 3:
                            this.LoadGrid();
                            this.LoadGridAlumnosInscriptos();
                            break;
                        default:
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Reporte Planes", "Home.aspx");
                            break;
                    }
                }
            }
        }

        private void MessageBoxAlert(string message, string title = "title", string page = "Login.aspx")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), title,
                        "alert('" + message + "'); window.location='" +
                        Request.ApplicationPath + page + "';", true);
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID= (int)this.gridView.SelectedValue;
        }

        protected void btnInscripcion_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                //this.divCursosInscriptos.Visible = true;
                //this.formValidationPanel.Visible = false
                
                int id_curso = Convert.ToInt32(this.gridView.SelectedRow.Cells[0].Text);
                AlumnoInscripcion aluIns = new AlumnoInscripcion();
                aluIns.Nota = 0;
                this.Logic.Insert(Convert.ToInt32(Session["id_persona"]), id_curso, aluIns.Condicion, aluIns.Nota);
                this.LoadGrid();
                this.LoadGridAlumnosInscriptos();
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void LoadGridAlumnosInscriptos()
        {
            List<Curso> listadoCursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();
            listadoCursos = curLog.GetAll();

            List<AlumnoInscripcion> listadoAlumno_Inscripciones = new List<AlumnoInscripcion>();
            AluInscLogic aluInscLog = new AluInscLogic();
            listadoAlumno_Inscripciones = aluInscLog.GetInscripcionesAlumno(Convert.ToInt32(Session["id_persona"]));

            List<Curso> listadoCursosInscriptos = new List<Curso>();

            for (int i = 0; i < listadoCursos.Count; i++)
            {
                bool bandera = false;

                for (int j = 0; j < listadoAlumno_Inscripciones.Count; j++)
                {
                    if (listadoAlumno_Inscripciones[j].Curso.ID == listadoCursos[i].ID)
                    {
                        bandera = true;
                    }
                }

                if (bandera == true)
                {
                    listadoCursosInscriptos.Add(listadoCursos[i]);
                }
            }

            this.gridViewCursosInscriptos.DataSource = listadoCursosInscriptos;
            this.gridViewCursosInscriptos.DataBind();
        }
        

        /*protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.divCursosInscriptos.Visible = false;
        }*/
    }
}
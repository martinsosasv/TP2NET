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
    public partial class CursosAsignado : System.Web.UI.Page
    {
        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        MateriaLogic _materiaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_materiaLogic == null)
                {
                    _materiaLogic = new MateriaLogic();
                }
                return _materiaLogic;
            }
        }

        private Plan Entity
        {
            get;
            set;
        }

        private int SelectedIDCurso
        {
            get
            {
                if (this.ViewState["SelectedIDCurso"] != null)
                {
                    return (int)this.ViewState["SelectedIDCurso"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDCurso"] = value;
            }
        }

        private int SelectedIDInscripcion
        {
            get
            {
                if (this.ViewState["SelectedIDInscripcion"] != null)
                {
                    return (int)this.ViewState["SelectedIDInscripcion"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDInscripcion"] = value;
            }
        }

        private bool IsEntitySelectedCurso
        {
            get
            {
                return (this.SelectedIDCurso != 0);
            }
        }

        private bool IsEntitySelectedInscripcion
        {
            get
            {
                return (this.SelectedIDInscripcion != 0);
            }
        }

        private void LoadGrid()
        {
            List<Docente_Curso> listadoDocenteCursos = new List<Docente_Curso>();
            Docente_CursoLogic docCurLog = new Docente_CursoLogic();
            listadoDocenteCursos = docCurLog.GetAll(Convert.ToInt32(Session["id_persona"]));
            if(listadoDocenteCursos.Count == 0)
            {
                this.gridView.Visible = false;
                this.gridViewActionsPanel.Visible = false;
                this.cursosAsignadosEmpty.Visible = true;
            }
            else
            {

                this.gridView.Visible = true;
                this.gridViewActionsPanel.Visible = true;
                this.cursosAsignadosEmpty.Visible = false;

                List<Curso> listadoCursos = new List<Curso>();
                CursoLogic curLog = new CursoLogic();
                listadoCursos = curLog.GetAll();

                var estado = from doccur in listadoDocenteCursos
                             join curso in listadoCursos
                             on doccur.Curso.ID equals curso.ID
                             select new
                             {
                                 id_curso = curso.ID,
                                 comision = curso.Comision.Descripcion,
                                 materia = curso.Materia.Descripcion,
                                 rol = doccur.Cargo
                             };

                //dgvCursosAsignados.DataSource = estado.ToList();
                this.gridView.DataSource = estado.ToList();
                this.gridView.DataBind();
                /*if (this.dgvAlumnosInscriptosACurso.Rows.Count == 0)
                { this.lblGridVacia.Visible = true; }*/
            }
            
        }

        private void LoadGridAlumnosInscriptos(int id)
        {

            List<AlumnoInscripcion> listadoAlumno_Inscripcion = new List<AlumnoInscripcion>();
            AluInscLogic aluInsLog = new AluInscLogic();
            listadoAlumno_Inscripcion = aluInsLog.GetAll();

            if(listadoAlumno_Inscripcion.Count == 0)
            {
                this.gridViewDetalleCurso.Visible = false;
                this.gridViewDetalleCursoActionsPanel.Visible = false;
                this.cursosAsignadosEmpty.Visible = true;
            }
            else
            {
                this.gridViewDetalleCurso.Visible = true;
                this.gridViewDetalleCursoActionsPanel.Visible = true;
                this.cursosAsignadosEmpty.Visible = false;
                List<Persona> listadoPersonas = new List<Persona>();
                PersonaLogic perLog = new PersonaLogic();
                listadoPersonas = perLog.GetAll();

                var inscriptos = from aluins in listadoAlumno_Inscripcion
                                 join alu in listadoPersonas
                                 on aluins.Alumno.ID equals alu.ID
                                 //where (aluins.Curso.ID == Convert.ToInt32(id) && aluins.Condicion == "Cursando")
                                 where (aluins.Curso.ID == Convert.ToInt32(id) )
                                 select new
                                 {
                                     id_inscripcion = aluins.ID,
                                     legajo = alu.IdLegajo,
                                     apellido = alu.Apellido,
                                     nombre = alu.Nombre,
                                     nota = aluins.Nota
                                 };

                gridViewDetalleCurso.DataSource = inscriptos.ToList();
                gridViewDetalleCurso.DataBind();
                /*if (this.dgvAlumnosInscriptosACurso.Rows.Count == 0)
                { this.lblGridVacia.Visible = true; }*/
            }

            

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
                        //docente
                        case 2:
                            this.LoadGrid();
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
            this.SelectedIDCurso = (int)this.gridView.SelectedValue;
            this.divDetalleCurso.Visible = false;
            this.formPanelInscripcion.Visible = false;
        }

        protected void gridViewDetalleCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDInscripcion = (int)this.gridView.SelectedValue;
            this.formPanelInscripcion.Visible = false;
        }

        protected void btnAlumnosInscriptos_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelectedCurso)
            {
                this.divDetalleCurso.Visible = true;
                //this.formValidationPanel.Visible = false
                this.LoadGridAlumnosInscriptos(this.SelectedIDCurso);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        protected void btnAgregarNota_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelectedInscripcion)
            {
                
                this.formPanelInscripcion.Visible = true;
                this.formValidationPanel.Visible = false;
                this.LoadForm(this.SelectedIDInscripcion);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void LoadForm(int id)
        {

            AlumnoInscripcion aluIns = new AlumnoInscripcion();

            AluInscLogic aluInsLogic = new AluInscLogic();
            aluIns = aluInsLogic.GetOne(id);
            this.txtIDInscripcion.Text = aluIns.ID.ToString();
            this.ddlNota.SelectedValue = aluIns.Nota.ToString();
            
            //TODO: Ocultar formulario y actualizar detalle curso


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion aluIns = new AlumnoInscripcion();
            aluIns.ID = Convert.ToInt32(txtIDInscripcion.Text);
            aluIns.Nota = Convert.ToInt32(ddlNota.SelectedValue);

            AluInscLogic aluInsLogic = new AluInscLogic();
            aluInsLogic.UpdateNota(aluIns);

            this.formPanelInscripcion.Visible = false;
            this.LoadGridAlumnosInscriptos(this.SelectedIDCurso);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.divDetalleCurso.Visible = false;
        }
    }
}
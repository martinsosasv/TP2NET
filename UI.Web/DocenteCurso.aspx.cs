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
    public partial class DocenteCurso : System.Web.UI.Page
    {
        Docente_CursoLogic _logic;
        private Docente_CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new Docente_CursoLogic();
                }
                return _logic;
            }
        }

        PersonaLogic _personaLogic;
        private PersonaLogic PersonaLogic
        {
            get
            {
                if (_personaLogic == null)
                {
                    _personaLogic = new PersonaLogic();
                }
                return _personaLogic;
            }
        }

        CursoLogic _cursoLogic;
        private CursoLogic CursoLogic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
       } 


        public enum FormModes
        {
            Alta, Baja, Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private Docente_Curso Entity
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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
            this.ddlCargo.DataSource = Enum.GetNames(typeof(Docente_Curso.TipoCargo));
            this.ddlCargo.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    MessageBoxAlert("Su sesión ha expirado", "Docentes cursos", "Login.aspx");
                }
                else
                {
                    int id_tipo_persona = Convert.ToInt32(Session["id_tipo_persona"]);
                    switch (id_tipo_persona)
                    {
                        //admin
                        case 1:
                            this.LoadGrid();
                            break;
                        default:
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Docentes cursos", "Home.aspx");
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
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            
            this.Entity = this.Logic.GetOne(id);
            this.ddlDocente.SelectedValue = this.Entity.Docente.ID.ToString();
            this.ddlCurso.SelectedValue = this.Entity.Curso.ID.ToString();
            this.ddlCargo.SelectedValue =  this.Entity.Cargo.ToString();          
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.ClearForm();
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formValidationPanel.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void LoadEntity(Docente_Curso doc_curso)
        {

            doc_curso.Cargo = (Docente_Curso.TipoCargo)Enum.Parse(typeof(Docente_Curso.TipoCargo), this.ddlCargo.SelectedValue);
           
            Persona doc = new Persona();
            doc = this.PersonaLogic.GetOne(Convert.ToInt32(this.ddlDocente.SelectedValue));
            doc_curso.Docente = doc;

            Curso cur = new Curso();
            cur = this.CursoLogic.GetOne(Convert.ToInt32(this.ddlCurso.SelectedValue));
            doc_curso.Curso = cur;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                        this.Entity = new Docente_Curso();
                        this.Entity.ID = this.SelectedID;
                        this.LoadEntity(this.Entity);
                        this.Logic.Update(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;                    
                    break;
                case FormModes.Alta:                                        
                        this.Entity = new Docente_Curso();
                        this.LoadEntity(this.Entity);
                        this.Logic.Insert(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;                    
                    break;

                default:
                    break;
            }
        }

        private void EnableForm(bool enable)
        {
            this.ddlCargo.Enabled = enable;
            this.ddlCurso.Enabled = enable;
            this.ddlDocente.Enabled = enable;           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.ClearForm();
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.formValidationPanel.Visible = false;
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
            this.formValidationPanel.Visible = false;
        }

        private void ClearForm()
        {
            this.ddlCargo.SelectedIndex = -1;
            this.ddlCurso.SelectedIndex = -1;
            this.ddlDocente.SelectedIndex = -1;

            this.lblAsteriscoCurso.Visible = false;
            this.lblAsteriscoDocente.Visible = false;
            this.lblAsteriscoCargo.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
    }
}
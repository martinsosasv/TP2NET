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
    public partial class Cursos : System.Web.UI.Page
    {
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
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

        ComisionLogic _comisionLogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_comisionLogic == null)
                {
                    _comisionLogic = new ComisionLogic();
                }
                return _comisionLogic;
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

        private Curso Entity
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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    MessageBoxAlert("Su sesión ha expirado", "Cursos", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Cursos", "Home.aspx");
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
            this.ddlComision.SelectedValue = this.Entity.Comision.ID.ToString();
            this.ddlMateria.SelectedValue = this.Entity.Materia.ID.ToString();
            this.txtAnioCalendario.Text = this.Entity.AnioCalendario.ToString();
            this.txtCupo.Text = this.Entity.Cupo.ToString();
            this.txtID.Text = Entity.ID.ToString();
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

        private void LoadEntity(Curso curso)
        {

            curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            Comision com = new Comision();
            com = ComisionLogic.GetOne(Convert.ToInt32(this.ddlComision.SelectedValue));
            curso.Comision = com;

            Materia mat = new Materia();
            mat = MateriaLogic.GetOne(Convert.ToInt32(this.ddlMateria.SelectedValue));
            curso.Materia = mat;

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
                    if (Validar())
                    {
                        this.Entity = new Curso();
                        this.Entity.ID = this.SelectedID;
                        this.LoadEntity(this.Entity);
                        this.Logic.Update(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    if (Validar())
                    {
                        this.Entity = new Curso();
                        this.LoadEntity(this.Entity);
                        this.Logic.Insert(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    break;

                default:
                    break;

            }
        }

        private bool Validar()
        {
            this.alertForm.InnerHtml = "";
            string mensaje = "";
            //Descripcion
            if (!Validaciones.esAnioCalendarioValido(this.txtAnioCalendario.Text))
            {
                this.lblAsteriscoAnioCalendario.Visible = true;
                mensaje += "- El campo Año Calendario es requerido y debe ser mayor a 1949" + "<br/>";
            }
            if (!Validaciones.esCupoValido(this.txtCupo.Text))
            {
                this.lblAsteriscoCupo.Visible = true;
                mensaje += "- El campo Cupo es requerido y debe contener números" + "<br/>";
            }
            if (this.ddlComision.SelectedValue == "-1")
            {
                this.lblAsteriscoComision.Visible = true;
                mensaje += "- El curso debe tener una comisión asignada" + "<br/>";
            }
            if (this.ddlMateria.SelectedValue == "-1")
            {
                this.lblAsteriscoMateria.Visible = true;
                mensaje += "- El curso debe tener una materia asignada" + "<br/>";
            }

            //Mostrar los errores
            if (!String.IsNullOrEmpty(mensaje))
            {
                this.alertForm.InnerHtml = mensaje;
                formValidationPanel.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EnableForm(bool enable)
        {
            this.txtAnioCalendario.Enabled = enable;
            this.txtCupo.Enabled = enable;
            this.ddlComision.Enabled = enable;
            this.ddlMateria.Enabled = enable;
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
            this.txtID.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
            this.txtAnioCalendario.Text = string.Empty;
            this.ddlComision.SelectedIndex = -1;
            this.ddlComision.SelectedIndex = -1;

            this.lblAsteriscoAnioCalendario.Visible = false;
            this.lblAsteriscoComision.Visible = false;
            this.lblAsteriscoCupo.Visible = false;
            this.lblAsteriscoMateria.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
    }
}
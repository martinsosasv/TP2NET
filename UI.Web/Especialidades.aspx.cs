using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using Util;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
    {
        #region PROPIEDADES
        EspecialidadLogic _logic;
        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
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

        private Especialidad Entity
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

        #endregion

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
                    MessageBoxAlert("Su sesión ha expirado", "Especialidades", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Especialidades", "Home.aspx");
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
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtID.Text = Entity.ID.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
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

        private void LoadEntity(Especialidad especialidad)
        {

            especialidad.Descripcion = this.txtDescripcion.Text;
            
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

                        this.Entity = new Especialidad();
                        this.Entity.ID = this.SelectedID;
                        //this.Entity.State = Entidades.Entidades.States.Modified;
                        this.LoadEntity(this.Entity);
                        //this.SaveEntity(this.Entity);
                        this.Logic.Update(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }

                    break;
                case FormModes.Alta:
                    if (Validar())
                    {
                        this.Entity = new Especialidad();
                        this.LoadEntity(this.Entity);
                        this.Logic.Create(this.Entity);
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
            if (!Validaciones.esDescripcionValida(this.txtDescripcion.Text))
            {
                this.lblAsteriscoDescripcion.Visible = true;
                mensaje += "- El campo Descripción es requerido y no debe contener caracteres especiales" + "<br/>";
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
            this.txtDescripcion.Enabled = enable;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
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
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.formValidationPanel.Visible = false;
        }

        private void ClearForm()
        {
            
            this.txtID.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
           
            this.lblAsteriscoDescripcion.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
    }
}
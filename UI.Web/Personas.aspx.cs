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
    public partial class Personas : System.Web.UI.Page
    {
        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
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

        private Persona Entity
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
                    //MessageBoxAlert("Su sesión ha expirado", "Home");
                    MessageBoxAlert("Su sesión ha expirado", "Personas", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Personas", "Home.aspx");
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
            this.formPanel.Visible = false;
            this.ClearForm();
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtID.Text = this.Entity.ID.ToString();
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtDireccion.Text = this.Entity.Direccion;
            this.txtEmail.Text = this.Entity.Email;
            this.txtTelefono.Text = this.Entity.Telefono;
            this.txtDiaNac.Text = this.Entity.FechaNacimiento.Day.ToString();
            this.txtMesNac.Text = this.Entity.FechaNacimiento.Month.ToString();
            this.txtAnioNac.Text = this.Entity.FechaNacimiento.Year.ToString();

            this.ddlTipoPersona.DataSource = Enum.GetNames(typeof(Persona.TiposPersonas));
            this.ddlTipoPersona.DataBind();
            this.ddlTipoPersona.SelectedValue = this.Entity.TipoPersona.ToString();

            if (this.Entity.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.txtLegajo.Enabled = true;
                this.ddlPlan.Enabled = true;
                this.txtLegajo.Text = this.Entity.IdLegajo.ToString();
                this.ddlPlan.SelectedValue = this.Entity.Plan.ID.ToString();
            }
            else
            {
                this.txtLegajo.Enabled = false;
                this.ddlPlan.Enabled = false;
                this.txtLegajo.Text = string.Empty;
                this.ddlPlan.SelectedIndex = -1;
            }

            
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

        private void LoadEntity(Persona per)
        {
            per.Nombre = this.txtNombre.Text;
            per.Apellido = this.txtApellido.Text;
            per.Direccion = this.txtDireccion.Text;
            per.Telefono = this.txtTelefono.Text;
            per.Email = this.txtEmail.Text;
            per.Nombre = this.txtNombre.Text;
            int dia = new int();
            dia = Convert.ToInt32(this.txtDiaNac.Text);
            int mes = new int();
            mes = Convert.ToInt32(this.txtMesNac.Text);
            int anio = new int();
            anio = Convert.ToInt32(this.txtAnioNac.Text);
            DateTime fecNac = new DateTime(anio, mes, dia);
            per.FechaNacimiento = fecNac;
            per.TipoPersona = (Persona.TiposPersonas)Enum.Parse(typeof(Persona.TiposPersonas), this.ddlTipoPersona.SelectedValue);

            if(per.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                per.IdLegajo = Convert.ToInt32(this.txtLegajo.Text);
                PlanLogic planLogic = new PlanLogic();
                Plan plan = new Plan();
                plan = planLogic.GetOne(Convert.ToInt32(this.ddlPlan.SelectedValue));
                per.Plan = plan;
            }
            else
            {
                per.IdLegajo = -1;
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    this.ClearForm();
                    break;
                case FormModes.Modificacion:
                    if (Validar())
                    {

                        this.Entity = new Persona();
                        this.Entity.ID = this.SelectedID;
                        this.LoadEntity(this.Entity);
                        this.Logic.Update(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        this.ClearForm();
                    }

                    break;
                case FormModes.Alta:
                    if (Validar())
                    {
                        this.Entity = new Persona();
                        this.LoadEntity(this.Entity);
                        this.Logic.Insert(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        this.ClearForm();
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


            //Nombre
            if (!Validaciones.esDescripcionValida(this.txtNombre.Text))
            {
                this.lblAsteriscoNomber.Visible = true;
                mensaje += "- El campo Nombre es requerido" + "<br/>";
            }
            else
            {
                this.lblAsteriscoNomber.Visible = false;
            }
            //Apellido
            if (!Validaciones.esDescripcionValida(this.txtApellido.Text))
            {
                this.lblAsteriscoApellido.Visible = true;
                mensaje += "- El campo Apellido es requerido" + "<br/>";
            }
            else
            {
                this.lblAsteriscoApellido.Visible = false;
            }
            //Direccion
            if (!Validaciones.esDescripcionValida(this.txtDireccion.Text))
            {
                this.lblAsteriscoDireccion.Visible = true;
                mensaje += "- El campo Descripción es requerido" + "<br/>";
            }
            else
            {
                this.lblAsteriscoDireccion.Visible = false;
            }
            //Email
            if (!Validaciones.esEmailValido(this.txtEmail.Text))
            {
                mensaje += "- El campo Email es requerido y debe ser del formato de correo electrónico" + "<br/>";
                this.lblAsteriscoEmail.Visible = true;
            }
            else
            {
                this.lblAsteriscoEmail.Visible = false;
            }
            //Telefono
            if (!Validaciones.esTelefonoValido(this.txtTelefono.Text))
            {
                mensaje += "- El campo Teléfono es requerido y no debe contener caracteres especiales" + "<br/>";
                this.lblAsteriscoTelefono.Visible = true;
            }
            else
            {
                this.lblAsteriscoTelefono.Visible = false;
            }
            // Fecha Nacimiento
            //Dia
            if (!Validaciones.esDiaValido(this.txtDiaNac.Text))
            {
                mensaje += "- El campo Día es requerido y debe ser un número entre 1 y 31" + "<br/>";
                this.lblAsteriscoFechaNacimiento.Visible = true;
            }
            else if (!Validaciones.esMesValido(this.txtMesNac.Text))
            {
                mensaje += "- El campo Mes es requerido y debe ser un número entre 1 y 12" + "<br/>";
                this.lblAsteriscoFechaNacimiento.Visible = true;
            } else if (!Validaciones.esAnioValido(this.txtAnioNac.Text))
            {
                mensaje += "- El campo Año es requerido y debe ser un número entre 1900 y "+ DateTime.Today.Year + "<br/>";
                this.lblAsteriscoFechaNacimiento.Visible = true;
            }
            else
            {
                this.lblAsteriscoFechaNacimiento.Visible = false;
            }
            //Tipo
            if (this.ddlTipoPersona.SelectedIndex == -1)
            {
                mensaje += "- El campo Tipo Persona es requerido" + "<br/>";
                this.lblAsteriscoTipoPersona.Visible = true;
            }
            else if (this.ddlTipoPersona.SelectedValue.ToString() == Entidades.Persona.TiposPersonas.Alumno.ToString())
            {
                if (!Validaciones.esLegajoValido(this.txtLegajo.Text))
                {
                    mensaje += "- El campo Legajo es requerido y debe ser un número" + "<br/>";
                    this.lblAsteriscoLegajo.Visible = true;
                }

                if (this.ddlPlan.SelectedIndex == -1)
                {
                    mensaje += "- El campo Plan es requerido" + "<br/>";
                    this.lblAsteriscoPlan.Visible = true;
                }
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
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtDiaNac.Enabled = enable;
            this.txtMesNac.Enabled = enable;
            this.txtAnioNac.Enabled = enable;
            this.ddlTipoPersona.Enabled = enable;
            this.ddlPlan.Enabled = enable;
            this.txtLegajo.Enabled = enable;

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
            this.ddlTipoPersona.DataSource = Enum.GetNames(typeof(Persona.TiposPersonas));
            this.ddlTipoPersona.DataBind();
            this.ddlTipoPersona.SelectedValue = Persona.TiposPersonas.Alumno.ToString();
        }

        private void ClearForm()
        {
            this.txtID.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDiaNac.Text = string.Empty;
            this.txtMesNac.Text = string.Empty;
            this.txtAnioNac.Text = string.Empty;
            this.ddlTipoPersona.SelectedIndex = -1;
            this.ddlPlan.SelectedIndex = -1;
            this.txtLegajo.Text = string.Empty;

            this.lblAsteriscoNomber.Visible = false;
            this.lblAsteriscoApellido.Visible = false;
            this.lblAsteriscoEmail.Visible = false;
            this.lblAsteriscoTelefono.Visible = false;
            this.lblAsteriscoDireccion.Visible = false;
            this.lblAsteriscoFechaNacimiento.Visible = false;
            this.lblAsteriscoLegajo.Visible = false;
            this.lblAsteriscoTipoPersona.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void ddlTipoPersona_Change(object sender, EventArgs e)
        {
            if(this.ddlTipoPersona.SelectedValue == Persona.TiposPersonas.Alumno.ToString())
            {
                this.ddlPlan.Enabled = true;
                this.txtLegajo.Enabled = true;
            }
            else
            {
                this.ddlPlan.Enabled = false;
                this.txtLegajo.Enabled = false;
            }
        }
    }
}
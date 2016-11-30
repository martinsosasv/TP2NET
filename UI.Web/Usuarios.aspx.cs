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
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
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

        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get 
            {
                if(this.ViewState["SelectedID"] != null)
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
            if(!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    //MessageBoxAlert("Su sesión ha expirado", "Home");
                    MessageBoxAlert("Su sesión ha expirado", "Usuarios", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Usuarios","Home.aspx");
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
            this.ddlPersonasUsuario.SelectedValue = this.Entity.Persona.ID.ToString();
            this.txtEmail.Text = this.Entity.Email;
            this.chkHabilitado.Checked = this.Entity.Habilitado;
            this.txtUsuario.Text = this.Entity.NombreUsuario;
            this.txtClave.Text = this.Entity.Clave;
            this.txtClave2.Text = this.Entity.Clave;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.IsEntitySelected)
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

        private void LoadEntity(Usuario usuario)
        {
            
            //usuario.Persona.Nombre = this.txtNombre.Text;
            //usuario.Persona.Apellido = this.txtApellido.Text;
            Persona per = new Persona();
            per = PersonaLogic.GetOne(Convert.ToInt32(this.ddlPersonasUsuario.SelectedValue));
            usuario.Persona = per;
            usuario.Email = this.txtEmail.Text;
            usuario.NombreUsuario = this.txtUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.chkHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            // TODO: Ver que se quitó el Save
            //this.Logic.Save(usuario);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch(this.FormMode){
                case FormModes.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        break;
                case FormModes.Modificacion:
                    if (Validar())
                    {

                        this.Entity = new Usuario();
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
                        this.Entity = new Usuario();
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
            //Persona
            if (this.ddlPersonasUsuario.SelectedValue == "-1")
            {
                this.lblAsteriscoPersona.Visible = true;
                mensaje += "- El usuario debe tener una persona asignada" + "<br/>";
            }
            //Clave
            if (!Validaciones.esClaveValida(this.txtClave.Text))
            {
                this.lblAsteriscoClave.Visible = true;
                mensaje += "- El campo Clave es requerido y debe contener al menos 6 caracteres" + "<br/>";
            }
            else
            {
                if (!Validaciones.coincideClave(this.txtClave.Text, this.txtClave2.Text))
                {
                    this.lblAsteriscoClave.Visible = true;
                    mensaje += "- Las Claves deben coincidir" + "<br/>";
                }
            }
            //Email
            if (!Validaciones.esEmailValido(this.txtEmail.Text))
            {
                mensaje += "- El campo Email es requerido y debe ser del formato de correo electrónico" + "<br/>";
                this.lblAsteriscoEmail.Visible = true;
            }
            // Usuario
            if (!Validaciones.esUsuarioValido(this.txtUsuario.Text))
            {
                mensaje += "- El campo Usuario es requerido y no debe contener caracteres especiales" + "<br/>";
                this.lblAsteriscoUsuario.Visible = true;
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
            this.ddlPersonasUsuario.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtUsuario.Enabled = enable;
            this.txtClave.Visible = enable;
            this.lblClave.Visible = enable;
            this.txtClave2.Visible = enable;
            this.lblClave2.Visible = enable;

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
            this.ddlPersonasUsuario.SelectedIndex = -1;
            this.txtEmail.Text = string.Empty;
            this.chkHabilitado.Checked = false;
            this.txtUsuario.Text = string.Empty;
            this.txtClave.Text = string.Empty;
            this.txtClave2.Text = string.Empty;

            this.lblAsteriscoUsuario.Visible = false;
            this.lblAsteriscoPersona.Visible = false;
            this.lblAsteriscoEmail.Visible = false;
            this.lblAsteriscoClave2.Visible = false;
            this.lblAsteriscoClave.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }


    }
}
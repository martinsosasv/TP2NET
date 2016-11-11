using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

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

        public enum FormModes
        { Alta, Baja, Modificacion }
        
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
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
            get { return (this.SelectedID != 0); }
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
                this.LoadGrid();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.chkHabilitado.Checked = this.Entity.Habilitado;
            this.txtUsuario.Text = this.Entity.NombreUsuario;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.NombreUsuario = this.txtUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.chkHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
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
                    if (ValidateFormPanel())
                    {

                        this.Entity = new Usuario();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = Entidades.Entidades.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    
                    break;
                case FormModes.Alta:
                    if (ValidateFormPanel())
                    {
                        this.Entity = new Usuario();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    break;

                default:
                    break;

            }
            
        }

        private bool ValidateFormPanel()
        {
            listValidationPanel.Items.Clear();

            if (this.txtNombre.Text == string.Empty)
            {
                this.lblAsteriscoNombre.Visible = true;
                ListItem item = new ListItem("El nombre no puede estar vacío");
                listValidationPanel.Items.Add(item);
            }
            


            if (this.txtApellido.Text == string.Empty)
            {
                this.lblAsteriscoApellido.Visible = true;
                ListItem item = new ListItem("El Apellido no puede estar vacio");
                listValidationPanel.Items.Add(item);
            }

            if (this.txtEmail.Text == string.Empty || !this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains(".com"))
            {
                this.lblAsteriscoEmail.Visible = true;
                ListItem item = new ListItem("El Email es inválido");
                listValidationPanel.Items.Add(item);
            }

            if (this.txtUsuario.Text == string.Empty)
            {
                this.lblAsteriscoUsuario.Visible = true;
                ListItem item = new ListItem("El Nombre de Usuario no puede estar vacio");
                listValidationPanel.Items.Add(item);
                
            }

            if (this.txtClave.Text.Length < 8 || this.txtClave.Text != this.txtClave2.Text)
            {
                this.lblAsteriscoClave.Visible = true;
                ListItem item = new ListItem("Las claves deben coincidir y tener más de 8 caracteres");
                listValidationPanel.Items.Add(item);
            }

            if (listValidationPanel.Items.Count > 0)
            {
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
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.chkHabilitado.Checked = false;
            this.txtUsuario.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }


    }
}
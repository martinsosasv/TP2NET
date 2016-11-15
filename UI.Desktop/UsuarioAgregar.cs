using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class UsuarioAgregar : Form
    {
        bool estadoEdicion;
        public UsuarioAgregar()
        {
            try
            {
                InitializeComponent();
                estadoEdicion = false;
                List<Entidades.Personas> listadoPersonas = new List<Entidades.Personas>();
                PersonaLogic perLog = new PersonaLogic();
                listadoPersonas = perLog.GetAll();
                cbxPersona.DataSource = listadoPersonas;
                cbxPersona.DisplayMember = "ApellidoNombre";
                cbxPersona.ValueMember = "ID";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void Editar(Usuario usuario)
        {
            estadoEdicion = true;
            this.Text = "Editar persona";
            this.txtID.Text = usuario.ID.ToString();
            this.txtNombreUsuario.Text = usuario.NombreUsuario.ToString();
            this.chkHabilitado.Checked = usuario.Habilitado;
            this.txtNombre.Text = usuario.Nombre.ToString();
            this.txtApellido.Text = usuario.Apellido.ToString();
            this.txtEmail.Text = usuario.Email.ToString();
            cbxPersona.SelectedValue = usuario.Persona.ID;
            
        }

        
    }
}

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
            this.txtClave.Text = usuario.Clave.ToString();
            this.txtEmail.Text = usuario.Email.ToString();
            cbxPersona.SelectedValue = usuario.Persona.ID;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Validar())
                //{
                if (MessageBox.Show(estadoEdicion == true ? "Esta seguro que desea editar este Usuario?" : "Esta seguro que desea agregar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuarioLogic userLog = new UsuarioLogic();
                    Usuario user = new Usuario();
                    user.NombreUsuario = this.txtNombreUsuario.Text;
                    user.Habilitado = this.chkHabilitado.Checked;
                    user.Clave = this.txtClave.Text;
                    user.Email = this.txtEmail.Text;
                    user.Persona = (Entidades.Personas)this.cbxPersona.SelectedItem;

                    if (!estadoEdicion)
                    {
                        userLog.Insert(user);
                        MessageBox.Show("Se ha agregado correctamente el Usuario", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        user.ID = Int32.Parse(this.txtID.Text);
                        userLog.Update(user);
                        MessageBox.Show("Se ha editado correctamente el Usuario", "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    this.Close();
                    //}
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        

        
    }
}

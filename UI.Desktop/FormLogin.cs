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
using UI.Desktop;
using Util;

namespace CreacionFormLogin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(this.Validar())
            {
                Usuario user = new Usuario();
                UsuarioLogic userLog = new UsuarioLogic();
                user = userLog.GetOne(this.txtUsuario.Text);
                if (user.NombreUsuario == this.txtUsuario.Text && user.Clave == this.txtPass.Text)
                {
                    this.txtUsuario.Text = "";
                    this.txtPass.Text = "";
                    frmMain frmMain = new frmMain();
                    frmMain.Persona = user.Persona;
                    frmMain.ShowDialog();
                }
                else
                {
                    if (user.NombreUsuario != this.txtUsuario.Text)
                    {
                        MessageBox.Show("El Usuario no existe");
                    }
                    else
                    {
                        MessageBox.Show("La Clave ingresada es incorrecta");
                    }
                    
                }
            }
            
        }

        private void lnkOlvidaPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private bool Validar()
        {
            string mensaje = "";
            if (!Validaciones.esUsuarioValido(this.txtUsuario.Text))
            {
                mensaje += "- El campo Nombre de Usuario es requerido y no debe contener caracteres especiales" + "\n";
            }

            if (!Validaciones.esClaveValida(this.txtPass.Text))
            {
                mensaje += "- El campo Contraseña es requerido y debe contener al menos 6 caracteres" + "\n";
            }

            //Mostrar los errores
            if (!String.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }

}

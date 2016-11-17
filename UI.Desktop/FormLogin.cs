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
                MessageBox.Show("El usuario no existe");
            }
        }

        private void lnkOlvidaPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}

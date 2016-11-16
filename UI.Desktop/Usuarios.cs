using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class Usuarios : UI.Desktop.Base
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Usuario = new DataGridViewTextBoxColumn();
            colId_Usuario.Name = "id_usuario";
            colId_Usuario.HeaderText = "Id Usuario";
            colId_Usuario.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colId_Usuario);

            DataGridViewTextBoxColumn colNombre_Usuario = new DataGridViewTextBoxColumn();
            colNombre_Usuario.Name = "nombre_usuario";
            colNombre_Usuario.HeaderText = "Nombre Usuario";
            colNombre_Usuario.DataPropertyName = "NombreUsuario";
            this.dgvBase.Columns.Add(colNombre_Usuario);

            DataGridViewCheckBoxColumn colHabilitado_Usuario = new DataGridViewCheckBoxColumn();
            colHabilitado_Usuario.Name = "habilitado";
            colHabilitado_Usuario.HeaderText = "Habilitado";
            colHabilitado_Usuario.DataPropertyName = "Habilitado";
            this.dgvBase.Columns.Add(colHabilitado_Usuario);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "NombrePersona";
            this.dgvBase.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "ApellidoPersona";
            this.dgvBase.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            this.dgvBase.Columns.Add(colEmail);
        }

        public void Listar()
        {
            UsuarioLogic userLog = new UsuarioLogic();
            List<Usuario> listaUser = new List<Usuario>();
            listaUser = userLog.GetAll();
            this.dgvBase.DataSource = listaUser;
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuarioAgregar frmUserAgr = new UsuarioAgregar();
            frmUserAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                UsuarioAgregar frmUserAdd = new UsuarioAgregar();
                frmUserAdd.Editar((Usuario)dgvBase.SelectedRows[0].DataBoundItem);
                frmUserAdd.ShowDialog();
                this.Listar();
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UsuarioLogic userLog = new UsuarioLogic();
                        Usuario user = new Usuario();
                        user = (Usuario)this.dgvBase.SelectedRows[0].DataBoundItem;
                        userLog.Delete(user.ID);
                        MessageBox.Show("Se ha eliminado correctamente el Usuario", "Eliminación Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Listar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

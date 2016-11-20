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
    public partial class frmPersonas : UI.Desktop.Base
    {
        public frmPersonas()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colIdPer = new DataGridViewTextBoxColumn();
            colIdPer.Name = "id_persona";
            colIdPer.HeaderText = "ID";
            colIdPer.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colIdPer);

            DataGridViewTextBoxColumn colNomPer = new DataGridViewTextBoxColumn();
            colNomPer.Name = "nombre_persona";
            colNomPer.HeaderText = "Nombre";
            colNomPer.DataPropertyName = "Nombre";
            this.dgvBase.Columns.Add(colNomPer);

            DataGridViewTextBoxColumn colApePer = new DataGridViewTextBoxColumn();
            colApePer.Name = "apellido_persona";
            colApePer.HeaderText = "Apellido";
            colApePer.DataPropertyName = "Apellido";
            this.dgvBase.Columns.Add(colApePer);

            DataGridViewTextBoxColumn colDirPer = new DataGridViewTextBoxColumn();
            colDirPer.Name = "direccion_persona";
            colDirPer.HeaderText = "Dirección";
            colDirPer.DataPropertyName = "Direccion";
            this.dgvBase.Columns.Add(colDirPer);

            DataGridViewTextBoxColumn colEmailPer = new DataGridViewTextBoxColumn();
            colEmailPer.Name = "email_persona";
            colEmailPer.HeaderText = "E-mail";
            colEmailPer.DataPropertyName = "Email";
            this.dgvBase.Columns.Add(colEmailPer);

            DataGridViewTextBoxColumn colTelper = new DataGridViewTextBoxColumn();
            colTelper.Name = "telefono_persona";
            colTelper.HeaderText = "Teléfono";
            colTelper.DataPropertyName = "Telefono";
            this.dgvBase.Columns.Add(colTelper);

            DataGridViewTextBoxColumn colFecNac = new DataGridViewTextBoxColumn();
            colFecNac.Name = "fechaNac_persona";
            colFecNac.HeaderText = "Fecha de Nacimiento";
            colFecNac.DataPropertyName = "FechaNacimiento";
            this.dgvBase.Columns.Add(colFecNac);

            DataGridViewTextBoxColumn colLegPer = new DataGridViewTextBoxColumn();
            colLegPer.Name = "legajo_persona";
            colLegPer.HeaderText = "Legajo";
            colLegPer.DataPropertyName = "IdLegajo";
            this.dgvBase.Columns.Add(colLegPer);

            DataGridViewTextBoxColumn coltipoPer = new DataGridViewTextBoxColumn();
            coltipoPer.Name = "tipo_persona";
            coltipoPer.HeaderText = "Tipo de Persona";
            coltipoPer.DataPropertyName = "TipoPersona";
            this.dgvBase.Columns.Add(coltipoPer);

            DataGridViewTextBoxColumn colPlanPer = new DataGridViewTextBoxColumn();
            colPlanPer.Name = "plan_persona";
            colPlanPer.HeaderText = "Plan";
            colPlanPer.DataPropertyName = "PlanPersona";
            this.dgvBase.Columns.Add(colPlanPer);
        }

        public void Listar()
        {
            PersonaLogic perLog = new PersonaLogic();
            List<Entidades.Persona> listaPersonas = new List<Entidades.Persona>();
            listaPersonas = perLog.GetAll();
            this.dgvBase.DataSource = listaPersonas;
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPersonaAgregar frmPerAgr = new frmPersonaAgregar();
            frmPerAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                frmPersonaAgregar frmPerAgr = new frmPersonaAgregar();
                frmPerAgr.Editar((Entidades.Persona)dgvBase.SelectedRows[0].DataBoundItem);
                frmPerAgr.ShowDialog();
                this.Listar();
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar esta persona?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PersonaLogic perLog = new PersonaLogic();
                        Entidades.Persona persona = new Entidades.Persona();
                        persona = (Entidades.Persona)this.dgvBase.SelectedRows[0].DataBoundItem;
                        perLog.Delete(persona);
                        MessageBox.Show("Se ha eliminado correctamente la persona", "Eliminación persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Listar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

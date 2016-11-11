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
    public partial class Comisiones : UI.Desktop.Base
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colIdCom = new DataGridViewTextBoxColumn();
            colIdCom.Name = "id_comision";
            colIdCom.HeaderText = "ID";
            colIdCom.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colIdCom);

            DataGridViewTextBoxColumn colDescCom = new DataGridViewTextBoxColumn();
            colDescCom.Name = "desc_comision";
            colDescCom.HeaderText = "Descripción";
            colDescCom.DataPropertyName = "Descripcion";
            this.dgvBase.Columns.Add(colDescCom);

            DataGridViewTextBoxColumn colanioEspec = new DataGridViewTextBoxColumn();
            colanioEspec.Name = "anioEspec_comision";
            colanioEspec.HeaderText = "Año";
            colanioEspec.DataPropertyName = "AnioEspecialidad";
            this.dgvBase.Columns.Add(colanioEspec);

            DataGridViewTextBoxColumn colPlanCom = new DataGridViewTextBoxColumn();
            colPlanCom.Name = "plan_comision";
            colPlanCom.HeaderText = "Plan";
            colPlanCom.DataPropertyName = "PlanDescripcion";
            this.dgvBase.Columns.Add(colPlanCom);

            DataGridViewTextBoxColumn colEspPlanCom = new DataGridViewTextBoxColumn();
            colEspPlanCom.Name = "espec_plan_comision";
            colEspPlanCom.HeaderText = "Especialidad";
            colEspPlanCom.DataPropertyName = "DescripcionEspecPlan";
            this.dgvBase.Columns.Add(colEspPlanCom);
        }

        public void Listar()
        {
            ComisionLogic comLog = new ComisionLogic();
            List<Comision> listaComisiones = new List<Comision>();
            listaComisiones = comLog.GetAll();
            this.dgvBase.DataSource = listaComisiones;
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionAgregar frmComAgr = new ComisionAgregar();
            frmComAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                ComisionAgregar frmComAgr = new ComisionAgregar();
                frmComAgr.Editar((Comision)dgvBase.SelectedRows[0].DataBoundItem);
                frmComAgr.ShowDialog();
                this.Listar();
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar esta comisión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ComisionLogic comLog = new ComisionLogic();
                        Comision comision = new Comision();
                        comision = (Comision)this.dgvBase.SelectedRows[0].DataBoundItem;
                        comLog.Delete(comision);
                        MessageBox.Show("Se ha eliminado correctamente la comisión", "Eliminación comisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

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
    public partial class frmMaterias : UI.Desktop.Base
    {
        public frmMaterias()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colIdMat = new DataGridViewTextBoxColumn();
            colIdMat.Name = "id_materia";
            colIdMat.HeaderText = "ID";
            colIdMat.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colIdMat);

            DataGridViewTextBoxColumn colDescMat = new DataGridViewTextBoxColumn();
            colDescMat.Name = "desc_materia";
            colDescMat.HeaderText = "Descripción";
            colDescMat.DataPropertyName = "Descripcion";
            this.dgvBase.Columns.Add(colDescMat);

            DataGridViewTextBoxColumn colHSSem = new DataGridViewTextBoxColumn();
            colHSSem.Name = "HSSem_materia";
            colHSSem.HeaderText = "Horas Semanales";
            colHSSem.DataPropertyName = "HSSemanales";
            this.dgvBase.Columns.Add(colHSSem);

            DataGridViewTextBoxColumn colHSTot = new DataGridViewTextBoxColumn();
            colHSTot.Name = "HSTot_materia";
            colHSTot.HeaderText = "Horas Totales";
            colHSTot.DataPropertyName = "HSTotales";
            this.dgvBase.Columns.Add(colHSTot);

            DataGridViewTextBoxColumn colPlanMat = new DataGridViewTextBoxColumn();
            colPlanMat.Name = "plan_materia";
            colPlanMat.HeaderText = "Plan";
            colPlanMat.DataPropertyName = "DescripcionPlan";
            this.dgvBase.Columns.Add(colPlanMat);

            DataGridViewTextBoxColumn colEspPlanMat = new DataGridViewTextBoxColumn();
            colEspPlanMat.Name = "espec_plan_materia";
            colEspPlanMat.HeaderText = "Especialidad";
            colEspPlanMat.DataPropertyName = "DescripcionEspecPlan";
            this.dgvBase.Columns.Add(colEspPlanMat);
        }

        public void Listar()
        {
            MateriaLogic matLog = new MateriaLogic();
            List<Materia> listaMaterias = new List<Materia>();
            listaMaterias = matLog.GetAll();
            this.dgvBase.DataSource = listaMaterias;
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMateriaAgregar frmMatAgr = new frmMateriaAgregar();
            frmMatAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                frmMateriaAgregar frmMatAgr = new frmMateriaAgregar();
                frmMatAgr.Editar((Materia)dgvBase.SelectedRows[0].DataBoundItem);
                frmMatAgr.ShowDialog();
                this.Listar();
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar esta materia?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MateriaLogic plaLog = new MateriaLogic();
                        Materia materia = new Materia();
                        materia = (Materia)this.dgvBase.SelectedRows[0].DataBoundItem;
                        plaLog.Delete(materia);
                        MessageBox.Show("Se ha eliminado correctamente la materia", "Eliminación materia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

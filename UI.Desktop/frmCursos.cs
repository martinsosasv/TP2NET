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
    public partial class frmCursos : UI.Desktop.Base
    {
        public frmCursos()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Curso = new DataGridViewTextBoxColumn();
            colId_Curso.Name = "id_curso";
            colId_Curso.HeaderText = "Id Curso";
            colId_Curso.DataPropertyName = "Id";
            this.dgvBase.Columns.Add(colId_Curso);

            DataGridViewTextBoxColumn colDescripcionCom = new DataGridViewTextBoxColumn();
            colDescripcionCom.Name = "descripcion_comision";
            colDescripcionCom.HeaderText = "Descripción Comision";
            colDescripcionCom.DataPropertyName = "DescComision";
            this.dgvBase.Columns.Add(colDescripcionCom);

            DataGridViewTextBoxColumn colDescripcionMat = new DataGridViewTextBoxColumn();
            colDescripcionMat.Name = "descripcion_materia";
            colDescripcionMat.HeaderText = "Descripción Materia";
            colDescripcionMat.DataPropertyName = "DescMateria";
            this.dgvBase.Columns.Add(colDescripcionMat);

            DataGridViewTextBoxColumn colAnio_Calendario = new DataGridViewTextBoxColumn();
            colAnio_Calendario.Name = "anio_calendario";
            colAnio_Calendario.HeaderText = "Año Calendario";
            colAnio_Calendario.DataPropertyName = "AnioCalendario";
            this.dgvBase.Columns.Add(colAnio_Calendario);
        }

        public void Listar()
        {
            CursoLogic curLog = new CursoLogic();
            List<Curso> listaCursos = new List<Curso>();
            listaCursos = curLog.GetAll();
            this.dgvBase.DataSource = listaCursos;
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCursoAgregar frmCurAgr = new frmCursoAgregar();
            frmCurAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                frmCursoAgregar frmCurAgr = new frmCursoAgregar();
                frmCurAgr.Editar((Curso)dgvBase.SelectedRows[0].DataBoundItem);
                frmCurAgr.ShowDialog();
                this.Listar();
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar este curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CursoLogic curLog = new CursoLogic();
                        Curso curso = new Curso();
                        curso = (Curso)this.dgvBase.SelectedRows[0].DataBoundItem;
                        curLog.Delete(curso);
                        MessageBox.Show("Se ha eliminado correctamente el curso", "Eliminación curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

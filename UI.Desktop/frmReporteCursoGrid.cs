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
    public partial class frmReporteCursoGrid : Form
    {
        public frmReporteCursoGrid()
        {
            try
            {
                InitializeComponent();
                this.dgvCursos.AutoGenerateColumns = false;
                this.GenerarColumnas();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void cargarGrilla()
        {
            List<Curso> listadoCursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();
            listadoCursos = curLog.GetAll();
            this.dgvCursos.DataSource = listadoCursos;
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Curso = new DataGridViewTextBoxColumn();
            colId_Curso.Name = "id_curso";
            colId_Curso.HeaderText = "Id Curso";
            colId_Curso.DataPropertyName = "ID";
            this.dgvCursos.Columns.Add(colId_Curso);

            DataGridViewTextBoxColumn colDescripcionCom = new DataGridViewTextBoxColumn();
            colDescripcionCom.Name = "descripcion_comision";
            colDescripcionCom.HeaderText = "Descripción Comision";
            colDescripcionCom.DataPropertyName = "DescPlanEsp";
            this.dgvCursos.Columns.Add(colDescripcionCom);

            DataGridViewTextBoxColumn colDescripcionMat = new DataGridViewTextBoxColumn();
            colDescripcionMat.Name = "descripcion_materia";
            colDescripcionMat.HeaderText = "Descripción Materia";
            colDescripcionMat.DataPropertyName = "DescMateria";
            this.dgvCursos.Columns.Add(colDescripcionMat);

            DataGridViewTextBoxColumn colAnio_Calendario = new DataGridViewTextBoxColumn();
            colAnio_Calendario.Name = "anio_calendario";
            colAnio_Calendario.HeaderText = "Año Calendario";
            colAnio_Calendario.DataPropertyName = "AnioCalendario";
            this.dgvCursos.Columns.Add(colAnio_Calendario);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                frmReporteCurso reporte = new frmReporteCurso(((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID);
                reporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}

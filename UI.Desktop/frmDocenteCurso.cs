using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class frmDocenteCurso : UI.Desktop.Base
    {
        public frmDocenteCurso()
        {
            try
            {
                InitializeComponent();
                this.dgvBase.AutoGenerateColumns = false;
                GenerarColumnas();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void cargarGrilla()
        {
            List<Docente_Curso> listadoDocCursos = new List<Docente_Curso>();
            Docente_CursoLogic docCurLog = new Docente_CursoLogic();
            listadoDocCursos = docCurLog.GetAll();
            this.dgvBase.DataSource = listadoDocCursos;
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Docente = new DataGridViewTextBoxColumn();
            colId_Docente.Name = "id_docente";
            colId_Docente.HeaderText = "Id Docente";
            colId_Docente.DataPropertyName = "DescDocente";
            this.dgvBase.Columns.Add(colId_Docente);

            DataGridViewTextBoxColumn colId_Curso = new DataGridViewTextBoxColumn();
            colId_Curso.Name = "id_curso";
            colId_Curso.HeaderText = "Id Curso";
            colId_Curso.DataPropertyName = "DescCurso";
            this.dgvBase.Columns.Add(colId_Curso);

            DataGridViewTextBoxColumn colRol = new DataGridViewTextBoxColumn();
            colRol.Name = "rol";
            colRol.HeaderText = "Rol";
            colRol.DataPropertyName = "Cargo";
            this.dgvBase.Columns.Add(colRol);
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmDocenteCursoAgregar frmDocCurso = new frmDocenteCursoAgregar();
                frmDocCurso.ShowDialog();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    frmDocenteCursoAgregar frmDocCurso = new frmDocenteCursoAgregar();
                    frmDocCurso.editar((Docente_Curso)(this.dgvBase.SelectedRows[0].DataBoundItem));
                    frmDocCurso.ShowDialog();
                    this.cargarGrilla();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar docente_curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Docente_CursoLogic docCurLog = new Docente_CursoLogic();
                        docCurLog.Delete((Docente_Curso)this.dgvBase.SelectedRows[0].DataBoundItem);
                        MessageBox.Show("Se ha eliminado correctamente la asignacion del docente al curso", "Eliminar Docente asignado a un curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.cargarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        } 
    }
}

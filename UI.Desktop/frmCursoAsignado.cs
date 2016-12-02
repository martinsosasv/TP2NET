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
    public partial class frmCursoAsignado : Form
    {
        #region Propiedades
        private Persona _docente;
        public Persona Docente
        {
            get { return _docente; }
            set { _docente = value; }
        }
        #endregion

        #region Métodos
        public frmCursoAsignado()
        {
            InitializeComponent();
        }

        public frmCursoAsignado(Persona docente)
        {
            try
            {
                InitializeComponent();
                this.Docente = docente;
                this.dgvCursosAsignados.AutoGenerateColumns = false;
                this.GenerarColumnas();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Curso = new DataGridViewTextBoxColumn();
            colId_Curso.Name = "id_curso";
            colId_Curso.HeaderText = "ID Curso";
            colId_Curso.DataPropertyName = "id_curso";
            this.dgvCursosAsignados.Columns.Add(colId_Curso);

            DataGridViewTextBoxColumn colComision = new DataGridViewTextBoxColumn();
            colComision.Name = "comision";
            colComision.HeaderText = "Comisión";
            colComision.DataPropertyName = "comision";
            this.dgvCursosAsignados.Columns.Add(colComision);

            DataGridViewTextBoxColumn colMateria = new DataGridViewTextBoxColumn();
            colMateria.Name = "materia";
            colMateria.HeaderText = "Materia";
            colMateria.DataPropertyName = "materia";
            this.dgvCursosAsignados.Columns.Add(colMateria);

            DataGridViewTextBoxColumn colRol = new DataGridViewTextBoxColumn();
            colRol.Name = "rol";
            colRol.HeaderText = "Rol";
            colRol.DataPropertyName = "rol";
            this.dgvCursosAsignados.Columns.Add(colRol);
        }

        private void cargarGrilla()
        {
            List<Docente_Curso> listadoDocenteCursos = new List<Docente_Curso>();
            Docente_CursoLogic docCurLog = new Docente_CursoLogic();
            listadoDocenteCursos = docCurLog.GetAll(this.Docente.ID);

            List<Curso> listadoCursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();
            listadoCursos = curLog.GetAll();

            var estado = from doccur in listadoDocenteCursos
                         join curso in listadoCursos
                         on doccur.Curso.ID equals curso.ID
                         select new
                         {
                             id_curso = curso.ID,
                             comision = curso.Comision.Descripcion,
                             materia = curso.Materia.Descripcion,
                             rol = doccur.Cargo
                         };

            dgvCursosAsignados.DataSource = estado.ToList();

        }
        #endregion

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCursosAsignados.SelectedRows.Count > 0)
                {
                    frmAlumnoInscriptoACurso frmAlumnoInscriptoACurso = new frmAlumnoInscriptoACurso(Convert.ToInt32(this.dgvCursosAsignados.SelectedRows[0].Cells["id_curso"].Value));
                    frmAlumnoInscriptoACurso.ShowDialog();
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

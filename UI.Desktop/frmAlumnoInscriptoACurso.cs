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
    public partial class frmAlumnoInscriptoACurso : Form
    {
        #region Propiedades
        private int _idCurso;
        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }
        #endregion

        #region Métodos
        public frmAlumnoInscriptoACurso()
        {
            InitializeComponent();
        }

        public frmAlumnoInscriptoACurso(int id)
        {
            try
            {
                InitializeComponent();
                this.IdCurso = id;
                this.dgvAlumnosDelCurso.AutoGenerateColumns = false;
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
            DataGridViewTextBoxColumn colIdInsc = new DataGridViewTextBoxColumn();
            colIdInsc.Name = "id_inscripcion";
            colIdInsc.HeaderText = "Nro. Inscripción";
            colIdInsc.DataPropertyName = "id_inscripcion";
            this.dgvAlumnosDelCurso.Columns.Add(colIdInsc);

            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "legajo";
            colLegajo.HeaderText = "legajo";
            colLegajo.DataPropertyName = "legajo";
            this.dgvAlumnosDelCurso.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            this.dgvAlumnosDelCurso.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            this.dgvAlumnosDelCurso.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colNota = new DataGridViewTextBoxColumn();
            colNota.Name = "nota";
            colNota.HeaderText = "Nota";
            colNota.DataPropertyName = "nota";            
            this.dgvAlumnosDelCurso.Columns.Add(colNota);

            DataGridViewTextBoxColumn colCondicion = new DataGridViewTextBoxColumn();
            colCondicion.Name = "condicion";
            colCondicion.HeaderText = "Condicion";
            colCondicion.DataPropertyName = "condicion";
            this.dgvAlumnosDelCurso.Columns.Add(colCondicion);
        }

        private void cargarGrilla()
        {
            List<AlumnoInscripcion> listadoAlumnoInscripcion = new List<AlumnoInscripcion>();
            AluInscLogic aluInscLog = new AluInscLogic();
            listadoAlumnoInscripcion = aluInscLog.GetAll();

            List<Persona> listadoPersonas = new List<Persona>();
            PersonaLogic perLog = new PersonaLogic();
            listadoPersonas = perLog.GetAll();

            var inscriptos = from aluins in listadoAlumnoInscripcion
                             join alu in listadoPersonas
                             on aluins.Alumno.ID equals alu.ID
                             where (aluins.Curso.ID == this.IdCurso)
                             select new
                             {
                                 id_inscripcion = aluins.ID,
                                 legajo = alu.IdLegajo,
                                 apellido = alu.Apellido,
                                 nombre = alu.Nombre,
                                 nota = aluins.Nota,
                                 condicion = aluins.Condicion
                             };

            dgvAlumnosDelCurso.DataSource = inscriptos.ToList();

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditarNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAlumnosDelCurso.SelectedRows.Count > 0)
                {
                    int id;
                    string nombre, apellido, legajo;

                    id = Convert.ToInt32(this.dgvAlumnosDelCurso.SelectedRows[0].Cells["id_inscripcion"].Value);
                    nombre = this.dgvAlumnosDelCurso.SelectedRows[0].Cells["nombre"].Value.ToString();
                    apellido = this.dgvAlumnosDelCurso.SelectedRows[0].Cells["apellido"].Value.ToString();
                    legajo = this.dgvAlumnosDelCurso.SelectedRows[0].Cells["legajo"].Value.ToString();

                    frmEditarNota frmEditNote = new frmEditarNota(id, nombre, apellido, legajo);
                    frmEditNote.StartPosition = FormStartPosition.CenterParent;
                    frmEditNote.ShowDialog();
                    this.cargarGrilla();
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

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
                this.dgvAlumnosInscriptos.AutoGenerateColumns = false;
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
            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "legajo";
            colLegajo.HeaderText = "legajo";
            colLegajo.DataPropertyName = "legajo";
            this.dgvAlumnosInscriptos.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "apellido";
            this.dgvAlumnosInscriptos.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "nombre";
            this.dgvAlumnosInscriptos.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colNota = new DataGridViewTextBoxColumn();
            colNota.Name = "nota";
            colNota.HeaderText = "Nota";
            colNota.DataPropertyName = "nota";
            colNota.ReadOnly = false;
            
            this.dgvAlumnosInscriptos.Columns.Add(colNota);
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
                             where (aluins.Curso.ID == this.IdCurso && aluins.Condicion == "Cursando")
                             select new
                             {
                                 legajo = alu.IdLegajo,
                                 apellido = alu.Apellido,
                                 nombre = alu.Nombre,
                                 nota = aluins.Nota
                             };

            dgvAlumnosInscriptos.DataSource = inscriptos.ToList();

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

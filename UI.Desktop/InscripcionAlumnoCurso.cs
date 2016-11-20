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
    public partial class InscripcionAlumnoCurso : Form
    {
        Entidades.Persona _alumno;
        public Entidades.Persona Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }
        }

        public InscripcionAlumnoCurso(Entidades.Persona alumno )
        {
            InitializeComponent();
            this.Alumno = alumno;
            this.dgvCursos.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId_Curso = new DataGridViewTextBoxColumn();
            colId_Curso.Name = "id_curso";
            colId_Curso.HeaderText = "Id Curso";
            colId_Curso.DataPropertyName = "Id";
            this.dgvCursos.Columns.Add(colId_Curso);

            DataGridViewTextBoxColumn colDescripcionCom = new DataGridViewTextBoxColumn();
            colDescripcionCom.Name = "descripcion_comision";
            colDescripcionCom.HeaderText = "Descripción Comision";
            colDescripcionCom.DataPropertyName = "DescComision";
            this.dgvCursos.Columns.Add(colDescripcionCom);

            DataGridViewTextBoxColumn colDescripcionMat = new DataGridViewTextBoxColumn();
            colDescripcionMat.Name = "descripcion_materia";
            colDescripcionMat.HeaderText = "Descripción Materia";
            colDescripcionMat.DataPropertyName = "DescMateria";
            this.dgvCursos.Columns.Add(colDescripcionMat);

            DataGridViewTextBoxColumn colDescripcionPlanEsp = new DataGridViewTextBoxColumn();
            colDescripcionPlanEsp.Name = "descripcion_planEsp";
            colDescripcionPlanEsp.HeaderText = "Especialidad";
            colDescripcionPlanEsp.DataPropertyName = "DescPlanEsp";
            this.dgvCursos.Columns.Add(colDescripcionPlanEsp);

            DataGridViewTextBoxColumn colAnio_Calendario = new DataGridViewTextBoxColumn();
            colAnio_Calendario.Name = "anio_calendario";
            colAnio_Calendario.HeaderText = "Nivel";
            colAnio_Calendario.DataPropertyName = "AnioCalendario";
            this.dgvCursos.Columns.Add(colAnio_Calendario);
        }

        public void Listar()
        {
            List<Curso> listadoCursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();
            listadoCursos = curLog.GetAll();

            List<AlumnoInscripcion> listadoAlumno_Inscripciones = new List<AlumnoInscripcion>();
            AluInscLogic aluInscLog = new AluInscLogic();
            listadoAlumno_Inscripciones = aluInscLog.GetInscripcionesAlumno(this.Alumno.ID);

            List<Curso> listadoCursosAInscribir = new List<Curso>();

            for (int i = 0; i < listadoCursos.Count; i++)
            {
                bool bandera = false;

                for (int j = 0; j < listadoAlumno_Inscripciones.Count; j++)
                {
                    if (listadoAlumno_Inscripciones[j].Curso.ID == listadoCursos[i].ID)
                    {
                        bandera = true;
                    }
                }

                if (bandera == false)
                {
                    listadoCursosAInscribir.Add(listadoCursos[i]);
                }
            }

            this.dgvCursos.DataSource = listadoCursosAInscribir;
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion aluIns = new AlumnoInscripcion();
            AluInscLogic aluInscLog = new AluInscLogic();
            aluIns.Alumno = this.Alumno;
            aluIns.Curso = (Curso)this.dgvCursos.SelectedRows[0].DataBoundItem;
            aluInscLog.Insert(aluIns);
            this.Listar();
        }
    }
}

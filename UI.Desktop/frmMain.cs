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

namespace UI.Desktop
{
    public partial class frmMain : Form
    {

        private Entidades.Persona _persona;

        public Entidades.Persona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            switch(this.Persona.TipoPersona)
            {
                case(Entidades.Persona.TiposPersonas.Administrador):
                    this.mnuABM.Visible = true;
                    this.mnuReportes.Visible = true;
                    break;
                case(Entidades.Persona.TiposPersonas.Alumno):
                    this.mnuOpciones.Visible = true;
                    break;
                case(Entidades.Persona.TiposPersonas.Docente):
                    this.mnuCursos.Visible = true;
                    break;
            }

        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEspecialidades frmEspecialidad = new frmEspecialidades();
            frmEspecialidad.Show();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPlanes frmPlanes = new frmPlanes();
            frmPlanes.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterias frmMaterias = new frmMaterias();
            frmMaterias.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComisiones frmComisiones = new frmComisiones();
            frmComisiones.Show();
        }

        private void cursosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCursos frmCursos = new frmCursos();
            frmCursos.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonas frmPersonas = new frmPersonas();
            frmPersonas.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUser = new frmUsuarios();
            frmUser.Show();
        }

        private void inscripciónACursadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InscripcionAlumnoCurso frmInscAlu = new InscripcionAlumnoCurso(this.Persona);
            frmInscAlu.Show();
        }

        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteCursoGrid frmCursoGrid = new frmReporteCursoGrid();
            frmCursoGrid.ShowDialog();
        }
    }
}

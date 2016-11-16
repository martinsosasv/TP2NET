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

        private Personas _persona;

        public Personas Persona
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
            /*switch(this.Persona.TipoPersona)
            {
                case(Entidades.Personas.TiposPersonas.Administrador):
                    this.mnuABM.Visible = true;
                    this.mnuReportes.Visible = true;
                    break;
                case(Entidades.Personas.TiposPersonas.Alumno):
                    this.mnuOpciones.Visible = true;
                    break;
                case(Entidades.Personas.TiposPersonas.Docente):
                    this.mnuCursos.Visible = true;
                    break;
            }*/

        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades frmEspecialidad = new Especialidades();
            frmEspecialidad.Show();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Planes frmPlanes = new Planes();
            frmPlanes.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias frmMaterias = new Materias();
            frmMaterias.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones frmComisiones = new Comisiones();
            frmComisiones.Show();
        }

        private void cursosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cursos frmCursos = new Cursos();
            frmCursos.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas frmPersonas = new Personas();
            frmPersonas.Show();
        }
    }
}

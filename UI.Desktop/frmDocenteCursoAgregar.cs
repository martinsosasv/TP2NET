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
    public partial class frmDocenteCursoAgregar : Form
    {
        #region Métodos
        private bool estadoEdicion;

        public frmDocenteCursoAgregar()
        {
            try
            {
                InitializeComponent();
                estadoEdicion = false;

                List<Persona> listadoDocentes = new List<Persona>();
                PersonaLogic perLog = new PersonaLogic();
                listadoDocentes = perLog.GetAllDocentes();
                cbxDocentes.DataSource = listadoDocentes;
                cbxDocentes.DisplayMember = "ApellidoNombre";
                cbxDocentes.ValueMember = "ID";

                List<Curso> listadoCursos = new List<Curso>();
                CursoLogic curLog = new CursoLogic();
                listadoCursos = curLog.GetAll();
                cbxCursos.DataSource = listadoCursos;
                cbxCursos.DisplayMember = "DescMateriaComision";
                cbxCursos.ValueMember = "ID";

                cbxRoles.DataSource = Enum.GetValues(typeof(Docente_Curso.TipoCargo));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void editar(Docente_Curso docCurso)
        {
            this.Text = "Editar Docente_Curso";
            estadoEdicion = true;
            cbxCursos.SelectedValue = docCurso.Curso.ID;
            cbxCursos.Enabled = false;
            cbxDocentes.SelectedValue = docCurso.Docente.ID;
            cbxDocentes.Enabled = false;
            cbxRoles.SelectedItem= docCurso.Cargo;
        } 

        #endregion

        #region HANDLERS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(estadoEdicion == true ? "Esta seguro que desea editar docente_curso?" : "Esta seguro que desea agregar docente_curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Docente_Curso doc_Curso = new Docente_Curso();
                    doc_Curso.Docente = (Persona)cbxDocentes.SelectedItem;
                    doc_Curso.Curso = (Curso)cbxCursos.SelectedItem;
                    doc_Curso.Cargo = (Entidades.Docente_Curso.TipoCargo)this.cbxRoles.SelectedItem;
                    Docente_CursoLogic docCurLog = new Docente_CursoLogic();

                    if (estadoEdicion == false)
                    {
                        
                        docCurLog.Insert(doc_Curso);
                        MessageBox.Show("Se ha agregado correctamente el Docente al Curso", "Agregar Docente al Curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        doc_Curso.Cargo = (Docente_Curso.TipoCargo)cbxRoles.SelectedItem;
                        docCurLog.Update(doc_Curso);
                        MessageBox.Show("Se ha editado correctamente el Docente en el Curso", "Editar el docente en el Curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}

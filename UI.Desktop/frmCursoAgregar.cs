using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;
using Util;

namespace UI.Desktop
{
    public partial class frmCursoAgregar : Form
    {
        bool estadoEdicion;
        public frmCursoAgregar()
        {
            try
            {
                InitializeComponent();
                estadoEdicion = false;
                List<Comision> listadoComisiones = new List<Comision>();
                ComisionLogic comLog = new ComisionLogic();
                listadoComisiones = comLog.GetAll();
                cbxComision.DataSource = listadoComisiones;
                cbxComision.DisplayMember = "DescComPlanEsp";
                cbxComision.ValueMember = "ID";

                List<Materia> listadoMaterias = new List<Materia>();
                MateriaLogic matLog = new MateriaLogic();
                listadoMaterias = matLog.GetAll();
                cbxMateria.DataSource = listadoMaterias;
                cbxMateria.DisplayMember = "Descripcion";
                cbxMateria.ValueMember = "ID";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void Editar(Curso curso)
        {
            estadoEdicion = true;
            this.Text = "Editar curso";
            this.txtID.Text = curso.ID.ToString();
            this.txtAnioCalendario.Text = curso.AnioCalendario.ToString();
            this.txtCupo.Text = curso.Cupo.ToString();
            cbxComision.SelectedValue = curso.Comision.ID;
            cbxMateria.SelectedValue = curso.Materia.ID;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (MessageBox.Show(estadoEdicion == true ? "Esta seguro que desea editar este curso?" : "Esta seguro que desea agregar este curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CursoLogic curLog = new CursoLogic();
                        Curso curso = new Curso();
                        curso.Comision = (Comision)cbxComision.SelectedItem;
                        curso.Materia = (Materia)cbxMateria.SelectedItem;
                        curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                        curso.Cupo = Int32.Parse(this.txtCupo.Text);

                        if (!estadoEdicion)
                        {
                            curLog.Insert(curso);
                            MessageBox.Show("Se ha agregado correctamente el curso", "Agregar curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            curso.ID = Int32.Parse(this.txtID.Text);
                            curLog.Update(curso);
                            MessageBox.Show("Se ha editado correctamente el curso", "Editar curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.Close();
                    }
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

        private bool Validar()
        {
            string mensaje = "";
            if (!Validaciones.esAnioCalendarioValido(this.txtAnioCalendario.Text))
            {
                mensaje += "- El campo Año Calendario es requerido y debe contener un numero entre 1950 y el año actual" + "\n";
            }
            if (this.cbxComision.SelectedIndex == -1 )
            {
                mensaje += "- El campo Comisión es requerido" + "\n";
            }
            if (this.cbxMateria.SelectedIndex == -1)
            {
                mensaje += "- El campo Materia es requerido" + "\n";
            }
            if (!Validaciones.esCupoValido(this.txtCupo.Text))
            {
                mensaje += "- El campo Cupo es requerido y debe ser como máximo de 100 personas" + "\n";
            }

            //Mostrar los errores
            if (!String.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

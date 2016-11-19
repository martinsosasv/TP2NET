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
using Util;

namespace UI.Desktop
{
    public partial class PlanAgregar : Form
    {
        bool estadoEdicion;
        public PlanAgregar()
        {
            InitializeComponent();

            estadoEdicion = false;
            EspecialidadLogic espLog = new EspecialidadLogic();
            List<Especialidad> listadoEspecialidades = new List<Especialidad>();
            listadoEspecialidades = espLog.GetAll();
            cbxEspecialidad.DataSource = listadoEspecialidades;
            cbxEspecialidad.DisplayMember = "Descripcion";
            cbxEspecialidad.ValueMember = "ID";
        }

        public void Editar(Plan plan)
        {
            estadoEdicion = true;
            this.Text = "Editar plan";
            this.txtID.Text = plan.ID.ToString();
            this.txtDescripcion.Text = plan.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                Plan plan = new Plan();
                PlanLogic plaLog = new PlanLogic();
                plan.Descripcion = this.txtDescripcion.Text;
                plan.Especialidad = (Especialidad)cbxEspecialidad.SelectedItem;
                if (estadoEdicion == false)
                {

                    plaLog.Insert(plan);
                    MessageBox.Show("Se ha agregado correctamente el plan", "Agregar plan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    plan.ID = Convert.ToInt32(this.txtID.Text);

                    plaLog.Update(plan);
                    MessageBox.Show("Se ha editado correctamente el plan", "Editar plan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar()
        {
            string mensaje = "";
            if (!Validaciones.esDescripcionValida(this.txtDescripcion.Text))
            {
                mensaje += "- El campo Descripción es requerido y no debe contener caracteres especiales" + "\n";
            }
            if (this.cbxEspecialidad.SelectedIndex == -1)
            {
                mensaje += "- El campo Especialidad es requerido" + "\n";
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

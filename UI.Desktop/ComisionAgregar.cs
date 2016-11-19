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
    public partial class ComisionAgregar : Form
    {
        bool estadoEdicion;
        public ComisionAgregar()
        {
            InitializeComponent();
            estadoEdicion = false;
            PlanLogic plaLog = new PlanLogic();
            List<Plan> listaPlanes = plaLog.GetAll();
            cbxPlan.DataSource = listaPlanes;
            cbxPlan.DisplayMember = "DescripcionEspPlan";
            cbxPlan.ValueMember = "ID";
                    }

        public void Editar(Comision comision)
        {
            estadoEdicion = true;
            this.Text = "Editar comisión";
            this.txtID.Text = comision.ID.ToString();
            this.txtDescripcion.Text = comision.Descripcion;
            this.txtAnio.Text = comision.AnioEspecialidad.ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                Comision comision = new Comision();
                ComisionLogic comLog = new ComisionLogic();
                comision.Descripcion = this.txtDescripcion.Text;
                comision.AnioEspecialidad = Convert.ToInt32(txtAnio.Text);
                comision.Plan = (Plan)cbxPlan.SelectedItem;
                if (estadoEdicion == false)
                {

                    comLog.Insert(comision);
                    MessageBox.Show("Se ha agregado correctamente la comisión", "Agregar comisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    comision.ID = Convert.ToInt32(this.txtID.Text);

                    comLog.Update(comision);
                    MessageBox.Show("Se ha editado correctamente la comisión", "Editar comisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (!Validaciones.esAnioCursoValido(this.txtAnio.Text))
            {
                mensaje += "- El campo Año es requerido y debe contener un numero entre 1 y 6" + "\n";
            }
            if (this.cbxPlan.SelectedIndex == -1)
            {
                mensaje += "- El campo Plan es requerido" + "\n";
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

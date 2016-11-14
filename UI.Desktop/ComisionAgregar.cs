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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

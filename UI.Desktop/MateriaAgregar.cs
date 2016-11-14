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
    public partial class MateriaAgregar : Form
    {
        bool estadoEdicion;
        public MateriaAgregar()
        {
            InitializeComponent();
            estadoEdicion = false;
            PlanLogic plaLog = new PlanLogic();
            List<Plan> listaPlanes = plaLog.GetAll();
            cbxPlan.DataSource = listaPlanes;
            cbxPlan.DisplayMember = "DescripcionEspPlan";
            cbxPlan.ValueMember = "ID";
        }

        public void Editar(Materia materia)
        {
            estadoEdicion = true;
            this.Text = "Editar Materia";
            this.txtID.Text = materia.ID.ToString();
            this.txtDescripcion.Text = materia.Descripcion;
            this.txtHSSemanales.Text = materia.HSSemanales.ToString();
            this.txtHSTotales.Text = materia.HSTotales.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            MateriaLogic matLog = new MateriaLogic();
            materia.Descripcion = this.txtDescripcion.Text;
            materia.HSSemanales = Convert.ToInt32(txtHSSemanales.Text);
            materia.HSTotales = Convert.ToInt32(txtHSTotales.Text);
            materia.Plan = (Plan)cbxPlan.SelectedItem;
            if (estadoEdicion == false)
            {

                matLog.Insert(materia);
                MessageBox.Show("Se ha agregado correctamente la materia", "Agregar materia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                materia.ID = Convert.ToInt32(this.txtID.Text);

                matLog.Update(materia);
                MessageBox.Show("Se ha editado correctamente la materia", "Editar materia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}

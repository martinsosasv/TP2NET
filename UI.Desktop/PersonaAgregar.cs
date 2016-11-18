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

namespace UI.Desktop
{
    public partial class PersonaAgregar : Form
    {
        bool estadoEdicion;
        public PersonaAgregar()
        {
            InitializeComponent();
            estadoEdicion = false;
            List<Plan> planes = new List<Plan>();
            PlanLogic plaLog = new PlanLogic();
            planes = plaLog.GetAll();
            cbxPlan.DataSource = planes;
            cbxPlan.DisplayMember = "DescripcionEspPlan";
            cbxPlan.ValueMember = "ID";
            cbxTipo.DataSource = Enum.GetValues(typeof(Entidades.Personas.TiposPersonas));
             
        }

        public void Editar(Entidades.Personas persona)
        {
            estadoEdicion = true;
            this.Text = "Editar Persona";
            this.txtID.Text = persona.ID.ToString();
            this.txtNombre.Text = persona.Nombre;
            this.txtApellido.Text = persona.Apellido;
            this.txtDireccion.Text = persona.Direccion;
            this.txtEmail.Text = persona.Email;
            this.txtTelefono.Text = persona.Telefono;
            this.dtpFechaNac.Text = persona.FechaNacimiento.ToString();
            this.txtLegajo.Text = persona.IdLegajo.ToString();
            this.cbxTipo.SelectedItem = persona.TipoPersona;
            this.cbxPlan.SelectedValue = persona.Plan.ID;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Entidades.Personas persona = new Entidades.Personas();
            PersonaLogic perLog = new PersonaLogic();
            persona.Nombre = this.txtNombre.Text;
            persona.Apellido = this.txtApellido.Text;
            persona.Direccion = this.txtDireccion.Text;
            persona.Email = this.txtEmail.Text;
            persona.Telefono = this.txtTelefono.Text;
            persona.FechaNacimiento = this.dtpFechaNac.Value;
            persona.IdLegajo = Convert.ToInt32(this.txtLegajo.Text);
            persona.TipoPersona = (Entidades.Personas.TiposPersonas)this.cbxTipo.SelectedItem;
            persona.Plan = (Plan)this.cbxPlan.SelectedItem;
        
            if (estadoEdicion == false)
            {

                perLog.Insert(persona);
                MessageBox.Show("Se ha agregado correctamente la persona", "Agregar persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                persona.ID = Convert.ToInt32(this.txtID.Text);

                perLog.Update(persona);
                MessageBox.Show("Se ha editado correctamente la persona", "Editar persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.cbxTipo.SelectedIndex == 2)
            {
                this.txtLegajo.Enabled = true;
                this.cbxPlan.Enabled = true;
            }
            else
            {
                this.txtLegajo.Enabled = false;
                this.cbxPlan.Enabled = false;
            }
        }
    }
}

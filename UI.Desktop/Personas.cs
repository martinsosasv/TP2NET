using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class Personas : UI.Desktop.Base
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            this.Listar();
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colIdPer = new DataGridViewTextBoxColumn();
            colIdPer.Name = "id_persona";
            colIdPer.HeaderText = "ID";
            colIdPer.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colIdPer);

            DataGridViewTextBoxColumn colNomPer = new DataGridViewTextBoxColumn();
            colNomPer.Name = "nombre_persona";
            colNomPer.HeaderText = "Nombre";
            colNomPer.DataPropertyName = "Nombre";
            this.dgvBase.Columns.Add(colNomPer);

            DataGridViewTextBoxColumn colApePer = new DataGridViewTextBoxColumn();
            colApePer.Name = "apellido_persona";
            colApePer.HeaderText = "Apellido";
            colApePer.DataPropertyName = "Apellido";
            this.dgvBase.Columns.Add(colApePer);

            DataGridViewTextBoxColumn colEmailPer = new DataGridViewTextBoxColumn();
            colEmailPer.Name = "email_persona";
            colEmailPer.HeaderText = "E-mail";
            colEmailPer.DataPropertyName = "Email";
            this.dgvBase.Columns.Add(colEmailPer);

            DataGridViewTextBoxColumn colLegPer = new DataGridViewTextBoxColumn();
            colLegPer.Name = "legajo_persona";
            colLegPer.HeaderText = "Legajo";
            colLegPer.DataPropertyName = "IdLegajo";
            this.dgvBase.Columns.Add(colLegPer);

            DataGridViewTextBoxColumn coltipoPer = new DataGridViewTextBoxColumn();
            coltipoPer.Name = "tipo_persona";
            coltipoPer.HeaderText = "Tipo de Persona";
            coltipoPer.DataPropertyName = "TipoPersona";
            this.dgvBase.Columns.Add(coltipoPer);
        }

        public void Listar()
        {
            PersonaLogic perLog = new PersonaLogic();
            List<Entidades.Personas> listaPersonas = new List<Entidades.Personas>();
            listaPersonas = perLog.GetAll();
            this.dgvBase.DataSource = listaPersonas;
        }
    }
}

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
    public partial class frmReportePlan : Form
    {
        public frmReportePlan()
        {
            try
            {
                InitializeComponent();
                this.dgvPlanes.AutoGenerateColumns = false;
                GenerarColumnas();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void cargarGrilla()
        {
            List<ReportePlan> reportePlanes = new List<ReportePlan>();
            ReporteLogic repLog = new ReporteLogic();
            reportePlanes = repLog.GetAllReportePlan();
            this.dgvPlanes.DataSource = reportePlanes;
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colEsp = new DataGridViewTextBoxColumn();
            colEsp.Name = "especialidad";
            colEsp.HeaderText = "Especialidad";
            colEsp.DataPropertyName = "Especialidad";
            this.dgvPlanes.Columns.Add(colEsp);

            DataGridViewTextBoxColumn colPlan = new DataGridViewTextBoxColumn();
            colPlan.Name = "plan";
            colPlan.HeaderText = "Plan";
            colPlan.DataPropertyName = "Plan";
            this.dgvPlanes.Columns.Add(colPlan);

            DataGridViewTextBoxColumn colMat = new DataGridViewTextBoxColumn();
            colMat.Name = "materia";
            colMat.HeaderText = "Materia";
            colMat.DataPropertyName = "Materia";
            this.dgvPlanes.Columns.Add(colMat);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}

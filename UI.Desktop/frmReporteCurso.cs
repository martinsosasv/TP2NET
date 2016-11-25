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
    public partial class frmReporteCurso : Form
    {
        private int id_curso;
        public int Id_Curso
        {
            get
            {
                return id_curso;
            }
            set
            {
                id_curso = value;
            }
        }
        public frmReporteCurso(int id_curso)
        {
            try
            {
                InitializeComponent();
                this.Id_Curso = id_curso;
                lblReporte.Text += " " + Id_Curso.ToString();
                this.dgvReporteCurso.AutoGenerateColumns = false;
                this.GenerarColumnas();
                this.cargarGrilla();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void cargarGrilla()
        {
            List<ReporteCurso> reporteCurso = new List<ReporteCurso>();
            ReporteLogic repLog = new ReporteLogic();
            reporteCurso = repLog.GetAllReporteCurso(Id_Curso);
            this.dgvReporteCurso.DataSource = reporteCurso;
        }

        private void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "legajo";
            colLegajo.HeaderText = "Legajo";
            colLegajo.DataPropertyName = "Legajo";
            this.dgvReporteCurso.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "Apellido";
            this.dgvReporteCurso.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            this.dgvReporteCurso.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colCondicion = new DataGridViewTextBoxColumn();
            colCondicion.Name = "condicion";
            colCondicion.HeaderText = "Condicion";
            colCondicion.DataPropertyName = "Condicion";
            this.dgvReporteCurso.Columns.Add(colCondicion);

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmEditarNota : Form
    {
        AlumnoInscripcion _aluIns;
        public AlumnoInscripcion AluIns
        {
            get { return _aluIns; }
            set { _aluIns = value; }
        }

        public frmEditarNota()
        {
            InitializeComponent();
        }

        int _idInsc;
        public int IdInsc
        {
            get { return _idInsc; }
            set { _idInsc = value; }
        }

        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        string _legajo;
        public string Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }
        
        public frmEditarNota(int id,string nombre, string apellido, string legajo)
        {
            InitializeComponent();
            this.IdInsc = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Legajo = legajo;
            this.lblIdentificacion.Text = this.Nombre + " " + this.Apellido + " - " + this.Legajo; 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion aluIns = new AlumnoInscripcion();
            aluIns.ID = this.IdInsc;
            aluIns.Nota = Convert.ToInt32(this.cbxNota.SelectedValue);
            
            AluInscLogic aluInscLog = new AluInscLogic();
            try
            {
                aluInscLog.UpdateNota(aluIns);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

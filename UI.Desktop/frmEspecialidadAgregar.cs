﻿using System;
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
    public partial class frmEspecialidadAgregar : Form
    {
        private bool estadoEdicion;
        public frmEspecialidadAgregar()
        {
            InitializeComponent();
            estadoEdicion = false;
        }

        public void Editar(Especialidad esp)
        {
            estadoEdicion = true;
            this.Text = "Editar especialidad";
            this.btnAgregar.Text = "Editar";
            this.txtID.Text = esp.ID.ToString();
            this.txtDescripcion.Text = esp.Descripcion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.Validar())
            {
                Especialidad especialidad = new Especialidad();
                EspecialidadLogic espLog = new EspecialidadLogic();
                especialidad.Descripcion = this.txtDescripcion.Text;
                if(estadoEdicion == false)
                {

                    espLog.Create(especialidad);
                    MessageBox.Show("Se ha agregado correctamente la especialidad", "Agregar especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    especialidad.ID = Convert.ToInt32(this.txtID.Text);
                
                    espLog.Update(especialidad);
                    MessageBox.Show("Se ha editado correctamente la especialidad", "Editar especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Validar()
        {
            string mensaje = "";
            if(!Validaciones.esDescripcionComisionValida(this.txtDescripcion.Text))
            {
                mensaje += "- El campo Descripción es requerido y no debe contener caracteres especiales" + "\n";
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
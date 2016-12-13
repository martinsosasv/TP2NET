﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using Util;

namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
    {
        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        EspecialidadLogic _especialidadLogic;
        private EspecialidadLogic EspecialidadLogic
        {
            get
            {
                if (_especialidadLogic == null)
                {
                    _especialidadLogic = new EspecialidadLogic();
                }
                return _especialidadLogic;
            }
        }


        public enum FormModes
        {
            Alta, Baja, Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private Plan Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    MessageBoxAlert("Su sesión ha expirado", "Planes", "Login.aspx");
                }
                else
                {
                    int id_tipo_persona = Convert.ToInt32(Session["id_tipo_persona"]);
                    switch (id_tipo_persona)
                    {
                        //admin
                        case 1:
                            this.LoadGrid();
                            break;
                        default:
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Planes", "Home.aspx");
                            break;

                    }
                }

            }
        }

        private void MessageBoxAlert(string message, string title = "title", string page = "Login.aspx")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), title,
                        "alert('" + message + "'); window.location='" +
                        Request.ApplicationPath + page + "';", true);
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlDescripcionEspecialidad.SelectedValue = this.Entity.Especialidad.ID.ToString();
            this.txtID.Text = Entity.ID.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.ClearForm();
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.formValidationPanel.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void LoadEntity(Plan plan)
        {

            plan.Descripcion = this.txtDescripcion.Text;
            Especialidad esp = new Especialidad();
            esp = EspecialidadLogic.GetOne(Convert.ToInt32(this.ddlDescripcionEspecialidad.SelectedValue));
            plan.Especialidad = esp;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    if (Validar())
                    {

                        this.Entity = new Plan();
                        this.Entity.ID = this.SelectedID;
                        this.LoadEntity(this.Entity);
                        this.Logic.Update(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }

                    break;
                case FormModes.Alta:
                    if (Validar())
                    {
                        this.Entity = new Plan();
                        this.LoadEntity(this.Entity);
                        this.Logic.Insert(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }
                    break;

                default:
                    break;

            }

        }

        private bool Validar()
        {
            this.alertForm.InnerHtml = "";
            string mensaje = "";
            //Descripcion
            if (!Validaciones.esDescripcionValida(this.txtDescripcion.Text))
            {
                this.lblAsteriscoDescripcion.Visible = true;
                mensaje += "- El campo Descripción es requerido y no debe contener caracteres especiales" + "<br/>";
            }
            if (this.ddlDescripcionEspecialidad.SelectedValue == "-1")
            {
                this.lblAsteriscoDescripcionEspecialidad.Visible = true;
                mensaje += "- El plan debe tener una especialidad asignada" + "<br/>";
            }

            //Mostrar los errores
            if (!String.IsNullOrEmpty(mensaje))
            {
                this.alertForm.InnerHtml = mensaje;
                formValidationPanel.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.ddlDescripcionEspecialidad.Enabled = enable;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.ClearForm();
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.formValidationPanel.Visible = false;

            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.formValidationPanel.Visible = false;
        }

        private void ClearForm()
        {

            this.txtID.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.ddlDescripcionEspecialidad.SelectedIndex = -1;

            this.lblAsteriscoDescripcion.Visible = false;
            this.lblAsteriscoDescripcionEspecialidad.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
    }
}
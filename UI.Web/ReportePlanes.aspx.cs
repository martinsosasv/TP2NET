using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Util;


namespace UI.Web
{
    public partial class ReportePlanes : System.Web.UI.Page
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

        MateriaLogic _materiaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_materiaLogic == null)
                {
                    _materiaLogic = new MateriaLogic();
                }
                return _materiaLogic;
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
            if (this.gridView.Rows.Count == 0)
            {

                this.gridViewEmpty.Visible = true;
                this.gridView.Visible = false;
                this.gridViewActionsPanel.Visible = false;

            }
            else
            {
                this.gridView.Visible = true;
                this.gridViewActionsPanel.Visible = true;
                this.gridViewEmpty.Visible = false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.IsPostBack))
            {
                if (Session["usuario"] == null)
                {
                    MessageBoxAlert("Su sesión ha expirado", "Reporte Planes", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Reporte Planes", "Home.aspx");
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
            this.divReportePlan.Visible = false;
        }

        private void LoadGridReportePlan(int id)
        {
            this.gridViewReportePlan.DataSource = this.MateriaLogic.GetAllMateriasPlan(id);
            this.gridViewReportePlan.DataBind();

            if (this.gridViewReportePlan.Rows.Count == 0)
            {

                this.gridViewReportePlanEmpty.Visible = true;
                this.gridViewReportePlan.Visible = false;

            }
            else
            {
                this.gridViewReportePlan.Visible = true;
                this.gridViewReportePlanEmpty.Visible = false;
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.divReportePlan.Visible = true;
                //this.formValidationPanel.Visible = false
                this.LoadGridReportePlan(this.SelectedID);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.divReportePlan.Visible = false;
        }
    }
}
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
    public partial class ReporteCursos : System.Web.UI.Page
    {
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        ReporteLogic _reporteCursoLogic;
        private ReporteLogic ReporteCursoLogic
        {
            get
            {
                if (_reporteCursoLogic == null)
                {
                    _reporteCursoLogic = new ReporteLogic();
                }
                return _reporteCursoLogic;
            }
        }
        
        private Curso Entity
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
                    MessageBoxAlert("Su sesión ha expirado", "Cursos", "Login.aspx");
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
                            MessageBoxAlert("No tienes permiso para ingresar a ésta página.", "Cursos", "Home.aspx");
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

        private void LoadGridReporteCurso(int id)
        {
            this.gridViewReporteCursos.DataSource = this.ReporteCursoLogic.GetAllReporteCurso(id);
            this.gridViewReporteCursos.DataBind();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.divReporteCurso.Visible = true;
                //this.formValidationPanel.Visible = false
                this.LoadGridReporteCurso(this.SelectedID);
            }
            else
            {
                Response.Write("<script>window.alert('Asegúrese de seleccionar un campo.');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.divReporteCurso.Visible = false;
        }
    }
}
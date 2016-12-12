using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace UI.Web
{
     
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblErrorIngreso.Visible = false;
            Session.Clear();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioLogic userLog = new UsuarioLogic();
                user = userLog.GetOne(this.txtUsuario.Text);
                if (user.NombreUsuario == this.txtUsuario.Text.ToLower() && user.Clave == this.txtPassword.Text.ToLower() && user.Habilitado == true)
                {
                    this.txtUsuario.Text = "";
                    this.txtPassword.Text = "";
                    Session["usuario"] = user.NombrePersona + " " + user.ApellidoPersona;
                    Session["id_tipo_persona"] = user.Persona.TipoPersona;
                    Session["id_persona"] = user.Persona.ID;
                    Page.Response.Redirect("~/Home.aspx");
                }
                else
                {
                    if(user.Habilitado == false)
                    {
                        //El Usuario está deshabilitado
                        this.lblErrorIngreso.Visible = true;
                        this.lblErrorIngreso.InnerHtml = "El Usuario se encuentra deshabilitado";
                    }
                    else if (user.NombreUsuario != this.txtUsuario.Text)
                    {
                        //El Usuario no existe
                        this.lblErrorIngreso.Visible = true;
                        this.lblErrorIngreso.InnerHtml = "El Usuario no existe";
                    }
                    else
                    {
                        //La Clave ingresada es incorrecta
                        this.lblErrorIngreso.Visible = true;
                        this.lblErrorIngreso.InnerHtml = "La Clave ingresada es incorrecta";
                    }

                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page), "myscript", "alert('Error al tratar de ingresar')", true);
            }

        }
        protected void lbOlvidaPassword_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(typeof(Page), "myscript", "alert('Eres un usuario muy descuidado! Haga memoria')", true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppWeb
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("login.aspx", false);
                return;
            }
            if (((Usuario)Session["Usuario"]).NivelUsuario > 1)
            {
                // No tiene permiso a esta pantalla
            }
            if (IsPostBack)
            {
                return;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                return;
            }
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Response.Write("<script>alert('Por favor, complete ambos campos de contraseña..');</script>");
                return;
            }
            UsuarioDatos UsuarioDatos = new UsuarioDatos();
            UsuarioDatos.setUserPassword(id, txtPassword.Text);
            Response.Redirect("gerenciaPersonal.aspx", true);
        }
    }
}
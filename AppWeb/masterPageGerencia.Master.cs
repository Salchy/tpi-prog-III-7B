using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsuarioDatos.SesionActiva(Session["Usuario"]))
            {
                Response.Redirect("login.aspx", false);
                return;
            }
            if (UsuarioDatos.GetLevel(Session["Usuario"]) > 1)
            {
                Session.Add("error", "Mensaje de error");
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class gerenciaReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsuarioDatos.SesionActiva(Session["Usuario"])) {
                Response.Redirect("login.aspx", false);
                return;
            }
            if (UsuarioDatos.GetLevel(Session["Usuario"]) > 1)
            {
                // No tiene permiso a esta pantalla
            }
        }
    }
}
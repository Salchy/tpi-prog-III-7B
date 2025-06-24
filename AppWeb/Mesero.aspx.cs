using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        int nivelUsuario;

        // Esto va a cambiar el MasterPage dependiendo del nivel de usuario
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
            nivelUsuario = ((Usuario)Session["Usuario"]).NivelUsuario;

            if (nivelUsuario == 0) // Es mesero
                this.MasterPageFile = "~/masterPageMesero.Master";
            else if (nivelUsuario == 1) // Es gerente
                this.MasterPageFile = "~/masterPageGerencia.master";
        }

        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ordenes.aspx", false);
        }
    }
}
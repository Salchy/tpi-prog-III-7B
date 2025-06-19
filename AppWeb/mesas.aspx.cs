using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace AppWeb
{
    public partial class WebForm3 : System.Web.UI.Page
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

            switch (nivelUsuario)
            {
                case 0:
                    Response.Redirect("Gerencia.aspx");
                    break;
                case 1:
                    Response.Redirect("Gerencia.aspx");
                    break;
                case 2:
                    Response.Redirect("Mesero.aspx");
                    break;
                default:
                    Response.Redirect("Mesero.aspx");
                    return;
            }

            if (nivelUsuario < 2) // Es Gerente o admin
                this.MasterPageFile = "~/masterPageMesero.Master";
            else if (nivelUsuario == 1) // Es gerente
                this.MasterPageFile = "~/masterPageGerencia.master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Acá se habilitarán los botones o no, dependiendo el nivel que tiene


        }
    }
}
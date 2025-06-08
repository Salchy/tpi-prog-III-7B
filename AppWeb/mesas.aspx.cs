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
            nivelUsuario = ((Usuario)Session["Usuario"]).NivelUsuario;

            if (nivelUsuario == 0) // Es mesero
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
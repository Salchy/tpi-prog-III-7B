using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        public bool paginaerror{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = Session["error"].ToString();

            if (Session["PaginaActual"] != null)
            {
                paginaerror = true;

            }
            else
            {
                paginaerror = false;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string paginaOrigen = Convert.ToString(Session["Paginaorigen"]);
            Response.Redirect(paginaOrigen, false);
        }
    }
}
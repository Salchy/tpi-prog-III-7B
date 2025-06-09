using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        UsuarioDatos UsuarioDatos = new UsuarioDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("login.aspx", false);
            //    return;
            //}
            if (IsPostBack)
            {
                return;
            }

            dataGridEmpleados.DataSource = UsuarioDatos.getUsuarios();
            dataGridEmpleados.DataBind();
        }
    }
}
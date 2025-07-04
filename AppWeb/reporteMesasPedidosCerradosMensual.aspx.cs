using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class reporteMesasPedidosCerradosMensual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioDatos.GetLevel(Session["Usuario"]) > 1)
            {
                Session.Add("error", "Mensaje de error");
                Response.Redirect("Error.aspx", false);
                return;
            }

            ReportesDatos manager = new ReportesDatos();
            dgvReporte.DataSource = manager.listarRankingMasPedidosCerrados("mensual");
            dgvReporte.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerencia.aspx");
        }
    }
}
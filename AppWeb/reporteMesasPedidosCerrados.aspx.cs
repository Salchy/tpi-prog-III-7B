using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace AppWeb
{
    public partial class reporteMesasPedidosCerrados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportesDatos manager = new ReportesDatos();
            dgvReporte.DataSource = manager.listarRankingMasPedidosCerrados();
            DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaReportes.aspx", false);
        }
    }
}
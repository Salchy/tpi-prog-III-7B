using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using negocio;

namespace AppWeb
{
    public partial class reporteItemMasPedidoMes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportesDatos manager = new ReportesDatos();
            dgvReporte.DataSource = manager.ListaMenuMasPedido("mensual");
            dgvReporte.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerencia.aspx");
        }
    }
}
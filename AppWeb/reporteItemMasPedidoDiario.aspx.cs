using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class reporteItemMasPedidoDiario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportesDatos manager = new ReportesDatos();
            dgvReporte.DataSource = manager.ListaMenuMasPedido("diario");
            DataBind();
        }
    }
}
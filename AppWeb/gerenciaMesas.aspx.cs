using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class gerenciaMesas : System.Web.UI.Page
    {
        MesaDatos mesaDatos = new MesaDatos();
        List<Mesa> mesasAsignadas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            reloadDataBind();
        }

        private void reloadDataBind()
        {
            try
            {
                mesasAsignadas = mesaDatos.getMesas();
                dgvMesas.DataSource = mesasAsignadas;
                dgvMesas.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Error al intentar obtener listado de mesas");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvMesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "management")
            {
                int idMesa = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("gerenciaAdministrarMesa.aspx?id=" + idMesa, false);
            }
        }

        protected void dgvMesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Mesa mesa = (Mesa)e.Row.DataItem;
                Label lblMesero = (Label)e.Row.FindControl("lblMeseroAsignado");

                if (lblMesero != null && mesa != null)
                {
                    try
                    {
                        lblMesero.Text = mesa.MeseroAsignado.getFullName();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
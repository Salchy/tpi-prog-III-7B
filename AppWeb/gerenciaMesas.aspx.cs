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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            MesaDatos mesaDatos = new MesaDatos();
            List<Mesa> mesasAsignadas = mesaDatos.getMesas();

            dgvMesas.DataSource = mesasAsignadas;
            dgvMesas.DataBind();
        }

        protected void dgvMesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignar")
            {
                int idMesa = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("gerenciaAsignarMesero.aspx?id=" + idMesa, false);
            }
            else if (e.CommandName == "Editar")
            {
                int idMesa = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("gerenciaEditarMesa.aspx?id=" + idMesa, false);
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
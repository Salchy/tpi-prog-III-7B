using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class WebForm4 : System.Web.UI.Page
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

            if (nivelUsuario == 0) // Es mesero
                this.MasterPageFile = "~/masterPageMesero.Master";
            else if (nivelUsuario == 1) // Es gerente
                this.MasterPageFile = "~/masterPageGerencia.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MesaDatos mesaDatos = new MesaDatos();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("login.aspx", false);
                return;
            }
            if (((Usuario)Session["Usuario"]).NivelUsuario > 2)
            {
                // No tiene permiso a esta pantalla
                //Session.Add("error", ex.ToString());
                Session.Add("error", "Mensaje de error");
                Response.Redirect("Error.aspx");
                return;
            }
            if (IsPostBack)
            {
                return;
            }
            Usuario Mesero = (Usuario)Session["Usuario"];
            List<Mesa> mesasAsignadas;
            if (((Usuario)Session["Usuario"]).NivelUsuario < 2) // Es Admin o Gerente
                mesasAsignadas = mesaDatos.getMesas();
            else
                mesasAsignadas = mesaDatos.getMesasAsignadas(Mesero.Id);

            dgvMesas_asignadas.DataSource = mesasAsignadas;
            dgvMesas_asignadas.DataBind();

            Session["MesasAsignadas"] = mesasAsignadas;
        }

        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {

            Response.Redirect("Ordenes.aspx", false);
        }

        protected void dgvMesas_asignadas_SelectedIndexChanged(object sender, EventArgs e) //es igual el de ordenes pero salta error, al buscar la lista de ordenes de la mesa
        {
            /*OrdenDatos orden = new OrdenDatos();
            PedidoDatos pedido = new PedidoDatos();

            int idmesa = int.Parse(dgvMesas_asignadas.SelectedDataKey.Value.ToString());
            int idpedido = pedido.getIdPedidoMesaAbierta(idmesa);


            dvgOrdenes.DataSource= orden.getOrdenesPedido(idpedido);
            dvgOrdenes.DataBind();*/
        }
    }
}
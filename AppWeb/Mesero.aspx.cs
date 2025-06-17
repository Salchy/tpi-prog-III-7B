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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             MesaDatos mesaDatos = new MesaDatos();
            List<Mesa> lista = mesaDatos.getMesasAsignadas(3);
            
            


            /*Usuario Mesero = (Usuario) Session["Usuario"];
             dgvMesas_asignadas.DataSource = mesaDatos.getMesasAsignadas(Mesero.Id);//recuperar el id del usuario cuando se loguea
             dgvMesas_asignadas.DataBind();*/

            dgvMesas_asignadas.DataSource = lista;//recuperar el id del usuario cuando se loguea
            dgvMesas_asignadas.DataBind();
            Session["MesasAsignadas"] = lista;

        }

        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Ordenes.aspx", false);
        }

        protected void dgvMesas_asignadas_SelectedIndexChanged(object sender, EventArgs e)//es igual el de ordenes pero salta error, al buscar la lista de ordenes de la mesa
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
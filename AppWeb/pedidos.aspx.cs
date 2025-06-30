using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            //if (nivelUsuario == 2) // Es mesero
            //   this.MasterPageFile = "~/masterPageMesero.Master";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MesaDatos mesaDatos = new MesaDatos();

            if (IsPostBack)
            {
                return;
            }
            Usuario Mesero = (Usuario)Session["Usuario"];
            List<Mesa> mesasAsignadas;
            mesasAsignadas = mesaDatos.getMesasAsignadas(Mesero.Id);

            dgvMesas_asignadas.DataSource = mesasAsignadas;
            dgvMesas_asignadas.DataBind();

            Session["MesasAsignadas"] = mesasAsignadas;
        }

        protected void dgvMesas_asignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrdenDatos orden = new OrdenDatos();
            PedidoDatos pedido = new PedidoDatos();

            int idmesa = Convert.ToInt32(dgvMesas_asignadas.SelectedDataKey.Value.ToString());
            int idpedido = pedido.getIdPedidoFromIdMesa(idmesa);

            dgvOrdenes.DataSource = orden.getOrdenesPedido(idpedido);
            dgvOrdenes.DataBind();

        }
        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ordenes.aspx", false);

        }

        

        protected void dgvMesas_asignadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMesa = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Cerrar Pedido")
            {

                try
                {
                    PedidoDatos pedido = new PedidoDatos();
                    int idPedido = pedido.getIdPedidoFromIdMesa(idMesa);
                    if (idPedido != 0)
                    {
                        pedido.EliminarPedido(idPedido);

                    }
                    
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cerrar el pedido: " + ex.Message);
                    Session["Paginaorigen"] = "Mesero.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                    Response.Redirect("Error.aspx", false);
                }

            }

        }
        
        protected void dgvOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idOrden = Convert.ToInt32(e.CommandArgument);
            
            if (e.CommandName == "Eliminar Orden")
            {

                try
                {
                    OrdenDatos orden=new OrdenDatos();  
                    Orden eliminada = new Orden();
                    eliminada = orden.getOrden(idOrden);

                    orden.EliminarOrden(idOrden);

                    dgvOrdenes.DataSource = orden.getOrdenesPedido(eliminada.Pedido.Id);
                    dgvOrdenes.DataBind();


                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al eliminar la orden: " + ex.Message);
                    Session["Paginaorigen"] = "Mesero.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                    Response.Redirect("Error.aspx", false);
                }

            }
            else
            {
                try
                {
                    Session["Orden seleccionada"] = idOrden;
                    OrdenDatos orden = new OrdenDatos();
                    Orden selecionada = new Orden();
                    selecionada = orden.getOrden(idOrden);
                    lblMenu.Text = selecionada.Menu.Nombre;

                }
                catch (Exception ex)
                {

                    Session.Add("error", "Error al obtener el nombre del menu de la orden seleccionada: " + ex.Message);
                    Session["Paginaorigen"] = "Mesero.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                    Response.Redirect("Error.aspx", false);
                }

            }
        }

        protected void btnModificarOrden_Click(object sender, EventArgs e)
        {
            
            try
            {
                Validaciones validar = new Validaciones();
                
                OrdenDatos orden = new OrdenDatos();
                Orden selecionada = new Orden();
                selecionada = orden.getOrden(int.Parse(Session["Orden seleccionada"].ToString()));
                int cantMax = (selecionada.Pedido.mesa.NumeroComensales) * 6;
                //la cantidad maxima de un menu que se toma en una orden es 6 veces el numero de comensales de la mesa

                if (validar.SoloNumeros(txtCantidad.Text) > 0 && validar.SoloNumeros(txtCantidad.Text) < cantMax)
                {
                    
                    selecionada.Cantidad = int.Parse(txtCantidad.Text);
                    orden.ModificarOrden(selecionada);

                    dgvOrdenes.DataSource = orden.getOrdenesPedido(selecionada.Pedido.Id);
                    dgvOrdenes.DataBind();

                    txtCantidad.Text = "";
                }
                else
                {
                    txtCantidad.Text = "";
                }            

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al modificar la orden seleccionada: " + ex.Message);
                Session["Paginaorigen"] = "Mesero.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
            }                      
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppWeb
{
    public partial class WebForm3 : System.Web.UI.Page
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

            /*switch (nivelUsuario)
            {
                case 0:
                    this.MasterPageFile = "~/masterPageGerencia.Master";
                    break;
                case 1:
                    this.MasterPageFile = "~/masterPageGerencia.Master";
                    break;
                case 2:
                    this.MasterPageFile = "~/masterPageMesero.master";
                    break;
                default:
                    this.MasterPageFile = "~/masterPageMesero.master";
                    return;
            }*/
            this.MasterPageFile = "~/masterPageMesero.master";
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

                protected void dgvMesas_asignadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMesa = Convert.ToInt32(e.CommandArgument);
            PedidoDatos pedido = new PedidoDatos();
            if (e.CommandName == "Eliminar Pedido")
            {

                try
                {
                   
                    int idPedido = pedido.getIdPedidoFromIdMesa(idMesa);
                    if (idPedido != 0)
                    {
                        pedido.EliminarPedido(idPedido);

                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al eliminar el pedido: " + ex.Message);
                    Session["Paginaorigen"] = "mesas.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                    Response.Redirect("Error.aspx", false);
                }

            }
            else
            {
                if (e.CommandName == "Cerrar Pedido")
                {
                    try
                    {

                        int idPedido = pedido.getIdPedidoFromIdMesa(idMesa);


                        if (idPedido != 0)
                        {
                            OrdenDatos ordenes = new OrdenDatos();
                            decimal importe = 0;
                            importe = pedido.ImportePedido(idPedido);
                            pedido.ModificarPedido(idPedido, importe, false);
                            ordenes.EliminarOrdenesdelPedido(idPedido);


                        }

                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", "Error al cerrar el pedido: " + ex.Message);
                        Session["Paginaorigen"] = "mesas.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {

                    try
                    {
                                            

                        PedidoDatos nuevo = new PedidoDatos();
                        int idpedido = nuevo.getIdPedidoFromIdMesa(idMesa);
                        if (idpedido == 0)
                        {
                            nuevo.CrearPedido(idMesa);

                        }
                        //Session["MesaAbierta"] =idMesa;
                        Response.Redirect("Ordenes.aspx", false);

                    }
                    catch (Exception ex)
                    {

                        Session.Add("error", "Error al cargar el pedido: " + ex.Message);
                        Session["Paginaorigen"] = "mesas.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                        Response.Redirect("Error.aspx", false);
                    }
                }



            }

        }
    }
}
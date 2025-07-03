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
using static System.Net.Mime.MediaTypeNames;

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

            if (!IsPostBack)
            {
                ddlMesasAsignadas.DataSource = ((List<Mesa>)Session["MesasAsignadas"]);
                ddlMesasAsignadas.DataTextField = "NumeroMesa";
                ddlMesasAsignadas.DataValueField = "IdMesa";
                ddlMesasAsignadas.DataBind();
                ddlMesasAsignadas.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
                lblMesaSinPedido.Visible = false;
                lblMesaSinPedido.Text = "";
                btnVolver.Visible = false;
                lblPedido.Visible = false;
                lblOrdenModificada.Visible = false;
                lblPedidoVacio.Visible = false;

                if (Session["MesaAbierta"] != null && Session["MesaAbierta"].ToString() != "0")
                {
                    ddlMesasAsignadas.SelectedValue = Session["MesaAbierta"].ToString();
                    try
                    {
                        int idmesa = Convert.ToInt32(ddlMesasAsignadas.SelectedValue);
                        if (idmesa == 0)
                        {
                            return;
                        }

                        PedidoDatos nuevo = new PedidoDatos();
                        int idpedido = nuevo.getIdPedidoFromIdMesa(idmesa);
                        if (idpedido == 0)
                        {
                            
                            lblMesaSinPedido.Visible = true;
                            lblMesaSinPedido.Text = "No existe ningun pedido abierto asignado a la mesa";
                            btnVolver.Visible = true;
                            lblPedido.Visible = false;
                            lblOrdenModificada.Visible = false;
                            lblPedidoVacio.Visible = false;

                        }
                        else
                        {
                            lblPedido.Visible = true;
                            OrdenDatos orden = new OrdenDatos();
                            List<Orden> Pedidas = orden.getOrdenesPedido(idpedido);
                            dgvOrdenes.DataSource = Pedidas;
                            dgvOrdenes.DataBind();
                            Session["MesaAbierta"] = idmesa;

                            int cont = 0;

                            foreach (var item in Pedidas)
                            {
                                cont++;

                            }
                            if (cont == 0)
                            {
                                lblPedidoVacio.Visible = true;
                            }


                        }

                          
                    }
                    catch (Exception ex)
                    {

                        Session.Add("error", "Error al cargar el pedido: " + ex.Message);
                        Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }


        }

        protected void ddlMesasAsignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMesaSinPedido.Visible = false;
                lblMesaSinPedido.Text = "";
                btnVolver.Visible = false;
                lblPedido.Visible = true;
                lblMenu.Visible = false;
                txtCantidad.Visible = false;
                btnModificarOrden.Visible = false;
                lblOrdenModificada.Visible = false;
                lblPedidoVacio.Visible = false;
                int idmesa = Convert.ToInt32(ddlMesasAsignadas.SelectedValue);
                if (idmesa == 0)
                {
                    return;
                }
                PedidoDatos nuevo = new PedidoDatos();
                int idpedido = nuevo.getIdPedidoFromIdMesa(idmesa);
                if (idpedido == 0 )
                {
                    
                    lblMesaSinPedido.Visible = true;
                    lblMesaSinPedido.Text = "No existe ningun pedido abierto asignado a la mesa";
                    btnVolver.Visible = true;
                    lblPedido.Visible = false;
                    lblMenu.Visible = false;
                    txtCantidad.Visible = false;
                    btnModificarOrden.Visible = false;
                    lblOrdenModificada.Visible = false;
                    lblPedidoVacio.Visible = false;
                    dgvOrdenes.Visible = false;




                }
                else
                {
                    OrdenDatos orden = new OrdenDatos();
                    List<Orden> Pedidas = orden.getOrdenesPedido(idpedido);
                    dgvOrdenes.DataSource = Pedidas;
                    dgvOrdenes.DataBind();
                    Session["MesaAbierta"] = idmesa;
                    dgvOrdenes.Visible = true;

                    int cont = 0;

                    foreach (var item in Pedidas)
                    {
                        cont++;

                    }
                    if (cont == 0)
                    {
                        lblPedidoVacio.Visible = true;
                    }

                }
                               

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar el pedido: " + ex.Message);
                Session["Paginaorigen"] = "pedidos.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
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
                    menuItemDatos menuseleccionado = new menuItemDatos();
                    eliminada = orden.getOrden(idOrden);
                    eliminada.Menu.Stock = eliminada.Menu.Stock + eliminada.Cantidad;
                    menuseleccionado.ModificarItem(eliminada.Menu);

                    orden.EliminarOrden(idOrden);

                    
                    List<Orden> Pedidas = orden.getOrdenesPedido(eliminada.Pedido.Id);
                    dgvOrdenes.DataSource = Pedidas;
                    dgvOrdenes.DataBind();

                    int cont = 0;

                    foreach (var item in Pedidas)
                    {
                        cont++;

                    }
                    if (cont == 0)
                    {
                        lblPedidoVacio.Visible = true;
                    }
                    txtCantidad.Text = "";
                    lblMenu.Text = "Menu";
                    lblErrorCantidad.Visible = false;
                    lblOrdenModificada.Visible = false;
                    lblMenu.Visible = false;
                    txtCantidad.Visible = false;
                    btnModificarOrden.Visible = false;


                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al eliminar la orden: " + ex.Message);
                    Session["Paginaorigen"] = "pedidos.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
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
                    lblMenu.Visible = true;
                    txtCantidad.Visible = true;
                    btnModificarOrden.Visible = true;
                    lblOrdenModificada.Visible = true;


                }
                catch (Exception ex)
                {

                    Session.Add("error", "Error al obtener el nombre del menu de la orden seleccionada: " + ex.Message);
                    Session["Paginaorigen"] = "pedidos.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
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

                if (lblMenu.Text != "Menu" && validar.SoloNumeros(txtCantidad.Text) > 0 && validar.SoloNumeros(txtCantidad.Text) < cantMax)
                {
                    
                    selecionada.Cantidad = int.Parse(txtCantidad.Text);
                    orden.ModificarOrden(selecionada);

                    dgvOrdenes.DataSource = orden.getOrdenesPedido(selecionada.Pedido.Id);
                    dgvOrdenes.DataBind();

                    txtCantidad.Text = "";
                    lblMenu.Text = "Menu";
                    lblErrorCantidad.Visible = false;
                    lblOrdenModificada.Visible = false;
                    lblMenu.Visible = false;
                    txtCantidad.Visible = false;
                    btnModificarOrden.Visible = false;
                }
                else
                {
                    txtCantidad.Text = "";
                   
                    lblErrorCantidad.Visible = true;
                    lblErrorCantidad.Text = "Ingrese un numero mayor 0 y menor que " + cantMax + " .";
                }            

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al modificar la orden seleccionada: " + ex.Message);
                Session["Paginaorigen"] = "pedidos.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
            }                      
        }
               
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("mesas.aspx", false);
        }
    }
}
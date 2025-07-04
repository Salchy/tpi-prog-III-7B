using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
            lblComensales.Visible = false;
            txtCantidad.Visible = false;
            btnConfirmar.Visible = false;

        }

        protected void dgvMesas_asignadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMesa = Convert.ToInt32(e.CommandArgument);
            PedidoDatos pedido = new PedidoDatos();
            MesaDatos mesa= new MesaDatos();
            if (e.CommandName == "Abrir Pedido")
            {

                try
                {

                    lblComensales.Visible = true;
                    txtCantidad.Visible = true;
                    btnConfirmar.Visible = true;
                    Session["MesaAbierta"] = idMesa;

                }
                catch (Exception ex)
                {

                    Session.Add("error", "Error al abrir mesa: " + ex.Message);
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
                            mesa.ComensalesMesa(0, pedido.BuscarPedido(idPedido));



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
                    ////////////////////
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
                    ///////////////
                    
                }


                Usuario Mesero = (Usuario)Session["Usuario"];
                List<Mesa> mesasAsignadas;
                mesasAsignadas = mesa.getMesasAsignadas(Mesero.Id);
                dgvMesas_asignadas.DataSource = mesasAsignadas;
                dgvMesas_asignadas.DataBind();

                Session["MesasAsignadas"] = mesasAsignadas;
                lblComensales.Visible = false;
                txtCantidad.Visible = false;
                btnConfirmar.Visible = false;

            }
           
            
        }

        protected void dgvMesas_asignadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // busco el valor de los comensales
                    string valorColumna = e.Row.Cells[2].Text;

                    // Verificamos si el valor es distinto de cero
                    if (!string.IsNullOrEmpty(valorColumna) && Convert.ToInt32(valorColumna) != 0)
                    {
                        Button btn = (Button)e.Row.FindControl("btnAbrirMesa");
                        btn.Visible = false;
                        btn = (Button)e.Row.FindControl("btnCerraPedido");
                        btn.Visible = true;
                        btn = (Button)e.Row.FindControl("btnEliminarPedido");
                        btn.Visible = true;
                    }
                    else
                    {
                        Button btn = (Button)e.Row.FindControl("btnCerraPedido");
                        btn.Visible = false;
                        btn = (Button)e.Row.FindControl("btnEliminarPedido");
                        btn.Visible = false;
                        btn = (Button)e.Row.FindControl("btnAbrirMesa");
                        btn.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al estabbleser visibilidad de botones: " + ex.Message);
                Session["Paginaorigen"] = "mesas.Aspx";//guarda la pagina donde se origina el error para usarno en un boton de volveren la pagina de error
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
             try
             {
                    Validaciones validar = new Validaciones();
                    if ( validar.SoloNumeros(txtCantidad.Text) > 0 && validar.SoloNumeros(txtCantidad.Text) < 10)
                    {
                        PedidoDatos nuevo = new PedidoDatos();
                        MesaDatos mesa = new MesaDatos();
                        int idmesa = int.Parse(Session["MesaAbierta"].ToString());
                        int idpedido = nuevo.getIdPedidoFromIdMesa(idmesa);
                        if (idpedido == 0)
                        {
                           idpedido= nuevo.CrearPedido(idmesa);
                            
                        }
                       mesa.ComensalesMesa(int.Parse(txtCantidad.Text), nuevo.BuscarPedido(idpedido));

                       Response.Redirect("Ordenes.aspx", false);


                    }
                    else
                    {
                        txtCantidad.Text = "";
                        lblErrorCantidad.Visible = true;
                        lblErrorCantidad.Text = "Ingrese un numero mayor 0 y menor que 10.";
                    }




             }
            catch (Exception ex)
             {

                    Session.Add("error", "Error al definir comensales y crear el pedido: " + ex.Message);
                    Session["Paginaorigen"] = "mesas.Aspx";//guarda la pagina donde se origina el error para usarno en un boton de volveren la pagina de error
                    Response.Redirect("Error.aspx", false);

             }
                


        }
    }
}
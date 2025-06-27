using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dominio;
using System.Web.DynamicData;

namespace AppWeb
{
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasDatos categoria = new CategoriasDatos();
            SubCategoriaDatos subcat = new SubCategoriaDatos();
            try
            {
                if (!IsPostBack)
                {
                    List<SubCategoria> ListaSubcategorias = subcat.listarSubCategorias();
                    Session["ListaSubcategorias"] = ListaSubcategorias;
                    List<Categoria> lista = categoria.listarCategorias();
                    //List<Orden> OrdenesTomadas = new List<Orden>();
                    // Session["OrdenesTomadas"] = OrdenesTomadas;

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO

                    ddlMesaActiva.DataSource = ((List<Mesa>)Session["MesasAsignadas"]);
                    ddlMesaActiva.DataTextField = "NumeroMesa";
                    ddlMesaActiva.DataValueField = "IdMesa";
                    ddlMesaActiva.DataBind();
                    ddlMesaActiva.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminarOrden_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mesero.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlMesaActiva_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int idmesa = Convert.ToInt32(ddlMesaActiva.SelectedValue);
                if (idmesa == 0)
                {
                    return;
                }
                PedidoDatos pedidoDatos = new PedidoDatos();
                Pedido pedido = pedidoDatos.BuscarPedido(idmesa);
                if (pedido == null)
                {
                    pedidoDatos.CrearPedido(idmesa);
                }

                //OrdenDatos orden = new OrdenDatos();
                // dgvOrdenes.DataSource = orden.getOrdenesPedido(idpedido);
                //dgvOrdenes.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (IsPostBack)
                {
                    int id = Convert.ToInt32(ddlCategoria.SelectedValue);
                    ddlSubCategoria.DataSource = ((List<SubCategoria>)Session["ListaSubcategorias"]).FindAll(x => x.IdCategoriaPadre == id);
                    ddlSubCategoria.DataTextField = "Nombre";
                    ddlSubCategoria.DataValueField = "id";
                    ddlSubCategoria.DataBind();
                    ddlSubCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                menuItemDatos submenu = new menuItemDatos();
                int id = Convert.ToInt32(ddlSubCategoria.SelectedValue);
                Session.Add("Submenu", submenu.listarSubMenu(id));
                dgvMenu.DataSource = Session["Submenu"];


                dgvMenu.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtMenu_TextChanged(object sender, EventArgs e)
        {
            List<dominio.MenuItem> submenu = (List<dominio.MenuItem>)Session["Submenu"];

            List<dominio.MenuItem> MenuBuscado = submenu.FindAll(x => x.Nombre.ToUpper().Contains(txtMenu.Text.ToUpper()));
            dgvMenu.DataSource = MenuBuscado;
            dgvMenu.DataBind();
        }

        protected void dgvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddlCategoria.SelectedValue != "0" && ddlSubCategoria.SelectedValue != "0")
                {
                    menuItemDatos menu = new menuItemDatos();
                    dominio.MenuItem item = menu.GetItem(Convert.ToInt32(dgvMenu.SelectedDataKey.Value.ToString()));
                    lblMenu.Text = item.Nombre;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            menuItemDatos menu = new menuItemDatos();
            OrdenDatos orden = new OrdenDatos();
            PedidoDatos nuevo = new PedidoDatos();
            Orden orden1 = new Orden();
            Validaciones validar = new Validaciones();
            MesaDatos mesaselecionada = new MesaDatos();
            int cantMax = (mesaselecionada.getMesa(Convert.ToInt32(ddlMesaActiva.SelectedValue)).NumeroComensales) * 6;
            //la cantidad maxima de un menu que se toma en una orden es 6 veces el numero de comensales de la mesa



            try
            {
                if (ddlCategoria.SelectedValue != "0" && ddlSubCategoria.SelectedValue != "0" && validar.SoloNumeros(txtCantidad.Text) > 0 && validar.SoloNumeros(txtCantidad.Text) < cantMax)
                {
                    orden1.Menu = menu.GetItem(Convert.ToInt32(dgvMenu.SelectedDataKey.Value));
                    orden1.Estado = true;
                    orden1.Pedido = nuevo.BuscarPedido(nuevo.getIdPedidoFromIdMesa(Convert.ToInt32(ddlMesaActiva.SelectedValue)));


                    orden1.Cantidad = int.Parse(txtCantidad.Text);

                    orden.AgregarOrden(orden1);



                    dgvOrdenes.DataSource = orden.getOrdenesPedido(orden1.Pedido.Id);
                    dgvOrdenes.DataBind();

                    txtMenu.Text = "";
                    ddlCategoria.SelectedValue = "0";
                    txtCantidad.Text = "";
                    lblMenu.Text = "Menu";
                    ddlSubCategoria.SelectedValue = "0";

                }
                else
                {
                    txtCantidad.Text = "";
                }




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
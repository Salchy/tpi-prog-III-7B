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
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO

                    ddlMesaActiva.DataSource = ((List<Mesa>)Session["MesasAsignadas"]);
                    ddlMesaActiva.DataTextField = "numeroMesa";
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

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                if (IsPostBack)
                {

                    int id = int.Parse(ddlCategoria.SelectedValue);
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
                int id = int.Parse(ddlSubCategoria.SelectedValue);
                dgvMenu.DataSource = submenu.listarSubMenu(id);
                dgvMenu.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuItemDatos menu = new menuItemDatos();
            OrdenDatos orden = new OrdenDatos();
            PedidoDatos nuevo = new PedidoDatos();
            Orden orden1 = new Orden();

            orden1.Menu = menu.GetItem(int.Parse(dgvMenu.SelectedDataKey.Value.ToString()));
            orden1.Estado = true;
            orden1.Pedido = nuevo.BuscarPedido(nuevo.getIdPedidoMesaAbierta(int.Parse(ddlMesaActiva.SelectedValue)));


            orden1.Cantidad = 99;//tomarlo de la textbox

            orden.AgregarOrden(orden1);



            //((List<Orden>)Session["OrdenesTomadas"].Add(orden1);  
            //dgvOrdenes.DataSource= ((List<Orden>)Session["OrdenesTomadas"]).FindAll(x => x.Pedido.Id == orden1.Pedido.Id);

            dgvOrdenes.DataSource = orden.getOrdenesPedido(orden1.Pedido.Id);
            dgvOrdenes.DataBind();

        }

        protected void ddlMesaActiva_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                int id = int.Parse(ddlMesaActiva.SelectedValue);
                PedidoDatos nuevo = new PedidoDatos();
                if (nuevo.getIdPedidoMesaAbierta(id) == 0)
                {
                    nuevo.CrearPedido(id);

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



       


    }
}
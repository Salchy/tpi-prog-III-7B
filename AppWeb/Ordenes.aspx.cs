using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dominio;

namespace AppWeb
{
    public partial class Ordenes : System.Web.UI.Page
    {

        Orden nueva = new Orden();
        protected void Page_Load(object sender, EventArgs e)
        {
           CategoriasDatos categoria = new CategoriasDatos();
            SubCategoriaDatos subcat= new SubCategoriaDatos();
            

            try
            {
                if (!IsPostBack)
                {
                    List<SubCategoria> ListaSubcategorias = subcat.listarSubCategorias();
                    Session["ListaSubcategorias"] = ListaSubcategorias;
                    List<Categoria> lista = categoria.listarCategorias();
                                       
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
           /* menuItemDatos menu = new menuItemDatos();
            nueva.Menu= menu.GetItem(int.Parse(dgvMenu.SelectedDataKey.Value.ToString()));
            nueva.Estado = true;
            OrdenDatos orden = new OrdenDatos();
            orden.AgregarOrden(nueva);*/

        }

        protected void ddlMesaActiva_SelectedIndexChanged(object sender, EventArgs e)
        {

           /* try
            {
                 
                MesaDatos mesaactiva = new MesaDatos();
                    int id = int.Parse(ddlMesaActiva.SelectedValue);
                    PedidoDatos nuevo = new PedidoDatos();
                Pedido aux = new Pedido();
                if (nuevo.getIdPedidoMesaAbierta(id) == 0)
                    {
                        nuevo.CrearPedido(id);
                        
                    }
                aux= nuevo.BuscarPedido(nuevo.getIdPedidoMesaAbierta(id));
                nueva.Pedido = aux;
                           
            }
            catch (Exception ex)
            {

                throw ex;
            }*/
        }

      

        protected void txtCantiad_TextChanged(object sender, EventArgs e)
        {
            //nueva.Cantidad=int.Parse(txtCantidad.Text);
            nueva.Cantidad = 999;
        }

        protected void chkAgregar_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
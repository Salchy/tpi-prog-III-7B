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
using Microsoft.Ajax.Utilities;
using System.Runtime.InteropServices;

namespace AppWeb
{
    public partial class Ordenes : System.Web.UI.Page
    {
        public bool ver { get; set; }
        public bool ver2 { get; set; }
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

                    
                   

                    lblMesaSinPedido.Visible = false;
                    lblMesaSinPedido.Text = "";
                    btnVolver.Visible = false;
                    //lblMenuDisponible
                    //lblCategoria
                    //lblSubCategoria
                    //txtMenu



                    ver2 = false;

                    btnPedidos.Visible = false;

                    if ( Session["MesaAbierta"] != null && Session["MesaAbierta"].ToString() != "0")
                    {
                        ddlMesaActiva.SelectedValue = Session["MesaAbierta"].ToString();
                        try
                        {
                            
                            int idmesa = Convert.ToInt32(ddlMesaActiva.SelectedValue);
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
                                btnPedidos.Visible = false;
                                ver = false;                                                       

                            }
                            else
                            {

                                ver = true;
                                lblMesaSinPedido.Visible = false;
                                lblMesaSinPedido.Text = "";
                                btnVolver.Visible = false;
                                
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
                                    
                                    lblOrdenesPedido.Visible=false;
                                    btnPedidos.Visible = false;
                                }
                                else
                                {
                                    lblOrdenesPedido.Visible = true;
                                    btnPedidos.Visible = true;
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
                    

                    Session.Remove("Paginaorigen");//por si es secion quedo guardada alguna pagina distinta a la actual
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al cargar las mesas o las categorias del menu: " + ex.Message);
                Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
            }
        }


        protected void btnPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedidos.aspx", false);

            int idMesa = Convert.ToInt32(ddlMesaActiva.SelectedValue);
            Session["MesaAbierta"] = idMesa;
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

                    PedidoDatos nuevo = new PedidoDatos();
                    int idpedido = nuevo.getIdPedidoFromIdMesa(idmesa);
                    if (idpedido == 0)
                    {

                        lblMesaSinPedido.Visible = true;
                        lblMesaSinPedido.Text = "No existe ningun pedido abierto asignado a la mesa";
                        btnVolver.Visible = true;
                        btnPedidos.Visible = false;
                        ver = false;

                    }
                    else
                    {

                        ver = true;
                        lblMesaSinPedido.Visible = false;
                        lblMesaSinPedido.Text = "";
                        btnVolver.Visible = false;

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

                            lblOrdenesPedido.Visible = false;
                            btnPedidos.Visible = false;
                        }
                        else
                        {
                            lblOrdenesPedido.Visible = true;
                            btnPedidos.Visible = true;
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


        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ver = true;
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

                Session.Add("error", "Error al cargar las subcategorias del menu: " + ex.Message);
                Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
            }
        }



        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ver = true;
                menuItemDatos submenu = new menuItemDatos();
                int id = Convert.ToInt32(ddlSubCategoria.SelectedValue);
                Session.Add("Submenu", submenu.listarSubMenu(id));
                dgvMenu.DataSource = Session["Submenu"];
                dgvMenu.DataBind();

                txtMenu.ReadOnly = false;

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar los menues asociados a la subcategorias seleccionada: " + ex.Message);
                Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtMenu_TextChanged(object sender, EventArgs e)
        {
            ver = true;
            Validaciones val = new Validaciones();
            List<dominio.MenuItem> submenu = (List<dominio.MenuItem>)Session["Submenu"];

            if (val.validarTextos(txtMenu.Text) == false)
            {
                txtMenu.Text = "";
                lblErrorMenu.Visible = true;
                lblErrorMenu.Text = "Valor ingresado invalido, no se permiten caracteres especiales ni solo numeros";
            }
            else
            {
                lblErrorMenu.Visible = false;
                List<dominio.MenuItem> MenuBuscado = submenu.FindAll(x => x.Nombre.ToUpper().Contains(txtMenu.Text.ToUpper()));
                dgvMenu.DataSource = MenuBuscado;
                dgvMenu.DataBind();
            }
            
        }

        protected void dgvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ver = true;
                if (ddlCategoria.SelectedValue != "0" && ddlSubCategoria.SelectedValue != "0")
                {
                    menuItemDatos menu = new menuItemDatos();
                    dominio.MenuItem item = menu.GetItem(Convert.ToInt32(dgvMenu.SelectedDataKey.Value.ToString()));
                    lblMenu.Visible = true;
                    lblMenu.Text = item.Nombre;
                    ver2 = true;
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al obtener el nombre del menu seleccionado: " + ex.Message);
                Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usar lo en un boton de volver en la pagina de error
                Response.Redirect("Error.aspx", false);
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
            ver = true;

            //la cantidad maxima de un menu que se toma en una orden es 6 veces el numero de comensales de la mesa
            try
            {
                ver = true;
                int cantMax = (mesaselecionada.getMesa(Convert.ToInt32(ddlMesaActiva.SelectedValue)).NumeroComensales) * 6;
                if (lblMenu.Text != "Menu" && ddlCategoria.SelectedValue != "0" && ddlSubCategoria.SelectedValue != "0" && validar.SoloNumeros(txtCantidad.Text) > 0 && validar.SoloNumeros(txtCantidad.Text) < cantMax)
                {
                    
                    orden1.Menu = menu.GetItem(Convert.ToInt32(dgvMenu.SelectedDataKey.Value));
                    orden1.Estado = true;
                    orden1.Pedido = nuevo.BuscarPedido(nuevo.getIdPedidoFromIdMesa(Convert.ToInt32(ddlMesaActiva.SelectedValue)));


                    orden1.Cantidad = int.Parse(txtCantidad.Text);

                    orden.AgregarOrden(orden1);



                    dgvOrdenes.DataSource = orden.getOrdenesPedido(orden1.Pedido.Id);
                    dgvOrdenes.DataBind();

                    txtMenu.Text = "";
                    txtMenu.ReadOnly = true;
                    lblErrorMenu.Visible = false;
                    ddlCategoria.SelectedValue = "0";
                    txtCantidad.Text = "";
                    lblErrorCantidad.Visible = false;
                    lblMenu.Text = "Menu";
                    ddlSubCategoria.SelectedValue = "0";
                    ver2 = false;
                    lblOrdenesPedido.Visible = true; 
                    btnPedidos.Visible = true;
                    

                }
                else
                {
                    txtCantidad.Text = "";
                    lblErrorCantidad.Visible = true;
                    lblErrorCantidad.Text = "Ingrese un numero mayor 0 y menor que " + cantMax + " .";
                    ver2 = true;

                }




            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar la orden: " + ex.Message);
                Session["Paginaorigen"] = "Ordenes.Aspx";//guarda la pagina donde se origina el error para usarno en un boton de volveren la pagina de error
                Response.Redirect("Error.aspx", false);
              
            }
        }

        

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("mesas.aspx", false);
        }

        
    }
}
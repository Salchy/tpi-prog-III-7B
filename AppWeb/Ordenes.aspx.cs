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
        public bool AgregarOrden { get; set; }
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

       
    }
}
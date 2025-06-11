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
    public partial class formItemMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriasDatos lista = new CategoriasDatos();
                ddlCategoria.DataSource = lista.listarCategorias();
                ddlCategoria.DataTextField = "Nombre";     // VISUAL
                ddlCategoria.DataValueField = "Id";        // QUE SE GUARDA
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
            }
        }
        
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int idCategoriaPadre = int.Parse(ddlCategoria.SelectedValue);

            SubCategoriaDatos datos = new SubCategoriaDatos();

            List<SubCategoria> todas = datos.listarSubCategorias();

            List<SubCategoria> filtradas = todas.Where(x => x.IdCategoriaPadre == idCategoriaPadre).ToList();

            ddlSubcategoria.DataSource = filtradas;
            ddlSubcategoria.DataTextField = "Nombre";
            ddlSubcategoria.DataValueField = "Id";
            ddlSubcategoria.DataBind();

            ddlSubcategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                dominio.MenuItem nuevo = new dominio.MenuItem();
                menuItemDatos manager = new menuItemDatos();


                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.SubCategoria = new SubCategoria();
                nuevo.SubCategoria.Id = int.Parse(ddlSubcategoria.SelectedValue);


                manager.Agregar(nuevo);


                Response.Redirect("gerenciaMenu.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
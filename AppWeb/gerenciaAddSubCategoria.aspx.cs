using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace AppWeb
{
    public partial class gerenciaAddSubCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CategoriasDatos lista = new CategoriasDatos();
                    List<Categoria> todasCategorias = lista.listarCategorias();
                    List<Categoria> activas = todasCategorias.Where(x => x.Estado == true).ToList();

                    ddlCategoriaPadre.DataSource = activas;
                    ddlCategoriaPadre.DataTextField = "Nombre";     // VISUAL
                    ddlCategoriaPadre.DataValueField = "Id";        // QUE SE GUARDA
                    ddlCategoriaPadre.DataBind();

                    ddlCategoriaPadre.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        SubCategoriaDatos manager = new SubCategoriaDatos();

                        SubCategoria sub = manager.GetSubCategoria(id);
                        txtNombre.Text = sub.Nombre;
                        ddlCategoriaPadre.SelectedValue = sub.IdCategoriaPadre.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cargar las sub categorías: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnVolverSubCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaSubCategorias.aspx",false);
        }

        protected void btnAceptarSubCate_Click(object sender, EventArgs e)
        {
            try
            {
                SubCategoria nuevo = new SubCategoria();
                SubCategoriaDatos manager = new SubCategoriaDatos();

                nuevo.Nombre = txtNombre.Text;
                nuevo.IdCategoriaPadre = int.Parse(ddlCategoriaPadre.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    manager.ModificarSub(nuevo);
                }
                else
                {
                    manager.Agregar(nuevo);
                }
                Response.Redirect("gerenciaSubCategorias.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al agregar/modificar la sub categoría: " + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class gerenciaAddSubCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasDatos lista = new CategoriasDatos();
            ddlCategoriaPadre.DataSource = lista.listarCategorias();
            ddlCategoriaPadre.DataTextField = "Nombre";     // VISUAL
            ddlCategoriaPadre.DataValueField = "Id";        // QUE SE GUARDA
            ddlCategoriaPadre.DataBind();

            ddlCategoriaPadre.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO

        }

        protected void btnVolverSubCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaSubCategorias.aspx");
        }
    }
}
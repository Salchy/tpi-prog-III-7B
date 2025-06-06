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
            CategoriasDatos lista = new CategoriasDatos();
            ddlCategoria.DataSource = lista.listarCategorias();
            ddlCategoria.DataTextField = "Nombre";     // VISUAL
            ddlCategoria.DataValueField = "Id";        // QUE SE GUARDA
            ddlCategoria.DataBind();


            ddlCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO

        }

       
    }
}
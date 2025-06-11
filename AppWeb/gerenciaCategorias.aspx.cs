using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class gerenciaCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriasDatos categorias = new CategoriasDatos();
                dgvCategorias.DataSource = categorias.listarCategorias();
                
                dgvCategorias.DataBind();
            }
        }


        protected void btnAgregarCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaAddCategoria.aspx");
        }
    }
}
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

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            


                int id = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("gerenciaAddCategoria.aspx?id=" + id);
                }
                else if (e.CommandName == "Estado")
                {
                    CategoriasDatos manager = new CategoriasDatos();
                    Categoria cate = manager.GetCategoria(id);
                    cate.Estado = !cate.Estado;

                    manager.habilitarInhabilitarCategoria(id, cate.Estado);

                    dgvCategorias.DataSource = manager.listarCategorias();
                    dgvCategorias.DataBind();
                }
            
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;

            CategoriasDatos manager = new CategoriasDatos();
            dgvCategorias.DataSource = manager.listarCategorias();
            dgvCategorias.DataBind();
        }
    }
}

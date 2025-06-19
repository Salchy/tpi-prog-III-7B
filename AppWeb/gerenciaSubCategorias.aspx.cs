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
    public partial class gerenciaSubCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubCategoriaDatos subcate = new SubCategoriaDatos();
                dgvSubCate.DataSource = subcate.listarSubCategorias();
                dgvSubCate.DataBind();
            }
        }

        protected void dgvSubCate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSubCate.PageIndex = e.NewPageIndex;

            SubCategoriaDatos manager = new SubCategoriaDatos();
            dgvSubCate.DataSource = manager.listarSubCategorias();
            dgvSubCate.DataBind();
        }

        protected void btnAgregarSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaAddSubCategoria.aspx");
        }

        protected void dgvSubCate_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
            {
                Response.Redirect("gerenciaAddSubCategoria.aspx?id=" + id);
            }
            else if (e.CommandName == "Estado")
            {
                SubCategoriaDatos manager = new SubCategoriaDatos();
                SubCategoria sub = manager.GetSubCategoria(id);
                sub.Estado = !sub.Estado;

                manager.habilitarInhabilitarSubCategoria(id, sub.Estado);

                dgvSubCate.DataSource = manager.listarSubCategorias();
                dgvSubCate.DataBind();
            }
        }
    }
}

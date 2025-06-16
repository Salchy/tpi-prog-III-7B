using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

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
            if (e.CommandName == "Editar" || e.CommandName == "Borrar")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                int id = int.Parse(dgvSubCate.DataKeys[index].Value.ToString());

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("gerenciaAddSubCategoria.aspx?id=" + id);
                }
                else if (e.CommandName == "Borrar")
                {
                    //Response.Redirect("gerenciaAddCategoria.aspx");
                }
            }
        }
    }
}
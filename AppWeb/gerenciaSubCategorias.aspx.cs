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
                dgvSubCate.Columns[0].Visible = false; 
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
    }
}
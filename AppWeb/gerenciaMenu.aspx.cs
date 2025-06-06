using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace AppWeb
{
    public partial class gerenciaMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                menuItemDatos menu = new menuItemDatos();
                dgvMenu.DataSource = menu.listarMenu();
                //dgvMenu.
                dgvMenu.DataBind();
            }
            
        }

        protected void dgvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMenu.PageIndex = e.NewPageIndex;

            menuItemDatos menu = new menuItemDatos();
            dgvMenu.DataSource = menu.listarMenu();
            dgvMenu.DataBind();
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formItemMenu.aspx", false);
        }

        protected void dgvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }



}
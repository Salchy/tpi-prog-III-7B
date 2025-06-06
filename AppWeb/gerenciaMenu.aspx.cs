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
            menuItemDatos menu = new menuItemDatos();
            dgvMenu.DataSource = menu.listarMenu();
            //dgvMenu.
            dgvMenu.DataBind();
        }
    }
}
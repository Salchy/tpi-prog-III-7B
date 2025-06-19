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
    public partial class gerenciaMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("login.aspx", false);
                return;
            }
            if (((Usuario)Session["Usuario"]).NivelUsuario > 1)
            {
                // No tiene permiso a esta pantalla
            }
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



        protected void dgvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString());


            if (e.CommandName == "Editar")
            {
                Response.Redirect("formItemMenu.aspx?id=" + id);
            }
            
            else if (e.CommandName == "Estado")
            {

                menuItemDatos manager = new menuItemDatos();
                dominio.MenuItem menu = manager.GetItem(id);
                menu.Estado = !menu.Estado;

                manager.habilitarInhabilitarMenu(id, menu.Estado);

                dgvMenu.DataSource = manager.listarMenu();
                dgvMenu.DataBind();
                


            }
        }
    }



}
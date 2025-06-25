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
            if (!IsPostBack)
            {

                try
                {
                    menuItemDatos menu = new menuItemDatos();
                    dgvMenu.DataSource = menu.filtrar("Ítem","","Activo");
                    dgvMenu.DataBind();


                }
                catch (Exception ex)
                {

                    throw ex;
                }
               
            }
        }

        protected void dgvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvMenu.PageIndex = e.NewPageIndex;

                menuItemDatos manager = new menuItemDatos();
                string campo = ddlCampo.SelectedValue;
                string filtro = txtFiltroAvanzado.Text;
                string estado = ddlEstado.SelectedValue;

                // Volver a aplicar el filtro actual
                dgvMenu.DataSource = manager.filtrar(campo, filtro, estado);
                dgvMenu.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                try
                {
                    menuItemDatos manager = new menuItemDatos();
                    dominio.MenuItem menu = manager.GetItem(id);
                    menu.Estado = !menu.Estado;

                    manager.habilitarInhabilitarMenu(id, menu.Estado);

                    string campo = ddlCampo.SelectedValue;
                    string filtro = txtFiltroAvanzado.Text;
                    string estado = ddlEstado.SelectedValue;

                    // Volver a aplicar el filtro actual
                    dgvMenu.DataSource = manager.filtrar(campo, filtro, estado);
                    dgvMenu.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                menuItemDatos manager = new menuItemDatos();
                dgvMenu.DataSource = manager.filtrar(ddlCampo.SelectedItem.ToString(),
                  txtFiltroAvanzado.Text, ddlEstado.SelectedItem.ToString());
                dgvMenu.DataBind();
                    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
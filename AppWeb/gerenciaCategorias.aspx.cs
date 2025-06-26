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
                try
                {
                    CategoriasDatos manager = new CategoriasDatos();
                    dgvCategorias.DataSource = manager.FiltrarCategorias(
                      "", "Activo");
                    dgvCategorias.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cargar las categorías." + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            }
        }

        protected void btnAgregarCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaAddCategoria.aspx",false);
        }

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
            {
                Response.Redirect("gerenciaAddCategoria.aspx?id=" + id,false);
            }
            else if (e.CommandName == "Estado")
            {
                try
                {
                    CategoriasDatos manager = new CategoriasDatos();
                    Categoria cate = manager.GetCategoria(id);
                    cate.Estado = !cate.Estado;

                    manager.habilitarInhabilitarCategoria(id, cate.Estado);

                    
                    dgvCategorias.DataSource = manager.FiltrarCategorias(
                      txtFiltroAvanzado.Text, ddlEstado.SelectedValue);
                    dgvCategorias.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvCategorias.PageIndex = e.NewPageIndex;

                CategoriasDatos manager = new CategoriasDatos();
                dgvCategorias.DataSource = manager.FiltrarCategorias(
                  txtFiltroAvanzado.Text, ddlEstado.SelectedValue);
                dgvCategorias.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnBuscarCategorias_Click(object sender, EventArgs e)
        {
            try
            {

                CategoriasDatos manager = new CategoriasDatos();
                dgvCategorias.DataSource = manager.FiltrarCategorias(
                  txtFiltroAvanzado.Text, ddlEstado.SelectedValue);
                dgvCategorias.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriasDatos manager = new CategoriasDatos();
                txtFiltroAvanzado.Text = "";
                ddlEstado.SelectedValue = "Activo";
                

                dgvCategorias.DataSource = manager.FiltrarCategorias(txtFiltroAvanzado.Text, "Activo");
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}

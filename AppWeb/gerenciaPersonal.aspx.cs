using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Data;

namespace AppWeb
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        UsuarioDatos UsuarioDatos = new UsuarioDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("login.aspx", false);
            //    return;
            //}
            if (((Usuario)Session["Usuario"]).NivelUsuario > 1)
            {
                // No tiene permiso a esta pantalla
                //Session.Add("error", ex.ToString());
                Session.Add("error", "Mensaje de error");


                return;
            }
            if (IsPostBack)
            {
                return;
            }

            dataGridEmpleados.DataSource = UsuarioDatos.getUsuarios();
            dataGridEmpleados.DataBind();
        }

        protected void dataGridEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow fila = dataGridEmpleados.Rows[e.NewEditIndex];
            int id = fila.Cells[0]
            Response.Redirect("gerenciaAddEmpleado.aspx?id=" + id);
        }

        protected void dataGridEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(dataGridEmpleados.DataKeys[e.RowIndex].Value.ToString());
        }

        protected void addEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaAddEmpleado.aspx");
        }

        protected void dataGridEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridEmpleados.PageIndex = e.NewPageIndex;
            dataGridEmpleados.DataBind();
        }
    }
}
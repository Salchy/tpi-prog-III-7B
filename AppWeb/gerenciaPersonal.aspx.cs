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
                Response.Redirect("Error.aspx");
                return;
            }
            if (IsPostBack)
            {
                return;
            }

            dataGridEmpleados.DataSource = UsuarioDatos.getUsuarios();
            dataGridEmpleados.DataBind();
        }

        protected void dataGridEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify" || e.CommandName == "Delete")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                int id = int.Parse(dataGridEmpleados.Rows[index].Cells[0].Text);

                if (e.CommandName == "Modify")
                {
                    Response.Redirect("gerenciaAddEmpleado.aspx?id=" + id);
                }
                else if (e.CommandName == "Delete")
                {
                    Response.Redirect("gerenciaAddEmpleado.aspx");
                }
            }
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
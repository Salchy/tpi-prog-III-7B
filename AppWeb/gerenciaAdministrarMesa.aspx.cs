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
    public partial class gerenciaAdministrarMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null) // Es una modificación
                {
                    lblTitle.Text = "Modificar Empleado";
                    cancelBtn.Text = "Cancelar Modificación";
                    regUserBTN.Text = "Modificar Empleado";

                    int id = int.Parse(Request.QueryString["id"].ToString());
                    try
                    {
                        UsuarioDatos userDB = new UsuarioDatos();
                        List<Usuario> empleados = userDB.getUsuarios();
                        foreach (Usuario empleado in empleados)
                        {
                            listBoxEmpleados.Items.Add(new ListItem(empleado.getFullName(), empleado.Id.ToString()));
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", "Error al cargar los empleados: " + ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAcceptModify_Click(object sender, EventArgs e)
        {

        }
    }
}
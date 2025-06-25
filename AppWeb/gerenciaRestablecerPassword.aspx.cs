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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                return;
            }
            int id = int.Parse(Request.QueryString["id"].ToString());
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Response.Write("<script>alert('Por favor, complete el campo de contraseña.');</script>");
                return;
            }
            try
            {
                UsuarioDatos UsuarioDatos = new UsuarioDatos();
                if (UsuarioDatos.getUsuario(id) == null)
                {
                    Response.Write("<script>alert('El usuario no existe.');</script>");
                    return;
                }
                UsuarioDatos.setUserPassword(id, txtPassword.Text);
                Response.Redirect("gerenciaPersonal.aspx", false);
            }
            catch (Exception)
            {
                Session.Add("error", "Error al restablecer la contraseña del usuario.");
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}
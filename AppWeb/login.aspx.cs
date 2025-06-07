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
    public partial class WebForm2 : System.Web.UI.Page
    {
        UsuarioDatos UserDB = new UsuarioDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dni = txtBarDNI.Text;
            string password = txtBarPassword.Text;
            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Por favor, complete todos los campos.');</script>");
                return;
            }
            Usuario user = UserDB.getUsuario(dni, password);
            if (user == null)
            {
                Response.Write("<script>alert('Usuario o contraseña incorrecta, ¿Olvidaste tu contraseña?.');</script>");
                return;
            }
            Session["Usuario"] = user; // Guardo en sesión el usuario que hizo login

            if (user.NivelUsuario == 1)
                Response.Redirect("Gerencia.aspx");
            else
                Response.Redirect("Mesero.aspx");
        }
    }
}
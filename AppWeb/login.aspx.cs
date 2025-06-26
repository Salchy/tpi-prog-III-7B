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
            if (Session["Usuario"] != null)
            {
                Usuario user = (Usuario)Session["Usuario"];
                if (user.NivelUsuario == 0 || user.NivelUsuario == 1)
                {
                    Response.Redirect("Gerencia.aspx");
                }
                else if (user.NivelUsuario == 2)
                {
                    Response.Redirect("Mesero.aspx");
                }
            }
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
            if (!user.Estado)
            {
                Response.Write("<script>alert('El usuario está deshabilitado.');</script>");
                return;
            }
            Session["Usuario"] = user; // Guardo en sesión el usuario que hizo login

            switch (user.NivelUsuario)
            {
                case 0:
                    Response.Redirect("Gerencia.aspx");
                    break;
                case 1:
                    Response.Redirect("Gerencia.aspx");
                    break;
                case 2:
                    Response.Redirect("Mesero.aspx");
                    break;
                default:
                    Response.Redirect("Mesero.aspx");
                    return;
            }
        }
    }
}
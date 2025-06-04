using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace AppWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
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
            // Validar inicio de sesion y bla, redirigir a una pagina u otra dependiendo el perfil

            // Hardcodding, luego se quita
            Usuario usuario = new Usuario("12345678", "Leandro", new Perfil(1, "Gerencia", 0));

            if (usuario.GetPerfil().Nivel == 1)
                Response.Redirect("Gerencia.aspx");
            else
                Response.Redirect("Mesero.aspx");
        }
    }
}
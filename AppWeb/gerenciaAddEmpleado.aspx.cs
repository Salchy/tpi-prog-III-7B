using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace AppWeb
{
    public partial class gerenciaPersonal : System.Web.UI.Page
    {
        private UsuarioDatos userDB = new UsuarioDatos();
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
            }
            if (IsPostBack)
            {
                return;
            }
            dropDownPerfil.Items.Add(new ListItem("Mesero", "2"));
            dropDownPerfil.Items.Add(new ListItem("Gerente", "1"));

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                Usuario usuario = userDB.getUsuario(id);
                if (usuario == null)
                {
                    Response.Write("El usuario no existe.");
                    return;
                }
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDNI.Text = usuario.Dni;
                dropDownPerfil.SelectedValue = usuario.NivelUsuario.ToString();
            }
        }
        protected void registrarUsuario(object sender, EventArgs e)
        {
            string userName = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(userName))
            {
                Response.Write("Debes ingresar un Nombre.");
                return;
            }
            string userSurName = txtApellido.Text;
            if (string.IsNullOrWhiteSpace(userSurName))
            {
                Response.Write("Debes ingresar un Apellido.");
                return;
            }
            string userDNI = txtDNI.Text;
            if (string.IsNullOrWhiteSpace(userDNI))
            {
                Response.Write("Debes ingresar un DNI.");
                return;
            }
            if (!esNumerico(userDNI))
            {
                Response.Write("Debes ingresar un DNI válido.");
                return;
            }
            if (!dniValido(userDNI))
            {
                Response.Write("Debes ingresar un DNI válido.");
                return;
            }
            
            Usuario nuevoUsuario = new Usuario(0, userDNI, userName, userSurName, int.Parse(dropDownPerfil.SelectedValue));
            int nuevoUsuarioID = userDB.registrarUsuario(nuevoUsuario, userDNI);
            if (nuevoUsuarioID > 0) {
                // Notificacion de usuario creado con éxito.
            }
        }

        private bool esNumerico(string str)
        {
            bool numerico = true;
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    numerico = false;
                    break;
                }
            }
            return numerico;
        }

        private bool dniValido(string str) // Sólo compara que no sea menor a 7 cifras, y que no sea mayor a 9 cifras
        {
            if (str.Length < 7 || str.Length > 9)
            {
                return false;
            }
            return true;
        }
    }
}
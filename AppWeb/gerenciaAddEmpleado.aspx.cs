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
            if (IsPostBack)
            {
                return;
            }
            dropDownPerfil.Items.Add(new ListItem("Mesero", "2"));
            dropDownPerfil.Items.Add(new ListItem("Gerente", "1"));

            if (Request.QueryString["id"] != null) // Es una modificación
            {
                lblTitle.Text = "Modificar Empleado";
                cancelBtn.Text = "Cancelar Modificación";
                regUserBTN.Text = "Modificar Empleado";

                int id = int.Parse(Request.QueryString["id"].ToString());
                try
                {
                    Usuario usuario = userDB.getUsuario(id);
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtDNI.Text = usuario.Dni;
                    dropDownPerfil.SelectedValue = usuario.NivelUsuario.ToString();
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cargar el usuario: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            }
        }
        protected void btnRegistrarUsuario(object sender, EventArgs e)
        {
            string userName = txtNombre.Text.Trim();
            string userSurName = txtApellido.Text.Trim();
            string userDNI = txtDNI.Text.Trim();
            if (!validaciones(userName, userSurName, userDNI))
            {
                return;
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                try
                {
                    Usuario usuario = userDB.getUsuario(id);
                    usuario.Nombre = userName;
                    usuario.Apellido = userSurName;
                    //usuario.Dni = userDNI;
                    usuario.NivelUsuario = int.Parse(dropDownPerfil.SelectedValue);
                    if (userDB.modificarUsuario(usuario))
                    {
                        // Notificar que se modificó correctamente
                        Response.Redirect("gerenciaPersonal.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error " + lblTitle.Text + " el usuario: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                try
                {
                    registrarUsuario(userName, userSurName, userDNI);
                    // Notificiar que el usuario se agregó correctamente
                    Response.Redirect("gerenciaPersonal.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al registrar el usuario: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        private bool validaciones(string userName, string userSurName, string userDNI)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                mostrarMensaje("Nombre inválido", "ERROR: Debes ingresar un nombre para el empleado.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(userSurName))
            {
                mostrarMensaje("Apellido inválido", "ERROR: Debes ingresar un apellido para el empleado.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(userDNI))
            {
                mostrarMensaje("DNI inválido", "ERROR: Debes ingresar un DNI asociado el empleado.");
                return false;
            }
            if (!esNumerico(userDNI))
            {
                mostrarMensaje("DNI inválido", "ERROR: Debes ingresar un DNI válido.");
                return false;
            }
            if (!dniValido(userDNI))
            {
                mostrarMensaje("DNI inválido", "ERROR: Debes ingresar un DNI válido.");
                return false;
            }
            UsuarioDatos userDatos = new UsuarioDatos();
            if (userDatos.getUsuario(userDNI) != null)
            {
                mostrarMensaje("DNI ya registrado", "ERROR: El DNI ingresado ya está registrado en el sistema.");
                return false;
            }
            return true;
        }
        private bool registrarUsuario(string userName, string userSurName, string userDNI)
        {
            Usuario nuevoUsuario = new Usuario(0, userDNI, userName, userSurName, int.Parse(dropDownPerfil.SelectedValue));
            try
            {
                int nuevoUsuarioID = userDB.registrarUsuario(nuevoUsuario, userDNI);
                if (nuevoUsuarioID > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
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

        private bool dniValido(string str) // Sólo compara que no sea menor a 6 cifras, y que no sea mayor a 9 cifras
        {
            if (str.Length < 6 || str.Length > 9)
            {
                return false;
            }
            return true;
        }

        protected void cancelRegistrarUsuario(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaPersonal.aspx");
        }

        // todo: Hacer un método para mostrar mensajes de notificaciones
        private void mostrarMensaje(string title, string msg)
        {
            literal.Text = "<div class='modal-dialog modal-dialog-centered'>" + title + "</div>" +
                "<div class='modal-dialog modal-dialog-centered modal-dialog-scrollable'>" + msg + "</div>";
        }
    }
}
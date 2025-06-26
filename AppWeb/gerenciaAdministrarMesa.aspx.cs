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
        MesaDatos MesaDatos = new MesaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEmpleados();
                if (Request.QueryString["id"] != null) // Es una modificación
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    lblTitle.Text = "Modificar una mesa";
                    try
                    {
                        Mesa mesa = MesaDatos.getMesa(id);
                        txtNombreMesa.Text = mesa.NumeroMesa;

                        foreach (ListItem item in listBoxEmpleados.Items)
                        {
                            if (item.Value == mesa.MeseroAsignado.Id.ToString())
                            {
                                item.Selected = true;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", "Error al cargar la mesa: " + ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        private void cargarEmpleados()
        {
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaMesas.aspx");
        }
        private bool crearMesa(string nombreMesa, int idMeseroAsignado)
        {
            try
            {
                if (MesaDatos.crearMesa(nombreMesa, idMeseroAsignado))
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

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string nombreMesa = txtNombreMesa.Text.Trim(); // Trim quita los espacios del principio y final
            if (string.IsNullOrEmpty(nombreMesa))
            {
                Session.Add("error", "El nombre de la mesa no puede estar vacío.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            int idMeseroAsignado = int.Parse(listBoxEmpleados.SelectedValue);

            // Logica de añadir / modificar mesa
            if (Request.QueryString["id"] != null) // Es una modificación
            {

            }
            else
            {
                try
                {
                    bool success = crearMesa(nombreMesa, idMeseroAsignado);
                    if (success)
                    {
                        Response.Redirect("gerenciaMesas.aspx");
                    }
                }
                catch (Exception)
                {
                    Session.Add("error", "Error al crear la mesa.");
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}
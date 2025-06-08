using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWeb
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             MesaDatos mesaDatos = new MesaDatos();

             /*Usuario Mesero = (Usuario) Session["Usuario"];
             dgvMesas_asignadas.DataSource = mesaDatos.getMesasAsignadas(Mesero.Id);//recuperar el id del usuario cuando se loguea
             dgvMesas_asignadas.DataBind();*/
           
            dgvMesas_asignadas.DataSource = mesaDatos.getMesasAsignadas(1);//recuperar el id del usuario cuando se loguea
            dgvMesas_asignadas.DataBind();

        }

        protected void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ordenes.aspx", false);
        }
    }
}
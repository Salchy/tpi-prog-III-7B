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
    public partial class gerenciaAddCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptarCate_Click(object sender, EventArgs e)
        {

            try
            {
                Categoria nuevo = new Categoria();
                CategoriasDatos manager = new CategoriasDatos();


                nuevo.Nombre = txtNombre.Text;      

                manager.Agregar(nuevo);


                Response.Redirect("gerenciaCategorias.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
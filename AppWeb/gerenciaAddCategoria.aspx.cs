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
            if(IsPostBack)
            {
                return;
            }
            
              if(Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    CategoriasDatos manager = new CategoriasDatos();

                    Categoria cate = manager.GetCategoria(id);
                    txtNombre.Text = cate.Nombre;
                    
               }
            
        }

        protected void btnAceptarCate_Click(object sender, EventArgs e)
        {

            try
            {
                Categoria nuevo = new Categoria();
                CategoriasDatos manager = new CategoriasDatos();


                nuevo.Nombre = txtNombre.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    manager.ModificarItem(nuevo);
                }
                else
                {
                    manager.Agregar(nuevo);
                }

                Response.Redirect("gerenciaCategorias.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void btnVolverCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaCategorias.aspx");
        }
    }
}
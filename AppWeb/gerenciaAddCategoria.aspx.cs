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
            if (IsPostBack)
            {
                return;
            }

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                CategoriasDatos manager = new CategoriasDatos();

                try
                {
                    Categoria cate = manager.GetCategoria(id);
                    txtNombre.Text = cate.Nombre;
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cargar la categoría: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnAceptarCate_Click(object sender, EventArgs e)
        {

            try
            {
                Categoria nuevo = new Categoria();
                CategoriasDatos manager = new CategoriasDatos();
                Validaciones val = new Validaciones();
                bool IngresoValido = true;

                if (val.validarTextos(txtNombre.Text) == false)
                {
                    lblErrorCategoria.Visible = true;
                    lblErrorCategoria.Text = "No puede estar vacio, no se permiten caracteres especiales ni solo numeros";
                    IngresoValido = false;
                }
                else
                {
                    lblErrorCategoria.Visible = false;
                }

                List<Categoria> categorias = manager.listarCategorias();


                Categoria cate = null;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    cate = manager.GetCategoria(id);
                }
                    

                foreach (var item in categorias)
                {
                    if (item.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower() && (cate==null || item.Id != cate.Id))
                    {
                        lblErrorCategoria.Visible = true;
                        lblErrorCategoria.Text = "Categoria repetido";
                        IngresoValido = false;
                        break;
                    }
                }


                if (IngresoValido == false)
                {
                    return;
                }

                nuevo.Nombre = txtNombre.Text.Trim();

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    manager.ModificarItem(nuevo);
                }
                else
                {
                    manager.Agregar(nuevo);
                }
                Response.Redirect("gerenciaCategorias.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al agregar/modificar la categoría: " + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnVolverCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaCategorias.aspx",false);
        }
    }
}
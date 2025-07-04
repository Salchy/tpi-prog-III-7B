﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace AppWeb
{
    public partial class gerenciaAddSubCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioDatos.GetLevel(Session["Usuario"]) > 1)
            {
                Session.Add("error", "Mensaje de error");
                Response.Redirect("Error.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                try
                {
                    CategoriasDatos lista = new CategoriasDatos();
                    List<Categoria> todasCategorias = lista.listarCategorias();
                  

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        SubCategoriaDatos manager = new SubCategoriaDatos();
                        btnAceptarSubCate.Text = "Modificar Subcategoria";
                        lblTitle.Text = "Modificar Subcategoria existente";

                        SubCategoria sub = manager.GetSubCategoria(id);
                        txtNombre.Text = sub.Nombre;


                        // cuando estoy modificando me traigo las cateegorias activas mas la propia si esta inactiva.

                        List<Categoria> ActivasMasActual = todasCategorias.Where(c => c.Estado == true || c.Id == sub.IdCategoriaPadre).ToList();

                        foreach (var item in ActivasMasActual)
                        {
                            if (item.Id == sub.IdCategoriaPadre)
                            {
                                if (item.Estado == false)
                                {
                                    item.Nombre += " (Inactiva)";
                                }
                            }
                        }


                        ddlCategoriaPadre.DataSource = ActivasMasActual;
                        ddlCategoriaPadre.DataTextField = "Nombre";
                        ddlCategoriaPadre.DataValueField = "Id";
                        ddlCategoriaPadre.DataBind();                   

                        ddlCategoriaPadre.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
                        ddlCategoriaPadre.SelectedValue = sub.IdCategoriaPadre.ToString();
                    } else
                    {

                        // cuando agrego solo me traigo las categorias activas
                        List<Categoria> activas = todasCategorias.Where(x => x.Estado == true).ToList();

                        ddlCategoriaPadre.DataSource = activas;
                        ddlCategoriaPadre.DataTextField = "Nombre";     // VISUAL
                        ddlCategoriaPadre.DataValueField = "Id";        // QUE SE GUARDA
                        ddlCategoriaPadre.DataBind();

                        ddlCategoriaPadre.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al cargar las sub categorías: " + ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnVolverSubCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaSubCategorias.aspx",false);
        }

        protected void btnAceptarSubCate_Click(object sender, EventArgs e)
        {
            try
            {
                SubCategoria nuevo = new SubCategoria();
                SubCategoriaDatos manager = new SubCategoriaDatos();
                Validaciones val = new Validaciones();
                bool IngresoValido = true;

                if(val.validarTextos(txtNombre.Text) == false)
                {
                    lblErrorSubCategoria.Visible = true;
                    lblErrorSubCategoria.Text = "No puede estar vacio, no se permiten caracteres especiales ni solo numeros";
                    IngresoValido = false;
                } else
                {
                    lblErrorSubCategoria.Visible = false;
                }

                List<SubCategoria> subcategorias = manager.listarSubCategorias();


                SubCategoria Subcate = null;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    Subcate = manager.GetSubCategoria(id);
                }

                foreach (var item in subcategorias)
                {
                    if(item.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower() && (Subcate == null || item.Id != Subcate.Id))
                    {
                        lblErrorSubCategoria.Visible = true;
                        lblErrorSubCategoria.Text = "Subcategoria repetida";
                        IngresoValido = false;
                        break;
                    }
                }


                if(ddlCategoriaPadre.SelectedValue == "0")
                {
                    lblErrorDDL.Visible = true;
                    lblErrorDDL.Text = "Debe seleccionar una categoria";
                    IngresoValido = false;
                } else
                {
                    lblErrorDDL.Visible = false;

                }


                if (IngresoValido == false)
                {
                    return;
                }


                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.IdCategoriaPadre = int.Parse(ddlCategoriaPadre.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    manager.ModificarSub(nuevo);
                }
                else
                {
                    manager.Agregar(nuevo);
                }
                Response.Redirect("gerenciaSubCategorias.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al agregar/modificar la sub categoría: " + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace AppWeb
{
    public partial class formItemMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriasDatos lista = new CategoriasDatos();

                List<Categoria> todasCategorias = lista.listarCategorias();
                List <Categoria> activas = todasCategorias.Where(x => x.Estado == true).ToList();

                ddlCategoria.DataSource = activas;
                ddlCategoria.DataTextField = "Nombre";     // VISUAL
                ddlCategoria.DataValueField = "Id";        // QUE SE GUARDA
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO


                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    menuItemDatos manager = new menuItemDatos();
                    dominio.MenuItem seleccionado = manager.GetItem(id);
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtStock.Text = seleccionado.Stock.ToString();

                    // NECESITO EL DDL CARGADO PARA QUE LO PUEDA ASIGNAR  
                    SubCategoriaDatos datos = new SubCategoriaDatos();
                    List<SubCategoria> todas = datos.listarSubCategorias();

                    List<SubCategoria> filtradas = todas.Where(x => x.Estado==true && x.IdCategoriaPadre == seleccionado.Categoria.Id) .ToList();

                    ddlSubcategoria.DataSource = filtradas;
                    ddlSubcategoria.DataTextField = "Nombre";
                    ddlSubcategoria.DataValueField = "Id";
                    ddlSubcategoria.DataBind();

                    ddlSubcategoria.SelectedValue = seleccionado.SubCategoria.Id.ToString();
                }
            }


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCategoriaPadre = int.Parse(ddlCategoria.SelectedValue);

                SubCategoriaDatos datos = new SubCategoriaDatos();

                List<SubCategoria> todas = datos.listarSubCategorias();

                List<SubCategoria> filtradas = todas.Where(x => x.Estado == true && x.IdCategoriaPadre == idCategoriaPadre).ToList();

                ddlSubcategoria.DataSource = filtradas;
                ddlSubcategoria.DataTextField = "Nombre";
                ddlSubcategoria.DataValueField = "Id";
                ddlSubcategoria.DataBind();

                ddlSubcategoria.Items.Insert(0, new ListItem("-- Seleccione --", "0")); // PREDETERMINADO
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                Validaciones val = new Validaciones();
                dominio.MenuItem nuevo = new dominio.MenuItem();
                menuItemDatos manager = new menuItemDatos();

                bool ingresoValido = true;



                if (val.validarTextos(txtNombre.Text) == false)
                {
                    lblErrorNombre.Visible = true;
                    lblErrorNombre.Text = "Valor ingresado invalido, no se permiten caracteres especiales ni solo numeros";
                    ingresoValido = false;
                } else
                {
                    lblErrorNombre.Visible = false;
                }

                List<dominio.MenuItem> menu = manager.listarMenu();


                dominio.MenuItem itemMenu = null;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    itemMenu = manager.GetItem(id);
                }


                foreach (var item in menu)
                {
                    if (item.Nombre.Trim().ToLower() == txtNombre.Text.Trim().ToLower() && (itemMenu == null || item.IdMenuItem != itemMenu.IdMenuItem))
                    {
                        lblErrorNombre.Visible = true;
                        lblErrorNombre.Text = "Menu repetido";
                        ingresoValido = false;
                        break;
                    }
                }



                if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text.Trim(), out _)) // tryParse intenta convertir el numero en decimal, devuelve bool // out _ ignora la salida
                {
                    lblErrorPrecio.Visible = true;
                    lblErrorPrecio.Text = "Valor ingresado invalido, debe ser numero";
                    ingresoValido = false; ;
                }
                else if (decimal.Parse(txtPrecio.Text) < 0)
                {
                    lblErrorPrecio.Visible = true;
                    lblErrorPrecio.Text = "No puede ser menor a 0";
                    ingresoValido = false; ;
                } else
                {
                    lblErrorPrecio.Visible = false;

                }


                if (val.validarTextos(txtDescripcion.Text) == false)
                {
                    lblErrorDescripcion.Visible = true;
                    lblErrorDescripcion.Text = "Valor ingresado invalido, no se permiten caracteres especiales ni solo numeros";
                    ingresoValido = false;
                } else
                {
                    lblErrorDescripcion.Visible = false;
                }

               



                if (string.IsNullOrEmpty(txtStock.Text) || !int.TryParse(txtStock.Text.Trim(), out _)) // tryParse intenta convertir el numero en int, devuelve bool // out _ ignora la salida
                {
                    lblErrorStock.Visible = true;
                    lblErrorStock.Text = "Valor ingresado invalido, debe ser numero";
                    ingresoValido = false; ;
                }
                else if (int.Parse(txtStock.Text) < 0)
                {
                    lblErrorStock.Visible = true;
                    lblErrorStock.Text = "No puede ser menor a 0";
                    ingresoValido = false; 
                } else
                {
                    lblErrorStock.Visible = false;

                }

                if (ddlCategoria.SelectedValue == "0")
                {
                    lblErrorCategoria.Visible = true;
                    lblErrorCategoria.Text = "Debe seleccionar una categoria";
                    ingresoValido = false;

                } else
                {
                    lblErrorCategoria.Visible = false;
                }

                if (ddlSubcategoria.Items.Count == 0)
                {
                    lblErrorSubCategoria.Visible = true;
                    lblErrorSubCategoria.Text = "Debe seleccionar una categoria";
                    ingresoValido = false;
                } else if (ddlSubcategoria.SelectedValue == "0")
                {
                    lblErrorSubCategoria.Visible = true;
                    lblErrorSubCategoria.Text = "Debe seleccionar una subcategoria";
                    ingresoValido = false;
                } else
                {
                    lblErrorSubCategoria.Visible = false;
                }


                if (ingresoValido == false)
                {
                    return;
                }


                nuevo.Nombre = txtNombre.Text.Trim();

                


                lblErrorPrecio.Visible = false;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                

                nuevo.Descripcion = txtDescripcion.Text.Trim();

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.SubCategoria = new SubCategoria();
                nuevo.SubCategoria.Id = int.Parse(ddlSubcategoria.SelectedValue);


                

                nuevo.Stock = int.Parse(txtStock.Text);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.IdMenuItem = int.Parse(Request.QueryString["id"]);
                    manager.ModificarItem(nuevo);
                }
                else
                {
                    manager.Agregar(nuevo);
                }

                Response.Redirect("gerenciaMenu.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("gerenciaMenu.aspx", false);
        }
    }
}
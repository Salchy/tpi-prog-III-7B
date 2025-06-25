using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class menuItemDatos
    {
        Database database;
        public List<MenuItem> listarMenu()
        {
            List<MenuItem> menuCompleto = new List<MenuItem>();

            database = new Database();
            //database.setQuery("SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio, M.Estado, C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria FROM Menu M INNER JOIN SubCategoriaMenu S ON M.idSubCategoria = S.idSubCategoria INNER JOIN Categoria_Menu C ON S.idCategoriaPrincipal = C.id_Categoria");
            //database.execQuery();

            database.setProcedure("SP_GetAllMenu"); // Ya estaba el procedimiento armado en la base de datos
            database.execQuery();

            while (database.Reader.Read())
            {
                MenuItem item = new MenuItem(
                    (int)database.Reader["id_Menu_Item"],
                    database.Reader["Nombre_Menu"].ToString(),
                    database.Reader.IsDBNull(database.Reader.GetOrdinal("Descripcion")) ? "" : database.Reader["Descripcion"].ToString(),
                    Math.Round((decimal)database.Reader["Precio"], 2),
                    Convert.ToInt32(database.Reader["id_Categoria"]), // Porque en la DB lo definimos como TINYINT
                    (string)database.Reader["Nombre_Categoria"],
                    Convert.ToInt32(database.Reader["idSubCategoria"]),
                    (string)database.Reader["NombreSubCategoria"]
                );
                item.Estado = (bool)database.Reader["Estado"];
                item.Stock = Convert.ToInt32(database.Reader["Stock"]);
                menuCompleto.Add(item);
            }

            return menuCompleto;
        }



        public List<MenuItem> filtrar(string campo,string filtro, string estado)
        {
            List<MenuItem> menuFiltrado = new List<MenuItem>();
            database = new Database();
            try
            {
                string consulta = "SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio, M.Stock, CM.Nombre_Categoria, CM.id_Categoria, SCM.NombreSubCategoria, M.idSubCategoria, M.Estado FROM Menu AS M INNER JOIN SubCategoriaMenu AS SCM ON M.idSubCategoria = SCM.idSubCategoria INNER JOIN Categoria_Menu AS CM ON SCM.idCategoriaPrincipal = CM.id_Categoria ";

                if (campo == "Ítem")
                {
                   consulta += "WHERE Nombre_Menu like '" + filtro + "%' ";
                        
                           
                }
                else if (campo == "Categoria")
                {
                    consulta += "WHERE Nombre_Categoria like '" + filtro + "%' ";
                }
                else if (campo == "SubCategoria")
                {
                    consulta += "WHERE NombreSubCategoria like '" + filtro + "%' ";
                }

                if (estado == "Activo")
                    consulta += " and M.Estado = 1";
                else if (estado == "Inactivo")
                    consulta += " and M.Estado = 0";


                consulta += "ORDER BY CM.Nombre_Categoria ASC, SCM.NombreSubCategoria ASC, M.Nombre_Menu ASC";

                database.setQuery(consulta);
                database.execQuery();
                while (database.Reader.Read())
                {
                    MenuItem item = new MenuItem(
                    (int)database.Reader["id_Menu_Item"],
                    database.Reader["Nombre_Menu"].ToString(),
                    database.Reader.IsDBNull(database.Reader.GetOrdinal("Descripcion")) ? "" : database.Reader["Descripcion"].ToString(),
                    Math.Round((decimal)database.Reader["Precio"], 2),
                    Convert.ToInt32(database.Reader["id_Categoria"]), // Porque en la DB lo definimos como TINYINT
                    (string)database.Reader["Nombre_Categoria"],
                    Convert.ToInt32(database.Reader["idSubCategoria"]),
                    (string)database.Reader["NombreSubCategoria"]
                );
                    item.Estado = (bool)database.Reader["Estado"];
                    item.Stock = Convert.ToInt32(database.Reader["Stock"]);
                    menuFiltrado.Add(item);
                    
                }

                return menuFiltrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MenuItem GetItem(int id)
        {
            try
            {
                database = new Database();
                database.setQuery("SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion,M.Estado ,M.Precio, M.Stock ,C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria FROM Menu M INNER JOIN SubCategoriaMenu S ON M.idSubCategoria = S.idSubCategoria INNER JOIN Categoria_Menu C ON S.idCategoriaPrincipal = C.id_Categoria WHERE M.id_Menu_Item = @id");
                database.setParameter("@id", id);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }
                MenuItem item = new MenuItem(
                     (int)database.Reader["id_Menu_Item"],
                     database.Reader["Nombre_Menu"].ToString(),
                     database.Reader.IsDBNull(database.Reader.GetOrdinal("Descripcion")) ? "" : database.Reader["Descripcion"].ToString(),
                     Math.Round((decimal)database.Reader["Precio"], 2),
                     Convert.ToInt32(database.Reader["id_Categoria"]), // Porque en la DB lo definimos como TINYINT
                     (string)database.Reader["Nombre_Categoria"],
                     Convert.ToInt32(database.Reader["idSubCategoria"]),
                     (string)database.Reader["NombreSubCategoria"]
                 );
                item.Estado = (bool)database.Reader["Estado"];
                item.Stock = Convert.ToInt32(database.Reader["Stock"]);

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                database.closeConnection();
            }
        }

        public void Agregar(MenuItem menuNuevo)
        {

            database = new Database();

            try
            {
                database.setQuery("INSERT INTO MENU (Nombre_Menu,idSubCategoria,Precio,Estado,Descripcion,Stock) VALUES (@nombre,@IDSub,@precio,@estado,@descripcion,@stock)");
                database.setParameter("@nombre", menuNuevo.Nombre);
                database.setParameter("@IDSub", menuNuevo.SubCategoria.Id);
                database.setParameter("@precio", menuNuevo.Precio);
                database.setParameter("@estado", 1);
                database.setParameter("@descripcion", menuNuevo.Descripcion);
                database.setParameter("@stock", menuNuevo.Stock);

                database.execNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                database.closeConnection();
            }
        }


        public void ModificarItem(MenuItem item)
        {
            database = new Database();
            try
            {
                database.setQuery("UPDATE MENU SET Nombre_Menu = @nombre, idSubCategoria = @IDSub, Precio = @precio, Estado = @estado, Descripcion = @descripcion, Stock = @stock WHERE  id_Menu_Item = @id");
                database.setParameter("@nombre", item.Nombre);
                database.setParameter("@IDSub", item.SubCategoria.Id);
                database.setParameter("@precio", item.Precio);
                database.setParameter("@estado", 1);
                database.setParameter("@descripcion", item.Descripcion);
                database.setParameter("@id", item.IdMenuItem);
                database.setParameter("@stock", item.Stock);

                database.execNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                database.closeConnection();
            }

        }


        /// 
        public void setMenu(MenuItem aux, SqlDataReader data)
        {
            CategoriasDatos cat = new CategoriasDatos();
            SubCategoriaDatos subcat = new SubCategoriaDatos();


            aux.IdMenuItem = (int)database.Reader["id_Menu_Item"];
             aux.Nombre = database.Reader["Nombre_Menu"].ToString();
              aux.Descripcion = database.Reader.IsDBNull(database.Reader.GetOrdinal("Descripcion")) ? "" : database.Reader["Descripcion"].ToString();
               aux.Precio = Math.Round((decimal)database.Reader["Precio"], 2);
            aux.Stock = Convert.ToInt32(database.Reader["Stock"]); // Porque en la DB lo definimos como TINYINT
                aux.SubCategoria = subcat.GetSubCategoria(Convert.ToInt32(database.Reader["idSubCategoria"]));
              aux.Estado = (bool)database.Reader["Estado"];
            aux.Categoria = cat.GetCategoria(aux.SubCategoria.IdCategoriaPadre);
                                  
        }

        /// 
        public List<MenuItem> listarSubMenu(int id)
        {
            List<MenuItem> submenu = new List<MenuItem>();

            database = new Database();

          // database.setQuery("SP_GetMenuItemsFromCategory"); //Revisar pasaje del parametro no lo esta tomando, dejo la consulta "larga" para continuar con el desarrollo
           database.setQuery("SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion, M.Precio,M.Stock, C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria, M.Estado FROM Menu AS M INNER JOIN SubCategoriaMenu AS S ON M.idSubCategoria = S.idSubCategoria INNER JOIN Categoria_Menu AS C ON S.idCategoriaPrincipal = C.id_Categoria WHERE M.idSubCategoria = @idCategoriaPrincipal ORDER BY S.NombreSubCategoria ASC;");
            database.setParameter("@idCategoriaPrincipal", id);
            database.execQuery();

            while (database.Reader.Read())
            {
                MenuItem item = new MenuItem();
                setMenu(item, database.Reader);
                submenu.Add(item);
            }

            return submenu;
        }

        public bool habilitarInhabilitarMenu(int id, bool estado)
        {
            try
            {
                database.setQuery("UPDATE MENU SET Estado = @estado WHERE  id_Menu_Item = @id");
                database.setParameter("@id", id);
                database.setParameter("@estado", estado);
                database.execNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                database.closeConnection();
            }
        }
    }



}


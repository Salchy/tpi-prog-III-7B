using System;
using System.Collections.Generic;
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
                menuCompleto.Add(item);
            }

            return menuCompleto;
        }


        public MenuItem GetItem(int id)
        {
            try
            {
                database = new Database();
                database.setQuery("SELECT M.id_Menu_Item, M.Nombre_Menu, M.Descripcion,M.Estado ,M.Precio, C.id_Categoria, C.Nombre_Categoria, S.idSubCategoria, S.NombreSubCategoria FROM Menu M INNER JOIN SubCategoriaMenu S ON M.idSubCategoria = S.idSubCategoria INNER JOIN Categoria_Menu C ON S.idCategoriaPrincipal = C.id_Categoria WHERE M.id_Menu_Item = @id");
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
                database.setQuery("INSERT INTO MENU (Nombre_Menu,idSubCategoria,Precio,Estado,Descripcion) VALUES (@nombre,@IDSub,@precio,@estado,@descripcion)");
                database.setParameter("@nombre", menuNuevo.Nombre);
                database.setParameter("@IDSub", menuNuevo.SubCategoria.Id);
                database.setParameter("@precio", menuNuevo.Precio);
                database.setParameter("@estado", 1);
                database.setParameter("@descripcion", menuNuevo.Descripcion);

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
                database.setQuery("UPDATE MENU SET Nombre_Menu = @nombre, idSubCategoria = @IDSub, Precio = @precio, Estado = @estado, Descripcion = @descripcion WHERE  id_Menu_Item = @id");
                database.setParameter("@nombre", item.Nombre);
                database.setParameter("@IDSub", item.SubCategoria.Id);
                database.setParameter("@precio", item.Precio);
                database.setParameter("@estado", 1);
                database.setParameter("@descripcion", item.Descripcion);
                database.setParameter("@id", item.IdMenuItem);

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

        public List<MenuItem> listarSubMenu(int id)
        {
            List<MenuItem> submenu = new List<MenuItem>();

            database = new Database();

            database.setQuery("SP_GetMenuItemsFromCategory");
            database.setParameter("@id", id);
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


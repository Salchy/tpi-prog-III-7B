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
            database.setProcedure("SP_GETALLMENU");
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
                menuCompleto.Add(item);
            }

            return menuCompleto;
        }

        public void Agregar (MenuItem menuNuevo)
        {
            //La consulta funciona solo esta comentado hasta terminar de definir el voucher
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
    }
}


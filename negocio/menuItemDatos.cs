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
    }
}

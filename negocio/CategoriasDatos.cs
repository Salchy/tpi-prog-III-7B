using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriasDatos
    {
        Database database;
        public List<Categoria> listarCategorias()
        {

            List<Categoria> lista = new List<Categoria>();
            database = new Database();

            try
            {
                database.setQuery("SELECT id_Categoria, Nombre_Categoria From Categoria_Menu");
                database.execQuery();

                while (database.Reader.Read())
                {
                    Categoria cate = new Categoria(
                    Convert.ToInt32(database.Reader["id_Categoria"]),
                    database.Reader["Nombre_Categoria"].ToString());

                    lista.Add(cate);
                }
                return lista;
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

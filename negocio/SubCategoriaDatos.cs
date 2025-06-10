using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class SubCategoriaDatos
    {
        Database database;
        public List<SubCategoria> listarSubCategorias()
        {
            List<SubCategoria> lista = new List<SubCategoria>();
            database = new Database();

            try
            {
                database.setQuery("SELECT idSubCategoria, nombreSubCategoria, idCategoriaPrincipal FROM SubCategoriaMenu");
                database.execQuery();

                while (database.Reader.Read())
                {
                    SubCategoria subCate = new SubCategoria(
                        Convert.ToInt32(database.Reader["idSubCategoria"]),
                        database.Reader["nombreSubCategoria"].ToString(),
                        Convert.ToInt32(database.Reader["idCategoriaPrincipal"])
                    );
                    lista.Add(subCate);
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
        public SubCategoria GetSubCategoria(int id)
        {
            SubCategoria SubCate = new SubCategoria();

            database = new Database();

            try
            {
                database.setQuery("SELECT idSubCategoria, nombreSubCategoria, idCategoriaPrincipal FROM SubCategoriaMenu WHERE idSubCategoria = @id");
                database.setParameter("@id", id);
                database.execQuery();

                if (database.Reader.Read())
                {
                    SubCategoria subCate = new SubCategoria(
                        Convert.ToInt32(database.Reader["idSubCategoria"]),
                        database.Reader["nombreSubCategoria"].ToString(),
                        Convert.ToInt32(database.Reader["idCategoriaPrincipal"])
                    );
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                database.closeConnection();
            }

            return SubCate;
        }
    }
}

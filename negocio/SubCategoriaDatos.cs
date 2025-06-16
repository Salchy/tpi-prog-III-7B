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
                database.setQuery("SELECT s.idSubCategoria, s.nombreSubCategoria, s.idCategoriaPrincipal, c.Nombre_Categoria FROM SubCategoriaMenu s INNER JOIN Categoria_Menu c ON s.idCategoriaPrincipal = c.id_Categoria");
                database.execQuery();

                while (database.Reader.Read())
                {
                    SubCategoria subCate = new SubCategoria(
                        Convert.ToInt32(database.Reader["idSubCategoria"]),
                        database.Reader["nombreSubCategoria"].ToString(),
                        Convert.ToInt32(database.Reader["idCategoriaPrincipal"])
                    );

                    subCate.NombreCategoriaPadre = database.Reader["Nombre_Categoria"].ToString();

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
            try
            {
                database = new Database();
                database.setQuery("SELECT idSubCategoria, nombreSubCategoria, idCategoriaPrincipal FROM SubCategoriaMenu WHERE idSubCategoria = @id");
                database.setParameter("@id", id);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }

                SubCategoria subCate = new SubCategoria(
                    Convert.ToInt32(database.Reader["idSubCategoria"]),
                    database.Reader["nombreSubCategoria"].ToString(),
                    Convert.ToInt32(database.Reader["idCategoriaPrincipal"])
                );

                return subCate;
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



        public void Agregar(SubCategoria nueva)
        {

            database = new Database();

            try
            {
                database.setQuery("INSERT INTO SubCategoriaMenu (nombreSubCategoria,idCategoriaPrincipal,Estado) VALUES (@nombreCate,@idCategoria,@estadoCate)");
                database.setParameter("@nombreCate", nueva.Nombre);
                database.setParameter("@idCategoria", nueva.IdCategoriaPadre);
                database.setParameter("@estadoCate", 1);
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

        public void ModificarSub(SubCategoria sub)
        {
            database = new Database();

            try
            {
                database.setQuery("UPDATE SubCategoriaMenu SET nombreSubCategoria = @nombre, idCategoriaPrincipal = @idCategoria WHERE idSubCategoria = @id");
                database.setParameter("@id", sub.Id);
                database.setParameter("@nombre", sub.Nombre);
                database.setParameter("@idCategoria", sub.IdCategoriaPadre);
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

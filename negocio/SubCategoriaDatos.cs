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
                database.setQuery("SP_GetCategories");
                database.execQuery();

                while (database.Reader.Read())
                {
                    SubCategoria subCate = new SubCategoria(
                        Convert.ToInt32(database.Reader["idSubCategoria"]),
                        database.Reader["nombreSubCategoria"].ToString(),
                        Convert.ToInt32(database.Reader["idCategoriaPrincipal"])
                    );

                    subCate.NombreCategoriaPadre = database.Reader["Nombre_Categoria"].ToString();
                    subCate.Estado = (bool)database.Reader["Estado"];


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
                database.setQuery("SELECT idSubCategoria, nombreSubCategoria, idCategoriaPrincipal , Estado FROM SubCategoriaMenu WHERE idSubCategoria = @id");
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
                                    subCate.Estado = (bool)database.Reader["Estado"];

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


        public bool habilitarInhabilitarSubCategoria(int id, bool estado)
        {
            try
            {
                database.setQuery("UPDATE SubCategoriaMenu SET Estado = @estado WHERE idSubCategoria = @id");
                database.setParameter("@id", id);
                database.setParameter("@estado", estado);
                database.execNonQuery();

                database.closeConnection();


                //database.setQuery("UPDATE MENU SET Estado = @estado WHERE idSubCategoria = @id ");
                //database.setParameter("@id", id);
                //database.setParameter("@estado", estado);
                //database.execNonQuery();
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

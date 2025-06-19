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
                database.setQuery("SELECT id_Categoria, Nombre_Categoria , Estado From Categoria_Menu");
                database.execQuery();

                while (database.Reader.Read())
                {
                    Categoria cate = new Categoria(
                    Convert.ToInt32(database.Reader["id_Categoria"]),
                    database.Reader["Nombre_Categoria"].ToString());
                    cate.Estado = (bool)database.Reader["Estado"];
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

        public void Agregar(Categoria cateNueva)
        {

            database = new Database();

            try
            {
                database.setQuery("INSERT INTO Categoria_Menu (Nombre_Categoria,Estado) VALUES (@nombreCate,@estadoCate)");
                database.setParameter("@nombreCate", cateNueva.Nombre);
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

        public Categoria GetCategoria(int id)
        {
            try
            {
                database = new Database();
                database.setQuery("SELECT id_Categoria, Nombre_Categoria, Estado FROM Categoria_Menu WHERE id_Categoria = @id");
                database.setParameter("@id", id);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }
                Categoria cate = new Categoria(
                     Convert.ToInt32(database.Reader["id_Categoria"]),
                    database.Reader["Nombre_Categoria"].ToString());
                    cate.Estado = (bool)database.Reader["Estado"];
                return cate;
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



        public void ModificarItem(Categoria cate)
        {
            database = new Database();

            try
            {
                database.setQuery("UPDATE Categoria_Menu SET Nombre_Categoria = @nombre WHERE id_Categoria = @id");
                database.setParameter("@id", cate.Id);
                database.setParameter("@nombre", cate.Nombre);
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


        public bool habilitarInhabilitarCategoria(int id, bool estado)
        {
            try
            {
                database.setQuery("UPDATE Categoria_Menu SET Estado = @estado WHERE id_Categoria = @id");
                database.setParameter("@id", id);
                database.setParameter("@estado", estado);
                database.execNonQuery();

                database.closeConnection();



                database.setQuery("UPDATE SubCategoriaMenu SET Estado = @estado WHERE idCategoriaPrincipal = @id");
                database.setParameter("@id", id);
                database.setParameter("@estado", estado);
                database.execNonQuery();

                database.closeConnection();


                database.setQuery("UPDATE m SET m.Estado = @estado FROM MENU m INNER JOIN SubCategoriaMenu s ON m.idSubCategoria = s.idSubCategoria INNER JOIN Categoria_Menu c ON s.idCategoriaPrincipal = c.id_Categoria WHERE id_Categoria = @id");
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


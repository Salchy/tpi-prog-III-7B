using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using dominio;
using System.Data.SqlClient;
using System.Net;

namespace negocio
{
    public class UsuarioDatos
    {
        private Database database;
        public UsuarioDatos()
        {
            database = new Database();
        }

        public static bool SesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }
        public static int GetLevel(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario == null || usuario.Id == 0)
                return -1;
            return usuario.NivelUsuario;
        }

        public int registrarUsuario(Usuario user, string password)
        {
            try
            {
                // Pasa a ser procedimiento, para poder obtener el id del usuario ingresado en la DB
                //database.setQuery("INSERT INTO Usuarios (dni, password) VALUES (@dni, @password)");
                //database.setParameter("@dni", dni);
                //database.setParameter("@password", generateHashPassword(password));

                database.setProcedure("SP_CrearUsuario");
                database.setParameter("@dni", user.Dni);
                database.setParameter("@nombre", user.Nombre);
                database.setParameter("@apellido", user.Apellido);
                database.setParameter("@contraseña", generateHashPassword(password));
                database.setParameter("@permisos", user.NivelUsuario);
                int newID = database.execScalar();
                user.Id = newID;
                return newID;
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

        private string generateHashPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA256.Create().ComputeHash(inputBytes);

            // Formatear el hash en una cadena hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Para obtener un usuario de la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve un Usuario, a partir de su DNI, NULL si no existe en la DB</returns>
        /// <exception cref="Exception"></exception>
        public Usuario getUsuario(string dni)
        {
            try
            {
                database.setQuery("SELECT * FROM Usuarios WHERE dni = @dni");
                database.setParameter("@dni", dni);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }
                Usuario usuario = new Usuario(Convert.ToInt32(database.Reader["id_Usuario"]), database.Reader["dni"].ToString(), database.Reader["nombre"].ToString(), database.Reader["apellido"].ToString(), (int)database.Reader["Permisos"], (bool)database.Reader["Estado"]);
                return usuario;
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

        /// <summary>
        /// Para obtener un usuario de la base de datos, validando DNI y PASSWORD
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="password"></param>
        /// <returns>Devuelve un Usuario, a partir de su DNI, NULL si no existe en la DB</returns>
        /// <exception cref="Exception"></exception>
        public Usuario getUsuario(string dni, string password)
        {
            try
            {
                database.setQuery("SELECT * FROM Usuarios WHERE dni = @dni");
                database.setParameter("@dni", dni);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }
                if (database.Reader["Contraseña"] == null || database.Reader["Contraseña"].ToString() != generateHashPassword(password))
                {
                    return null;
                }
                Usuario usuario = new Usuario(Convert.ToInt32(database.Reader["id_Usuario"]), dni, database.Reader["nombre"].ToString(), database.Reader["apellido"].ToString(), Convert.ToInt32(database.Reader["Permisos"]), (bool)database.Reader["Estado"]);
                return usuario;
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

        public Usuario getUsuario(int id)
        {
            try
            {
                database.setQuery("SELECT * FROM Usuarios WHERE id_Usuario = @id");
                database.setParameter("@id", id);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return null;
                }
                Usuario usuario = new Usuario(Convert.ToInt32(database.Reader["id_Usuario"]), database.Reader["dni"].ToString(), database.Reader["nombre"].ToString(), database.Reader["apellido"].ToString(), Convert.ToInt32(database.Reader["Permisos"]), (bool)database.Reader["Estado"]);
                return usuario;
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

        /// <summary>
        /// Para obtener todos los usuarios de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                database.setQuery("SELECT * FROM Usuarios");
                database.execQuery();

                while (database.Reader.Read())
                {
                    string dni = database.Reader["dni"].ToString();
                    if (dni == "Admin")
                    {
                        continue; // Para que no añada al usuario Admin a la lista
                    }
                    Usuario usuario = new Usuario(Convert.ToInt32(database.Reader["id_Usuario"]), dni, database.Reader["nombre"].ToString(), database.Reader["apellido"].ToString(), Convert.ToInt32(database.Reader["Permisos"]), (bool)database.Reader["Estado"]);
                    usuarios.Add(usuario);
                }
                return usuarios;
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

        public bool modificarUsuario(Usuario usuario)
        {
            try
            {
                database.setProcedure("SP_ModificarUsuario");
                database.setParameter("@id", usuario.Id);
                database.setParameter("@nombre", usuario.Nombre);
                database.setParameter("@apellido", usuario.Apellido);
                database.setParameter("@permisos", usuario.NivelUsuario);
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

        public bool setUserPassword(int id, string password)
        {
            try
            {
                database.setProcedure("SP_SetPassword");
                database.setParameter("@id", id);
                database.setParameter("@password", generateHashPassword(password));
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
        public bool enableDisableUsuario(int id, bool state)
        {
            try
            {
                database.setProcedure("SP_ActivarDesactivarUsuario");
                database.setParameter("@id", id);
                database.setParameter("@state", state);
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
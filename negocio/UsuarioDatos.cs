using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class UsuarioDatos
    {
        private Database database;
        public UsuarioDatos()
        {
            database = new Database();
        }

        public bool registrarUsuario(string dni, string password)
        {
            try
            {
                database.setQuery("INSERT INTO Usuarios (dni, password) VALUES (@dni, @password)");
                database.setParameter("@dni", dni);
                database.setParameter("@password", generateHashPassword(password));
                database.execNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar usuario: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }

        public bool ValidarUsuario(string dni)
        {
            try
            {
                SqlDataReader data = getUsuarioFromDatabase(dni);
                if (!data.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }

        public bool ValidarUsuario(string dni, string password)
        {
            try
            {
                SqlDataReader data = getUsuarioFromDatabase(dni);
                if (!data.Read())
                {
                    return false;
                }
                if (data["password"] == null || data["password"].ToString() != generateHashPassword(password))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
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

        public Usuario getUsuario(string dni)
        {
            try
            {
                SqlDataReader data = getUsuarioFromDatabase(dni);
                if (!data.Read())
                {
                    return null;
                }
                Usuario usuario = new Usuario(data["dni"].ToString(), data["nombre"].ToString(), data["apellido"].ToString(), new Perfil((int)data["idPerfil"], data["nombrePerfil"].ToString()));
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }

        public Usuario getUsuario(string dni, string password)
        {
            try
            {
                SqlDataReader data = getUsuarioFromDatabase(dni);
                if (!data.Read())
                {
                    return null;
                }
                if (data["password"] == null || data["password"].ToString() != generateHashPassword(password))
                {
                    return null;
                }
                Usuario usuario = new Usuario(data["dni"].ToString(), data["nombre"].ToString(), data["apellido"].ToString(), new Perfil((int)data["idPerfil"], data["nombrePerfil"].ToString()));
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }

        private SqlDataReader getUsuarioFromDatabase(string dni)
        {
            try
            {
                database.setQuery("SELECT * FROM Usuarios WHERE dni = @dni");
                database.setParameter("@dni", dni);
                database.execQuery();

                return database.Reader;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
            finally
            {
                database.closeConnection();
            }
        }
    }
}

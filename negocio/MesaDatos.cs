using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dominio.Mesa;

namespace negocio
{
    public class MesaDatos
    {
        private Database database;
        public MesaDatos()
        {
            database = new Database();
        }

        public Mesa setMesaData(SqlDataReader data)
        {
            UsuarioDatos user = new UsuarioDatos();
            Usuario meseroAsignado = user.getUsuario(Convert.ToInt32(data["id_Usuario"]));

            Mesa mesa = new Mesa(
                Convert.ToInt32(data["id_Mesa"]),
                data["numeroMesa"].ToString(),
                Convert.ToInt32(data["Numero_Comensales"]),
                meseroAsignado,
                Convert.ToBoolean(data["Estado"])
            );
            return mesa;
        }

        public List<Mesa> getMesasAsignadas(int id)
        {
            List<Mesa> Asignadas = new List<Mesa>();
            try
            {
                database.setQuery("SELECT * FROM Mesas WHERE id_Usuario = @id and Estado =1" ); //tambien agregar filtrado de estado
                database.setParameter("@id", id);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Mesa aux = setMesaData(database.Reader);
                    if (!aux.Habilitado)
                    {
                        // Excluye la mesa con estado deshabilitado
                        continue;
                    }
                    Asignadas.Add(aux);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
            return Asignadas;
        }
        public List<Mesa> getMesas()
        {
            List<Mesa> Mesas = new List<Mesa>();
            UsuarioDatos user = new UsuarioDatos();

            try
            {
                database.setQuery("SELECT * FROM mesas");
                database.execQuery();

                while (database.Reader.Read())
                {
                    Mesa aux = setMesaData(database.Reader);
                    Mesas.Add(aux);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
            return Mesas;
        }
        public Mesa getMesa(int id)
        {
            Mesa aux;

            try
            {
                database.setQuery("SELECT * FROM mesas WHERE id_Mesa = @id");
                database.setParameter("@id", id);
                database.execQuery();
                if (!database.Reader.Read())
                {
                    return null;
                }
                aux = setMesaData(database.Reader);
                return aux;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
        }

        public bool enableDisableMesa(int idMesa, bool state)
        {
            try
            { // Quizá haga falta una condición para que no se pueda deshabilitar una mesa que está siendo utilizada (comensales > 0)
                database.setProcedure("SP_ActivarDesactivarMesa");
                database.setParameter("@idMesa", idMesa);
                database.setParameter("@state", state);
                database.execNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
        }

        public bool crearMesa(string nombreMesa, int idMeseroAsignado)
        {
            try
            {
                database.setProcedure("SP_CrearMesa");
                database.setParameter("@nombreMesa", nombreMesa);
                database.setParameter("@idMeseroAsignado", idMeseroAsignado);
                database.execNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
        }

        public bool modificarMesa(Mesa mesa)
        {
            try
            {
                database.setQuery("UPDATE Mesas SET numeroMesa = @nombreMesa, id_Usuario = @idMeseroAsignado WHERE id_Mesa = @idMesa;");
                database.setParameter("@nombreMesa", mesa.NumeroMesa);
                database.setParameter("@idMeseroAsignado", mesa.MeseroAsignado.Id);
                database.setParameter("@idMesa", mesa.IdMesa);
                database.execNonQuery();
                return true;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
        }
        public void ComensalesMesa(int comensales, Pedido pedido)
        {
            try
            {
                database.setQuery("UPDATE Mesas SET Numero_Comensales = @comensales WHERE id_Mesa = @idMesa;");
                database.setParameter("@comensales", comensales);
                database.setParameter("@idMesa",pedido.mesa.IdMesa);
                database.execNonQuery();
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                database.closeConnection();
            }
        }
    }
}
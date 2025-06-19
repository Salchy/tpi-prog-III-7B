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
                data["nombre"].ToString(),
                (Mesa.estadoMesa)Convert.ToInt32(data["id_Mesa"]),
                Convert.ToInt32(data["id_Mesa"]),
                meseroAsignado
            );

            return mesa;
        }

        public List<Mesa> getMesasAsignadas(int id)
        {
            List<Mesa> Asignadas = new List<Mesa>();
            try
            {
                database.setQuery("SELECT * FROM Mesas WHERE id_Usuario = @id");//tambien agregar filtrado de estado
                database.setParameter("@id", id);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Mesa aux = setMesaData(database.Reader);
                    Asignadas.Add(aux);
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
            catch (Exception ex)
            {

                throw ex;
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
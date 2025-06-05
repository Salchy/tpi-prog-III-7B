using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MesaDatos
    {
        private Database database;
        public MesaDatos()
        {
            database = new Database();
        }
        Database db;
        
        public List<Mesa> getMesas()
        public void setMesaData(Mesa aux, SqlDataReader data)
        {
            List<Mesa> mesas = new List<Mesa>();

            // Hardcoding para modelo de dominio funcional

            aux.Id = (int)data["id_Mesa"];
            aux.Numero= (string)data["Numero"];
            //aux.Usuario.id= (int)data["id_Usuario"];  es necesario agregar el ID a la clase usuario
            aux.Estado = (bool)data["Estado"];
            aux.Comensales = (string)data["Numero_Comensales"];
            
        }


        public List<Mesa> getMesasAsignadas(int id)
        {
            List<Mesa> Asignadas = new List<Mesa>();
            
            try
            {
                database.setQuery("SELECT * FROM Mesas WHERE id_Usuario = @id");//tambien agregar filtrado de estado
                database.setParameter("@id", id);
                database.execQuery();

            return mesas;
                while (database.Reader.Read())
                {
                    Mesa aux = new Mesa();
                   setMesaData(aux, database.Reader);
                    Asignadas.Add(aux);
                }
        }
            catch (Exception ex)
            {

        public MesaDatos() {
            db = new Database();
                throw ex;
            }
            finally
            {
                database.closeConnection();
            }
            return Asignadas;
        }
        


    }


}

using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class MesaDatos
    {
        
       /* Database db;

        public List<Mesa> getMesas()

        {
            List<Mesa> mesas = new List<Mesa>();

            // Hardcoding para modelo de dominio funcional


            return mesas;
        }
    
        

        public MesaDatos() {
            db = new Database();
               
        }*/

        
           private Database database;
        public MesaDatos()
        {
            database = new Database();
        }
        
        public void setMesaData(Mesa aux, SqlDataReader data)
        {
          UsuarioDatos user = new UsuarioDatos();
            
            aux.IdMesa = Convert.ToInt32(data["id_Mesa"]);
            aux.MeseroAsignado = user.getUsuario(Convert.ToInt32(data["id_Usuario"]));
            aux.numeroComensales = Convert.ToInt32(data["Numero_Comensales"]);
            aux.numeroMesa= Convert.ToInt32(data["Numero"]);
            aux.Disponibilidad= (bool)data["Estado"];
           

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
                    Mesa aux = new Mesa();
                   setMesaData(aux,database.Reader);
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

                    Mesa aux = new Mesa();
                    setMesaData(aux, database.Reader);
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
            Mesa aux = new Mesa();

            try
            {
                database.setQuery("SELECT * FROM mesas WHERE id_Mesa = @id");
                database.setParameter("@id", id);
                database.execQuery();
                if (!database.Reader.Read())
                {
                    return null;
                }
                setMesaData(aux, database.Reader);
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

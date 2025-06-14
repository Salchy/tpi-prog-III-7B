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
            aux.MeseroAsignado = user.getUsuario(Convert.ToInt32(data["id_Usuario"]));
            aux.IdMesa = Convert.ToInt32(data["id_Mesa"]);
            aux.numeroMesa= Convert.ToInt32(data["Numero"]); 
            aux.Disponibilidad= (bool)data["Estado"];
            aux.numeroComensales= Convert.ToInt32(data["Numero_Comensales"]);

        }


        public List<Mesa> getMesasAsignadas(int id)
        {
           List<Mesa> Asignadas = new List<Mesa>();
            
            /*try
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
            }*/
            return Asignadas;
           
        }
        
         
         


    }


}

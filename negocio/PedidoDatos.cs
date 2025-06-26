using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PedidoDatos
    {
        Database database;
        public int CrearPedido(int id)
        {
            database = new Database();
            

            try
            {
                database.setQuery("INSERT INTO Pedidos (id_Mesa,Estado,Importe) OUTPUT inserted.id_Pedido VALUES (@mesa,1,0)");
                database.setParameter("@mesa", id);
                database.execNonQuery();
                int idPedido = database.execScalar();
                return idPedido;
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

        

        public int getIdPedidoMesaAbierta(int id)//busco el id del pedido recein creado
        {
            int aux = 0;
            database = new Database();
            try
            {
                database.setQuery("SELECT id_Pedido FROM Pedidos WHERE id_Mesa= @id and Estado=1 and Importe=0");
                database.setParameter("@id", id);
                database.execQuery();

                if (!database.Reader.Read())
                {
                    return aux;
                    
                }
                aux = (int)database.Reader["id_Pedido"];
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

        public void ModificarPedido(int id, float importe, bool estado)
        {

            database = new Database();

            try
            {
                database.setQuery("update Pedidos set Estado=@estado, Importe=@importe Where id_Pedido=@id");
                database.setParameter("@importe", importe);
                database.setParameter("@estado", estado);
                database.setParameter("@id", id);

                database.execQuery();
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

        public void EliminarPedido(int id)//elimina el importe, lo deja en cero
        {

            database = new Database();

            try
            {
                database.setQuery("update Pedidos set Estado=0, Importe=0 Where id_Pedido=@id");
                database.setParameter("@id", id);
                database.execQuery();
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

        public void setPedidoData(Pedido aux, SqlDataReader data)
        {
            MesaDatos mesa = new MesaDatos();

            aux.Id = (int)data["id_Pedido"];
            aux.mesa= mesa.getMesa(Convert.ToInt32(data["id_Mesa"]));
            aux.Estado= (bool)data["Estado"];
            aux.Importe= Convert.ToInt32(data["Importe"]);
        }

        public Pedido BuscarPedido( int id)
        {
            database = new Database();

            try
            {
                database.setQuery("SELECT * FROM Pedidos WHERE id_Pedido= @id");
                database.setParameter("@id", id);
                database.execQuery();
                if (!database.Reader.Read())
                {
                    return null;
                }
                Pedido aux = new Pedido();
                setPedidoData(aux, database.Reader);
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

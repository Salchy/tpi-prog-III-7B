using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class PedidoDatos
    {
        Database database;
        public void CrearPedido(Mesa mesa)
        {

            database = new Database();

            try
            {
                database.setQuery("INSERT INTO Ordenes (id_Mesa,Estado,Importe) VALUES (@mesa,1,-1)");
                database.setParameter("@mesa", mesa.IdMesa);
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

        /*public void setPedidoData(Mesa mesa, Pedido aux, SqlDataReader data)
        {
            aux.Id= (int)data["id_Pedido"];
            aux.mesa = mesa;
            aux.Estado= (bool)data["Estado"];
            aux.Importe= (int)data["Importe"];

        }*/

        public int getPedidoMesaAbierta(Mesa mesa)//busco el id del pedido recein creado
        {
            int aux = 0;
            try
            {
                database.setQuery("SELECT * FROM Pedidos WHERE id_Mesa= @id and Estado=1 and Importe=-1");
                database.setParameter("@id", mesa.IdMesa);
                database.execQuery();
                aux = (int)database.Reader["id_Pedido"];

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                database.closeConnection();
            }
            return aux;

        }

        public void ModificarPedido(int id, float importe, bool estado)
        {

            database = new Database();

            try
            {
                database.setQuery("update Ordenes set Estado=@estado, Importe=@importe Where id_Pedido=@id");
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
                database.setQuery("update Ordenes set Estado=0, Importe=0 Where id_Pedido=@id");
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
    }
}

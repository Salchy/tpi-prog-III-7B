using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class OrdenDatos
    {
        Database database;
        public void AgregarOrden(Orden orden)
        {

            database = new Database();

            try
            {
                database.setQuery("INSERT INTO Ordenes (id_Menu,Cantidad,id_Pedido) VALUES (@menu,@cant,@pedido)");
                database.setParameter("@menu", orden.Menu.IdMenuItem);
                database.setParameter("@cant", orden.Cantidad);
                database.setParameter("@pedido", orden.Pedido.Id);

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



        public void ModificarOrden(Orden orden)
        {

            database = new Database();

            try
            {
                database.setQuery("update Ordenes set Cantidad=@cant Where id_Orden=@id and Estado=1");
                database.setParameter("@cant", orden.Cantidad);
                database.setParameter("@id", orden.id);

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

        public void EliminarOrden(int idOrden)
        {

            database = new Database();

            try
            {
                database.setQuery("update Ordenes set Estado=0 Where id_Orden=@id and Estado=1");
                database.setParameter("@id", idOrden);

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

        public void EliminarOrdenesdelPedido(int idPedido)
        {
                     
            try
            {
                OrdenDatos orden = new OrdenDatos();
                List<Orden> Pedidas = orden.getOrdenesPedido(idPedido);

                foreach (var item in Pedidas)
                {
                    orden.EliminarOrden(item.id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setOrdenData(Orden aux, SqlDataReader data)
        {
           menuItemDatos menu = new menuItemDatos();
           PedidoDatos pedido = new PedidoDatos();
           

            aux.Menu = menu.GetItem((int)data["id_Menu"]);
            aux.Estado= (bool)data["Estado"];
            aux.Pedido = pedido.BuscarPedido((int)data["id_Pedido"]);
            aux.Cantidad = Convert.ToInt32(data["Cantidad"]);
            aux.id = (int)data["id_Orden"];

        }
        public List<Orden> getOrdenesPedido(int idPedido)
        {
            List<Orden> Pedidas = new List<Orden>();
            database = new Database();
            try
            {
                database.setQuery("SELECT * FROM Ordenes WHERE id_Pedido=@id and Estado=1");//tambien agregar filtrado de estado
                database.setParameter("@id", idPedido);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Orden aux = new Orden();
                    setOrdenData(aux, database.Reader);
                    Pedidas.Add(aux);
                }
                return Pedidas;
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

        public Orden getOrden(int idOrden)
        {
            database = new Database();
            Orden aux = new Orden();
            try
            {
                database.setQuery("SELECT * FROM Ordenes WHERE id_Orden=@id and Estado=1");
                database.setParameter("@id", idOrden);
                database.execQuery();

                if (database.Reader.Read())
                {
                    setOrdenData(aux, database.Reader);
                }
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

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
                database.setQuery("INSERT INTO Ordenes (id_Menu,Cantidad,Estado,id_Mesa,id_Pedido) VALUES (@menu,@cant,@Estado,@mesa,@pedido)");
                database.setParameter("@menu", orden.Menu.IdMenuItem);
                database.setParameter("@cant", orden.Cantidad);
                database.setParameter("@Estado", orden.Estado);
                database.setParameter("@mesa", orden.Pedido.mesa.IdMesa);
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
                database.setQuery("update Ordenes set id_Menu=@menu, Cantidad=@cant Where id_Orden=@id");
                database.setParameter("@menu", orden.Menu.IdMenuItem);
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

        public void EliminarOrden(int id)
        {

            database = new Database();

            try
            {
                database.setQuery("update Ordenes set Estado=0 Where id_Orden=@id");
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
        public List<Orden> getOrdenesPedido(int id)
        {
            List<Orden> Pedidas = new List<Orden>();

            try
            {
                database.setQuery("SELECT * FROM Ordenes WHERE id_Pedido= @id");//tambien agregar filtrado de estado
                database.setParameter("@id", id);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Orden aux = new Orden();
                    setOrdenData(aux, database.Reader);
                    Pedidas.Add(aux);
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
            return Pedidas;

        }
    }
}

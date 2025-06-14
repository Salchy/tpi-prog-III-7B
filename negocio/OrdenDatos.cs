using dominio;
using System;
using System.Collections.Generic;
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
                database.setQuery("INSERT INTO Ordenes (id_Menu,Cantidad,Estado,id_Mesa,id_Pedido) VALUES (@menu,@cant,1,@mesa,@pedido)");
                database.setParameter("@menu", orden.Menu.IdMenuItem);
                database.setParameter("@cant", orden.Cantidad);
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


    }
}

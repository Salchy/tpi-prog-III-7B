using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace AppWeb
{
    public partial class gerenciaReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ocupacionMesaCantidad.InnerText = getPedidosActivos().ToString() + "/" + getMesasHabilitadas().ToString();
            estadoOrdenesCantidad.InnerText = getOrdenesActivas().ToString();
            PedidosCerradosDia.InnerText = MesaMasPedidosDiaMes("diario");
            PedidosCerradosMes.InnerText = MesaMasPedidosDiaMes("mensual");
            //estadoOrdenesCantidad.InnerText = "1";
        }

        // Me devuelve la cantidad de mesas totales habilitadas.
        private int getMesasHabilitadas()
        {
            Database database = new Database();
            try
            {
                database.setQuery("SELECT COUNT(id_Mesa) AS Cantidad FROM Mesas WHERE Estado = 1");
                return database.execScalar();
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

        private int getPedidosActivos()
        {
            Database database = new Database();
            try
            {
                database.setQuery("SELECT COUNT(id_Pedido) AS Cantidad FROM Pedidos WHERE Estado = 1");
                return database.execScalar();
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

        private int getOrdenesActivas()
        {
            Database database = new Database();
            try
            {
                database.setQuery("SELECT SUM(Cantidad) AS Cantidad FROM Ordenes WHERE Estado = 1");
                return database.execScalar();
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


        private string MesaMasPedidosDiaMes(string tipoReporte)
        {
            Database database = new Database();
            try
            {
                string consulta = "SELECT TOP 1 id_Mesa,COUNT(*) as TotalPedidos FROM Pedidos "; 
                
                if(tipoReporte == "diario")
                {
                    consulta += "WHERE CONVERT(DATE, Fecha) = CONVERT(DATE, GETDATE()) ";
                } else if (tipoReporte == "mensual" )
                {
                    consulta += "WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE()) ";
                } else
                {
                   return "Tipo reporte invalido";
                }

                consulta += "AND Importe <> 0 AND Estado = 0 GROUP BY id_Mesa ORDER BY TotalPedidos DESC";

                database.setQuery(consulta);
                int id = database.execScalar();

                if (id == 0)
                {
                    return "Sin datos";
                }
                MesaDatos manager = new MesaDatos();
                Mesa mesa = manager.getMesa(id);

                return mesa.NumeroMesa;
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
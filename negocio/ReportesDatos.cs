using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    class ReportesDatos
    {
        Database database;
        public List<ReporteMesasPedidosCerrados> listarRankingMasPedidosCerrados()
        {

            List<ReporteMesasPedidosCerrados> lista = new List<ReporteMesasPedidosCerrados>();
            database = new Database();

            try
            {
                database.setQuery("SELECT TOP 1 id_Mesa,COUNT(*) as TotalPedidos FROM Pedidos WHERE CONVERT (DATE,Fecha) = CONVERT(DATE,GETDATE()) AND IMPORTE <> 0 AND Estado = 0 GROUP BY id_Mesa ORDER BY TotalPedidos DESC");
                database.execQuery();

                while (database.Reader.Read())
                {
                    ReporteMesasPedidosCerrados reporte = new ReporteMesasPedidosCerrados();
                      reporte.IDMesa = Convert.ToInt32(database.Reader["id_Mesa"]);
                    reporte.TotalPedidos = Convert.ToInt32(database.Reader["TotalPedidos"]);  


                    lista.Add(reporte);
                }

                return lista;
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

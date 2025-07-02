using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ReportesDatos
    {
        Database database;
        public List<ReporteMesasPedidosCerrados> listarRankingMasPedidosCerrados()
        {

            List<ReporteMesasPedidosCerrados> lista = new List<ReporteMesasPedidosCerrados>();
            database = new Database();

            try
            {
                database.setQuery("SELECT M.numeroMesa,COUNT(*) as TotalPedidos FROM Pedidos P INNER JOIN Mesas M ON P.id_Mesa = M.id_Mesa WHERE CONVERT (DATE,Fecha) = CONVERT(DATE,GETDATE()) AND P.Importe <> 0 AND P.Estado = 0 GROUP BY M.numeroMesa ORDER BY TotalPedidos DESC");
                database.execQuery();

                while (database.Reader.Read())
                {
                    ReporteMesasPedidosCerrados reporte = new ReporteMesasPedidosCerrados();
                      reporte.numeroMesa = database.Reader["numeroMesa"].ToString();
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

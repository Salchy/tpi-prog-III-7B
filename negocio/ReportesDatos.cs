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
        public List<Reportes> listarRankingMasPedidosCerrados(string tipoReporte)
        {

            List<Reportes> lista = new List<Reportes>();
            database = new Database();

            try
            {
                string consulta = "SELECT M.numeroMesa,COUNT(*) as TotalPedidos FROM Pedidos P INNER JOIN Mesas M ON P.id_Mesa = M.id_Mesa ";


                if (tipoReporte == "diario")
                {
                    consulta += "WHERE CONVERT(DATE, Fecha) = CONVERT(DATE, GETDATE()) ";
                } else if (tipoReporte == "mensual")
                {
                    consulta += "WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE()) ";
                }

                consulta += "AND P.Importe <> 0 AND P.Estado = 0 GROUP BY M.numeroMesa ORDER BY TotalPedidos DESC";

                database.setQuery(consulta);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Reportes reporte = new Reportes();
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



        public List<Reportes> ListaMenuMasPedido(string tipoReporte)
        {
            List<Reportes> lista = new List<Reportes>();
            database = new Database();
            try
            {
                string consulta = "SELECT M.Nombre_Menu,Sum(O.Cantidad) as TotalPedidos FROM Ordenes O INNER JOIN Menu M ON O.id_Menu = M.id_Menu_Item INNER JOIN Pedidos P ON O.id_Pedido = P.id_Pedido ";

                if (tipoReporte == "diario")
                {
                    consulta += "WHERE CONVERT(DATE, P.Fecha) = CONVERT(DATE, GETDATE()) ";
                }
                else if (tipoReporte == "mensual")
                {
                    consulta += "WHERE MONTH(P.Fecha) = MONTH(GETDATE()) AND YEAR(P.Fecha) = YEAR(GETDATE()) ";
                }
                

                consulta += "AND P.Importe <> 0 AND P.Estado = 0 GROUP BY M.Nombre_Menu ORDER BY TotalPedidos DESC";

                database.setQuery(consulta);
                database.execQuery();

                while (database.Reader.Read())
                {
                    Reportes reporte = new Reportes();
                    reporte.NombreMenu = database.Reader["Nombre_Menu"].ToString();
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

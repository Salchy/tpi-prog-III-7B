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
    public partial class gerencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ocupacionMesaCantidad.InnerText = getPedidosActivos().ToString() + "/" + getMesasHabilitadas().ToString();
            estadoOrdenesCantidad.InnerText = getOrdenesActivas().ToString();
            PedidosCerradosDia.InnerText = MesaMasPedidosDiaMes("diario");
            PedidosCerradosMes.InnerText = MesaMasPedidosDiaMes("mensual");
            PlatoMasPedidoDia.InnerText = MenuMasPedido("diario");
            PlatoMasPedidoMes.InnerText = MenuMasPedido("mensual");

            if (PedidosCerradosDia.InnerText == "Sin datos")
            {
                btnMesasDia.Visible = false;
            }
            else
            {
                btnMesasDia.Visible = true;
            }

            if(PedidosCerradosMes.InnerText == "Sin datos")
            {
                btnMesasMes.Visible = false;
            } else
            {
                btnMesasMes.Visible = true;
            }



            if (PlatoMasPedidoDia.InnerText == "Sin datos")
            {
                btnItemDia.Visible = false;
            }
            else
            {
                btnItemDia.Visible = true;
            }

            if (PlatoMasPedidoMes.InnerText == "Sin datos")
            {
                btnItemMes.Visible = false;
            } else
            {
                btnItemMes.Visible = true;
            }

           


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

        private string MenuMasPedido(string tipoReporte)
        {
            Database database = new Database();
            try
            {
                string consulta = "SELECT TOP 1 O.id_Menu,Sum(O.Cantidad) as TotalPedidos FROM Ordenes O INNER JOIN Menu M ON O.id_Menu = M.id_Menu_Item INNER JOIN Pedidos P ON O.id_Pedido = P.id_Pedido ";

                if (tipoReporte == "diario")
                {
                    consulta += "WHERE CONVERT(DATE, P.Fecha) = CONVERT(DATE, GETDATE()) ";
                }
                else if (tipoReporte == "mensual")
                {
                    consulta += "WHERE MONTH(P.Fecha) = MONTH(GETDATE()) AND YEAR(P.Fecha) = YEAR(GETDATE()) ";
                }
                else
                {
                    return "Tipo reporte invalido";
                }

                consulta += "AND P.Importe <> 0 AND P.Estado = 0 GROUP BY O.id_Menu ORDER BY TotalPedidos DESC";

                database.setQuery(consulta);
                int id = database.execScalar();

                if (id == 0)
                {
                    return "Sin datos";
                }
                menuItemDatos manager = new menuItemDatos();
                dominio.MenuItem menu = new dominio.MenuItem();
                menu = manager.GetItem(id);
                
                

                return menu.Nombre;
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

        protected void btnMesasDia_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteMesasPedidosCerrados.aspx", false);
        }

        protected void btnItemDia_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteItemMasPedidoDiario.aspx", false);
        }

        protected void btnItemMes_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteItemMasPedidoMes.aspx", false);
        }

        protected void btnMesasMes_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporteMesasPedidosCerradosMensual.aspx", false);
        }
    }
}
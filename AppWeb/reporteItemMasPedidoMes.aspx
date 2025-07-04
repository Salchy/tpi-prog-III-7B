<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporteItemMasPedidoMes.aspx.cs" Inherits="AppWeb.reporteItemMasPedidoMes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</head>
<body class="bg-dark text-white">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="text-center">
                <h1>ITEM MAS VENDIDO EN EL MES</h1>
            </div>
            <div class="row ">
                <div class="col-md-4 text-center">
                    <img src="img/logo.png" class="img-fluid" style="max-height: 400px;" alt="Logo" />
                </div>
                <div class="col-md-4 text-center" style="margin-top: 50px; margin-left: 40px;">
                    <asp:GridView ID="dgvReporte" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" Height="100%">
                        <Columns>
                            <asp:BoundField HeaderText="Item" DataField="NombreMenu" />
                            <asp:BoundField HeaderText="Cantidad de pedidos" DataField="TotalPedidos" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-2">
                    <asp:Button Text="VOLVER A REPORTES" CssClass="btn btn-primary" runat="server" ID="btnVolver" OnClick="btnVolver_Click" Style="margin-top: 50px;" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>




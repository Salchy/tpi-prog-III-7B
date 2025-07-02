<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaReportes.aspx.cs" Inherits="AppWeb.gerenciaReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <%-- Ocupación de la sala --%>
        <div class="col-3">
            <div class="card text-bg-secondary mb-2" style="max-width: 18rem;">
                <div class="card-header">OCUPACIÓN DE MESAS</div>
                <div class="card-body">
                    <h5 class="card-title" id="ocupacionMesaCantidad" runat="server">0/0</h5>
                    <p class="card-text" id="ocupacionMesaCard" runat="server">Aún hay mesas disponibles</p>
                </div>
            </div>
        </div>
        <%-- Estado de ordenes --%>
        <div class="col-3">
            <div class="card text-bg-secondary mb-2" style="max-width: 18rem;">
                <div class="card-header">ORDENES ACTIVAS</div>
                <div class="card-body">
                    <h5 class="card-title" id="estadoOrdenesCantidad" runat="server">0</h5>
                    <p class="card-text" id="estadoOrdenesMensaje" runat="server">Platillos en cola</p>
                </div>
            </div>
        </div>
        <div class="col-5">
            <div class="card text-bg-secondary mb-2" style="max-width: 24rem;">
                <div class="card-header">MESA CON MAS PEDIDOS CERRADOS (DIARIO)</div>
                <div class="card-body">
                    <h5 class="card-title" id="PedidosCerrados" runat="server"></h5>
                    <a href="reporteMesasPedidosCerrados.aspx" style="text-decoration:underline;color:inherit;">MAS DETALLES</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

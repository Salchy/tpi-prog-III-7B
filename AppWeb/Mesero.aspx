<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Mesero.aspx.cs" Inherits="AppWeb.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mesas asignadas</h1>
    <asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="false">
        <Columns>   
            <asp:BoundField  HeaderText="Mesas asignadas" DataField="Numero" />
        </Columns>
    </asp:GridView>
    <h1>Pedido de la mesa</h1>
    <asp:GridView ID="dvgOrdenes" runat="server">
   </asp:GridView>
   
    <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregarOrden" OnClick="btnAgregarOrden_Click" runat="server" />
</asp:Content>

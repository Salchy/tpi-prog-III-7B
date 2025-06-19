<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Mesero.aspx.cs" Inherits="AppWeb.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pedido de la mesa</h1>
    <asp:GridView ID="dvgOrdenes" runat="server">
        <Columns>
            <asp:BoundField DataField="Orden.Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Menu" DataField="Menu.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Pecio" DataField="Menu.Precio" />
            <asp:BoundField HeaderText="Mesa" DataField="Pedido.Mesa.numeroMesa" />
        </Columns>
    </asp:GridView>
    <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregarOrden" OnClick="btnAgregarOrden_Click" runat="server" />
</asp:Content>

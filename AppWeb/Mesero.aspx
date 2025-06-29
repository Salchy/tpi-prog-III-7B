<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Mesero.aspx.cs" Inherits="AppWeb.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div> 
     <h1>Mesas asignadas</h1>
<asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnSelectedIndexChanged="dgvMesas_asignadas_SelectedIndexChanged" DataKeyNames="IdMesa">
    <Columns>
        <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
        <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
        <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Ver Pedido" />
    </Columns>
</asp:GridView>
</div>

<div> 
     <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregarOrden" OnClick="btnAgregarOrden_Click" runat="server" />
</div>
<div> 
    <h1>Pedido de la mesa</h1>
    <asp:GridView ID="dgvOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" DataKeyNames="id">
        <Columns>
            <asp:BoundField DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
            <asp:BoundField HeaderText="Menu" DataField="Menu.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Pecio" DataField="Menu.Precio" />

         </Columns>
    </asp:GridView>
</div>
   

</asp:Content>

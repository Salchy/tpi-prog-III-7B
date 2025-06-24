<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="mesas.aspx.cs" Inherits="AppWeb.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mesas asignadas</h1>
    <asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnSelectedIndexChanged="dgvMesas_asignadas_SelectedIndexChanged" DataKeyNames="IdMesa">
        <Columns>
            <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
            <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Ver Mesa" />
        </Columns>
    </asp:GridView>
</asp:Content>
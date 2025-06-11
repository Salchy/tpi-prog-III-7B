<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaCategorias.aspx.cs" Inherits="AppWeb.gerenciaCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvCategorias" runat="server" CssClass =" table" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField HeaderText="IDCategoria" DataField="Id" Visible="false"/>
            <asp:BoundField HeaderText="Nombre" DataField ="Nombre" />
            <asp:CommandField HeaderText ="Detalles" ShowSelectButton="true" SelectText="🔍 Ver detalles" />

        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAgregarCate" runat="server" Text="Agregar" OnClick="btnAgregarCate_Click" />
</asp:Content>

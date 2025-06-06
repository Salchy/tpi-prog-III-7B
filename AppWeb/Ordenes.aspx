<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="AppWeb.Ordenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Carga de Ordenes</h1>
    <h2>Categorias</h2>
    <asp:DropDownList ID="ddlCategoria" runat="server" ></asp:DropDownList>
    <h2>Menu disponible</h2>
    <asp:GridView ID="dgvMenu" runat="server"></asp:GridView>
    <asp:Label ID="lbCantidad" runat="server" Text="Cantidad"></asp:Label>
    <asp:TextBox ID="tbcCantidad" runat="server"></asp:TextBox>
    <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    <h2>Ordenes a asiignar</h2>
     <asp:GridView ID="dgvOrdenes" runat="server"></asp:GridView>
    <asp:Button Text="Enviar orden" CssClass="btn btn-primary btn-sm" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
    <asp:Button Text="Eliminar orden" CssClass="btn btn-primary btn-sm" ID="btnEliminarOrden" OnClick="btnEliminarOrden_Click" runat="server" />
    <asp:Button Text="Volver" CssClass="btn btn-primary btn-sm" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />
</asp:Content>

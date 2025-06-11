 <%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaMenu.aspx.cs" Inherits="AppWeb.gerenciaMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <asp:GridView ID="dgvMenu" CssClass="table" OnSelectedIndexChanged="dgvMenu_SelectedIndexChanged" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvMenu_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="IdMenuItem" DataField="IdMenuItem" Visible="false"/>
            <asp:BoundField HeaderText="Ítem" DataField="Nombre"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
            <asp:Boundfield HeaderText ="Categoria" Datafield="Categoria.Nombre"></asp:Boundfield>
            <asp:BoundField HeaderText ="Subcategoria" Datafield="SubCategoria.Nombre"></asp:BoundField>
            <asp:CommandField HeaderText ="Detalles" ShowSelectButton="true" SelectText="🔍 Ver detalles" />
        </Columns>
    </asp:GridView>
    <asp:Button Text="AGREGAR" ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
</asp:Content>

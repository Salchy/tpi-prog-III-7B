<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaSubCategorias.aspx.cs" Inherits="AppWeb.gerenciaSubCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvSubCate" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvSubCate_PageIndexChanging" OnRowCommand="dgvSubCate_RowCommand" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Categoria asociada" DataField="NombreCategoriaPadre" />
            <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" ControlStyle-CssClass="btn btn-info" />
            <asp:ButtonField ButtonType="Button" CommandName="Borrar" Text="Borrar" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

    <asp:Button Text="AGREGAR" ID="btnAgregarSub" runat="server" OnClick="btnAgregarSub_Click" />
</asp:Content>

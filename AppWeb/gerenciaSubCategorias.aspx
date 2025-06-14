<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaSubCategorias.aspx.cs" Inherits="AppWeb.gerenciaSubCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvSubCate" runat="server" AutoGenerateColumns="false" CssClass="table">
      <Columns>
           <asp:BoundField HeaderText="IDSubCategoria" DataField="Id"/>
            <asp:BoundField HeaderText="Nombre" DataField ="Nombre" />
          <asp:BoundField HeaderText="Categoria asociada" DataField ="NombreCategoriaPadre" />
            <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" ControlStyle-CssClass="btn btn-info" />
            <asp:ButtonField ButtonType="Button" CommandName="Borrar" Text="Borrar" ControlStyle-CssClass="btn btn-danger" />
      </Columns>
    </asp:GridView>
</asp:Content>

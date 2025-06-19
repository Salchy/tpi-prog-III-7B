<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaSubCategorias.aspx.cs" Inherits="AppWeb.gerenciaSubCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvSubCate" runat="server" AutoGenerateColumns="false" CssClass="table" AllowPaging="true" pageSize="10" OnPageIndexChanging ="dgvSubCate_PageIndexChanging" OnRowCommand="dgvSubCate_RowCommand">
      <Columns>
            <asp:BoundField HeaderText="Nombre" DataField ="Nombre" />
          <asp:BoundField HeaderText="Categoria asociada" DataField ="NombreCategoriaPadre" />
           <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <ItemTemplate>
                
                    <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-danger"
                        Visible='<%# (bool)Eval("Estado") == true %>' />

                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-success"
                        Visible='<%# (bool)Eval("Estado") == false %>' />
                </ItemTemplate>
            </asp:TemplateField>
      </Columns>
    </asp:GridView>

    <asp:Button Text="AGREGAR" ID="btnAgregarSub" runat="server" OnClick="btnAgregarSub_Click" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaCategorias.aspx.cs" Inherits="AppWeb.gerenciaCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" Height="100%" OnRowCommand="dgvCategorias_RowCommand" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvCategorias_PageIndexChanging" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <%--<asp:CommandField HeaderText ="Detalles" ShowSelectButton="true" SelectText="🔍 Ver detalles" />--%>

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

    <asp:Button ID="btnAgregarCate" runat="server" Text="AGREGAR" CssClass="btn btn-success" OnClick="btnAgregarCate_Click" />
</asp:Content>

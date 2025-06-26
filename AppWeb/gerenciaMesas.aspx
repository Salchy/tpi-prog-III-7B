<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaMesas.aspx.cs" Inherits="AppWeb.gerenciaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvMesas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnRowDataBound="dgvMesas_RowDataBound" DataKeyNames="IdMesa" OnRowCommand="dgvMesas_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="ID Mesa" DataField="IdMesa" />
            <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
            <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
            <asp:TemplateField HeaderText="Mesero Asignado">
                <ItemTemplate>
                    <asp:Label ID="lblMeseroAsignado" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAdministrar" runat="server" Text="Administrar" CommandName="management" CommandArgument='<%# Eval("IdMesa") %>' CssClass="btn btn-warning" />
                    <asp:Button ID="buttonDisable" runat="server" Text="Deshabilitar" CommandName="ToggleEstado" CommandArgument='<%# Eval("IdMesa") %>' CssClass="btn btn-danger" Visible='<%# (bool)Eval("Habilitado") == true %>' />
                    <asp:Button ID="buttonEnable" runat="server" Text="Habilitar" CommandName="ToggleEstado" CommandArgument='<%# Eval("IdMesa") %>' CssClass="btn btn-success" Visible='<%# (bool)Eval("Habilitado") == false %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button Text="Añadir Mesa" ID="btnAgregarMesa" runat="server" CssClass="btn btn-success" OnClick="btnAgregarMesa_Click" />
</asp:Content>

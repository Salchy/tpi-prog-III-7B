<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="mesas.aspx.cs" Inherits="AppWeb.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mesas asignadas</h1>
    <asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" DataKeyNames="IdMesa" OnRowCommand="dgvMesas_asignadas_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
            <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btbAbrirMesa" runat="server" Text="Abrir Mesa"
                        AccessKey CommandName="Abrir Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-success"
                        Visible='<%# (bool)Eval("Habilitado") == true %>' />

                    <asp:Button ID="btnCerraPedido" runat="server" Text="Cerrar Mesa"
                        CommandName="Cerrar Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-warning"
                        Visible='<%# (bool)Eval("Habilitado") == true %>' />

                    <asp:Button ID="btnEliminarPedido" runat="server" Text="Eliminar Pedido"
                        CommandName="Eliminar Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-danger"
                        Visible='<%# (bool)Eval("Habilitado") == true %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

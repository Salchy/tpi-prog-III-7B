<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaMesas.aspx.cs" Inherits="AppWeb.gerenciaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvMesas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnRowDataBound="dgvMesas_RowDataBound" DataKeyNames="IdMesa">
        <Columns>
            <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
            <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
            <asp:TemplateField HeaderText="Mesero Asignado">
                <ItemTemplate>
                    <asp:Label ID="lblMeseroAsignado" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

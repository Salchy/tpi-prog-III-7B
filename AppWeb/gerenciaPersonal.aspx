<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaPersonal.aspx.cs" Inherits="AppWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <asp:GridView ID="dataGridEmpleados" CssClass="table" runat="server" OnPageIndexChanging="dataGridEmpleados_PageIndexChanging" AutoGenerateColumns="false" OnRowEditing="dataGridEmpleados_RowEditing" OnRowDeleting="dataGridEmpleados_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="DNI" DataField="Dni" />

            <%--            
            <asp:ButtonField ButtonType="Button" CommandName="Modify" Text="Editar"/>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Borrar"/>
            --%>

            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:Button ID="addEmpleado" runat="server" CssClass="btn btn-primary" Text="Añadir Empleado" OnClick="addEmpleado_Click" />
</asp:Content>

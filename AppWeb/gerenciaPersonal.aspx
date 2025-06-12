<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaPersonal.aspx.cs" Inherits="AppWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <asp:GridView ID="dataGridEmpleados" CssClass="table" runat="server" OnPageIndexChanging="dataGridEmpleados_PageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="dataGridEmpleados_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="DNI" DataField="Dni" />
            <asp:BoundField HeaderText="Estado" DataField="Estado" />



            <%--            
                 <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            --%>


            <asp:ButtonField ButtonType="Button" CommandName="Modify" Text="Editar" ControlStyle-CssClass="btn btn-info" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Borrar" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:Button ID="addEmpleado" runat="server" CssClass="btn btn-success" Text="Añadir Empleado" OnClick="addEmpleado_Click" />
</asp:Content>

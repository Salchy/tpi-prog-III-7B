<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaAdministrarMesa.aspx.cs" Inherits="AppWeb.gerenciaAdministrarMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblTitle" runat="server">Añadir una mesa</asp:Label>
    </figure>
    <div class="container text-center">
        <div class="col">
            <label for="lblNombreMesa" class="form-label">Nombre Mesa</label>
            <asp:TextBox ID="txtNombreMesa" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="col-3 mb-6 mx-auto">
        <label for="perfil" class="form-label">Mesero Asignado</label>
        <asp:ListBox ID="listBoxEmpleados" runat="server" CssClass="form-control" SelectionMode="Single"></asp:ListBox>
    </div>
    <hr />
    <div>
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger col-3 mx-auto" Text="Cancelar" OnClick="btnCancel_Click" />
        <asp:Button ID="btnAccept" runat="server" CssClass="btn btn-success col-3 mx-auto" Text="Añadir mesa" OnClick="btnAccept_Click" />
    </div>
</asp:Content>

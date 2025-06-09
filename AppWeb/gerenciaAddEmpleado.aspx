<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaAddEmpleado.aspx.cs" Inherits="AppWeb.gerenciaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Registrar nuevo empleado</h2>
    <div class="container text-center">
        <div class="row g-3">
            <div class="col">
                <label for="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col">
                <label for="lblApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col">
                <label for="lblDNI" class="form-label">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="mb-6">
            <label for="perfil" class="form-label">Perfíl</label>
            <asp:DropDownList ID="dropDownPerfil" runat="server" CssClass="form-select" />
        </div>
        <hr/>
        <div>
            <asp:Button ID="regUserBTN" runat="server" CssClass="btn btn-success d-grid gap-2 col-6 mx-auto" Text="Añadir Empleado" OnClick="registrarUsuario" />
        </div>
    </div>
</asp:Content>

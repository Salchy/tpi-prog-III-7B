<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaPersonal.aspx.cs" Inherits="AppWeb.gerenciaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Registrar nuevo empleado</h2>
    <div class="container">
        <div class="row g-3">
            <div class="col">
                <label for="txtNombre" class="form-label">Nombre</label>
                <input type="text" class="form-control" placeholder="Nombre...">
            </div>
            <div class="col">
                <label for="txtApellido" class="form-label">Apellido</label>
                <input type="text" class="form-control" placeholder="Apellido...">
            </div>
            <div class="col">
                <label for="txtDNI" class="form-label">DNI</label>
                <input type="text" class="form-control" placeholder="DNI">
            </div>
        </div>
        <div class="mb-6">
            <label for="perfil" class="form-label">Perfíl</label>
            <asp:DropDownList ID="dropDownPerfil" runat="server" CssClass="form-select" />
        </div>
    </div>
</asp:Content>

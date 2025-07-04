﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaAddEmpleado.aspx.cs" Inherits="AppWeb.gerenciaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblTitle" runat="server">Registrar nuevo empleado</asp:Label>
    </figure>
    <asp:Panel runat="server" DefaultButton="regUserBTN">
        <div class="container text-center">
            <div class="row g-3">
                <div class="col">
                    <label for="lblNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorNombre" ForeColor="Red" Visible="false" runat="server" Style="font-size: 12px" />
                </div>
                <div class="col">
                    <label for="lblApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorApellido" ForeColor="Red" Visible="false" runat="server" Style="font-size: 12px" />
                </div>
                <div class="col">
                    <label for="lblDNI" class="form-label">DNI</label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorDNI" ForeColor="Red" Visible="false" runat="server" Style="font-size: 12px" />
                </div>
            </div>
            <div class="col-3 mb-6 mx-auto">
                <label for="perfil" class="form-label">Perfíl</label>
                <asp:DropDownList ID="dropDownPerfil" runat="server" CssClass="form-select" />
            </div>
            <hr />
            <div>
                <asp:Button ID="cancelBtn" runat="server" CssClass="btn btn-danger col-3 mx-auto" Text="Cancelar" OnClick="cancelRegistrarUsuario" />
                <asp:Button ID="regUserBTN" runat="server" CssClass="btn btn-success col-3 mx-auto" Text="Añadir Empleado" OnClick="btnRegistrarUsuario" />
            </div>
        </div>
        <asp:Literal ID="literal" runat="server"></asp:Literal>
    </asp:Panel>
</asp:Content>

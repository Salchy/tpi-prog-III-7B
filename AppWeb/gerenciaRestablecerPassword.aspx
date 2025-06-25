<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaRestablecerPassword.aspx.cs" Inherits="AppWeb.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="justify-content-center align-items-center">
    <div class="container m-3 text-center">
        <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblTitle" runat="server">Reestablecer contraseña</asp:Label>
        <h2></h2>
        <asp:Label CssClass="fs-6 fw-bold text-warning" ID="lblINfo" runat="server">Estas reestableciendo la contraseña del usuario: </asp:Label>
        <div class="mt-3">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control w-25 mx-auto mb-3" placeholder="Nueva contraseña"></asp:TextBox>
            <asp:Button ID="btnResetPassword" runat="server" Text="Reestablecer contraseña" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
    </div>
</div>
</asp:Content>

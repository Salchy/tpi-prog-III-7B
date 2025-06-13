<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaRestablecerPassword.aspx.cs" Inherits="AppWeb.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <asp:Button ID="btnResetPassword" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="Button1_Click" />
</asp:Content>

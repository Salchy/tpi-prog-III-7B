<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="text-center">
            <img src="img/logo.png" class="img-fluid" style="height: 200px" alt="...">
        </div>
        <div class="position-relative vh-100">
            <div class="position-absolute top-50 start-50 translate-middle">
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Usuario</label>
                    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="exampleInputPassword1">
                </div>
                <button type="submit" class="btn btn-primary">Iniciar Sesion</button>
            </div>
        </div>
    </main>
</asp:Content>

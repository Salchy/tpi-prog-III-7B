<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>RestoBar</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</head>
<body class="bg-dark text-white">
    <form id="form1" runat="server">
        <main>
            <div class="text-center">
                <img src="img/logo.png" class="img-fluid" style="height: 200px; width: 200px" alt="..." />
            </div>
            <div>
                <div class="position-absolute top-50 start-50 translate-middle">
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Usuario</label>
                        <asp:TextBox ID="txtBarDNI" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtBarPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3 position-relative">
                        <asp:Button ID="Button1" class="btn btn-primary position-relative bottom-0 start-50 translate-middle-x" runat="server" Text="Iniciar Sesion" OnClientClick="login" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
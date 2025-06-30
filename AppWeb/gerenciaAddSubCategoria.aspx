<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerenciaAddSubCategoria.aspx.cs" Inherits="AppWeb.gerenciaAddSubCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
</head>
<body class="bg-dark text-white">
    <form id="form1" runat="server">
        <div class="text-center">
            <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblTitle" runat="server">Registrar nueva Subcategoria</asp:Label>
        </div>
        <div class="container mt-5">
            <div class="row ">
                <div class="col-md-6 text-center">
                    <img src="img/logo.png" class="img-fluid" style="max-height: 400px;" alt="Logo" />
                </div>
                <div class="col-md-3">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                        <asp:Label ID="lblErrorSubCategoria" runat="server" ForeColor="Red" Visible="false" />

                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoriaPadre" class="form-label ">Categoria a la que pertenece</label>
                        <asp:DropDownList ID="ddlCategoriaPadre" runat="server" CssClass="form-select" />
                         <asp:Label ID="lblErrorDDL" runat="server" ForeColor="Red" Visible="false" />

                    </div>
                    <asp:Button Text="Agregar Categoria" ID="btnAceptarSubCate" runat="server" OnClick="btnAceptarSubCate_Click" CssClass="btn btn-success mx-auto" />
                    <asp:Button Text="Cancelar" ID="btnVolverSubCate" runat="server"  OnClick="btnVolverSubCate_Click" CssClass="btn btn-danger mx-auto"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

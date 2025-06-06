<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formItemMenu.aspx.cs" Inherits="AppWeb.formItemMenu" %>

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
        <div class="container mt-5">
            <div class="row ">
                <div class="col-6">

                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Item</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
                    </div>

                    <div class="mb-3">
                        <label for="ddlSubcategoria" class="form-label ">Subcategoría</label>
                        <asp:DropDownList ID="ddlSubcategoria" runat="server" CssClass="form-select" />
                    </div>

                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" />
                        <a href="gerenciaMenu.aspx">Cancelar</a>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>

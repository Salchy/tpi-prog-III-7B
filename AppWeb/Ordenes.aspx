<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="AppWeb.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scmCategorias" runat="server"></asp:ScriptManager>

    <h1>Carga de Ordenes</h1>

    <div class="=row">
        <div class="col">
            <h2>Mesa</h2>
            <asp:DropDownList ID="ddlMesaActiva" runat="server" OnSelectedIndexChanged="ddlMesaActiva_SelectedIndexChanged" AutoPostBack="true" class="btn btn-secondary dropdown-toggle">
            </asp:DropDownList>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h2>Menu disponible</h2>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
                        <asp:DropDownList ID="ddlCategoria" runat="server" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true" class="btn btn-secondary dropdown-toggle"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Subcategoria" runat="server" />
                        <asp:DropDownList ID="ddlSubCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCategoria_SelectedIndexChanged" class="btn btn-secondary dropdown-toggle"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:TextBox runat="server" ID="txtMenu" CssClass="form-control" placeholder="Menu" OnTextChanged="txtMenu_TextChanged" AutoPostBack="true" />
                    </div>
                </div>

            </div>

            <asp:GridView ID="dgvMenu" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMenu_SelectedIndexChanged" DataKeyNames="IdMenuItem">
                <Columns>
                    <asp:BoundField HeaderText="Menu" DataField="Nombre" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Stock" DataField="Stock" />
                    <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Seleccionar" />
                </Columns>
            </asp:GridView>

            <h2>Orden a agregar</h2>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Menu" runat="server" ID="lblMenu"></asp:Label>

                    </div>
                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>



    <div class="row">

        <div class="col-1">
            <div class="mb-3">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Agregar Orden" runat="server" CssClass="btn btn-primary" ID="btnAgregarOrden" OnClick="btnAgregarOrden_Click" />
            </div>
        </div>
    </div>



    <h2>Ordenes del Pedido</h2>

    <asp:GridView ID="dgvOrdenes" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Menu" DataField="Menu.Nombre" />
            <asp:BoundField HeaderText="Precio Unitario" DataField="Menu.Precio" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

        </Columns>

 
     </asp:GridView>
        
    
   
     <asp:Button Text="Pedidos" CssClass="btn btn-primary btn-sm" ID="btnPedidos" OnClick="btnPedidos_Click" runat="server" />
</asp:Content>

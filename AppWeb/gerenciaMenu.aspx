<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaMenu.aspx.cs" Inherits="AppWeb.gerenciaMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <div class="row">
        <div class ="col-2">
            <div class="mb-3">
                <asp:Label Text="Buscar por" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo">
                    <asp:ListItem Text="Ítem" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="SubCategoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Palabra clave" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" placeholder="Ingrese texto"/>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:Label Text="Estado" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado">
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-2 d-flex align-items-end">
            <div class="mb-3 w-100">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click"/>
            </div>
        </div>

        <div class ="col-2 d-flex align-items-end">
            <div class="mb-3 w-100">
                <asp:Button Text="Reestablecer filtros" runat="server"  CssClass="btn btn-primary" ID="btnLimpiarFiltros" OnClick="btnLimpiarFiltros_Click"/>
            </div>
        </div>
    </div>
    
        
   

    <asp:GridView ID="dgvMenu" CssClass="table table-dark table-striped" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvMenu_PageIndexChanging" OnRowCommand="dgvMenu_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Ítem" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre"></asp:BoundField>
            <asp:BoundField HeaderText="Subcategoria" DataField="SubCategoria.Nombre"></asp:BoundField>
            <asp:BoundField HeaderText="Stock" DataField="Stock"></asp:BoundField>


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# Eval("IdMenuItem") %>'
                        CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <ItemTemplate>
                

                    <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("IdMenuItem") %>'
                        CssClass="btn btn-danger"
                        Visible='<%# (bool)Eval("Estado") == true %>' />

                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("IdMenuItem") %>'
                        CssClass="btn btn-success"
                        Visible='<%# (bool)Eval("Estado") == false %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

   

    <asp:Button Text="AGREGAR" ID="btnAgregar" runat="server" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
</asp:Content>

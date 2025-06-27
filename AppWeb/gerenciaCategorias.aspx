<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaCategorias.aspx.cs" Inherits="AppWeb.gerenciaCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="panelCategorias" DefaultButton="btnBuscarCategorias">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Palabra clave" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" placeholder="Ingrese texto" />
            </div>
        </div>

        <div class="col-2">
            <div class="mb-3">
                <asp:Label Text="Estado" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlEstado">
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>


        <div class="col-2 d-flex align-items-end">
            <div class="mb-3 w-100">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscarCategorias" OnClick="btnBuscarCategorias_Click"/>
            </div>
        </div>

        <div class="col-2 d-flex align-items-end">
            <div class="mb-3 w-100">
                <asp:Button Text="Reestablecer filtros" runat="server" CssClass="btn btn-primary" ID="btnLimpiarFiltros" OnClick="btnLimpiarFiltros_Click"/>
            </div>

        </div>
    </div>
        </asp:Panel>



    <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" Height="100%" OnRowCommand="dgvCategorias_RowCommand" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvCategorias_PageIndexChanging" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <%--<asp:CommandField HeaderText ="Detalles" ShowSelectButton="true" SelectText="🔍 Ver detalles" />--%>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar"
                        CommandName="Editar"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-danger"
                        Visible='<%# (bool)Eval("Estado") == true %>' />

                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar"
                        CommandName="Estado"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-success"
                        Visible='<%# (bool)Eval("Estado") == false %>' />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAgregarCate" runat="server" Text="AGREGAR" CssClass="btn btn-success" OnClick="btnAgregarCate_Click" />
</asp:Content>

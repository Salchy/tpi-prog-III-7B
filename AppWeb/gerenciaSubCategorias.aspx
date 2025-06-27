<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaSubCategorias.aspx.cs" Inherits="AppWeb.gerenciaSubCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="panelSub" DefaultButton="btnBuscarSubCategorias">       
    <div class="row">
        <div class ="col-2">
            <div class="mb-3">
                <asp:Label Text="Buscar por" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCampo">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Categoria asociada" />
                </asp:DropDownList>
            </div>
        </div>

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
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscarSubCategorias" OnClick="btnBuscarSubCategorias_Click"/>
            </div>
        </div>

        <div class="col-2 d-flex align-items-end">
            <div class="mb-3 w-100">
                <asp:Button Text="Reestablecer filtros" runat="server" CssClass="btn btn-primary" ID="btnLimpiarFiltros" OnClick="btnLimpiarFiltros_Click"/>
            </div>

        </div>
    </div>
        </asp:Panel>

    <asp:GridView ID="dgvSubCate" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-striped" AllowPaging="true" pageSize="10" OnPageIndexChanging ="dgvSubCate_PageIndexChanging" OnRowCommand="dgvSubCate_RowCommand" >
      <Columns>
            <asp:BoundField HeaderText="Nombre" DataField ="Nombre" />
          <asp:BoundField HeaderText="Categoria asociada" DataField ="NombreCategoriaPadre" />
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

    <asp:Button Text="AGREGAR" ID="btnAgregarSub" runat="server" CssClass="btn btn-success" OnClick="btnAgregarSub_Click" />
</asp:Content>

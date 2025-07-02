<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="gerenciaPersonal.aspx.cs" Inherits="AppWeb.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
    <div class="mb-4">
        <asp:Panel runat="server">
            <div class="row d-flex align-items-center">
                <div class="col-3">
                    <div class="mb-3">
                        <div class="text-center">
                            <asp:Label Text="Buscar por" runat="server" />
                        </div>
                        <asp:DropDownList runat="server" CssClass="form-select" ID="dropDownFindParameter">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Apellido" />
                            <asp:ListItem Text="Nombre y Apelllido" />
                            <asp:ListItem Text="DNI" />
                            <asp:ListItem Text="Cargo" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-5">
                    <div class="mb-3">
                        <div class="text-center">
                            <asp:Label Text="Palabra clave" runat="server" />
                        </div>
                        <asp:TextBox runat="server" ID="textToFind" CssClass="form-control" placeholder="Ingrese la palabra a buscar" />
                    </div>
                </div>
                <div class="col-2">
                    <div class="mb-3">
                        <div class="text-center">
                            <asp:Label Text="Estado" runat="server" />
                        </div>
                        <asp:DropDownList runat="server" CssClass="form-select" ID="dropDownEstado">
                            <asp:ListItem Text="Habilitado" />
                            <asp:ListItem Text="Deshabilitado" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-2">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:GridView ID="dataGridEmpleados" CssClass="table table-dark table-striped" runat="server" OnPageIndexChanging="dataGridEmpleados_PageIndexChanging" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="dataGridEmpleados_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="DNI" DataField="Dni" />
                <asp:BoundField HeaderText="Cargo" DataField="NivelUsuario" />

                <%--
              <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                --%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Modify" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning" />
                        <asp:Button ID="btnRestorePassword" runat="server" Text="Reestablecer Contraseña" CommandName="RestorePassword" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-secondary" />

                        <asp:Button ID="Button1" runat="server" Text="Deshabilitar" CommandName="ToggleEstado" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" Visible='<%# (bool)Eval("Estado") == true %>' />
                        <asp:Button ID="Button2" runat="server" Text="Habilitar" CommandName="ToggleEstado" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" Visible='<%# (bool)Eval("Estado") == false %>' />


                        <%-- <asp:Button ID="btnHabilitar" runat="server" Text="Deshabilitar" CommandName="ToggleEstado" CommandArgument='<% Eval("Id") %>' CssClass="btn btn-danger" />
                 <asp:Button ID="btnDeshabilitar" runat="server" Text="Habilitar" CommandName="ToggleEstado" CommandArgument='<% Eval("Id") %>' CssClass="btn btn-success" />--%>

                        <%--<asp:Button ID="btnBorrar" runat="server" Text="Borrar" CommandName="Delete" CommandArgument='<% Eval("Id") %>' CssClass="btn btn-danger" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <hr />
    <asp:Button ID="addEmpleado" runat="server" CssClass="btn btn-success" Text="Añadir Empleado" OnClick="addEmpleado_Click" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="AppWeb.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        
        <div class="=row">

             <div class="text-center">
                 <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblMesaSelecionada" runat="server" Visible="true">Mesa</asp:Label>
             </div>

            <div class="col">
                <asp:DropDownList ID="ddlMesasAsignadas" runat="server" OnSelectedIndexChanged="ddlMesasAsignadas_SelectedIndexChanged" AutoPostBack="true" class="btn btn-secondary dropdown-toggle">
                </asp:DropDownList>
            </div>
        </div>
        <div class="=row">
            <div class="col">
                 <asp:Label ID="lblMesaSinPedido" runat="server" ForeColor="Red" Visible="false" Style="font-size: 30px;"/>
                 <asp:Button Text="Volver" runat="server" CssClass="btn btn-primary" ID="btnVolver" OnClick="btnVolver_Click" Visible="false" />
           </div>
        </div>
    </div>


    <div>
         <div class="text-center">
          <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblPedido" runat="server" Visible="true">Pedido de la mesa</asp:Label>
        </div>

        <asp:GridView ID="dgvOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" DataKeyNames="id" OnRowCommand="dgvOrdenes_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Menu" DataField="Menu.Nombre" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Pecio" DataField="Menu.Precio" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEliminarOrden" runat="server" Text="Eliminar"
                            CommandName="Eliminar Orden"
                            CommandArgument='<%# Eval("id") %>'
                            CssClass="btn btn-danger"
                            Visible='<%# (bool)Eval("Estado") == true %>' />

                        <asp:Button ID="btnModificarOrden" runat="server" Text="Modificar"
                            CommandName="Modificar Orden"
                            CommandArgument='<%# Eval("id") %>'
                            CssClass="btn btn-warning"
                            Visible='<%# (bool)Eval("Estado") == true %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

    <div class="row">
        <div class="text-center">
            <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblOrdenModificada" runat="server" Visible="true">Orden a modificar</asp:Label>
       </div>
        <div class="col-1">
            <div class="mb-3">
                <asp:Label Text="Menu" runat="server" ID="lblMenu" Visible="false"></asp:Label>
            </div>
        </div>

        <div class="col-1">
            <div class="mb-3">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad" ReadOnly="false" AutoPostBack="false"  Visible="false" ></asp:TextBox>
                <asp:Label ID="lblErrorCantidad" runat="server" ForeColor="Red" Visible="false" Style="font-size: 12px;" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Modificar Orden" runat="server" CssClass="btn btn-primary" ID="btnModificarOrden" OnClick="btnModificarOrden_Click"  Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>

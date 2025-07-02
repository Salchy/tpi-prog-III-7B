<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageGerencia.Master" AutoEventWireup="true" CodeBehind="mesas.aspx.cs" Inherits="AppWeb.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="text-center">
           <asp:Label CssClass="fs-2 fw-bold text-warning" ID="lblTitle" runat="server">Mesas Asignadas</asp:Label>
    </div>
    <asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" DataKeyNames="IdMesa" OnRowCommand="dgvMesas_asignadas_RowCommand" OnRowDataBound="dgvMesas_asignadas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
            <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAbrirMesa" runat="server" Text="Abrir Mesa"
                        CommandName="Abrir Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-success"
                        Visible="true" />  
                    
                   <asp:Button ID="btnCerraPedido" runat="server" Text="Cerrar Mesa"
                        CommandName="Cerrar Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-warning"
                        Visible="true"/>

                    <asp:Button ID="btnEliminarPedido" runat="server" Text="Eliminar Pedido"
                        CommandName="Eliminar Pedido"
                        CommandArgument='<%# Eval("IdMesa") %>'
                        CssClass="btn btn-danger"
                        Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="row">
        <div class="col-1">
        <div class="mb-3">
            <asp:Label Text="Numero de Comensales" runat="server" ID="lblComensales" Visible="false"></asp:Label>
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
            <asp:Button Text="Confirmar" runat="server" CssClass="btn btn-primary" ID="btnConfirmar" OnClick="btnConfirmar_Click"  Visible="false" />
        </div>
    </div>
</div>
</asp:Content>

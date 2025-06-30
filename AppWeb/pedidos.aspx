<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="AppWeb.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div> 
     <h1>Mesas asignadas</h1>
<asp:GridView ID="dgvMesas_asignadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnSelectedIndexChanged="dgvMesas_asignadas_SelectedIndexChanged" DataKeyNames="IdMesa" OnRowCommand="dgvMesas_asignadas_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
        <asp:BoundField HeaderText="Numero de Mesa" DataField="numeroMesa" />
        <asp:BoundField HeaderText="Comensales" DataField="numeroComensales" />
        <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Ver Pedido" />

        <asp:TemplateField>
           <ItemTemplate>
              <asp:Button ID="btnEliminarPedido" runat="server" Text="Cerrar Pedido"
                          CommandName="Cerrar Pedido"
                          CommandArgument='<%# Eval("IdMesa") %>'
                          CssClass="btn btn-danger"
                          Visible='<%# (bool)Eval("Habilitado") == true %>' />
          </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
</div>

<div> 
     <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregarOrden" OnClick="btnAgregarOrden_Click" runat="server" />
</div>
<div> 
    <h1>Pedido de la mesa</h1>
    <asp:GridView ID="dgvOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" DataKeyNames="id"  OnRowCommand="dgvOrdenes_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
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
    <div class="col-1">
       <div class="mb-3">
          <asp:Label Text= "Menu" runat="server" ID="lblMenu"></asp:Label>      
       </div>
   </div>

   <div class="col-1">
     <div class="mb-3">
        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad" ReadOnly="false" AutoPostBack="false" ></asp:TextBox>
     </div>
   </div>
  <div class="col-3">
    <div class="mb-3">
        <asp:Button Text="Modificar Orden" runat="server" CssClass="btn btn-primary" Id="btnModificarOrden" OnClick="btnModificarOrden_Click" />
    </div>
   </div>
 </div>

   

</asp:Content>

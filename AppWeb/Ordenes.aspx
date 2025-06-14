<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="AppWeb.Ordenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scmCategorias" runat="server" ></asp:ScriptManager>

    
      <h1>Carga de Ordenes</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>   
            <div class="=row">   
                <div class="col"">   
                    <h2>Categorias</h2>
                    <asp:DropDownList ID="ddlCategoria" runat="server"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true" >

                    </asp:DropDownList>
                </div>
                <div class="col"">   
                    <h2>SubCategorias</h2>
            <asp:DropDownList ID="ddlSubCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubCategoria_SelectedIndexChanged"></asp:DropDownList>
                </div>
                
    
                <h2>Menu disponible</h2>
<asp:GridView ID="dgvMenu" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
    <Columns>
    <asp:BoundField DataField="IdMenuItem" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
    <asp:BoundField HeaderText="Menu" DataField="Nombre" />
    <asp:BoundField HeaderText="Precio" DataField="Precio" />
    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        
 <asp:TemplateField>
     <HeaderTemplate> Cantidad</HeaderTemplate>
     <ItemTemplate>
         <asp:CheckBox Text="" ID="chkAgregar"  runat="server"  />
         <asp:TextBox runat="server" ID="txtCantiadFiltro" CssClass="form-control" />
                  </ItemTemplate>
</asp:TemplateField>
</Columns>

</asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button Text="Agregar Orden" CssClass="btn btn-primary btn-sm" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    <h2>Ordenes del Pedido</h2>
     <asp:GridView ID="dgvOrdenes" runat="server"></asp:GridView>
    <asp:Button Text="Enviar orden" CssClass="btn btn-primary btn-sm" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
    <asp:Button Text="Eliminar orden" CssClass="btn btn-primary btn-sm" ID="btnEliminarOrden" OnClick="btnEliminarOrden_Click" runat="server" />
    <asp:Button Text="Volver" CssClass="btn btn-primary btn-sm" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />
</asp:Content>

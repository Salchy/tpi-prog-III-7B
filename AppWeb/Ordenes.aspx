<%@ Page Title="" Language="C#" MasterPageFile="~/masterPageMesero.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="AppWeb.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scmCategorias" runat="server"></asp:ScriptManager>

    <h1>Carga de Ordenes</h1>

    <div class="=row">   
    <div class="col">   
        <h2>Mesa</h2>
        <asp:DropDownList ID="ddlMesaActiva" runat="server"  OnSelectedIndexChanged="ddlMesaActiva_SelectedIndexChanged" AutoPostBack="true" class="btn btn-secondary dropdown-toggle" >
                    </asp:DropDownList>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>   
                <h2>Menu disponible</h2>
                <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
                   <asp:DropDownList ID="ddlCategoria" runat="server"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true" class="btn btn-secondary dropdown-toggle" ></asp:DropDownList>
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
                 
                    <asp:TextBox runat="server" ID="txtMenu" CssClass="form-control" placeholder="Menu" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="Button1" />
                </div>
            </div>
        </div>
        
     
    </div>
             </div>
             </div>
             

  

<asp:GridView ID="dgvMenu" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMenu_SelectedIndexChanged" DataKeyNames="IdMenuItem"  >
    <Columns>
     <asp:BoundField HeaderText="Menu" DataField="Nombre" />
    <asp:BoundField HeaderText="Precio" DataField="Precio" />
    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        
    <asp:CommandField  ShowSelectButton="true" ButtonType="Button" SelectText="Seleccionar"/>
        
</Columns>

</asp:GridView>
            </div>
            <div class="row">
            <h2>Orden a agregar</h2> 
            <div class="col-3">
                <div class="mb-3">
                    <<label for="lblMenu" class="visually-hidden">Menu</label>
      <asp:TextBox ID="txtMenuSelecionado" runat="server" CssClass="form-control-plaintext"  ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                 
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad" ReadOnly="false"></asp:TextBox>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Agregar a Pedido" runat="server" CssClass="btn btn-primary" id="Button2" />
                </div>
            </div>
        </div>
             </div>
         <h2>Ordenes del Pedido</h2>     
     <asp:GridView ID="dgvOrdenes" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" >

             <Columns>
     <asp:BoundField HeaderText="Menu" DataField="Menu.Nombre" />
    <asp:BoundField HeaderText="Precio Unitario" DataField="Menu.Precio" />
    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
        
</Columns>

 
     </asp:GridView>
        </ContentTemplate>

   

    </asp:UpdatePanel>
    
   
    <asp:Button Text="Enviar orden" CssClass="btn btn-primary btn-sm" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
        <asp:Button Text="Volver" CssClass="btn btn-primary btn-sm" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />
</asp:Content>

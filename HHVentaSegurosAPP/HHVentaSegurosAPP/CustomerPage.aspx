<%@ Page Title="HH Ventas Seguros | Clientes" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="HHVentaSegurosAPP.Pages.CustomerPage" %>
<%@ MasterType VirtualPath="~/Index.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
      <div class="container-fluid">

          <%if (Convert.ToBoolean(ViewState["ShowAlert"]))
           {%>

          <div class="alert alert-default-primary d-flex justify-content-between" role="alert" >
          <asp:Label ID="alertMessage" Width="100%" runat="server"></asp:Label>
          <asp:Button ID="dissmisAlert" runat="server" class="btn btn-outline-primary" Text="×" type="button" OnClick="dissmisAlert_Click" UseSubmitBehavior="false" BorderStyle="None"/>
         
        </div>
         <%}%>

           <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Mantenimiento de clientes</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body d-flex justify-content-start flex-column">
                    <div class="form-group col-1">
                    <label for="exampleInputEmail1">Id</label>
                       <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="d-flex justify-content-start">
                      <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Nombre completo</label>
                           <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" ></asp:TextBox>
                      </div>
                        <div class="form-group col-3 mr-3">
                            <label for="exampleInputEmail1">Tipo de cedula</label>
                            <asp:DropDownList ID="cedulasList" runat="server" CssClass="form-control" ></asp:DropDownList>
                      </div>
                      <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Numero de cedula</label>
                          <asp:TextBox ID="txtNumCedula" runat="server" CssClass="form-control" Type="text"></asp:TextBox>

                      </div>
                    </div>
                    <div class="d-flex justify-content-start">
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Numero de telefono</label>
                          <asp:TextBox ID="txtNumTelefono" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                        </div>
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Correo electronico</label>
                          <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" Type="email"></asp:TextBox>

                      </div>

                           <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Creado Por</label>
                           <asp:TextBox ID="txtCreadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                      </div>
                        
                  </div>
                    <div class="d-flex justify-content-start">
                        
                         <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">ModificadoPor</label>
                          <asp:TextBox ID="txtModificadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>

                      </div>
                  </div>
                </div>

              

                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNewCustomer" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNewCustomer_Click"/>
                    <asp:Button ID="btnSaveCustomer" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnSaveCustomer_Click"/>
                </div>
            </div>


        <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged" OnRowDeleting="grdClientes_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="IdCliente" HeaderText="Id Cliente"/>
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"/>
                <asp:BoundField DataField="TipoCedula" HeaderText="Tipo Cedula"/>
                <asp:BoundField DataField="NumeroCedula"  HeaderText="Numero Cedula"/>
                <asp:BoundField DataField="NumeroTelefono"  HeaderText="Numero tel."/>
                <asp:BoundField DataField="CorreoElectronico"  HeaderText="Correo"/>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="true" ShowDeleteButton="true" SelectText="Editar" ItemStyle-Width="200px"/>
                
            </Columns>
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

<%@ Page Title="HH Ventas Seguros | Servicios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ServicePage.aspx.cs" Inherits="HHVentaSegurosAPP.ServicePage" %>
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
                <h3 class="card-title">Mantenimiento de Servicios</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body d-flex justify-content-start flex-column">
                    <div class="form-group col-1">
                    <label for="exampleInputEmail1">Id</label>
                       <asp:TextBox ID="txtIdServicio" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="d-flex justify-content-start">
                      <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Tipo Servicio</label>
                           <asp:TextBox ID="txtTipoServicio" runat="server" CssClass="form-control" ></asp:TextBox>
                      </div>
                      <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Precio en Colones</label>
                          <asp:TextBox ID="txtPrecioColones" runat="server" CssClass="form-control" Type="text"></asp:TextBox>

                      </div>

                    </div>
                    <div class="d-flex justify-content-start">
                      <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Creado Por</label>
                           <asp:TextBox ID="txtCreadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                      </div>
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">ModificadoPor</label>
                          <asp:TextBox ID="txtModificadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>

                      </div>

                    </div>
                  </div>
                    
                </div>

             

                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNuevoServicio" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNuevoServicio_Click"/>
                    <asp:Button ID="btnGuardarServicio" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnGuardarServicio_Click"/>
                </div>
            </div>


        <asp:GridView ID="grdServicio" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered" OnSelectedIndexChanged="grdServicio_SelectedIndexChanged" OnRowDeleting="grdServicio_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="idServicio" HeaderText="Id Servicio"/>
                <asp:BoundField DataField="tipoServicio" HeaderText="Tipo de Seguro"/>
                <asp:BoundField DataField="precioColones" HeaderText="Precio en Colones"/>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="true" ShowDeleteButton="true" SelectText="Editar" ItemStyle-Width="200px"/>
                
            </Columns>
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

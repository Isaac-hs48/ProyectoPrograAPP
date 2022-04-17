<%@ Page Title="HH Ventas Seguros | Ventas" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="SalePage.aspx.cs" Inherits="HHVentaSegurosAPP.SalePage" %>
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
                <h3 class="card-title">Mantenimiento de Ventas</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body d-flex justify-content-start flex-column">
                    <div class="form-group col-1">
                    <label for="exampleInputEmail1">Id</label>
                       <asp:TextBox ID="txtIdVenta" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="d-flex justify-content-start">
                      <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Servicio</label>
                           <%--<asp:TextBox ID="txtIdServicio" runat="server" CssClass="form-control" ></asp:TextBox>--%>
                          <asp:DropDownList ID="servicesList" runat="server" CssClass="form-control" OnLoad="ServicesList_SelectedIndexChanged" OnSelectedIndexChanged="ServicesList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      </div>
                      <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Cliente</label>
                          <%--<asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" Type="text"></asp:TextBox>--%>
                          <asp:DropDownList ID="customerList" runat="server" CssClass="form-control" ></asp:DropDownList>
                    </div>
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Identificacion</label>
                          <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                    </div>
                        </div>
                    
                    <div class="d-flex justify-content-start">
                        <div class="form-group col-3 mr-3">
                        <label for="exampleInputPassword1">Total en Colones</label>
                           <asp:TextBox ID="txtTotalColones" runat="server" CssClass="form-control" Type="text" ></asp:TextBox>
                      </div>
                         <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Creado Por</label>
                           <asp:TextBox ID="txtCreadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                      </div>
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">ModificadoPor</label>
                          <asp:TextBox ID="txtModificadoPor" runat="server" CssClass="form-control" Type="text"></asp:TextBox>

                      </div>
                </div>

                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNuevaVenta" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNuevaVenta_Click"/>
                    <asp:Button ID="btnGuardarVenta" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnGuardarVenta_Click"/>
                </div>
            </div>
               </div>


        <asp:GridView ID="grdVenta" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered" OnSelectedIndexChanged="grdVenta_SelectedIndexChanged" OnRowDeleting="grdVenta_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="idVenta" HeaderText="Id Venta"/>
                <asp:BoundField DataField="idServicio" HeaderText="Id Servicio"/>
                <asp:BoundField DataField="idCliente" HeaderText="Id Cliente"/>
                <asp:BoundField DataField="identificacion" HeaderText="Identificacion"/>
                <asp:BoundField DataField="totalColones" HeaderText="Total en Colones"/>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="true" ShowDeleteButton="true" SelectText="Editar" ItemStyle-Width="200px"/>
                
            </Columns>
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

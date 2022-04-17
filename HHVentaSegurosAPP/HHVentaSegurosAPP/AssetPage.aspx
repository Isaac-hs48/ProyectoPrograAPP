<%@ Page Title="HH Ventas Seguros | Activos" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="AssetPage.aspx.cs" Inherits="HHVentaSegurosAPP.AssetPage" %>
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
                <h3 class="card-title">Mantenimiento de Activos</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body d-flex justify-content-start flex-column">
                    <div class="form-group col-1">
                    <label for="exampleInputEmail1">Id</label>
                       <asp:TextBox ID="txtIdActivo" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="d-flex justify-content-start">
                      <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Descripcion</label>
                           <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ></asp:TextBox>
                      </div>
                      <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Precio en Colones</label>
                          <asp:TextBox ID="txtPrecioColones" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                    </div>
                        <div class="form-group col-3 mr-3" >
                        <label for="exampleInputPassword1">Vida Util Años</label>
                          <asp:TextBox ID="txtVidaUtilAnos" runat="server" CssClass="form-control" Type="text"></asp:TextBox>
                    </div>
                    </div>
                    <div class="d-flex justify-content-start">
                        <div class="form-group col-3 mr-3">
                        <label for="exampleInputEmail1">Valor Desecho Colones</label>
                           <asp:TextBox ID="txtValorDesechoColones" runat="server" CssClass="form-control" ></asp:TextBox>
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
                    
                </div>

                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNuevoActivo" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNuevoActivo_Click"/>
                    <asp:Button ID="btnGuardarActivo" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnGuardarActivo_Click"/>
                </div>
            </div>


        <asp:GridView ID="grdActivo" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered" OnSelectedIndexChanged="grdActivo_SelectedIndexChanged" OnRowDeleting="grdActivo_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="idActivo" HeaderText="Id Activo"/>
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion"/>
                <asp:BoundField DataField="precioColones" HeaderText="Precio Colones"/>
                <asp:BoundField DataField="vidaUtilAnos" HeaderText="Vida Util Años"/>
                <asp:BoundField DataField="valorDesechoColones" HeaderText="Valor Desecho Colones"/>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="true" ShowDeleteButton="true" SelectText="Editar" ItemStyle-Width="200px"/>    
                <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ControlStyle-CssClass="btn btn-primary" ID="btnDepreciacion" runat="server" Text="Depreciacion" OnClick="btnDepreciacion_Click"/>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

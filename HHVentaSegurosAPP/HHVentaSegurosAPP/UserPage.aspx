<%@ Page Title="HH Venta Seguros | Usuarios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="HHVentaSegurosAPP.UserPage" %>
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
                <h3 class="card-title">Mantenimiento de usuarios</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body d-flex justify-content-between">
                    <div class="form-group col-1">
                    <label for="exampleInputEmail1">Id</label>
                       <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                  <div class="form-group col-3">
                    <label for="exampleInputEmail1">Nombre completo</label>
                       <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="form-group col-3">
                    <label for="exampleInputEmail1">Nombre usuario</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                  <div class="form-group col-3" >
                    <label for="exampleInputPassword1">Contraseña</label>
                      <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" Type="password"></asp:TextBox>

                  </div>
                </div>

                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNewUser" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNewUser_Click"/>
                    <asp:Button ID="btnSaveUser" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnSaveUser_Click"/>
                </div>
            </div>


        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged" OnRowDeleting="grdUsuarios_RowDeleting"> 
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Id Usuario"/>
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"/>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario"/>
                <asp:BoundField DataField="Contrasena"  HeaderText="Contraseña"/>
                <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowSelectButton="true" ShowDeleteButton="true" SelectText="Editar" ItemStyle-Width="200px"/>
                
            </Columns>
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

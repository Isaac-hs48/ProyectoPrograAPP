<%@ Page Title="HH Venta Seguros | Usuarios" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="HHVentaSegurosAPP.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Usuarios</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item">Inicio</li>
              <li class="breadcrumb-item active">
                  Usuarios
              </li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>


     <section class="content">
      <div class="container-fluid">
           <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Mantenimiento de usuarios</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form>
                <div class="card-body d-flex justify-content-between">
                  <div class="form-group col-3">
                    <label for="exampleInputEmail1">Nombre completo</label>
                       <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                    <div class="form-group col-3">
                    <label for="exampleInputEmail1">Nombre usuario</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                  <div class="form-group col-3">
                    <label for="exampleInputPassword1">Contraseña</label>
                      <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" ></asp:TextBox>
                  </div>
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                  <asp:Button ID="btnNewUser" runat="server" Text="Nuevo"  CssClass="btn btn-primary" OnClick="btnNewUser_Click"/>
                    <asp:Button ID="btnSaveUser" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnSaveUser_Click"/>
                </div>
              </form>
            </div>


        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Id Usuario"/>
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"/>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario"/>
                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelectUser" runat="server" Text="Editar"  CssClass="btn btn-warning" OnClick="btnSelectUser_Click"/>
                        <asp:Button ID="btnDeleteUser" runat="server" Text="Eliminar"  CssClass="btn btn-danger" OnClick="btnDeleteUser_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

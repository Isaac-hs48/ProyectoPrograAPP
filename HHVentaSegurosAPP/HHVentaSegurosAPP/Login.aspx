<%@ Page Title="HH Venta Seguros | Login" Language="C#"  MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HHVentaSegurosAPP.Login" %>
<%@ MasterType VirtualPath="~/Index.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <div class="row h-100 justify-content-center align-items-center" style="margin-top: 100px !important;">
                <div class="col-3">

                <div class="card card-primary ">
                      <div class="card-header">
                        <h3 class="card-title">Inicio de sesion</h3>
                      </div>
                      <!-- /.card-header -->
                      <!-- form start -->
                        <div class="card-body">
                          <div class="form-group">
                            <label for="exampleInputEmail1">Nombre de usuario</label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <label for="exampleInputPassword1">Contraseña</label>
                              <asp:TextBox ID="txtContrasena" Type="password" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                        <!-- /.card-body -->

                        <div class="card-footer">
                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesion" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click"/>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
           
</asp:Content>

<%@ Page Title="HH Ventas Seguros | Depreciacion" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="DepreciacionPage.aspx.cs" Inherits="HHVentaSegurosAPP.DepreciacionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
      <div class="container-fluid">
          
          <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Depreciacion de Activo</h3>
              </div>
              <asp:GridView ID="grdDepreciacion" runat="server" AutoGenerateColumns="false" PageSize="20" CssClass="table table-bordered"> 
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                <asp:BoundField DataField="Ano" HeaderText="Año"/>
                <asp:BoundField DataField="Depreciacion" HeaderText="Depreciacion"/>
                <asp:BoundField DataField="idActivo" HeaderText="IdActivo"/>
                </Columns>
            
        </asp:GridView>
          <div class="card-footer">
              <asp:Button ID="btnBack" runat="server" Text="Volver" CssClass="btn btn-primary" OnClick="btnBack_Click"/>
          </div>
            </div>
      </div><!-- /.container-fluid -->
    </section>
</asp:Content>

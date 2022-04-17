using HHVentaSegurosAPP.Services;
using HHVentaSegurosAPP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP.Pages
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.ClsCliente[] customers = CustomerService.GetCustomers();
            grdClientes.DataSource = null;
            grdClientes.DataBind();
            grdClientes.DataSource = customers;
            grdClientes.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                InitVariables();
                FillDataGrid();
                ViewState["Mode"] = 'C';
                ViewState["ShowAlert"] = false;
                cedulasList.DataSource = null;
                cedulasList.DataBind();
                cedulasList.DataSource = new string[] { "Fisica", "Juridica" };
                cedulasList.DataBind();
            }
        }
        private void InitVariables()
        {
            btnSaveCustomer.Enabled = false;
            txtCorreo.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtIdCliente.Enabled = false;
            txtNumCedula.Enabled = false;
            txtNumTelefono.Enabled = false;
            cedulasList.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnSaveCustomer.Enabled = enabled;
            txtCorreo.Enabled = enabled;
            txtNombreCompleto.Enabled = enabled;
            txtNumCedula.Enabled = enabled;
            txtNumTelefono.Enabled = enabled;
            cedulasList.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtCorreo.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
            txtNumCedula.Text = string.Empty;
            txtNumTelefono.Text = string.Empty;
        }


        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = CustomerService.InsertCustomer(txtNombreCompleto.Text, cedulasList.SelectedValue, txtNumCedula.Text, txtNumTelefono.Text, txtCorreo.Text, Master.currUser.IdUsuario);
            }
            else
            {
                message = CustomerService.UpdateCustomer(Convert.ToInt32(txtIdCliente.Text), txtNombreCompleto.Text, cedulasList.SelectedValue, txtNumCedula.Text, txtNumTelefono.Text, txtCorreo.Text, Master.currUser.IdUsuario);
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdClientes.SelectedRow;

            txtIdCliente.Text = selectedRow.Cells[0].Text;
            txtNombreCompleto.Text = selectedRow.Cells[1].Text;
            cedulasList.SelectedValue = selectedRow.Cells[2].Text;
            txtNumCedula.Text = selectedRow.Cells[3].Text;
            txtNumTelefono.Text = selectedRow.Cells[4].Text;
            txtCorreo.Text = selectedRow.Cells[5].Text;
            SetAuditoryField(Convert.ToInt32(selectedRow.Cells[0].Text));
            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(grdClientes.Rows[e.RowIndex].Cells[0].Text);

            string message = CustomerService.DeleteCustomer(customerId);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }

        protected void SetAuditoryField(int id)
        {
            WSHHVentaSeguros.ClsCliente[] customers = CustomerService.GetCustomers();
            WSHHVentaSeguros.ClsUsuario[] users = UserService.GetUsers();

            int idCreadoPor = customers.FirstOrDefault(i => i.IdCliente == id).IdCreadoPor;
            int idModicicadoPor = customers.FirstOrDefault(i => i.IdCliente == id).IdModificadoPor;

            txtCreadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idCreadoPor)?.NombreUsuario ?? string.Empty;
            txtModificadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idModicicadoPor)?.NombreUsuario ?? string.Empty;
        }
    }
}
using HHVentaSegurosAPP.Services;
using HHVentaSegurosAPP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP
{
    public partial class SupplierPage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.ClsProveedor[] suppliers = SupplierService.GetSuppliers();
            grdProveedor.DataSource = null;
            grdProveedor.DataBind();
            grdProveedor.DataSource = suppliers;
            grdProveedor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            btnSaveProveedor.Enabled = false;
            txtCorreo.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtIdProveedor.Enabled = false;
            txtNumCedula.Enabled = false;
            txtNumTelefono.Enabled = false;
            cedulasList.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnSaveProveedor.Enabled = enabled;
            txtCorreo.Enabled = enabled;
            txtNombreCompleto.Enabled = enabled;
            txtNumCedula.Enabled = enabled;
            txtNumTelefono.Enabled = enabled;
            cedulasList.Enabled = enabled;
            txtDescripcion.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtCorreo.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtIdProveedor.Text = string.Empty;
            txtNumCedula.Text = string.Empty;
            txtNumTelefono.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNewSupplier_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = SupplierService.InsertSupplier(txtNombreCompleto.Text, cedulasList.SelectedValue, txtNumCedula.Text, txtNumTelefono.Text, txtCorreo.Text, txtDescripcion.Text, Master.currUser.IdUsuario);
            }
            else
            {
                message = SupplierService.UpdateSupplier(Convert.ToInt32(txtIdProveedor.Text), txtNombreCompleto.Text, cedulasList.SelectedValue, txtNumCedula.Text, txtNumTelefono.Text, txtCorreo.Text,txtDescripcion.Text, Master.currUser.IdUsuario);
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void grdProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdProveedor.SelectedRow;

            txtIdProveedor.Text = selectedRow.Cells[0].Text;
            txtNombreCompleto.Text = selectedRow.Cells[1].Text;
            cedulasList.SelectedValue = selectedRow.Cells[2].Text;
            txtNumCedula.Text = selectedRow.Cells[3].Text;
            txtNumTelefono.Text = selectedRow.Cells[4].Text;
            txtCorreo.Text = selectedRow.Cells[5].Text;
            txtDescripcion.Text = selectedRow.Cells[6].Text;

            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdProveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SupplierId = Convert.ToInt32(grdProveedor.Rows[e.RowIndex].Cells[0].Text);

            string message = SupplierService.DeleteSupplier(SupplierId);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }
    }
}
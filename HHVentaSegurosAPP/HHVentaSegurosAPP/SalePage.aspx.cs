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
    public partial class SalePage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.clsVenta[] sales = SaleService.GetSales();
            grdVenta.DataSource = null;
            grdVenta.DataBind();
            grdVenta.DataSource = sales;
            grdVenta.DataBind();
        }
        private void InitVariables()
        {
            btnGuardarVenta.Enabled = false;
            txtIdVenta.Enabled = false;
            txtIdServicio.Enabled = false;
            txtIdCliente.Enabled = false;
            txtIdentificacion.Enabled = false;
            txtTotalColones.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnGuardarVenta.Enabled = enabled;
            txtIdServicio.Enabled = false;
            txtIdCliente.Enabled = false;
            txtIdentificacion.Enabled = false;
            txtTotalColones.Enabled = false;
        }

        private void ClearInputs()
        {
            txtIdVenta.Enabled = false;
            txtIdServicio.Enabled = false;
            txtIdCliente.Enabled = false;
            txtIdentificacion.Enabled = false;
            txtTotalColones.Enabled = false;
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = SaleService.InsertSale((Convert.ToInt32(txtIdServicio.Text)), Convert.ToInt32(txtIdCliente.Text), txtIdentificacion.Text, Convert.ToInt32(txtTotalColones.Text), Convert.ToInt32(txtIdCreadoPor.Text));
            }
            else
            {
                message = SaleService.UpdateSale(Convert.ToInt32(txtIdVenta.Text), (Convert.ToInt32(txtIdServicio.Text)), Convert.ToInt32(txtIdCliente.Text), txtIdentificacion.Text, Convert.ToInt32(txtTotalColones.Text), Convert.ToInt32(txtIdModificadoPor.Text));
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void grdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdVenta.SelectedRow;

            txtIdVenta.Text = selectedRow.Cells[0].Text;
            txtIdServicio.Text = selectedRow.Cells[1].Text;
            txtIdCliente.Text = selectedRow.Cells[2].Text;
            txtIdentificacion.Text = selectedRow.Cells[3].Text;
            txtTotalColones.Text = selectedRow.Cells[4].Text;

            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idVenta = Convert.ToInt32(grdVenta.Rows[e.RowIndex].Cells[0].Text);

            string message = SaleService.DeleteSale(idVenta);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }
    }
}
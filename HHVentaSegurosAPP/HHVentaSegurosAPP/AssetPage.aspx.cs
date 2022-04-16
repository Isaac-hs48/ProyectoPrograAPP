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
    public partial class AssetPage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.clsActivo[] assets = AssetService.GetAsset();
            grdActivo.DataSource = null;
            grdActivo.DataBind();
            grdActivo.DataSource = assets;
            grdActivo.DataBind();
        }
        private void InitVariables()
        {
            btnGuardarActivo.Enabled = false;
            txtIdActivo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecioColones.Enabled = false;
            txtVidaUtilAnos.Enabled = false;
            txtValorDesechoColones.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnGuardarActivo.Enabled = enabled;
            txtDescripcion.Enabled = false;
            txtPrecioColones.Enabled = false;
            txtVidaUtilAnos.Enabled = false;
            txtValorDesechoColones.Enabled = false;
        }

        private void ClearInputs()
        {
            txtIdActivo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecioColones.Enabled = false;
            txtVidaUtilAnos.Enabled = false;
            txtValorDesechoColones.Enabled = false;
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNuevoActivo_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnGuardarActivo_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = AssetService.InsertAsset(txtDescripcion.Text, Convert.ToInt32(txtPrecioColones.Text), Convert.ToInt32(txtVidaUtilAnos.Text), Convert.ToInt32(txtValorDesechoColones.Text), Convert.ToInt32(txtIdCreadoPor.Text));
            }
            else
            {
                message = AssetService.UpdateAsset(Convert.ToInt32(txtIdActivo.Text), txtDescripcion.Text, Convert.ToInt32(txtPrecioColones.Text), Convert.ToInt32(txtVidaUtilAnos.Text), Convert.ToInt32(txtValorDesechoColones.Text), Convert.ToInt32(txtIdModificadoPor.Text));
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void grdActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdActivo.SelectedRow;

            txtIdActivo.Text = selectedRow.Cells[0].Text;
            txtDescripcion.Text = selectedRow.Cells[1].Text;
            txtPrecioColones.Text = selectedRow.Cells[2].Text;
            txtVidaUtilAnos.Text = selectedRow.Cells[3].Text;
            txtValorDesechoColones.Text = selectedRow.Cells[4].Text;

            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdActivo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idActivo = Convert.ToInt32(grdActivo.Rows[e.RowIndex].Cells[0].Text);

            string message = AssetService.DeleteAsset(idActivo);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }
    }
}
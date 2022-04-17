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
        public static WSHHVentaSeguros.clsActivo AssetForDepreciation { get; set; }
        public static bool ShowDeprecation { get; set; }
        private void FillDataGrid()
        {
            WSHHVentaSeguros.clsActivo[] assets = AssetService.GetAsset();
            grdActivo.DataSource = null;
            grdActivo.DataBind();
            grdActivo.DataSource = assets;
            grdActivo.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowDeprecation = false;
                InitVariables();
                FillDataGrid();
                ViewState["Mode"] = 'C';
                ViewState["ShowAlert"] = false;
            }
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
            txtDescripcion.Enabled = enabled;
            txtPrecioColones.Enabled = enabled;
            txtVidaUtilAnos.Enabled = enabled;
            txtValorDesechoColones.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtIdActivo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecioColones.Text = string.Empty;
            txtVidaUtilAnos.Text = string.Empty;
            txtValorDesechoColones.Text = string.Empty;
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
                message = AssetService.InsertAsset(txtDescripcion.Text, Convert.ToInt32(txtPrecioColones.Text), Convert.ToInt32(txtVidaUtilAnos.Text), Convert.ToInt32(txtValorDesechoColones.Text), Master.currUser.IdUsuario);
            }
            else
            {
                message = AssetService.UpdateAsset(Convert.ToInt32(txtIdActivo.Text), txtDescripcion.Text, Convert.ToInt32(txtPrecioColones.Text), Convert.ToInt32(txtVidaUtilAnos.Text), Convert.ToInt32(txtValorDesechoColones.Text), Master.currUser.IdUsuario);
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
            SetAuditoryField(Convert.ToInt32(selectedRow.Cells[0].Text));
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

        protected void btnDepreciacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)Convert.ChangeType(sender, typeof(Button));

            int btnIndex = Convert.ToInt32(btn.ClientID.Substring(btn.ClientID.Length - 1 , 1));

            int idActivo = Convert.ToInt32(grdActivo.Rows[btnIndex].Cells[0].Text);

            Response.Redirect($"DepreciacionPage.aspx?idActivo={idActivo}");
        }

        protected void SetAuditoryField(int id)
        {
            WSHHVentaSeguros.clsActivo[] activos = AssetService.GetAsset();
            WSHHVentaSeguros.ClsUsuario[] users = UserService.GetUsers();

            int idCreadoPor = activos.FirstOrDefault(i => i.idActivo == id).IdCreadoPor;
            int idModicicadoPor = activos.FirstOrDefault(i => i.idActivo == id).IdModificadoPor;

            txtCreadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idCreadoPor)?.NombreUsuario ?? string.Empty;
            txtModificadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idModicicadoPor)?.NombreUsuario ?? string.Empty;
        }
    }
}
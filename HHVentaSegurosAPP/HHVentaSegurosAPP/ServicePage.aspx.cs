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
    public partial class ServicePage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.clsServicio[] services = ServicesService.GetServices();
            grdServicio.DataSource = null;
            grdServicio.DataBind();
            grdServicio.DataSource = services;
            grdServicio.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitVariables();
                FillDataGrid();
                ViewState["Mode"] = 'C';
                ViewState["ShowAlert"] = false;
            }
        }
        
        private void InitVariables()
        {
            btnGuardarServicio.Enabled = false;
            txtIdServicio.Enabled = false;
            txtPrecioColones.Enabled = false;
            txtTipoServicio.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnGuardarServicio.Enabled = enabled;
            txtPrecioColones.Enabled = enabled;
            txtTipoServicio.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtIdServicio.Text = string.Empty;
            txtPrecioColones.Text = string.Empty;
            txtTipoServicio.Text = string.Empty;
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = ServicesService.InsertService(txtTipoServicio.Text, (Convert.ToInt32(txtPrecioColones.Text)), Master.currUser.IdUsuario);
            }
            else
            {
                message = ServicesService.UpdateService(Convert.ToInt32(txtIdServicio.Text), txtTipoServicio.Text, Convert.ToInt32(txtPrecioColones.Text), Master.currUser.IdUsuario);
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void grdServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdServicio.SelectedRow;

            txtIdServicio.Text = selectedRow.Cells[0].Text;
            txtTipoServicio.Text = selectedRow.Cells[1].Text;
            txtPrecioColones.Text = selectedRow.Cells[2].Text;
            SetAuditoryField(Convert.ToInt32(selectedRow.Cells[0].Text));
            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdServicio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idServicio = Convert.ToInt32(grdServicio.Rows[e.RowIndex].Cells[0].Text);

            string message = ServicesService.DeleteService(idServicio);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }

        protected void SetAuditoryField(int id)
        {
            WSHHVentaSeguros.clsServicio[] services = ServicesService.GetServices();
            WSHHVentaSeguros.ClsUsuario[] users = UserService.GetUsers();

            int idCreadoPor = services.FirstOrDefault(i => i.idServicio == id).IdCreadoPor;
            int idModicicadoPor = services.FirstOrDefault(i => i.idServicio == id).IdModificadoPor;

            txtCreadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idCreadoPor)?.NombreUsuario ?? string.Empty;
            txtModificadoPor.Text = users.FirstOrDefault(u => u.IdUsuario == idModicicadoPor)?.NombreUsuario ?? string.Empty;
        }
    }
}
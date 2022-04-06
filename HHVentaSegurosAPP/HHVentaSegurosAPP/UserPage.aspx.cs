using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HHVentaSegurosAPP.Services;
using HHVentaSegurosAPP.Shared;

namespace HHVentaSegurosAPP
{
    public partial class UserPage : System.Web.UI.Page
    {
        private void FillDataGrid()
        {
            WSHHVentaSeguros.ClsUsuario[] users = UserService.GetUsers();
            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();
            grdUsuarios.DataSource = users;
            grdUsuarios.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                InitVariables();
                FillDataGrid();
                ViewState["Mode"] = 'C';
                ViewState["ShowAlert"] = false;
            }
        }

        private void InitVariables()
        {
            btnSaveUser.Enabled = false;
            txtContrasena.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtIdUsuario.Enabled = false;
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if(ViewState["Mode"].ToString() == "C")
            {
                message = UserService.CreateUser(txtNombreCompleto.Text, txtNombreUsuario.Text, txtContrasena.Text, Master.currUser.IdUsuario);
            }
            else
            {
               message = UserService.UpdateUser(Convert.ToInt32(txtIdUsuario.Text), txtNombreCompleto.Text, txtNombreUsuario.Text, txtContrasena.Text, Master.currUser.IdUsuario);
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdUsuarios.SelectedRow;

            txtContrasena.Text = selectedRow.Cells[3].Text;
            txtNombreCompleto.Text = selectedRow.Cells[1].Text;
            txtNombreUsuario.Text = selectedRow.Cells[2].Text;
            txtIdUsuario.Text = selectedRow.Cells[0].Text;

            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        private void EnableInputs(bool enabled)
        {
            btnSaveUser.Enabled = enabled;
            txtContrasena.Enabled = enabled;
            txtNombreCompleto.Enabled = enabled;
            txtNombreUsuario.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtContrasena.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtIdUsuario.Text = string.Empty;
        }

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[0].Text);

            string message = UserService.DeleteUser(userId);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }
        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            
            ViewState["ShowAlert"] = false;
        }
    }
}
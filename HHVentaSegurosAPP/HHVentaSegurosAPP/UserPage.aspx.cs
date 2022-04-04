using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP
{
    public partial class UserPage : System.Web.UI.Page
    {
        private void GetUsers()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.ClsUsuario[] users = service.GetUsers();
            
            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();
            grdUsuarios.DataSource = users;
            grdUsuarios.DataBind();
        }

        private void CreateUser()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.InsertUser(txtNombreCompleto.Text, txtNombreUsuario.Text, txtContrasena.Text);

            GetUsers();
            clsShared.ShowAlert(alertMessage, vMessage);
            ViewState["ShowAlert"] = true;
            //clsShared.Mensaje(vMessage, Page, this.GetType());
        }

        private void UpdateUser()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.UpdateUser(Convert.ToInt32(txtIdUsuario.Text),txtNombreCompleto.Text, txtNombreUsuario.Text, txtContrasena.Text);

            GetUsers();

            clsShared.ShowAlert(alertMessage, vMessage);
            ViewState["ShowAlert"] = true;
            //clsShared.Mensaje(vMessage, Page, this.GetType());
        }
        private void DeleteUser(int userId)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.DeleteUser(userId);

            GetUsers();

            clsShared.ShowAlert(alertMessage, vMessage);
            ViewState["ShowAlert"] = true;
            //clsShared.Mensaje(vMessage, Page, this.GetType());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                InitVariables();
                GetUsers();
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
            if(ViewState["Mode"].ToString() == "C")
            {
                CreateUser();
            }
            else
            {
                UpdateUser();
            }
            ClearInputs();
            ToggleInputs();
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            ToggleInputs();
        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdUsuarios.SelectedRow;

            txtContrasena.Text = selectedRow.Cells[3].Text;
            txtNombreCompleto.Text = selectedRow.Cells[1].Text;
            txtNombreUsuario.Text = selectedRow.Cells[2].Text;
            txtIdUsuario.Text = selectedRow.Cells[0].Text;

            ViewState["Mode"] = 'M';

            ToggleInputs();
        }

        private void ToggleInputs()
        {
            btnSaveUser.Enabled = !btnSaveUser.Enabled;
            txtContrasena.Enabled = !txtContrasena.Enabled;
            txtNombreCompleto.Enabled = !txtNombreCompleto.Enabled;
            txtNombreUsuario.Enabled = !txtNombreUsuario.Enabled;
        }

        private void ClearInputs()
        {
            txtContrasena.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
        }

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[0].Text);

            DeleteUser(userId);
        }
        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            
            ViewState["ShowAlert"] = false;
        }
    }
}
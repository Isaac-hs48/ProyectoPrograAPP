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
        protected void GetUsers()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.ClsUsuario[] users = service.GetUsers();
            
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
                GetUsers();

            }
        }

        private void InitVariables()
        {
            btnSaveUser.Enabled = false;
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {

        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelectUser_Click(object sender, EventArgs e)
        {
            FillTextBoxFromDtr();
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        //private void FillTextBoxFromDtr()
        //{
        //    grdUsuarios.SelectedDataKey

        //    foreach (BoundField column in grdUsuarios.Columns)
        //    {
                
        //       this.[$"txt{column.DataField}"] = 
                
        //    }
        //}
    }
}
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
    public partial class Register : System.Web.UI.Page
    {
        public static WSHHVentaSeguros.ClsUsuario[] users { get; set; }
        public bool ShowAlert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                users = UserService.GetUsers();
                ShowAlert = false;
            }
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            this.ShowAlert = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ValidateUsername();

            string vMessage = UserService.CreateUser(txtNombreCompleto.Text, txtUsuario.Text, txtContrasena.Text, null);
            clsShared.ShowAlert(alertMessage, vMessage);
            this.ShowAlert = true;
        }
        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidateUsername();
        }

        private bool ValidateUsername()
        {
            if (Register.users.Any(u => u.NombreUsuario == txtUsuario.Text))
            {
                txtUsuario.Text = string.Empty;
                clsShared.ShowAlert(alertMessage, "No se puede usar el nombre de usuario ingresado.");
                this.ShowAlert = true;
                return true;
            }

            return false;
        }
    }
}
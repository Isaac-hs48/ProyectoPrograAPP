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
    public partial class Login : System.Web.UI.Page
    {
        public bool ShowAlert { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                HttpContext.Current.Session.Add("CurrentUser", null);
                ShowAlert = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            WSHHVentaSeguros.ClsUsuario[] users = UserService.GetUsers();

            WSHHVentaSeguros.ClsUsuario user = users.FirstOrDefault(u => u.NombreUsuario == txtUsuario.Text && u.Contrasena == txtContrasena.Text);

            if (user == null)
            {
                clsShared.ShowAlert(alertMessage, "Usuario y/o contraseña incorrectos");
                this.ShowAlert = true;
            }
            else
            {
                HttpContext.Current.Session.Add("CurrentUser", user);

                Response.Redirect("/Home.aspx");
            }
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            this.ShowAlert = false;
        }
    }
}
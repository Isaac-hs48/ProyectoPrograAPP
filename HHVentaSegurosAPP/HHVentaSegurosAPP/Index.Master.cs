using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP
{
    public partial class Index : System.Web.UI.MasterPage
    {
        public WSHHVentaSeguros.ClsUsuario currUser { get; set; }
        public bool ShowMenu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            this.currUser = (WSHHVentaSeguros.ClsUsuario)HttpContext.Current.Session["CurrentUser"];

            lblUserName.Text = currUser != null ? currUser.NombreCompleto : string.Empty;

            if (currUser == null && !(path.Contains("/Login") || path.Contains("/Register")))
            {
                Response.Redirect("/Login.aspx");
            }
            
            ShowMenu = !(path.Contains("/Login") || path.Contains("/Register"));
        }
    }
}
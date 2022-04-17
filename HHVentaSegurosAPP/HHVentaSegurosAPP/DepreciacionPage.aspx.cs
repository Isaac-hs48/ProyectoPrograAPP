using HHVentaSegurosAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP
{
    public partial class DepreciacionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(HttpContext.Current.Request.QueryString.AllKeys.Contains("idActivo"))
                {
                    int idActivo = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("idActivo"));

                    grdDepreciacion.DataSource = null;
                    grdDepreciacion.DataBind();
                    grdDepreciacion.DataSource = AssetService.GenerateDeprecation(idActivo);
                    grdDepreciacion.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssetPage.aspx");
        }
    }
}
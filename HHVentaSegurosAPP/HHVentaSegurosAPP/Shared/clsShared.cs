using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP.Shared
{
    public class clsShared
    {
        public static void Mensaje(string pMensaje, Page _page, Type _this)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = _page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(_this, "PopupScript"))
            {
                String cstext = "alert('" + pMensaje + "');";
                cs.RegisterStartupScript(_this, "PopupScript", cstext, true);
            }
        }

        public static void ShowAlert(Label _alert, string _message)
        {
            _alert.Text = _message;
            _alert.Visible = true;
        }
    }
}
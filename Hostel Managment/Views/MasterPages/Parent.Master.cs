using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views.MasterPages
{
    public partial class Parent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect(GetRouteUrl("Login", null));

        }
        protected void showgatepass_click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("ShowGatePass", null));


        }
        protected void messbill_click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("ViewMessBill", null));
        }
    }

}
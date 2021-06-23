using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views.MasterPages
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if (Session["rollno"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));
            }*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["rollno"] = null;
            Response.Redirect(GetRouteUrl("Login", null));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("RequestGatePass", null));
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("StudentMessBill", null));
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("Complaints", null));
        }
    }
}
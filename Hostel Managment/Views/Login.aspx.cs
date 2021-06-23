using Hostel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostel_Managment.Controllers;

namespace Hostel_Managment.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            error_msg.Visible = false;
            UtilityController.updatelimits();
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Account modal = AccountController.Verfiy_user(rollno.Text.Trim().ToLower(), password.Text.Trim());
            if (modal.isauthenticated)
            {
                if (modal.Designation == "student")
                {
                    Session["rollno"] = rollno.Text.Trim().ToLower();
                    Response.Redirect(GetRouteUrl("RequestGatePass", null));

                }
                else if (modal.Designation == "admin")
                {
                    Session["username"] = rollno.Text.Trim();
                    Response.Redirect(GetRouteUrl("GatePassRequests", null));
                }
                else if (modal.Designation == "superadmin")
                {
                    Session["username"] = rollno.Text.Trim();
                    Response.Redirect(GetRouteUrl("GatePassLimits", null));
                }
                else if (modal.Designation == "attendance")
                {
                   // Session["username"] = rollno.Text.Trim();
                    Response.Redirect(GetRouteUrl("MarkAttendence", null));
                }
                else if (modal.Designation == "employee")
                {
                    // Session["username"] = rollno.Text.Trim();
                    Response.Redirect(GetRouteUrl("ViewAttandence", null));
                }
                else if (modal.Designation == "parent")
                {
                     Session["username"] = rollno.Text.Trim();
                    Response.Redirect(GetRouteUrl("ShowGatePass", null));
                }
            }
            else
            {
                error_msg.Text = "Invalid Username or Password";
                error_msg.Visible = true;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class Admin : System.Web.UI.MasterPage
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
        protected void gatepass_click(object sender, EventArgs e)
        {
            //LinkButton1.addClass("active");
            
            Response.Redirect(GetRouteUrl("GatePassRequests", null));


        }
        protected void inventory_click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("Inventory", null));
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Response.Redirect(GetRouteUrl("ViewGatePass", null));
        }
        protected void new_employee_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("AddEmployee", null));
        }

        protected void new_employee_Click1(object sender, EventArgs e)
        {

        }
        protected void menu_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("MessMenu", null));

        }
        protected void registeredStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("RegisteredStudents", null));
        }
    }
}
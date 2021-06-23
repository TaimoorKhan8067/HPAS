using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Hostel_Managment
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           RegisterCustomRoutes(RouteTable.Routes);
        }

       void RegisterCustomRoutes(RouteCollection route)
        {
            route.MapPageRoute("GatePassRequests", "GatePass", "~/Views/GatePass.aspx");
            route.MapPageRoute("RequestGatePass", "RequestGatePass", "~/Views/RequestGatePass.aspx");
            route.MapPageRoute("Inventory", "Inventory", "~/Views/Inventory1.aspx");
            route.MapPageRoute("Login", "Login", "~/Views/Login.aspx");
            route.MapPageRoute("AddEmployee", "AddEmployee", "~/Views/AddEmployee.aspx");
            route.MapPageRoute("ShowGatePass", "ShowGatePass", "~/Views/ShowGatePass.aspx");
            route.MapPageRoute("ViewGatePass", "ViewGatePass", "~/Views/ViewGatePass.aspx");
            route.MapPageRoute("GatePassLimits", "GatePassLimits", "~/Views/GatePassLimits.aspx");
            route.MapPageRoute("ViewMessBill", "ViewMessBill", "~/Views/ViewMessBill.aspx");
            route.MapPageRoute("MarkAttendence", "MarkAttendence", "~/Views/MarkAttendence.aspx");
            route.MapPageRoute("StudentMessBill", "StudentMessBill", "~/Views/StudentViewMessBill.aspx");
            route.MapPageRoute("RegisteredStudents", "RegisteredStudents", "~/Views/RegisteredStudents.aspx");
            route.MapPageRoute("ViewAttandence", "ViewAttandence", "~/Views/ViewAttandence.aspx");
            route.MapPageRoute("MessMenu", "MessMenu", "~/Views/MessMenu.aspx");
            route.MapPageRoute("Complaints", "Complaints", "~/Views/complaintform.aspx");
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
using Hostel_Managment.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class ShowGatePass : System.Web.UI.Page
    {
        GatePass_Controller controller;
        string parentid;
        string studentid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));

            }
            else
            {
                controller = new GatePass_Controller();
                parentid = Session["username"].ToString();
                int length = parentid.Length;
                length = length - 1;
                studentid=parentid.Substring(1, length);
               // studentid = Session["username"].ToString();
                loadtable();
            }
        }

        private void loadtable()
        {
            DataTable d1, d2;
            d1 = controller.ParentLoadTable(studentid);
            d2 = new DataTable();
           // d2.Columns.Add(new DataColumn("ID", typeof(string)));
            d2.Columns.Add(new DataColumn("Description", typeof(string)));
            d2.Columns.Add(new DataColumn("Status", typeof(string)));
            foreach (DataRow row in d1.Rows)
            {
                DataRow r = d2.NewRow();
                r["Description"] = row["description"].ToString();
                string status_temp = row["status"].ToString();
                if (status_temp == "1")
                {
                    r["Status"] = "Approved";
                }
                else if (status_temp == "-1")
                {
                    r["Status"] = "Pending";

                }
                else if (status_temp == "0")
                {
                    r["Status"] = "Rejected";

                }
                d2.Rows.Add(r);
            }
            passdata.DataSource = d2;
            passdata.DataBind();

        }
        protected void passdata_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "Approved")
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Green;
                }
                else if (e.Row.Cells[0].Text == "Rejected")
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                }

            }
        }

    }
}
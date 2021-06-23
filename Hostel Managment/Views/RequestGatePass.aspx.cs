using Hostel_Managment.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class RequestGatePass : System.Web.UI.Page
    {
        GatePass_Controller controller;
        string rollno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rollno"] == null)
            {   
                Response.Redirect(GetRouteUrl("Login", null));

            }
            else
            {
                controller = new GatePass_Controller();
                rollno = Session["rollno"].ToString();
                loadtable();
                populate_dropdown();
                check_permission();
            }
        }

        private void populate_dropdown()
        {
            Duration.Items.Insert(0, new ListItem("1 Hour", "1 Hour"));
            Duration.Items.Insert(1, new ListItem("2 Hour", "2 Hour"));
            Duration.Items.Insert(2, new ListItem("3 Hour", "3 Hour"));
            Duration.Items.Insert(3, new ListItem("4 Hour", "4 Hour"));
            Duration.Items.Insert(4, new ListItem("5 Hour", "5 Hour"));
            Duration.Items.Insert(5, new ListItem("6 Hour", "6 Hour"));
            Duration.Items.Insert(6, new ListItem("Half Day", "Half Day"));
            Duration.Items.Insert(7, new ListItem("Full Day", "Full Day"));
            Duration.Items.Insert(8, new ListItem("NA", "NA"));
        }

        private void loadtable()
        {
            DataTable d1, d2;
            d1 = controller.gettablebyroll(rollno);
            d2 = new DataTable();
            d2.Columns.Add(new DataColumn("Time Requested", typeof(string)));
            d2.Columns.Add(new DataColumn("Description", typeof(string)));
            d2.Columns.Add(new DataColumn("Reason", typeof(string)));
            foreach (DataRow row in d1.Rows)
            {
                DataRow r = d2.NewRow();
               r["Time Requested"] = row["time_added"].ToString();
                r["Description"] = row["description"].ToString();


                string status_temp = row["reason"].ToString();
                if (status_temp == ""||status_temp==null)
                {
                    r["Reason"] = "Approved";
                }
                else 
                {
                    r["Reason"] = status_temp;

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

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            controller.request(rollno, Description.Text, Duration.SelectedValue);

            Response.Redirect(Request.Url.AbsoluteUri);

        }

        private void check_permission()
        {
            if (controller.check_permission(rollno) == 0)
            {
                notallowed.Visible = false;
                blacklisted.Visible = false;
                formdiv.Visible = true;
            }
            else if (controller.check_permission(rollno) == 99)
            {
                notallowed.Visible = false;
                blacklisted.Visible = true;
                formdiv.Visible = false;
            }
            else
            {
                notallowed.Visible = true;
                blacklisted.Visible = false;
                formdiv.Visible = false;
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            controller.request(rollno, Description.Text, Duration.SelectedValue);

            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}
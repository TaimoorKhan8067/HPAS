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
    public partial class RegisteredStudents : System.Web.UI.Page
    {

        AccountController controller;
        DataTable d5;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));
            }
            else
            {
                controller = new AccountController();
                loadtable();
            }
        }

        private void loadtable()
        {
            DataTable d1, d2;
            d1 = controller.getRegisteredStudents();
            d2 = new DataTable();
            // d2.Columns.Add(new DataColumn("ID", typeof(string)));
            d2.Columns.Add(new DataColumn("rollNo", typeof(string)));
            d2.Columns.Add(new DataColumn("studentName", typeof(string)));
            d2.Columns.Add(new DataColumn("status", typeof(ButtonField)));
            d2.Columns.Add(new DataColumn("black", typeof(string)));
            foreach (DataRow row in d1.Rows)
            {
                DataRow r = d2.NewRow();
                
               
                r["rollNo"] = row["id"].ToString();
                r["studentName"] = row["username"].ToString();
                string blacklisted = row["blacklisted"].ToString();
                r["black"]=blacklisted;
                d2.Rows.Add(r);
            }
            d5 = d2;
            passrequests.DataSource = d2;
            passrequests.DataBind();

        }

        protected void passrequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void passrequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void passrequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (d5.Rows[e.Row.RowIndex][3].ToString().ToLower()== "true")
                {
                    e.Row.Cells[2].Text = "Yes";
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;


                }
            }
        }
    }
}
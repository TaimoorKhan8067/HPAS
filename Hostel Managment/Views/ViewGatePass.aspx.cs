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
    public partial class ViewGatePass : System.Web.UI.Page
    {
        GatePass_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new GatePass_Controller();
            getcount();
            loadtable();
        }

        private void loadtable()
        {
            DataTable d1, d2;
            d1 = obj.loadtable();
            if (d1.Rows.Count > 0)
            {

                tablerequests.Visible = true;
                norecords.Visible = false;
                d2 = new DataTable();
                d2.Columns.Add(new DataColumn("ID", typeof(string)));
                d2.Columns.Add(new DataColumn("RollNo", typeof(string)));
                d2.Columns.Add(new DataColumn("Name", typeof(string)));
                d2.Columns.Add(new DataColumn("Description", typeof(string)));
                d2.Columns.Add(new DataColumn("Duration", typeof(string)));
                d2.Columns.Add(new DataColumn("Status", typeof(string)));
                foreach (DataRow row in d1.Rows)
                {
                    DataRow r = d2.NewRow();
                    r["ID"] = row["gatepass_id"].ToString();

                    r["RollNo"] = row["user_id"].ToString();
                    r["Name"] = row["username"].ToString();
                    r["Duration"] = row["duration"].ToString();

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
                passrequests.DataSource = d2;
                passrequests.DataBind();
            }
            else
            {

                tablerequests.Visible = false;
                norecords.Visible = true;
            }
        }

        private void loadstatustable(string status)
        {
            DataTable d1, d2;
            d1 = obj.loadtablebystatus(status);
            if (d1.Rows.Count > 0)
            {
                tablerequests.Visible = true;
                norecords.Visible = false;
                d2 = new DataTable();
                d2.Columns.Add(new DataColumn("ID", typeof(string)));
                d2.Columns.Add(new DataColumn("RollNo", typeof(string)));
                d2.Columns.Add(new DataColumn("Name", typeof(string)));
                d2.Columns.Add(new DataColumn("Description", typeof(string)));
                d2.Columns.Add(new DataColumn("Duration", typeof(string)));
                d2.Columns.Add(new DataColumn("Status", typeof(string)));
                foreach (DataRow row in d1.Rows)
                {
                    DataRow r = d2.NewRow();
                    r["ID"] = row["gatepass_id"].ToString();

                    r["RollNo"] = row["user_id"].ToString();
                    r["Name"] = row["username"].ToString();
                    r["Duration"] = row["duration"].ToString();

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
                passrequests.DataSource = d2;
                passrequests.DataBind();
            }
            else
            {

                tablerequests.Visible = false;
                norecords.Visible = true;
            }
        }

        void getcount()
        {
            DataTable d1, d2, d3, d4;
            d1 = obj.loadtable();
            d2 = obj.loadtablebystatus("-1");
            d3 = obj.loadtablebystatus("1");
            d4 = obj.loadtablebystatus("0");

            allcount.Text = "(" + d1.Rows.Count.ToString() +")";
            pendingcount.Text = "(" + d2.Rows.Count.ToString() + ")";
            approvecount.Text = "(" + d3.Rows.Count.ToString() + ")";
            rejectcount.Text = "(" + d4.Rows.Count.ToString() + ")";
        }
        protected void allgatepass_Click(object sender, EventArgs e)
        {
            loadtable();
        }

        protected void pendinggatepass_Click(object sender, EventArgs e)
        {
            loadstatustable("-1");
        }

        protected void approved_Click(object sender, EventArgs e)
        {
            loadstatustable("1");
        }

        protected void rejectedgatepass_Click(object sender, EventArgs e)
        {
            loadstatustable("0");
        }

    }
}
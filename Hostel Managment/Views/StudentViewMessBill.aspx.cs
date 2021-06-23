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
    public partial class StudentViewMessBill : System.Web.UI.Page
    {
        MessBillController controller;
        //string parentid;
        string studentid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rollno"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));

            }
            else
            {
                controller = new MessBillController();
                studentid = Session["rollno"].ToString();
                loadtable();
            }
        }

        private void loadtable()
        {
            DataTable d1, d2;
            d1 = controller.StudentMessLoadTable(studentid);
            d2 = new DataTable();
            // d2.Columns.Add(new DataColumn("ID", typeof(string)));
            d2.Columns.Add(new DataColumn("dateGenerated", typeof(string)));
            d2.Columns.Add(new DataColumn("deadline", typeof(string)));
            d2.Columns.Add(new DataColumn("billAmount", typeof(string)));
            d2.Columns.Add(new DataColumn("fine", typeof(string)));
            foreach (DataRow row in d1.Rows)
            {
                DataRow r = d2.NewRow();
                string[] str = row["dateGenerated"].ToString().Split(' ');
                r["dateGenerated"] = str[0];
                str = row["deadline"].ToString().Split(' ');
                r["deadline"] = str[0];
                r["billAmount"] = row["amount"].ToString();
                r["fine"] = row["fine"].ToString();

                d2.Rows.Add(r);
            }
            studentGetData.DataSource = d2;
            studentGetData.DataBind();

        }
    }
}
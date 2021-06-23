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
    public partial class ViewMessBill : System.Web.UI.Page
    {
        MessBillController controller;
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
                controller = new MessBillController();
                parentid = Session["username"].ToString();
                int length = parentid.Length;
                length = length - 1;
                studentid = parentid.Substring(1, length);
                // studentid = Session["username"].ToString();
                loadtable();
            }

        }
        private void loadtable()
        {
            DataTable d1, d2;
            d1 = controller.ParentMessLoadTable(studentid);
            d2 = new DataTable();
            // d2.Columns.Add(new DataColumn("ID", typeof(string)));
            d2.Columns.Add(new DataColumn("Date", typeof(string)));
            d2.Columns.Add(new DataColumn("Bill Amount", typeof(string)));
            d2.Columns.Add(new DataColumn("Amount Paid", typeof(string)));
            d2.Columns.Add(new DataColumn("Remaining Amount", typeof(string)));
            d2.Columns.Add(new DataColumn("Fine", typeof(string)));
            foreach (DataRow row in d1.Rows)
            {
                DataRow r = d2.NewRow();
                string[] str = row["dateGenerated"].ToString().Split(' ');
                r["Date"] = str[0];
                r["Bill Amount"] = row["amount"].ToString();
                r["Amount Paid"] = row["amountPaid"].ToString();
                r["Remaining Amount"] = row["remainingAmount"].ToString();
                r["Fine"] = row["fine"].ToString();
      
                d2.Rows.Add(r);
            }
            passdata.DataSource = d2;
            passdata.DataBind();

        }

    }
}
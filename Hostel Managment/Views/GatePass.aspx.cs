using Hostel_Managment.Controllers;
using Hostel_Managment.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class GatePass : System.Web.UI.Page
    {
        GatePass_Controller controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new GatePass_Controller();
            if (!Page.IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect(GetRouteUrl("Login", null));
                }
                else
                {
                    controller = new GatePass_Controller();
                    loadtable();
                }
            }
            
        }

        private void loadtable()
        {
            error.Visible = false;
            table_div.Visible = true;
            reject_reason.Visible = false;
            DataTable dt = controller.loadtablebystatus("-1");
            passrequests.DataSource = dt;
            passrequests.DataBind();
            if (dt.Rows.Count == 0)
            {
                norecords.Visible = true;
                tablerequests.Visible = false;
            }
            else
            {
                norecords.Visible = false;
                tablerequests.Visible = true;
            }
        }
        
        protected void passrequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void passrequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approve")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = passrequests.Rows[crow].Cells[0].Text;
                string rollno = passrequests.Rows[crow].Cells[1].Text;
                string name = passrequests.Rows[crow].Cells[2].Text;
                controller.approve(id);
                string parentnumber = controller.getparentnumber(rollno);
                MailUtility mail = new MailUtility(rollno,name);
                string message = "Dear Student  "+name+ ", \n Your recent gatepass request no : " + id + " has been approved. Please Check your dashboard.\n Regards,\n Hostel Managment\n FAST CFD CAMPUS";
                mail.send(message, "GATEPASS APPROVAL NOTIFICATION");
                //SmsUtility sms = new SmsUtility();
                //string smsmessage = "Dear Parents, \n Your Son/Daughter " +name+ " has been Allowed for the GatePass. \n Please Check your dashboard.\n Regards,\n Hostel Managment\n FAST CFD CAMPUS";
                //string json = sms.SendSMSPOST(parentnumber, smsmessage);


                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else if (e.CommandName == "reject")
            {
                table_div.Visible = false;
                reject_reason.Visible = true;
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                 id_labl.Text = passrequests.Rows[crow].Cells[0].Text;
                 rollno.Text = passrequests.Rows[crow].Cells[1].Text;
                name.Text = passrequests.Rows[crow].Cells[2].Text;
                

            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loadtablebyname(string text)
        {
            DataTable dt = controller.loadtablebystatus("-1",text);
            passrequests.DataSource = dt;
            passrequests.DataBind();
            if (dt.Rows.Count == 0)
            {
                norecords.Visible = true;
                tablerequests.Visible = false;
            }
            else
            {
                norecords.Visible = false;
                tablerequests.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                loadtable();
            }
            else
            {
                loadtablebyname(TextBox1.Text);
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string re = reason.Text;
            if (string.IsNullOrEmpty(re) || string.IsNullOrWhiteSpace(re))
            {
                error.Visible = true;
            }
            else
            {
                error.Visible = false;
                controller.reject(id_labl.Text.Trim(),re);
                MailUtility mail = new MailUtility(rollno.Text.Trim(), name.Text.Trim());
                string message = "Dear Student, \n Your recent gatepass request no : " + id_labl.Text.Trim() + " has been rejected. Please Check your dashboard.\n Regards,\n Hostel Managment\n FAST CFD CAMPUS";
                mail.send(message, "GATEPASS REJECTION NOTIFICATION");
                Response.Redirect(Request.Url.AbsoluteUri);
                table_div.Visible = true;
                reject_reason.Visible = false;
            }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            table_div.Visible = true;
            reject_reason.Visible = false;
        }
    }
}
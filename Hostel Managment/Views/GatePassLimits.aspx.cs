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
    public partial class GatePassLimits : System.Web.UI.Page
    {
        GatePass_Controller controller = new GatePass_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));
            }
            else
            {
                loadtable();
                update_div.Visible = false;
                pending.Visible = false;

            }
        }

        private void loadtable()
        {
            DataTable dt = controller.loadlimittable();
            inventory.DataSource = dt;
            inventory.DataBind();
        }

        protected void inventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit_details")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = inventory.Rows[crow].Cells[0].Text;
                string day = inventory.Rows[crow].Cells[1].Text;
                string limit = inventory.Rows[crow].Cells[2].Text;
                name_lbl.Text = day;
                limit_txt_update.Text = limit;
                id_lbl.Text = id;
                update_div.Visible = true;
                tablelimits.Visible = false;

            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (int.Parse(limit_txt_update.Text.Trim()) >= -1)
            {
                int res = controller.setlimits(name_lbl.Text.Trim(), limit_txt_update.Text.Trim());
                if (res == 1)
                {
                    pending.Visible = true;
                }
                loadtable();
                update_div.Visible = false;
                tablelimits.Visible = true;
            }
            else
            {
                update_div.Visible = true;
                tablelimits.Visible = false;
            }


        }

        protected void close_Click(object sender, EventArgs e)
        {
            loadtable();
            update_div.Visible = false;
            tablelimits.Visible = true;
        }
    }
}
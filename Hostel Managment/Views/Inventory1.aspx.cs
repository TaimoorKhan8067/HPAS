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
    public partial class Inventory1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect(GetRouteUrl("Login", null));
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    loadtable();
                    update_div.Visible = false;
                    delete_div.Visible = false;
                    insert_div.Visible = false;
                    loaddropdowns();
                }
               
            }
        }

        private void loaddropdowns()
        {
            InventoryController controller = new InventoryController();
            DataTable dt = controller.load_category();
            update_cat_drp.DataTextField = dt.Columns["Name"].ToString();
            update_cat_drp.DataValueField = dt.Columns["cat_id"].ToString();
            update_cat_drp.DataSource = dt;
            update_cat_drp.DataBind(); 
            cat_insert_drp.DataTextField = dt.Columns["Name"].ToString();
            cat_insert_drp.DataValueField = dt.Columns["cat_id"].ToString();
            cat_insert_drp.DataSource = dt;
            cat_insert_drp.DataBind();

        }

        private void loadtable()
        {
            InventoryController controller = new InventoryController();

            DataTable dt = controller.loadtable();
            inventory.DataSource = dt;
            inventory.DataBind();
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

        private void loadTableByInventory(string text)
        {
            InventoryController controller = new InventoryController();

            DataTable dt = controller.loadTableByInventory(text);
            inventory.DataSource = dt;
            inventory.DataBind();
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

        protected void passrequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit_details")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = inventory.Rows[crow].Cells[0].Text;
                string name = inventory.Rows[crow].Cells[1].Text;
                string category = inventory.Rows[crow].Cells[2].Text;
                update_cat_drp.SelectedIndex = update_cat_drp.Items.IndexOf(update_cat_drp.Items.FindByText(category));
                string stock= inventory.Rows[crow].Cells[3].Text;
                nametxt_update.Text = name;
                stock_txt_update.Text = stock;
                id_lbl.Text = id;
                update_div.Visible = true;
                tablerequests.Visible = false;

            }
            if (e.CommandName == "delete_details")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = inventory.Rows[crow].Cells[0].Text;
                delete_id_lbl.Text = id;
                delete_div.Visible = true;
                tablerequests.Visible = false;

            }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            update_div.Visible = false;
            tablerequests.Visible = true;
        }

        protected void update_Click(object sender, EventArgs e)
        {
            InventoryController controller = new InventoryController();
            controller.Update(nametxt_update.Text, update_cat_drp.SelectedValue,stock_txt_update.Text,id_lbl.Text);
            loadtable();
            update_div.Visible = false;
            tablerequests.Visible = true;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InventoryController controller = new InventoryController();
            controller.delete(delete_id_lbl.Text);
            loadtable();
            delete_div.Visible = false;
            tablerequests.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            delete_div.Visible = false;
            tablerequests.Visible = true;
        }

        protected void add_new_Click(object sender, EventArgs e)
        {

            insert_div.Visible = true;
            tablerequests.Visible = false;
            add_new.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            InventoryController controller = new InventoryController();
            controller.insert(name_insert_txt.Text,cat_insert_drp.SelectedValue,stock_insert_txt.Text);
            loadtable();
            insert_div.Visible = false;
            add_new.Visible = true;
            tablerequests.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            insert_div.Visible = false;
            add_new.Visible = true;
            tablerequests.Visible = true;
        }


        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                loadtable();
            }
            else
            {
                loadTableByInventory(TextBox1.Text);
            }
        }
    }
}
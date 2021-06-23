using Hostel_Managment.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class MessMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue); }
                
            
        }
        private void showData(string month, string week)
        {
           
                MessMenuController obj = new MessMenuController();
                DataTable dt = obj.PrintMessMenu(month,week);
                if (dt.Rows.Count == 0)
            {
                string q = "INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Monday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Tuesday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Wednesday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Thursday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Friday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Saturday','-','-','-','0','0','0');INSERT INTO `messmenu`(`month`, `week`, `day`, `menubreakfast`, `menulunch`, `menudinner`, `pointbreakfast`, `pointlunch`, `pointdinner`) VALUES (?month,?week,'Sunday','-','-','-','0','0','0');";
                DatabaseController databaseController = DatabaseController.getinstance();
              
                MySqlCommand sci = databaseController.insertquery(q);
                sci.Parameters.AddWithValue("?mont", month);
                sci.Parameters.AddWithValue("?week", week);
                sci.ExecuteNonQuery();
                dt = obj.PrintMessMenu(month, week);
            }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                

        }
        protected void Save_Click(object sender, EventArgs e)
        {
          

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
           
            showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue);
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label day = GridView1.Rows[e.RowIndex].FindControl("day") as Label;
            TextBox breakfast = GridView1.Rows[e.RowIndex].FindControl("txt_menubreakfast") as TextBox;
            TextBox point1 = GridView1.Rows[e.RowIndex].FindControl("txt_pointbreakfast") as TextBox;
            TextBox lunch = GridView1.Rows[e.RowIndex].FindControl("txt_menulunch") as TextBox;
            TextBox point2 = GridView1.Rows[e.RowIndex].FindControl("txt_pointlunch") as TextBox;
            TextBox dinner = GridView1.Rows[e.RowIndex].FindControl("txt_menudinner") as TextBox;
            TextBox point3 = GridView1.Rows[e.RowIndex].FindControl("txt_pointdinner") as TextBox;
            DatabaseController databaseController = DatabaseController.getinstance();

            MySqlCommand sci = databaseController.insertquery("UPDATE `messmenu` SET `menubreakfast`=?break,`menulunch`=?lunch,`menudinner`=?dinner,`pointbreakfast`=?bp,`pointlunch`=?lp,`pointdinner`=?dp WHERE day=?day and week=?drop1 and month=?drop2");
            sci.Parameters.AddWithValue("?break", breakfast.Text);
            sci.Parameters.AddWithValue("?lunch", lunch.Text);
            sci.Parameters.AddWithValue("?dinner", dinner.Text);
            sci.Parameters.AddWithValue("?bp", point1.Text);
            sci.Parameters.AddWithValue("?lp", point2.Text);
            sci.Parameters.AddWithValue("?dp", point3.Text);
            sci.Parameters.AddWithValue("?day", day.Text);
            sci.Parameters.AddWithValue("?drop1", DropDownList1.SelectedValue);
            sci.Parameters.AddWithValue("?drop2", DropDownList2.SelectedValue);
            sci.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue);

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            showData(DropDownList2.SelectedValue, DropDownList1.SelectedValue);

        }
    }
}
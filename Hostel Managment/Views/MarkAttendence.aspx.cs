using Hostel_Managment.Controllers;
using Hostel_Managment.Modals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment.Views
{
    public partial class MarkAttendence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // rfid.Visible = false;

            SetFocus(rfid);
            time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");

        }
        
        protected void rfid_TextChanged(object sender, EventArgs e)
        {
            int error = 0;
            if(rfid.Text.Length==10)
            {
               Employee result= EmployeeController.markAttendance(rfid.Text,ref error);
                if (result.id != null)
                {
                    if (error == 0)
                    {
                        name.ForeColor = Color.Black;
                        name.Text = result.name;
                        designation.ForeColor = Color.Black;
                        designation.Text = result.designation;
                        rfid.Text = string.Empty;
                        img.Src = @"../EmployeeImages/" + result.id + ".jpg";
                        SetFocus(rfid);
                    }
                    else if(error==1)
                    {
                        name.Text = "Attendance Already Marked";
                        name.ForeColor = Color.Green;
                        designation.Text = "Attendance Already Marked";
                        designation.ForeColor = Color.Green;
                        rfid.Text = string.Empty;
                        img.Src = @"../EmployeeImages/" + result.id + ".jpg";
                        SetFocus(rfid);

                    }
                }
                else
                {
                    name.Text ="Not Found";
                    name.ForeColor = Color.Red;
                    designation.Text ="Not Found";
                    designation.ForeColor = Color.Red;
                    rfid.Text = string.Empty;
                    img.Src = @"../EmployeeImages/emp.jpg";
                    SetFocus(rfid);
                }
            }
        }
    }
}
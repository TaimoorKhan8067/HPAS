using Hostel_Managment.Modals;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class EmployeeController
    {
       public static Employee markAttendance(string RFID,ref int error)
        {
            string query = "SELECT * FROM `employee` WHERE rfid=?RFID";

            Employee modal = new Employee();
           DatabaseController database = DatabaseController.getinstance();
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?RFID", RFID);
            MySqlDataReader ds= sc.ExecuteReader();
            while (ds.Read())
            {
                modal.id = ds.GetInt32(0).ToString();
                modal.name = ds.GetString(1);
                modal.designation = ds.GetString(2);

            }


            ds.Close();

            if (modal.id != null)
            {
               // query = "SELECT* FROM `employeeattendance` WHERE empId = '" + modal.id + "' AND date = '" + DateTime.Now.ToString("d") + "'";

                query = "SELECT* FROM `employeeattendance` WHERE empId = ?id AND date = '" + DateTime.Now.ToString("d") + "'";
                database = DatabaseController.getinstance();
                 sc = database.select_query(query);
                sc.Parameters.AddWithValue("?id", modal.id);
                 ds = sc.ExecuteReader();

                if (!ds.HasRows)
                {
                    ds.Close();
                    query = "INSERT INTO `employeeattendance` (`empId`, `date`, `status`) VALUES (?id, '" + DateTime.Now.ToString("d") + "', 'P');";
                    MySqlCommand sci= database.insertquery(query);
                    sci.Parameters.AddWithValue("?id", modal.id);
                    sci.ExecuteNonQuery();
                }
                else
                {
                    ds.Close();
                    error = 1;
                }

            }
            return modal;

        }
     }
}
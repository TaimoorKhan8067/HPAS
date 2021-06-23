using Hostel.Models;
using Hostel_Managment.Modals;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class GatePass_Controller
    {
        private DatabaseController database;
        public DataTable loadlimittable()
        {
            database = DatabaseController.getinstance();
            string query = "SELECT * FROM `limits`";
            MySqlCommand sc = database.select_query(query);
            MySqlDataReader sda = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;

        }

     

        public bool approve(string id)
        {
            if (checklimits())
            {
                string query = "UPDATE `gatepass` SET `status`= '1' , reason='Approved' WHERE `gatepass_id`= ?id";
                database = DatabaseController.getinstance();
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?id", id);
                sci.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getparentnumber(string rollno)
        {
            string number = "";
            database = DatabaseController.getinstance();
            string query = "SELECT contact_no FROM parents WHERE stdid=?rollno";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            MySqlDataReader sda = sc.ExecuteReader();
            while (sda.Read())
            {
                number = sda.GetString("contact_no");
            }
            sda.Close();
            return number;
        }


       

        private bool checklimits()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string query;
            int count = 0;
            query = "SELECT * FROM `dailygatepasscount` WHERE `date`=?date;";
            database = DatabaseController.getinstance();
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?date", date);
            MySqlDataReader dataReader = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            if (dataTable.Rows.Count == 0)
            {
                query = "INSERT INTO `dailygatepasscount`(`date`, `count`) VALUES (?date,0);";
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?date", date);
                sci.ExecuteNonQuery();
            }
            else
            {
                count = int.Parse(dataTable.Rows[0][1].ToString());
            }
            string day = DateTime.Now.DayOfWeek.ToString();
            query = "SELECT `limit` FROM `limits` WHERE `day`=?day;";
            database = DatabaseController.getinstance();
             sc = database.select_query(query);
            sc.Parameters.AddWithValue("?day", day);
            dataReader = sc.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(dataReader);
            int daylimit = int.Parse(dataTable.Rows[0][0].ToString());
            if (daylimit == -1 || daylimit < count)
            {

                query = "UPDATE `dailygatepasscount` SET `count`= count+1 WHERE `date`=?date;";
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?date", date);
                sci.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void reject(string id,string re)
        {
            string query = "UPDATE `gatepass` SET `status`=0 , reason=?re WHERE `gatepass_id`=?id";
            database = DatabaseController.getinstance();
            MySqlCommand sci = database.insertquery(query);
            sci.Parameters.AddWithValue("?re", re);
            sci.Parameters.AddWithValue("?id", id);
            sci.ExecuteNonQuery();
        }

        public void request(string rollno, string description, string duration)
        {
            string query = "INSERT INTO `gatepass`(`user_id`, `description`, `duration`) VALUES (?rollno,?descrip,?durat);";
            database = DatabaseController.getinstance();
            MySqlCommand sci = database.insertquery(query);
            sci.Parameters.AddWithValue("?rollno", rollno);
            sci.Parameters.AddWithValue("?descrip", description);
            sci.Parameters.AddWithValue("?durat", duration);
            sci.ExecuteNonQuery();
        }

        public int check_permission(string rollno)
        {
            database = DatabaseController.getinstance();

            database = DatabaseController.getinstance();
            string blacklistedQuery = "SELECT blacklisted from user where id=?roll;";
            MySqlCommand sc = database.select_query(blacklistedQuery);
            sc.Parameters.AddWithValue("?roll", rollno);
            MySqlDataReader sda = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            String n = dataTable.Rows[0][0].ToString();
            if (n == "True")
            {

                return 99;
            }


            string initialuserLoadQuery = "SELECT * from gatepass where user_id=?rollno;";
             sc = database.select_query(initialuserLoadQuery);
            sc.Parameters.AddWithValue("?rollno", rollno);
             sda = sc.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(sda);
            if (dataTable.Rows.Count == 0)
            {
                return 0;
            }

            string query = "SELECT time_added FROM `gatepass` WHERE user_id=?roll ORDER BY time_added DESC LIMIT 1;";
             sc = database.select_query(query);
            sc.Parameters.AddWithValue("?roll", rollno);
             sda = sc.ExecuteReader();

            dataTable = new DataTable();
            dataTable.Load(sda);
            DateTime timestamp = DateTime.Parse(dataTable.Rows[0][0].ToString());
            DateTime now = DateTime.Now;
            var hours = Math.Abs((timestamp - now).TotalHours);
            if (hours < 12.00)
            {
                return 1;
            }
            else if (!checklimits())
            {
                return 2;
            }
            else return 0;

        }

        public int setlimits(string daystr, string limit)
        {
            DayOfWeek day;
            string query;

            if (Enum.TryParse<DayOfWeek>(daystr, out day) && day == DateTime.Today.DayOfWeek)
            {
                query = "INSERT INTO `pendinglimits`(`day`, `limit`) VALUES (?daystr,?limit)";
                DatabaseController databaseController = DatabaseController.getinstance();
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?daystr", daystr);
                sci.Parameters.AddWithValue("?limit", limit);
                sci.ExecuteNonQuery();
                return 1;
            }
            else
            {
                query = "UPDATE `limits` SET `limit`= ?limit WHERE `day`=?daystr;";
                DatabaseController databaseController = DatabaseController.getinstance();
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?limit", limit);
                sci.Parameters.AddWithValue("?daystr", daystr);
                sci.ExecuteNonQuery();
                return 0;

            }
        }


        public DataTable loadtable()
        {
            database = DatabaseController.getinstance();

            string query = "SELECT gatepass.gatepass_id,gatepass.user_id, user.username,gatepass.description,gatepass.duration,gatepass.status FROM `gatepass` JOIN user on user.id=gatepass.user_id";
            MySqlCommand sc = database.select_query(query);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;

        }

        public DataTable loadtablebystatus(string status)
        {
            database = DatabaseController.getinstance();

            string query = "SELECT gatepass.gatepass_id,gatepass.user_id, user.username,gatepass.description,gatepass.duration,gatepass.status FROM `gatepass` JOIN user on user.id=gatepass.user_id WHERE STATUS =?status ";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?status", status);
            MySqlDataReader sda = sc.ExecuteReader();

         
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            sda.Close();
            return dataTable;

        }
        public DataTable loadtablebystatus(string status,string rollno)
        {
            database = DatabaseController.getinstance();

            string query = "SELECT gatepass.gatepass_id,gatepass.user_id, user.username,gatepass.description,gatepass.duration,gatepass.status FROM `gatepass` JOIN user on user.id=gatepass.user_id WHERE user_id like '%?rollno%' and status=?status;";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            sc.Parameters.AddWithValue("?status", status);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            sda.Close();
            return dataTable;

        }



        public DataTable gettablebyroll(string rollno)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT gatepass.gatepass_id as 'id' ,gatepass.user_id,gatepass.description,gatepass.time_added,gatepass.status , gatepass.reason FROM `gatepass` JOIN user on user.id=gatepass.user_id   WHERE user_id=?rollno;";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }
        public DataTable ParentLoadTable(string rollno)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT gatepass.gatepass_id as 'id' ,gatepass.user_id,gatepass.description,gatepass.status FROM `gatepass` JOIN user on user.id=gatepass.user_id WHERE user_id=?rollno;";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }


    }
}
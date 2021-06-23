using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class UtilityController
    {
        public static void updatelimits()
        {
            string query;
            query = "SELECT * FROM `pendinglimits`";
            DatabaseController database = DatabaseController.getinstance();
            MySqlCommand sc = database.select_query(query);
           
            MySqlDataReader dataReader = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            if (dataTable.Rows.Count > 0)
            {
                string day = dataTable.Rows[0][0].ToString();
                string limit = dataTable.Rows[0][1].ToString();
                query = "DELETE FROM `pendinglimits` WHERE `day`=?day and `limit`=?limit;";
                GatePass_Controller gatePass = new GatePass_Controller();
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?day", day);
                sci.Parameters.AddWithValue("?limit", limit);
                sci.ExecuteNonQuery();
                gatePass.setlimits(day, limit);

            }
        }
    }
}
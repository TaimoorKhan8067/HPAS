using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class MessMenuController
    {
        private DatabaseController database;
       public DataTable PrintMessMenu()
        {
            database = DatabaseController.getinstance();
            string query = "SELECT day,menubreakfast,pointbreakfast,menulunch,pointlunch,menudinner,pointdinner FROM `messmenu`";
            MySqlCommand sc = database.select_query(query);
           
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;


    }
        public DataTable PrintMessMenu(string mon,string week)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT day,menubreakfast,pointbreakfast,menulunch,pointlunch,menudinner,pointdinner FROM `messmenu` WHERE month=?mon AND week=?week";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?mon", mon);
            sc.Parameters.AddWithValue("?week", week);
            MySqlDataReader sda = sc.ExecuteReader();

          
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;


        }

    }
}
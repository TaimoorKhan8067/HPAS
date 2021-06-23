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
    public class MessBillController
    {
        private DatabaseController database;
        public DataTable ParentMessLoadTable(string rollno)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT mess.dateGenerated,mess.amount,mess.amountPaid,mess.remainingAmount,mess.fine FROM mess WHERE mess.stdid=?rollno";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }


        public DataTable StudentMessLoadTable(string rollno)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT mess.dateGenerated,mess.deadline,mess.amount,mess.fine FROM mess WHERE mess.stdid=?rollno";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }
    }

}
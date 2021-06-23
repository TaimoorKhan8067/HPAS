using Hostel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class AccountController { 
    
        private static DatabaseController database;
        public static Account Verfiy_user(string rollno,string password)
        {
            int n=0;
            Console.WriteLine(n);
            Account modal = new Account();
            string query = "SELECT `id`,`username`,`designation` FROM `user` WHERE `id`=?rollno and `password`=?pass;";
            database = DatabaseController.getinstance();
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?rollno", rollno);
            sc.Parameters.AddWithValue("?pass", password);
            MySqlDataReader ds = sc.ExecuteReader();
            
            while (ds.Read())
            {
                modal.Designation = ds.GetString("designation");
                modal.isauthenticated = true;

            }
           
            ds.Close();
            
            return modal;
        }
        public static string getstudentid(string parentid)
        {
            string studentid=null;
            string query = "SELECT stdid FROM parents WHERE parentid=?parentid;";
            database = DatabaseController.getinstance();
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?parentid", parentid);
            MySqlDataReader ds = sc.ExecuteReader();

            while (ds.Read())
            {
                studentid = ds.GetString("stdid");
            }

            ds.Close();
            return studentid;
        }

     
        public DataTable getRegisteredStudents()
        {
            database = DatabaseController.getinstance();
            string query = "SELECT * from user where designation='student'";
            MySqlCommand sc = database.select_query(query);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }
    }
}
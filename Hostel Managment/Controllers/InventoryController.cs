using Hostel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Controllers
{
    public class InventoryController
    {
        DatabaseController database;
        public DataTable loadtable()
        {
            database = DatabaseController.getinstance();
            string query = "SELECT inventory.id,inventory.name,Category.Name as 'category',inventory.stock from inventory JOIN Category on inventory.Category=Category.cat_id;";
         
            MySqlCommand sc = database.select_query(query);

            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }

        public DataTable loadTableByInventory(string invName)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT inventory.id,inventory.name,Category.Name as 'category',inventory.stock from inventory JOIN Category on inventory.Category=Category.cat_id where inventory.name like '%?invName%';";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?invName", invName);
            MySqlDataReader sda = sc.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }

        public DataTable load_category()
        {
            database = DatabaseController.getinstance();
            string query = "SELECT * from Category";
            MySqlCommand sc = database.select_query(query);
            MySqlDataReader sda = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            return dataTable;
        }
        private string loadproducttable(string name)
        {
            database = DatabaseController.getinstance();
            string query = "SELECT inventory.id from inventory WHERE inventory.name=?name";
            MySqlCommand sc = database.select_query(query);
            sc.Parameters.AddWithValue("?name", name);
            MySqlDataReader sda = sc.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sda);
            if (dataTable.Rows.Count > 0)
            {
                string id = dataTable.Rows[0]["id"].ToString();
                return id;
            }
            else 
                return "-9999";

        }
       
        public void insert(string name, string category, string stock)
        {
            string id = loadproducttable(name);
            if (id == "-9999")
            {
                string query = "INSERT INTO `inventory`( `name`, `category`, `stock`) VALUES (?name,?cat,?stock)";
                database = DatabaseController.getinstance();
                MySqlCommand sci = database.insertquery(query);
                sci.Parameters.AddWithValue("?name", name);
                sci.Parameters.AddWithValue("?cat", category);
                sci.Parameters.AddWithValue("?stock", stock);
                sci.ExecuteNonQuery();
            }
            else
            {
                Update_increment(id,stock);
            }
        }

        private void Update_increment(string id, string stock)
        {
            string query = "UPDATE `inventory` SET stock=stock+?stock WHERE id=?id";
            database = DatabaseController.getinstance();
            MySqlCommand sci = database.insertquery(query);
            sci.Parameters.AddWithValue("?stock", stock);
            sci.Parameters.AddWithValue("?id", id);
            sci.ExecuteNonQuery();
        }

        public void Update(string name,string category,string stock,string id)
        {
            string query = "UPDATE `inventory` SET `name`=?name,`category`=?cat,`stock`=?stock WHERE `id`=?id;";
            database = DatabaseController.getinstance();
            MySqlCommand sci = database.insertquery(query);
            sci.Parameters.AddWithValue("?name", name);
            sci.Parameters.AddWithValue("?cat", category);
            sci.Parameters.AddWithValue("?stock", stock);
            sci.Parameters.AddWithValue("?id", id);
            sci.ExecuteNonQuery();
        }

        public void delete(string id)
        {
            string query= "DELETE FROM `inventory` WHERE `id`=?id;";
            database = DatabaseController.getinstance();
            MySqlCommand sci = database.insertquery(query);
            sci.Parameters.AddWithValue("?id", id);
            sci.ExecuteNonQuery();
        }
    }
}
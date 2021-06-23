using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Managment.Controllers
{
    public class DatabaseController
    {
        private static string dbname= "ph11624147981_";
        private static string servername= "n1nlmysql57plsk.secureserver.net";
        private static string username= "taimoor";
        private static string password="28July@168";
        private static string constring = @"server=" + servername+ ";userid=" + username + ";password=" + password + "; database=" + dbname+";";
        private MySqlConnection conn = null;
        private static DatabaseController instance;

        private DatabaseController()
        {
            conn = new MySqlConnection(constring);
            conn.Open();
            
        }
        public static DatabaseController getinstance()
        {
            
            if (instance != null && instance.conn.State== ConnectionState.Open)
            {
                return instance;
            }
            else
            {
                instance = new DatabaseController();
                return instance;
            }
        }

        internal void close()
        {
            conn.Close();
        }

        public MySqlCommand select_query(string query)
        {
            MySqlCommand da = new MySqlCommand(query, conn);
          /// MySqlDataReader ds = da.ExecuteReader();
                    return da;
               
        }
        public MySqlCommand insertquery(string query)
        {
            MySqlCommand da = new MySqlCommand(query, conn);
           // da.ExecuteNonQuery();
            return da;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{
    public class Account
    {
        public string Username { get; set; }

        public string  Password { get; set; }

        public string Designation { get; set; }

        public bool isauthenticated { get; set; }

       public Account()
        {
            Username = null;
            Password = null;
            Designation = null;
            isauthenticated = false;
        }
    }
}

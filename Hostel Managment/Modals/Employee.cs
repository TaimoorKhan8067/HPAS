using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hostel_Managment.Modals
{
    public class Employee
    {
      public  Employee()
        {
            this.id = null;
            this.name = null;
            this.RFID = null;
            this.designation = null;
        }
        public string id { get; set; }
        public string RFID { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
    }
}
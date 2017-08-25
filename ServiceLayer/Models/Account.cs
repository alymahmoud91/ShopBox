using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
   public class Account
    {
        public int uid { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string mobile { get; set; }
        public string title { get; set; }
        public object code { get; set; }
        public int verified_time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class CashRegister
    {
        public int uid { get; set; }
        public string name { get; set; }
        public int branch { get; set; }
        public int terminal_enabled { get; set; }
        public object fiscal_register { get; set; }
        public object package { get; set; }
        public object filter_uid { get; set; }
        public int crdate { get; set; }
        public int tstamp { get; set; }
        public string crdate_formatted { get; set; }
        public string tstamp_formatted { get; set; }
        public Filter filter { get; set; }
    }
}

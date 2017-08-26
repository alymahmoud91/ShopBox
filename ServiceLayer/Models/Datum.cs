using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Datum
    {
        public int uid { get; set; }
        public string name { get; set; }
        public string branch_pin { get; set; }
        public int cash_count { get; set; }
        public int client { get; set; }
        public string address { get; set; }
        public object phone { get; set; }
        public object email { get; set; }
        public int time_zone { get; set; }
        public object custom_receipt_text { get; set; }
        public int crdate { get; set; }
        public int tstamp { get; set; }
        public string crdate_formatted { get; set; }
        public string tstamp_formatted { get; set; }
        public List<CashRegister> cash_registers { get; set; }
        public Address address0 { get; set; }
        public Zone0 zone0 { get; set; }
    }
}

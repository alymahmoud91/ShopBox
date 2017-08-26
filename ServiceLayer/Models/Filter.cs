using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Filter
    {
        public int uid { get; set; }
        public string name { get; set; }
        public int client { get; set; }
        public int @default { get; set; }
        public int crdate { get; set; }
        public int tstamp { get; set; }
        public string crdate_formatted { get; set; }
        public string tstamp_formatted { get; set; }
    }
}

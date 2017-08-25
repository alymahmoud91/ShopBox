using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Client
    {
        public int uid { get; set; }
        public string tstamp { get; set; }
        public string crdate { get; set; }
        public int deleted { get; set; }
        public int hidden { get; set; }
        public Client2 client { get; set; }
        public Account account { get; set; }
        public int role { get; set; }
        public int preferred { get; set; }
        public object token { get; set; }
        public object branch { get; set; }
        public string code { get; set; }
    }

   
}

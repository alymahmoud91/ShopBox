using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RestClient
{
    public class GlobalResponse<T>
    {
       
        public Error error { get; set; }
        public T Value { get; set; }
    }
}

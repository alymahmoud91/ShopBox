using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class Product
    {
        public int uid { get; set; }
        public string name { get; set; }
        public object kitchen_name { get; set; }
        public object display_name { get; set; }
        public object stock_price { get; set; }
        public double selling_price { get; set; }
        public Image image { get; set; }
        public string code { get; set; }
        public int quantity { get; set; }
        public int client { get; set; }
        public string crdate { get; set; }
        public string tstamp { get; set; }
        public int deleted { get; set; }
        public int hidden { get; set; }
        public int weight { get; set; }
        public string color { get; set; }
        public int tax { get; set; }
        public object description { get; set; }
        public string type { get; set; }
        public int? web_shop_show { get; set; }
        public object tag { get; set; }
        public object integration { get; set; }
        public object preparation_time { get; set; }
        public Tag0 tag0 { get; set; }
        public int not_kitchen { get; set; }
        public List<object> product_variances { get; set; }
        public int is_favourite { get; set; }
        public Tax0 tax0 { get; set; }
        public Unit unit { get; set; }
    }
}
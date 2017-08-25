namespace ServiceLayer.Models
{
    public class Tax
    {
        public int uid { get; set; }
        public string crdate { get; set; }
        public string tstamp { get; set; }
        public int deleted { get; set; }
        public int hidden { get; set; }
        public string name { get; set; }
        public double percentage { get; set; }
        public int enabled { get; set; }
        public int client { get; set; }
    }
}
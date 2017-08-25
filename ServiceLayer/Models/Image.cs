namespace ServiceLayer.Models
{
    public class Image
    {
        public int uid { get; set; }
        public string path { get; set; }
        public string crdate { get; set; }
        public string tstamp { get; set; }
        public int deleted { get; set; }
        public int hidden { get; set; }
        public string image_original { get; set; }
        public string image_large { get; set; }
        public string image_medium { get; set; }
        public string image_small { get; set; }
    }
}
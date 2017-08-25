namespace ServiceLayer.RestClient
{
    public class Error
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public int status { get; set; }
        public string type { get; set; }
    }
}
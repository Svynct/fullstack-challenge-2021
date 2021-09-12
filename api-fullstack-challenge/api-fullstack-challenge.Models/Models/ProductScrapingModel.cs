namespace api_fullstack_challenge.Models
{
    public class ProductScrapingModel
    {
        public long code { get; set; }
        public string barcode { get; set; }
        public string quantity { get; set; }
        public string brands { get; set; }
        public string packaging { get; set; }
        public string categories { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string product_name { get; set; }
    }
}

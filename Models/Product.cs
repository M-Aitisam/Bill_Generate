namespace Bill_Generate.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }
        public string? ImgUrl { get; set; }
    }

}

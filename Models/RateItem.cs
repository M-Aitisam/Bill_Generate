namespace Bill_Generate.Models
{
    public class RateItem
    {
      
            public string? Name { get; set; }
            public decimal BasePrice { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; } = 1;
            public bool IsEditing { get; set; } = false;
            public string? ImageUrl { get; set; } = string.Empty;
        
    }
}

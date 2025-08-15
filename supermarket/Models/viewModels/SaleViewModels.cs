namespace supermarket.Models.ViewModels
{
    public class SaleViewModel
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public List<SaleItemViewModel> Products { get; set; } = new();
    }

    public class SaleItemViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class AddProductRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class SaveSaleRequest
    {
        public int CustomerId { get; set; }
        public List<SaleItemViewModel> Products { get; set; } = new();
    }
}


namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int StockQuantity { get; set; }
    }
}
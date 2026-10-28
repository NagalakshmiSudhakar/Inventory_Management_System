
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository =
            new ProductRepository();

        public bool AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductCode))
            {
                throw new ArgumentException(
                    "Product code cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                throw new ArgumentException(
                    "Product name cannot be empty.");
            }

            if (product.CostPrice < 0)
            {
                throw new ArgumentException(
                    "Cost price cannot be negative.");
            }

            if (product.SellingPrice < 0)
            {
                throw new ArgumentException(
                    "Selling price cannot be negative.");
            }

            if (product.StockQuantity < 0)
            {
                throw new ArgumentException(
                    "Stock quantity cannot be negative.");
            }

            return productRepository.AddProduct(product);
        }
    }
}

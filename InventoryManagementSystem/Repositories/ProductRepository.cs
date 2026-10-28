
using Microsoft.Data.SqlClient;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseConnection databaseConnection =
            new DatabaseConnection();

        public bool AddProduct(Product product)
        {
            using SqlConnection connection =
                databaseConnection.GetConnection();

            string query = @"
                INSERT INTO Products
                (ProductCode, ProductName, CostPrice,
                 SellingPrice, StockQuantity)
                VALUES
                (@ProductCode, @ProductName, @CostPrice,
                 @SellingPrice, @StockQuantity);";

            using SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);

            command.Parameters.AddWithValue(
                "@ProductName", product.ProductName);

            command.Parameters.AddWithValue(
                "@CostPrice", product.CostPrice);

            command.Parameters.AddWithValue(
                "@SellingPrice", product.SellingPrice);

            command.Parameters.AddWithValue(
                "@StockQuantity", product.StockQuantity);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }
}

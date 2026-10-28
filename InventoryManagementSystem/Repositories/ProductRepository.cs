
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseConnection databaseConnection =
            new DatabaseConnection();

        // Add a new product to the database
        public bool AddProduct(Product product)
        {
            using SqlConnection connection =
                databaseConnection.GetConnection();

            string query = @"
                INSERT INTO Products
                (
                    ProductCode,
                    ProductName,
                    CostPrice,
                    SellingPrice,
                    StockQuantity
                )
                VALUES
                (
                    @ProductCode,
                    @ProductName,
                    @CostPrice,
                    @SellingPrice,
                    @StockQuantity
                );";

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

        // Retrieve all products from the database
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using SqlConnection connection =
                databaseConnection.GetConnection();

            string query = @"
                SELECT
                    ProductId,
                    ProductCode,
                    ProductName,
                    CostPrice,
                    SellingPrice,
                    StockQuantity
                FROM Products
                ORDER BY ProductId;";

            using SqlCommand command =
                new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductCode = reader.GetString(1),
                    ProductName = reader.GetString(2),
                    CostPrice = reader.GetDecimal(3),
                    SellingPrice = reader.GetDecimal(4),
                    StockQuantity = reader.GetInt32(5)
                };

                products.Add(product);
            }

            return products;
        }
    }
}

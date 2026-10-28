
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

ProductService productService = new ProductService();

Console.WriteLine("===== INVENTORY MANAGEMENT SYSTEM =====");
Console.WriteLine("1. Add Product");
Console.WriteLine("0. Exit");
Console.Write("Enter your choice: ");

string? choice = Console.ReadLine();

switch (choice)
{
    case "1":
        AddProduct();
        break;

    case "0":
        Console.WriteLine("Exiting application...");
        break;

    default:
        Console.WriteLine("Invalid choice.");
        break;
}

void AddProduct()
{
    try
    {
        Console.Write("Enter product code: ");
        string productCode = Console.ReadLine() ?? "";

        Console.Write("Enter product name: ");
        string productName = Console.ReadLine() ?? "";

        Console.Write("Enter cost price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal costPrice))
        {
            Console.WriteLine("Invalid cost price.");
            return;
        }

        Console.Write("Enter selling price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal sellingPrice))
        {
            Console.WriteLine("Invalid selling price.");
            return;
        }

        Console.Write("Enter stock quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int stockQuantity))
        {
            Console.WriteLine("Invalid stock quantity.");
            return;
        }

        Product product = new Product
        {
            ProductCode = productCode,
            ProductName = productName,
            CostPrice = costPrice,
            SellingPrice = sellingPrice,
            StockQuantity = stockQuantity
        };

        bool result = productService.AddProduct(product);

        if (result)
        {
            Console.WriteLine("Product added successfully!");
        }
        else
        {
            Console.WriteLine("Product could not be added.");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Microsoft.Data.SqlClient.SqlException ex)
    {
        if (ex.Number == 2601 || ex.Number == 2627)
        {
            Console.WriteLine("Product code already exists.");
        }
        else
        {
            Console.WriteLine("Database error: " + ex.Message);
        }
    }
}

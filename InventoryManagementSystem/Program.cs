
using Microsoft.Data.SqlClient;
using InventoryManagementSystem.Repositories;

DatabaseConnection db = new DatabaseConnection();

try
{
    using SqlConnection connection = db.GetConnection();

    connection.Open();

    Console.WriteLine("Database connected successfully!");
    Console.WriteLine("Database name: " + connection.Database);
}
catch (Exception ex)
{
    Console.WriteLine("Database connection failed!");
    Console.WriteLine(ex.Message);
}

Console.ReadLine();

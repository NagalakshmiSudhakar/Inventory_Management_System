using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Repositories
{
    public class DatabaseConnection
    {

        private readonly string connectionString =
            @"Server=localhost;Database=InventoryManagementSystemDB;Integrated Security=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

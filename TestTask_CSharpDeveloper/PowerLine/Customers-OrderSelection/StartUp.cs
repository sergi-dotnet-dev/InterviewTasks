using Customers_OrderSelection.DAL;
using Microsoft.Data.SqlClient;
using System;

public static class Program
{
    static String defaultConnection = @"Server=INSPECTOR\LOCALSQLSERVER;Database=master;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=Yes;";
    public static async Task Main(String[] args)
    {
        CreateDatabase();
        CreateTables();
        await SeedCustomers();
        await SeedOrders();
        await NoOrderCustomersOutput();
    }

    private async static Task SeedOrders()
    {
        using (SqlConnection connection = new SqlConnection(ServerConnection.GetConnection))
        {
            await connection.OpenAsync();

            SqlCommand sqlCommand = new();
            sqlCommand.CommandText = "Insert into Orders (CustomerId) Values (2),(4)";
            sqlCommand.Connection = connection;

            await sqlCommand.ExecuteNonQueryAsync();
        }
    }

    private async static Task SeedCustomers()
    {
        using (SqlConnection connection = new SqlConnection(ServerConnection.GetConnection))
        {
            await connection.OpenAsync();

            SqlCommand sqlCommand = new();
            sqlCommand.CommandText = "Insert into Customers Values (@Max),(@Pavel),(@Ivan),(@Leonid)";
            sqlCommand.Parameters.Add("@Max", System.Data.SqlDbType.NVarChar).Value = "Max";
            sqlCommand.Parameters.Add("@Pavel", System.Data.SqlDbType.NVarChar).Value = "Pavel";
            sqlCommand.Parameters.Add("@Ivan", System.Data.SqlDbType.NVarChar).Value = "Ivan";
            sqlCommand.Parameters.Add("@Leonid", System.Data.SqlDbType.NVarChar).Value = "Leonid";
            sqlCommand.Connection = connection;

            await sqlCommand.ExecuteNonQueryAsync();
        }
    }

    private static async Task NoOrderCustomersOutput()
    {
        using (SqlConnection connection = new SqlConnection(ServerConnection.GetConnection))
        {
            await connection.OpenAsync();

            SqlCommand sqlCommand = new();
            sqlCommand.CommandText = "Select Customers.Name from Customers where not exists (select CustomerId from Orders where Customers.Id = Orders.CustomerId)";
            sqlCommand.Connection = connection;

            using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("Name");
                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine((String)reader["Name"]);
                    }
                }
            }
        }
    }
    private static void CreateDatabase()
    {
        using (SqlConnection connection = new(defaultConnection))
        {
            connection.Open();
            SqlCommand sqlCommand = new("Create database customersdb", connection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                Console.WriteLine("Database already exists");
            }
        }
    }
    private static void CreateTables()
    {
        using (SqlConnection connection = new SqlConnection(ServerConnection.GetConnection))
        {
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = "CREATE TABLE Customers (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(100) NOT NULL) " +
                " CREATE TABLE Orders (Id INT PRIMARY KEY IDENTITY, CustomerId Int, Foreign Key (CustomerId) references Customers (id))";
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                Console.WriteLine("Tables already exists");
            }
        }
    }
}
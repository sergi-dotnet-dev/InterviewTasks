namespace Customers_OrderSelection.DAL
{
    public static class ServerConnection
    {
        private const String connectionString = @"Server=INSPECTOR\LOCALSQLSERVER;Database=customersdb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=Yes;";
        public static String GetConnection => connectionString;
    }
}

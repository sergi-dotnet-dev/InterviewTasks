using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SpaMvc.Infrastructure.Abstract;

namespace SpaMvc.Infrastructure
{
    public class SqlConnect : IServerConnect
    {
        private readonly String _connection;
        public SqlConnect(String connection)
        {
            _connection = connection;
        }

        public SqlConnection Connect() 
            => new(_connection);
    }
}

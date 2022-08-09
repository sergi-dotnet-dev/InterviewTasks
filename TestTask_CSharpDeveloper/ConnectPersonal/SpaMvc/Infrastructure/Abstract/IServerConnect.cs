using Microsoft.Data.SqlClient;

namespace SpaMvc.Infrastructure.Abstract
{
    public interface IServerConnect
    {
        SqlConnection Connect();
    }
}

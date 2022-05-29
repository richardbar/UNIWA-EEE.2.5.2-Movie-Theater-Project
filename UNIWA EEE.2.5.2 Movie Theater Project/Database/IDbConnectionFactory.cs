using System.Data;

namespace MovieTheaterProject.Database;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}

using System.Data;

namespace MovieTheaterProject.API.Database;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}

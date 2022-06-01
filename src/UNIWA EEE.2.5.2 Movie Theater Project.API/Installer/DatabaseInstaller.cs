using MovieTheaterProject.API.Database;


namespace MovieTheaterProject.API.Installer;

public sealed class DatabaseInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException(null, nameof(configuration));

        services.AddSingleton<IDbConnectionFactory>(_ =>
            new SqliteConnectionFactory(connectionString));
        services.AddSingleton<DatabaseInitializer>();
    }
}

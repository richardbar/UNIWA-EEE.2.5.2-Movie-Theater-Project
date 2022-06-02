namespace MovieTheaterProject.API.Installer;

public sealed class CorsInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("*")
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
            });
        });
    }
}

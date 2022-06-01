namespace MovieTheaterProject.API.Installer;

public sealed class FastEndpointInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints();
    }
}

using FastEndpoints;

namespace MovieTheaterProject.Installer;

public sealed class FastEndpointInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints();
    }
}

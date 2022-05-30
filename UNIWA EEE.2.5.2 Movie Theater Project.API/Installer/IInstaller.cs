namespace MovieTheaterProject.API.Installer;

public interface IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration);
}

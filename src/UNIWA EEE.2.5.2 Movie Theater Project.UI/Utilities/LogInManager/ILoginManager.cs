namespace MovieTheaterProject.UI.Utilities.LoginManager;

public interface ILoginManager
{
    public void Login();

    public bool IsLoggedIn();

    public void Logout();
}

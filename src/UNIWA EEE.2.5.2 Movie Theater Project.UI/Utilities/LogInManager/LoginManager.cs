using Blazored.LocalStorage;

namespace MovieTheaterProject.UI.Utilities.LoginManager;

public sealed class LoginManager : ILoginManager
{
    private ISyncLocalStorageService _localStorage;

    public LoginManager(ISyncLocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public void Login()
    {
        _localStorage.SetItemAsString("loggedin", "true");
    }

    public bool IsLoggedIn()
    {
        return _localStorage.ContainKey("loggedin") && _localStorage.GetItemAsString("loggedin") == "true";
    }

    public void Logout()
    {
        _localStorage.SetItemAsString("loggedin", "false");
    }
}

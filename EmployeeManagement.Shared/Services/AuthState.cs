namespace EmployeeManagement.Shared.Services;

public class AuthState
{
    public bool IsLoggedIn { get; private set; }
    public string? Username { get; private set; }
    public string? FullName { get; private set; }

    public event Action? OnChange;

    public void SetUser(string username, string fullName)
    {
        IsLoggedIn = true;
        Username = username;
        FullName = fullName;
        OnChange?.Invoke();
    }

    public void Logout()
    {
        IsLoggedIn = false;
        Username = null;
        FullName = null;
        OnChange?.Invoke();
    }
}
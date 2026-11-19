namespace PracticeWebApp.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string PasswordHash { get; set; } = "";
}

public class UserCreate
{
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
}

public class UserLogin
{
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
}
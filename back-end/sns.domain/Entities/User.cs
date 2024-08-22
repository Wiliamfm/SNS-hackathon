using Microsoft.AspNetCore.Identity;
using sns.domain.Entities.Common;

namespace sns.domain.Entities;

public class User : AuditEntity
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private string _password = null!;

    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password
    {
        get => _password;
        set => _password = SetPassword(value);
    }
    public string Name { get; set; } = null!;
    public bool isActive { get; set; }
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    public User() { }

    public User(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string SetPassword(string password)
    {
        return _passwordHasher.HashPassword(this, password);
    }

    public bool IsValidPassword(string passowrd)
    {
        return _passwordHasher.VerifyHashedPassword(this, this.Password, passowrd) == PasswordVerificationResult.Success;
    }
}

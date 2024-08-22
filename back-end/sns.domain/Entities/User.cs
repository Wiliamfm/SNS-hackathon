using Microsoft.AspNetCore.Identity;
using sns.domain.Entities.Common;

namespace sns.domain.Entities;

public class User(IPasswordHasher<User> passwordHasher) : AuditEntity
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private string password = null!;

    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password
    {
        get => password;
        set => password = SetPassword(value);
    }
    public string Name { get; set; } = null!;
    public bool isActive { get; set; }

    public string SetPassword(string password)
    {
        return _passwordHasher.HashPassword(this, password);
    }

    public bool ValidatePassword(string passowrd)
    {
        return _passwordHasher.VerifyHashedPassword(this, this.Password, passowrd) == PasswordVerificationResult.Success;
    }
}

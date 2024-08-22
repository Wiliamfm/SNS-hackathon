using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using sns.application.Interfaces.Persistence;
using sns.domain.Entities;
using Sns.Application.Interfaces.Security;

namespace sns.application.Auth;

public class AuthService(ILogger<AuthService> logger, IJwtGenerator jwtGenerator, IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IAuthService
{
    private readonly ILogger<AuthService> _logger = logger;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetAsync(email);
        if (user is null || !user.IsValidPassword(password))
        {
            throw new Exception("Invalid Credentials");
        }
        var token = _jwtGenerator.GenerateToken(user.Email, user.Id, user.Roles.Select(role => role.Name));
        _logger.LogInformation($"User Logged in: {user.Email}");
        return new AuthenticationResult(token, user.Id, user.Email);
    }

    public async Task<AuthenticationResult> RegisterAsync(string email, string password, string name)
    {
        var user = await _userRepository.GetAsync(email);
        if (user is not null)
        {
            throw new Exception("User already exists");
        }

        user = new User(passwordHasher);
        user.Email = email;
        user.Name = name;
        user.Password = user.SetPassword(password);
        await _userRepository.AddAsync(user);
        _logger.LogInformation($"User registered: {email}");
        return new AuthenticationResult(_jwtGenerator.GenerateToken(user.Email, user.Id, user.Roles.Select(role => role.Name)), user.Id, email);
    }

    public Task LogoutAsync(string email)
    {
        throw new NotImplementedException();
    }
}

namespace sns.application.Auth;

public interface IAuthService
{
  Task<AuthenticationResult> LoginAsync(string email, string password);
  Task<AuthenticationResult> RegisterAsync(string email, string password, string name);
  Task LogoutAsync(string email);
}

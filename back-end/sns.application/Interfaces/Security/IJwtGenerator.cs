namespace Sns.Application.Interfaces.Security;

public interface IJwtGenerator
{
  string GenerateToken(string email, Guid id, IEnumerable<string> roles);
}

namespace sns.application.Auth;

public record AuthenticationResult
(
  string token,
  Guid userId,
  string email
);

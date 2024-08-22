namespace sns.contracts.Auth;

public record AuthResponse
(
  string token,
  Guid userId,
  string email
);

namespace sns.contracts.Auth;

public record RegisterRequest
(
  string Email,
  string Name,
  string Password
);

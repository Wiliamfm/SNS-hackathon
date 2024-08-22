using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sns.application.Auth;
using sns.contracts.Auth;

namespace sns.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [Authorize]
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> RegisterAsync()
    {
        var result = await _authService.RegisterAsync("email", "password", "name");
        return new AuthResponse(token: result.token, userId: result.userId, email: result.email);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> LoginAsync()
    {
        var result = await _authService.LoginAsync("email", "password");
        return new AuthResponse(token: result.token, userId: result.userId, email: result.email);
    }

    [HttpPost("logout")]
    public async Task<ActionResult<bool>> LogoutAsync()
    {
        var result = await _authService.RegisterAsync("email", "password", "name");
        return true;
    }
}

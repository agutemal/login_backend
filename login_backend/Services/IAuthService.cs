namespace login_backend.Services;
using login_backend.Dtos;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginRequestDto request);
    Task<AuthResult> RegisterAsync(RegisterRequestDto request);
}

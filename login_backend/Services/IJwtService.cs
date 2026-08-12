using login_backend.Models;

namespace login_backend.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

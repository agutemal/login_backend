using login_backend.Dtos;

namespace login_backend.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
    }
}

using login_backend.Models;

namespace login_backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task AddAsync(User user);
    }
}

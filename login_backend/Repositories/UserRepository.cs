using login_backend.Db;
using login_backend.Models;
using Microsoft.EntityFrameworkCore;
namespace login_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca un usuario por su correo
        public async Task<User?> GetByEmail(string correo)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == correo);
        }

        // Guarda un nuevo usuario en la base de datos
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}

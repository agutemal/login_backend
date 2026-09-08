using login_backend.Dtos;
using login_backend.Models;
using login_backend.Repositories;
namespace login_backend.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var usuarios = await _userRepository.GetAllUser();
            var resultado = usuarios.Select(u =>new UserResponseDto
            {
                Id = u.Id,
                Nombre = u.UserName,
                Correo = u.Email
            }).ToList();
            return resultado;
        }

    }
}

using BCrypt.Net;
using login_backend.Dtos;
using login_backend.Models;
using login_backend.Repositories;

namespace login_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;

        }
        public async Task<AuthResult> LoginAsync(LoginRequestDto request)
        {
            // Paso 1: Buscar al usuario por email
            var user = await _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                // No revelamos si fue el email o el password lo que falló
                // (evita que un atacante sepa qué emails existen)
                return AuthResult.Fail("Credenciales inválidas");
            }

            // Paso 2: Verificar el password contra el hash guardado
            bool passwordValido = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!passwordValido)
            {
                return AuthResult.Fail("Credenciales inválidas");
            }

            // Paso 3: Generar el token JWT para este usuario
            string token = _jwtService.GenerateToken(user);

            // Paso 4: Devolver el resultado exitoso con el token
            return AuthResult.Ok(token);

        }
        // ----------------------------------------------------
        // REGISTER
        // ----------------------------------------------------
        public async Task<AuthResult> RegisterAsync(RegisterRequestDto request)
        {
            // Paso 1: Verificar que el email no esté registrado ya
            var existente = await _userRepository.GetByEmail(request.email);

            if (existente != null)
            {
                return AuthResult.Fail("El email ya está registrado");
            }

            // Paso 2: Hashear el password (NUNCA se guarda en texto plano)
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password);

            // Paso 3: Crear la entidad User
            var nuevoUsuario = new User
            {
                Email = request.email,
                Password = passwordHash,
                UserName = request.name
            };

            // Paso 4: Guardar en la base de datos
            await _userRepository.AddAsync(nuevoUsuario);

            // Paso 5: Generar token para loguear automáticamente tras registrarse (opcional)
            string token = _jwtService.GenerateToken(nuevoUsuario);

            return AuthResult.Ok(token);
        }

    }
}

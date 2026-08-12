using login_backend.Dtos;
using login_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace login_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // Paso 1: ASP.NET Core ya validó automáticamente los [Required]
            // del DTO antes de llegar aquí (gracias a [ApiController]).
            // Si algo falta, el cliente ya recibió un 400 sin que este código se ejecute.

            // Paso 2: Delegar toda la lógica de negocio al AuthService
            var resultado = await _authService.LoginAsync(request);

            // Paso 3: Mapear el AuthResult (interno) a LoginResponseDto (lo que ve el cliente)
            var response = new LoginResponseDto
            {
                Success = resultado.Success,
                Token = resultado.Token,
                Menssaje = resultado.ErrorMessage
            };

            // Paso 4: Elegir el código HTTP correcto según el resultado
            if (!resultado.Success)
            {
                return Unauthorized(response); // 401
            }

            return Ok(response); // 200
        }

    }
}

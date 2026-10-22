using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_backend.Dtos
{
    public class CreateUserDto
    {
        [Required,StringLength(100),Column("user_name")]
        public string UserName { get; set; }=string.Empty;
        [Required, StringLength(100), EmailAddress, Column("email")]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(8), StringLength(100), Column("pass_word")]
        public string Pasword { get; set; } = string.Empty;


    }
    public class UpdateUserDto
    {
        [Required, StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;
    }
    // DTOs/UserResponseDto.cs  (lo único que sale hacia el cliente)
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}

namespace login_backend.Dtos
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? Menssaje { get; set; }
    }
}

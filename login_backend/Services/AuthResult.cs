namespace login_backend.Services
{
    public class AuthResult
    {
        public bool Success { get; private set; }
        public string? Token { get; private set; }
        public string? ErrorMessage { get; private set; }
        // Constructor privado: nadie puede hacer "new AuthResult()" directamente
        // Se fuerza a usar los métodos Ok() o Fail() de abajo
        private AuthResult() { }

        // Se usa cuando el login/registro fue exitoso
        public static AuthResult Ok(string token)
        {
            return new AuthResult
            {
                Success = true,
                Token = token,
                ErrorMessage = null
            };
        }

        // Se usa cuando el login/registro falló
        public static AuthResult Fail(string errorMessage)
        {
            return new AuthResult
            {
                Success = false,
                Token = null,
                ErrorMessage = errorMessage
            };
        }
    }
}

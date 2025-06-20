namespace finance_api.Dtos.UserDtos
{
    public class LoginUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Optional: You can add properties for RememberMe or other login-related fields if needed
        // public bool RememberMe { get; set; } = false;
    }
}

namespace finance_api.Dtos.UserDtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;

        /*public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
        public string Username { get; set; } = string.Empty;*/

        // Optional: Add any additional user information you want to return
        // public string Email { get; set; } = string.Empty;
        // public string FirstName { get; set; } = string.Empty;
        // public string LastName { get; set; } = string.Empty;
    }
}

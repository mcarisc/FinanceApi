using finance_api.Dtos.UserDtos;

namespace finance_api.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterUserDto dto);
        Task<string?> LoginAsync(LoginUserDto dto);
        /*Task<bool> LogoutAsync();
        Task<bool> IsUserAuthenticatedAsync();
        Task<string> GetCurrentUsernameAsync();
        Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);
        Task<bool> DeleteAccountAsync();*/
    }
}

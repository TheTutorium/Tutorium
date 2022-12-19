using tutorium.Dtos.UserDto;

namespace tutorium.Services.AuthService
{
    public interface IAuthService
    {
        Task<GetUserDto> CheckUser();
        Task<bool> DoesUserExist(string username);
        Task<int> GetUserId(string email);
        Task<GetUserDto> Login(LoginUserDto userLoginDto);
        Task<int> Register(SignupUserDto userRegisterDto);
    }
}

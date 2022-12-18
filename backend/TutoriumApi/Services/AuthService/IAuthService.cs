using tutorium.Dtos.User;
using tutorium.Models;
using tutorium.Utils;

namespace tutorium.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDto userDto);
        Task<ServiceResponse<GetUserDto>> Login(UserLoginDto userLoginDto);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<GetUserDto>> check();
        Task<ServiceResponse<int>> IdOfUser(string email);
        Task<ServiceResponse<int>> IdOfUser();
    }
}
using BlazorProject.Shared;

namespace BlazorProject.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceModel<int>> Register(UserRegister request);
        Task<ServiceModel<string>> Login(UserLogin request);
        Task<bool> IsUserAuthenticated();
        Task<int> GetUsersCount();
    }
}

namespace BlazorProject.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceModel<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceModel<string>> Login(string email, string password);
        int GetUserId();
        string GetUserEmail();
        Task<User> GetUserByEmail(string email);
    }
}

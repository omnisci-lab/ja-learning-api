using IdentityCore.Models;

namespace Japanese.LanguageCore.Identity;

public interface IIdentityManager
{
    Task CreateUserAsync(UserModel userModel);
    Task<UserModel> GetUserAsync(string username);
}
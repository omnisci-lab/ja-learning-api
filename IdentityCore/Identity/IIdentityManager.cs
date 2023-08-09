using IdentityCore.Models;

namespace Japanese.LanguageCore.Identity;

public interface IIdentityManager
{
    Task<UserModel> GetUserAsync(string username);
}
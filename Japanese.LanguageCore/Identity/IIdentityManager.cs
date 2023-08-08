using Japanese.LanguageCore.AWS.Cognito;

namespace Japanese.LanguageCore.Identity;

public interface IIdentityManager
{
    Task<UserModel> GetUserAsync(string username);
}
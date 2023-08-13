using IdentityCore;
using IdentityCore.Models;

namespace Japanese.LanguageCore.Identity;

public class IdentityManager : IIdentityManager
{
    private CognitoHelper _cognitoHelper;

    public IdentityManager(CognitoHelper cognitoHelper)
    {
        _cognitoHelper = cognitoHelper;
    }

    public async Task CreateUserAsync(UserModel userModel)
    {
        await _cognitoHelper.CreateUserAsync(userModel);
    }

    public Task<UserModel> GetUserAsync(string username) => null;
}
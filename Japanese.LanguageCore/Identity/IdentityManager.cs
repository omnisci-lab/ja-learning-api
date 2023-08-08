using Japanese.LanguageCore.AWS.Cognito;

namespace Japanese.LanguageCore.Identity;

public class IdentityManager : IIdentityManager
{
    private CognitoHelper _cognitoHelper;

    public IdentityManager(CognitoHelper cognitoHelper)
    {
        _cognitoHelper = cognitoHelper;
    }

    public Task<UserModel> GetUserAsync(string username) => null;
}
namespace Japanese.LanguageCore.AWS.Cognito;

public class SignInModel
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}

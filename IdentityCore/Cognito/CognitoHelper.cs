using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using IdentityCore.Models;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Microsoft.AspNetCore.Identity;

namespace IdentityCore;

public class CognitoHelper
{
    private readonly CognitoUserManager<CognitoUser> _userManager;
    private readonly SignInManager<CognitoUser> _signInManager;
    private readonly CognitoUserPool _pool;

    public CognitoHelper(CognitoUserManager<CognitoUser> userManager, SignInManager<CognitoUser> signInManager, CognitoUserPool pool)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _pool = pool;
    }

    public async Task<ExecResult> CreateUserAsync(UserModel user)
    {
        CognitoUser cognitoUser = _pool.GetUser(user.UserName);
        cognitoUser.Attributes.Add(CognitoAttribute.Email.AttributeName, user.Email);
        cognitoUser.Attributes.Add(CognitoAttribute.FamilyName.AttributeName, user.FamilyName);
        cognitoUser.Attributes.Add(CognitoAttribute.MiddleName.AttributeName, user.MiddleName);
        cognitoUser.Attributes.Add(CognitoAttribute.GivenName.AttributeName, user.GivenName);
        cognitoUser.Attributes.Add(CognitoAttribute.BirthDate.AttributeName, user.BirthDate.ToString("yyyy-MM-dd"));
        cognitoUser.Attributes.Add(CognitoAttribute.Gender.AttributeName, user.Gender);
        cognitoUser.Attributes.Add(CognitoAttribute.PhoneNumber.AttributeName, user.PhoneNumber);
        cognitoUser.Attributes.Add(CognitoAttribute.Locale.AttributeName, user.Locale);
        cognitoUser.Attributes.Add(CognitoAttribute.Address.AttributeName, user.Address);
        cognitoUser.Attributes.Add(CognitoAttribute.ZoneInfo.AttributeName, "Global");
        cognitoUser.Attributes.Add(CognitoAttribute.UpdatedAt.AttributeName, ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString());
        
        IdentityResult identityResult = await _userManager.CreateAsync(cognitoUser, user.Password);
        if (identityResult.Succeeded)
            return new ExecResult { Status = ExecStatus.Success };

        return new ExecResult { 
            Status = ExecStatus.Failed
        };
    }

    public async Task<ExecResult> SignInAsync(SignInModel signInModel)
    {
        CognitoUser cognitoUser = _pool.GetUser(signInModel.UserName);

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(cognitoUser, signInModel.Password, signInModel.RememberMe, lockoutOnFailure: false);
        if (signInResult.Succeeded)
            return new ExecResult { };
        else if (signInResult.RequiresTwoFactor)
        {
            return new ExecResult { };
        }


        return new ExecResult { Status = ExecStatus.Failed };
    }
}

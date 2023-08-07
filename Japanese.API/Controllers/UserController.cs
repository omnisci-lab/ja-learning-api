using Japanese.API.Base;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Services.Features.User.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Japanese.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        //private readonly IConfiguration _configuration;

        public UserController(IMediator mediator) : base(mediator)
        {
        }

        //private JwtSecurityToken GetToken(List<Claim> authClaims)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return token;
        //}

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(ExecResult),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] SignUpCommand command)
        {
            return await GetObjectResult(command);
        }


        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] RegistrationViewModel registrationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser
        //        {
        //            UserName = registrationViewModel.UserName,
        //            Email = registrationViewModel.Email
        //        };
        //        //create user and add simpleuser role
        //        try
        //        {
        //            var result = await _userManager.CreateAsync(user, registrationViewModel.Password);
        //            if (result.Succeeded)
        //            {
        //                await _userManager.AddToRoleAsync(user, Constants.SimpleUser);
        //                return Ok();
        //            }
        //            else return Ok(result);
        //        }
        //        catch
        //        {
        //            return BadRequest("Can Not Create User");
        //        }
        //    }
        //    else return BadRequest(ModelState);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        //{
        //    try
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
        //            {
        //                var claims = new List<Claim>(new[]
        //                {
        //                   new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //               });


        //                //add role to claim
        //                var roleNames = await _userManager.GetRolesAsync(user);

        //                foreach (var roleName in roleNames)
        //                {
        //                    var role = await _roleManager.FindByNameAsync(roleName);
        //                    if (role != null)
        //                    {
        //                        var roleClaim = new Claim(JwtRegisteredClaimNames.Nonce, role.Name);
        //                        claims.Add(roleClaim);

        //                        var roleClaims = await _roleManager.GetClaimsAsync(role);
        //                        claims.AddRange(roleClaims);
        //                    }
        //                }

        //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtIssuerOptions:Key"]));
        //                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //                var token = new JwtSecurityToken(
        //                    issuer: _config["JwtIssuerOptions:Issuer"],
        //                    audience: _config["JwtIssuerOptions:Audience"],
        //                    claims: claims,
        //                    expires: DateTime.UtcNow.AddMinutes(60),
        //                    signingCredentials: cred
        //                );

        //                return Ok(new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(token),
        //                    expiration = token.ValidTo
        //                });
        //            }
        //        }
        //        return BadRequest("User Not Found");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}

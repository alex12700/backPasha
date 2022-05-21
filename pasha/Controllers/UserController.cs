using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pasha.Models;
using pasha.Services;

namespace pasha.Controllers;

[ApiController]
[Route("user")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }
    
    [HttpGet]
    [Route("getname")]
    [Authorize]
    public string GetName()
    {
        return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName).Value;
    }

    [HttpPost]
    [Route("login")]
    public string Login([FromBody] UserLogin userLogin)
    {
        if (!ModelState.IsValid)
            return null;

        var loggedInUser = _userService.Get(userLogin);

        if (loggedInUser is null)
            return null;

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserName),
            new Claim(ClaimTypes.Email, loggedInUser.Email),
            new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
            new Claim(ClaimTypes.Role, loggedInUser.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(int.Parse(_configuration["JWT:Expires"])),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}
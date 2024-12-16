using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using To_Do_app_Backend.Models.Domains;

namespace To_Do_app_Backend.Utilities;

/*public interface ITokenHelper
{
    string CreateToken(User user);
}*/

public class TokenHelper
{
    private readonly string _jwtKey;
    private readonly string _jwtIssuer;
    
    public TokenHelper(IConfiguration configuration)
    {
        _jwtKey = configuration["Jwt:Key"] ?? throw new ArgumentNullException(configuration["Jwt:Key"]);
        _jwtIssuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException(configuration["Jwt:Issuer"]);
    }
    
    public string CreateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(_jwtIssuer,
            _jwtIssuer,
            [
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email)
            ],
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        var token =  new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
}
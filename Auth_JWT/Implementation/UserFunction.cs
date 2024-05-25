using Auth_JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Auth_JWT.Implementation
{
    public class UserFunction : IUserImpl
    {
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel{UserName="Batman",Password="Joker" }
        };
    private readonly IConfiguration _configuration;
    public UserFunction(IConfiguration configuration)
    {
        _configuration = configuration;
    }
        public string Login(UserModel user)
        {
            var LoginUser=_users.SingleOrDefault(x=>x.UserName == user.UserName && x.Password==user.Password);
            if(LoginUser == null)
            {
                return string.Empty;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

            };
             var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}

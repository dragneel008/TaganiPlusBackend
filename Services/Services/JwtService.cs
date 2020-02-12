namespace Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using System.Threading.Tasks;
    using Entities.Entities;
    using Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    public class JwtService : IJwtService
    {
        private readonly IUsersService usersService;
        private readonly IConfiguration configuration;

        public JwtService(IUsersService usersService, IConfiguration configuration)
        {
            this.usersService = usersService;
            this.configuration = configuration;
        }

        public string GenerateJSONWebToken(Users userInfo)
        {
            //var claims = new[] {
            //    new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id)
            // };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                this.configuration["Jwt:Issuer"],
              this.configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Users> AuthenticateUser(Users login)
        {
            var user = await this.usersService.GetUserByUsername(login);

            if (user != null && user.Password == login.Password)
            {
                return user;
            }

            return null;
        }
    }
}

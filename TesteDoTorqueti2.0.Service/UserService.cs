using System;
using System.Text;
using TesteDoTorqueti2._0.Domain.Models;
using TesteDoTorqueti2._0.Repository.Interfaces;
using TesteDoTorqueti2._0.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;

namespace TesteDoTorqueti2._0.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository) : base(repository) => this.repository = repository;

        public User Authenticate(string login, string senha)
        {
            User user = this.repository.GetByCondition(x => x.Login == login && x.Senha == senha).FirstOrDefault();

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(WebConfigurationManager.AppSettings["secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Senha = null;
            return user;
        }
    }
}

using CarSenegalBackend.Infrastruture.Repositories;
using CarSenegalBakend.Domain.Entities;
using CarSenegalBakend.Domain.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarSenegalBakend.Api.Services
{
    public class UserService : IUserService
    {
      
        private readonly IConfiguration _configuration;
        private readonly UserRepository<UserEntity> _userRepository;

        public  UserService(IConfiguration configuration, UserRepository<UserEntity> userRepository)
        {
            this._configuration = configuration;
            this._userRepository = userRepository;
        }
        public UserEntity Authenticate(string username, string password)
        {
            var user = _userRepository.GetAll().SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            ;
            var value = _configuration.GetSection("AppSettings").GetChildren().Select(b => b.Value);

            var key = Encoding.ASCII.GetBytes(value.FirstOrDefault());
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

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            // return users without passwords
            return _userRepository.GetAll().Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}

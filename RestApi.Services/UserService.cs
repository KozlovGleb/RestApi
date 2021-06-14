using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestApi.DataAccess;
using RestApi.DataAccess.DTOs;
using RestApi.DataAccess.Entities;
using RestApi.DataAccess.Request;
using RestApi.Services.Helpers;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;

        public UserService(IOptions<AppSettings> appSettings, DataContext dataContext)
        {
            _appSettings = appSettings.Value;
            _dataContext = dataContext;
        }
        public async Task AddUserAsync(UserDTO userDTO)
        {
            User user = new();
            user.Id = userDTO.Id;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
        }
        public string Authenticate(AuthenticateRequest model)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (user == null) return null;
            var token = generateJwtToken(user);
            return token;
        }
        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users;
        }

        public User GetById(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }
        #region Private helpers
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}

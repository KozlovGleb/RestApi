using RestApi.DataAccess.DTOs;
using RestApi.DataAccess.Entities;
using RestApi.DataAccess.Request;
using RestApi.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task AddUserAsync(UserDTO user);
    }
}

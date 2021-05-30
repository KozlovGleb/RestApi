﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.DataAccess.DTOs;
using RestApi.DataAccess.Entities;
using RestApi.DataAccess.Request;
using RestApi.Services.Helpers;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistrationAsync([FromQuery] UserDTO user)
        {
            await _userService.AddUserAsync(user);
            return Ok();//Добавить нормальные ошибки
        }
    }
}

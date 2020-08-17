using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testappdotnet.Data;
using testappdotnet.Dtos;
using testappdotnet.Models;

namespace testappdotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult>Register(UserToRegisterDto userToRegisterDto)
        {
            //validate req
            userToRegisterDto.UserName = userToRegisterDto.UserName.ToLower();
            if (await _authRepo.UserExists(userToRegisterDto.UserName)) return BadRequest("username exists");

            var userToCreate = new User { UserName = userToRegisterDto.UserName };
            var createdUser = await _authRepo.Register(userToCreate, userToRegisterDto.Password);

            return StatusCode(201);
        }
    }
}

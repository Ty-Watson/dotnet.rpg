using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.rpg.DTOs;
using dotnet.rpg.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterUser(UserRegisterDto request)
        {
            var response = await _authRepo.Register( new User { Username = request.Username}, request.Password );
            if (! response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
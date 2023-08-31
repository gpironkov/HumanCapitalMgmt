using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Controllers.Common;
using PeopleAPI.DTOs;
using PeopleAPI.Services;

namespace PeopleAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccount _authService;

        public AccountController(IAccount authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await _authService.LoginAsync(user))
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto user)
        { 
            if(!ModelState.IsValid) 
            { 
                return BadRequest("Something is not ok!");
            }

            return Ok(await _authService.RegisterUserAsync(user));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

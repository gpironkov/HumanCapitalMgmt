namespace PeopleAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccount _authService;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IAccount authService, UserManager<IdentityUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userInDb = await _userManager.FindByNameAsync(user.UserName);
            var roles = await _userManager.GetRolesAsync(userInDb);
                        
            if (await _authService.LoginAsync(user))
            {
                var tokenString = _authService.GenerateTokenString(user, roles);
                return Ok(tokenString);
            }

            return BadRequest("Username or password is invalid!");
        }

        [Authorize(Roles = $"{GlobalConstants.HumanResourcesRoleName},{GlobalConstants.ManagerRoleName}")]
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

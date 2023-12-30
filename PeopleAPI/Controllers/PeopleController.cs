namespace PeopleAPI.Controllers
{
    [Authorize(Roles = $"{GlobalConstants.HumanResourcesRoleName}, {GlobalConstants.ManagerRoleName}")]
    public class PeopleController : BaseApiController
    {
        private readonly IPeople _peopleService;

        public PeopleController(IPeople peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("people")]
        public async Task<IActionResult> GetAllPeople()
        {
            return Ok(await _peopleService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _peopleService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

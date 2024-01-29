using CommonLibrary.Models;

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
        public async Task<IActionResult> GetAllPeople([FromQuery]PagingParameters pagingParameters, [FromQuery]FilterSalaryParameters salaryParameters) //test people?size=2&page=3; people?MinSalary=2200
        {
            var allPeople = await _peopleService.GetAllUsersAsync();
            if (salaryParameters.MinSalary != null)
            {
                allPeople = allPeople.Where(s => s.Employee.Salary >= salaryParameters.MinSalary);
            }
            if (salaryParameters.MaxSalary != null)
            {
                allPeople = allPeople.Where(s => s.Employee.Salary <= salaryParameters.MaxSalary);
            }

            allPeople = allPeople.Skip(pagingParameters.Size * (pagingParameters.Page - 1)).Take(pagingParameters.Size);

            return Ok(allPeople);
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

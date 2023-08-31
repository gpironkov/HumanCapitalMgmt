using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Controllers.Common;
using PeopleAPI.Services;

namespace PeopleAPI.Controllers
{
    [Authorize]
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
            return Ok(await _peopleService.GetAllUsersAsync()); //"You hit me!";
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

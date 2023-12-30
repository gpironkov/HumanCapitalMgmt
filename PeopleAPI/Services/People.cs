namespace PeopleAPI.Services
{
    public class People : IPeople
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PeopleDbContext _peopleDbContext;

        public People(UserManager<IdentityUser> userManager, PeopleDbContext peopleDbContext)
        {
            _userManager = userManager;
            _peopleDbContext = peopleDbContext;
        }

        public async Task<IEnumerable<ResponseAspNetUsersDto>> GetAllUsersAsync()
        {
            var usersData = await GetUserData().ToListAsync();

            return usersData;
        }

        public async Task<ResponseAspNetUsersDto> GetUserByIdAsync(string userId)
        {
            var userData = await GetUserData().ToListAsync();
            var user = userData.Where(u => u.UserId == userId).FirstOrDefault();

            return user;
        }

        private IQueryable<ResponseAspNetUsersDto> GetUserData()
        {
            var userData = _userManager.Users
                .Join(_peopleDbContext.Employees, u => u.Id, e => e.UserId, (u, e) => new
                {
                    User = u,
                    Employee = e
                })
                //.Where(ue => ue.Employee != null)
                .Select(ue => new ResponseAspNetUsersDto(ue.User.Id, ue.User.UserName, ue.User.Email, ue.User.PhoneNumber,
                    new ResponseEmployeeDto(ue.Employee.FirstName, ue.Employee.SecondName, ue.Employee.LastName, ue.Employee.Salary, ue.Employee.Department.Name)
                ));

            return userData;
        }
    }
}

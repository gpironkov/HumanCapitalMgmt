using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeopleAPI.DTOs;

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

        public async Task<IEnumerable<AspNetUsersDto>> GetAllUsersAsync()
        {
            var usersData = await GetUserData().ToListAsync();

            return usersData;
        }

        public async Task<AspNetUsersDto> GetUserByIdAsync(string userId)
        {
            var userData = await GetUserData().Where(u => u.UserId == userId).FirstOrDefaultAsync();

            return userData;
        }

        private IQueryable<AspNetUsersDto> GetUserData()
        {
            var userData = _userManager.Users
                .Join(_peopleDbContext.Employees, u => u.Id, e => e.UserId, (u, e) => new
                {
                    User = u,
                    Employee = e
                })
                //.Where(ue => ue.Employee != null)
                .Select(ue => new AspNetUsersDto
                {
                    UserId = ue.User.Id,
                    UserName = ue.User.UserName,
                    Email = ue.User.Email,
                    PhoneNumber = ue.User.PhoneNumber,
                    Employee = new EmployeeDto
                    {
                        FirstName = ue.Employee.FirstName,
                        SecondName = ue.Employee.SecondName,
                        LastName = ue.Employee.LastName,
                        Salary = ue.Employee.Salary,
                        Department = ue.Employee.Department.Name
                    }
                });

            return userData;
        }
    }
}

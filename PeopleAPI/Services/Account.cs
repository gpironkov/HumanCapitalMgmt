using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PeopleAPI.DTOs;
using PeopleAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeopleAPI.Services
{
    public class Account : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PeopleDbContext _peopleDbContext;
        private readonly IConfiguration _config;

        public Account(UserManager<IdentityUser> userManager, IConfiguration config, PeopleDbContext peopleDbContext)
        {
            _userManager = userManager;
            _config = config;
            _peopleDbContext = peopleDbContext;
        }

        public async Task<string> RegisterUserAsync(RegisterUserDto user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.UserName,
                PhoneNumber = user.PhoneNumber
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            var employee = new Employee
            {
                UserId = identityUser.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SecondName = user.SecondName,
                Salary = user.Salary,
                DepartmentId = user.DepartmentId
            };

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(error => error.Description).ToList();
                return string.Join(Environment.NewLine, errorList);
            }            

            await _peopleDbContext.Employees.AddAsync(employee);
            await _peopleDbContext.SaveChangesAsync();

            return "User is created!";
        }

        public async Task<bool> LoginAsync(LoginUserDto user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.UserName);

            if (identityUser == null) 
            { 
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateTokenString(LoginUserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return tokenString;
        }
    }
}

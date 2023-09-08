using Microsoft.AspNetCore.Mvc;
using PeopleAPI.DTOs;

namespace PeopleAPI.Services
{
    public interface IAccount
    {
        Task<bool> LoginAsync(LoginUserDto user);

        Task<string> RegisterUserAsync(RegisterUserDto user);

        string GenerateTokenString(LoginUserDto user, IEnumerable<string> roles);
    }
}
using PeopleAPI.DTOs;

namespace PeopleAPI.Services
{
    public interface IPeople
    {
        Task<IEnumerable<AspNetUsersDto>> GetAllUsersAsync();

        Task<AspNetUsersDto> GetUserByIdAsync(string userId);
    }
}

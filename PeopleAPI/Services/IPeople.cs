namespace PeopleAPI.Services
{
    public interface IPeople
    {
        Task<IEnumerable<ResponseAspNetUsersDto>> GetAllUsersAsync();

        Task<ResponseAspNetUsersDto> GetUserByIdAsync(string userId);
    }
}

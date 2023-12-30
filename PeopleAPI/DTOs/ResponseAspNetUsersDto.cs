namespace PeopleAPI.DTOs
{
    public record ResponseAspNetUsersDto(
        string UserId,

        string UserName,

        string Email,

        string PhoneNumber,

        ResponseEmployeeDto Employee
    );
}

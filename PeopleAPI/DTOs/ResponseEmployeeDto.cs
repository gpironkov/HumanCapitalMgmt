namespace PeopleAPI.DTOs
{
    public record ResponseEmployeeDto(
        string FirstName,

        string SecondName,

        string LastName,

        decimal Salary,

        string Department,

        ushort DaysLeft
    );
}

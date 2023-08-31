namespace PeopleAPI.DTOs
{
    public class AspNetUsersDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}

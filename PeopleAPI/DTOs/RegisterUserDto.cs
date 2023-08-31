namespace PeopleAPI.DTOs
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string DepartmentId { get; set; }
    }
}

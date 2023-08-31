using Microsoft.AspNetCore.Identity;
using PeopleAPI.Models.Common;

namespace PeopleAPI.Models
{
    public class Employee : BaseModel
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public virtual IdentityUser User { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }   

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }        

        public virtual Department Department { get; set; }
        public string DepartmentId { get; set; }
    }
}

using PeopleAPI.Models.Common;

namespace PeopleAPI.Models
{
    public class Department : BaseModel
    {
        public Department()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

namespace PeopleAPI.Models.Common
{
    public abstract class BaseModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

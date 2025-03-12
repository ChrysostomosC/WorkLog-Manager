using MongoDB.Bson;

namespace Working_hours.Models
{
    public class Employee
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }

    }
}

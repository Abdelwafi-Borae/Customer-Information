using System.ComponentModel.DataAnnotations;

namespace Base.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Address> address { get; set; }
    }
}

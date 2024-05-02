using Base.Models;

namespace Base.DTOS
{
    public class AddCustomer
    {
        
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}

using Customer_Information.Models;

namespace Customer_Information.DTOS
{
    public class AddCustomer
    {
        
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}

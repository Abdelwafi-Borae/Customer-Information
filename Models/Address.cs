namespace Base.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public Customer customer { get; set; }
        public int  CustomerId { get; set; }
    }
}

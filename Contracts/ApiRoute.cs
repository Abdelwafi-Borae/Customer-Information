namespace Customer_Information.Contracts
{
    public class ApiRoute
    {
        public class CustomerRoute
        {
            public const string GetCustomers = "api/customer";
            public const string GetCustomer = "api/customer/{Id}";
            public const string GetCustomerByNmae = "api/customers/{name}";

            public const string CreateCustomer = "api/customer";
            public const string DeleteCustomer = "api/customer/{Id}";
            public const string UpdateCustomer = "api/customer/{Id}";
        }
        public class AddressRoute
        {
            public const string GetAddresses = "api/address";
            public const string GetAddress = "api/address/{Id}";
            public const string GetAddressByCity = "api/city/{city}";

            public const string CreateAddress = "api/address";
            public const string DeleteAddress = "api/address/{Id}";
            public const string UpdateAddresses = "api/address/{Id}";
        }
    }
}

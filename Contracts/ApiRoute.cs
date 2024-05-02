namespace Base.Contracts
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
    }
}

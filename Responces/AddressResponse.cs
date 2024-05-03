using Customer_Information.Models;

namespace Customer_Information.Responces
{
    public class AddressResponse
    {
        public static Response<Address> AddressNotFound(int? Id = null, string? city = null)
        {
            string text = Id != null ? "Id" : "city";
            string vlaue = Id != null ? Id.ToString() : city;
            return new Response<Address>
            { 
                IsSuccess = false,
                StatusCode = 404,

                ResponseMessage = $"No Address was found with  {text}:{vlaue}",
                Data = null
            };
        }
        public static Response<Address> NoAddressFound()
        {
            return new Response<Address>
            {
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No Address was found  ",
                Data = null
            };
        }
        public static Response<Address> AddressFound(List<Address> addresses)
        {
            return new Response<Address>
            {
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = $"retreaving data successfully",
                Data = addresses
            };
        }
        public static Response<Address> ServerError()
        {
            return new Response<Address>
            {
                IsSuccess = false,
                StatusCode = 500,
                ResponseMessage = $"ServerError",
                Data = null
            };
        }
        public static Response<Address> CreatedSeccessfully(Address address)
        {
            return new Response<Address>
            {
                IsSuccess = true,
                StatusCode = 201,
                ResponseMessage = $" Created Seccessfully",
                Data = new List<Address> { address }
            };
        }
        public static Response<Address> RemovedSeccessfully()
        {
            return new Response<Address>
            {
                IsSuccess = true,
                StatusCode = 204,
                ResponseMessage = $" removed Seccessfully",
                Data = null
            };
        }
        public static Response<Address> UpdateSeccessfully(Address address)
        {
            return new Response<Address>
            {
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = $" Update Seccessfully",
                Data = new List<Address> { address }
            };
        }
        public static Response<Address> BadRequest()
        {
            return new Response<Address>
            {
                IsSuccess = false,
                StatusCode = 400,
                ResponseMessage = $" Bad request ",
                Data = null
            };
        }

    }

}

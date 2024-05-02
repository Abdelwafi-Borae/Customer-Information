using Base.Models;
using System.Globalization;
using System.Xml.Linq;

namespace Base.Responces
{
    public class CustomerResponse
    {
        public static Response<Customer> CustomerNotFound(int? Id=null ,string? name=null)
        {
            string text = Id != null ? "Id" : "Name";
            string vlaue= Id != null ? Id.ToString() : name;
            return new Response<Customer>
            {
                IsSuccess = false,
                StatusCode = 404,
                
                ResponseMessage = $"No customer was found with  {text}:{vlaue}",
                Data = null
            };
        }
        public static Response<Customer> NoCustomerFound()
        {
            return new Response<Customer>
            {
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No customer was found  ",
                Data = null
            };
        }
        public static Response<Customer> CustomerFound(List<Customer> customer)
        {
            return new Response<Customer>
            {
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = $"retreaving data successfully",
                Data = customer 
            };
        }
        public static Response<Customer> ServerError()
        {
            return new Response<Customer>
            {
                IsSuccess = false,
                StatusCode = 500,
                ResponseMessage = $"ServerError",
                Data = null
            };
        }
        public static Response<Customer> CreatedSeccessfully(Customer customer)
        {
            return new Response<Customer>
            {
                IsSuccess = true,
                StatusCode = 201,
                ResponseMessage = $" Created Seccessfully",
                Data =  new List<Customer> { customer }
            };
        }
        public static Response<Customer> RemovedSeccessfully()
        {
            return new Response<Customer>
            {
                IsSuccess = true,
                StatusCode = 204,
                ResponseMessage = $" removed Seccessfully",
                Data = null
            };
        }
        public static Response<Customer> UpdateSeccessfully( Customer customer)
        {
            return new Response<Customer>
            {
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = $" Update Seccessfully",
                Data = new List<Customer> { customer }
            };
        }
        public static Response<Customer> BadRequest()
        {
            return new Response<Customer>
            {
                IsSuccess = false,
                StatusCode = 400,
                ResponseMessage = $" Bad request ",
                Data = null
            };
        }

    }
}

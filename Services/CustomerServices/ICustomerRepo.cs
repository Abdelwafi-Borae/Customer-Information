using Customer_Information.DTOS;
using Customer_Information.Models;
using Customer_Information.Responces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;

namespace Customer_Information.Services.CustomerServices
{
    public interface ICustomerRepo 
    {
        public Task<Response<Customer>> AddCustomer(AddCustomer customer);
        public Task<Response<Customer>> UpdateCustomer(int Id, JsonPatchDocument< Customer> patch);
        public Task<Response<Customer>> DeleteCustomer(int  id);
        public Task<Response<Customer>> GetCustomerByID(int id);
        public Task<Response<Customer>> GetAllCustomer();
        public  Task<Response<Customer>> GetCustomerByName(string id);
    }
}

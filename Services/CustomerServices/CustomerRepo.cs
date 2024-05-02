using AutoMapper;
using Base.Data;
using Base.DTOS;
using Base.Models;
using Base.Responces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Base.Services.CustomerServices
{
    public class CustomerRepo : ICustomerRepo
    {
        public IMapper mapper;
       readonly private ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context ,IMapper _mapper) 
        {
            _context = context;
            mapper = _mapper;
        }

        public async Task<Response<Customer>> AddCustomer(AddCustomer customer)
        {
            
            if (customer == null)
            { return CustomerResponse.BadRequest(); }
            try {
                Customer newcustomer = mapper.Map<Customer>(customer);
                

                await _context.customers.AddAsync(newcustomer);
                    return CustomerResponse.CreatedSeccessfully(newcustomer);
                 }
            catch
            {
                return CustomerResponse.ServerError();
            }
        }


        public async Task<Response<Customer>> GetCustomerByID(int id)
        {
            try
            {
              Customer customer = await _context.customers.FindAsync(id);
                if (customer == null)
                    return CustomerResponse.CustomerNotFound(id);
                List < Customer > customers = new List<Customer> { customer};
                return CustomerResponse.CustomerFound(customers);
            }
            catch
            {
                return CustomerResponse.ServerError();
            }
           
        }



        public async Task<Response<Customer>> DeleteCustomer(int  id)
        {

            try
            {
                Response < Customer > Respone =  await GetCustomerByID(id);
                Customer customer = Respone.Data==null?null: Respone.Data.First();

                if (customer == null)
                { return CustomerResponse.CustomerNotFound(id); }
                _context.customers.Remove(customer);
                return CustomerResponse.RemovedSeccessfully();
            }
            catch
            {
                return CustomerResponse.ServerError();
            }

        }

        public async Task<Response<Customer>> GetAllCustomer()
        {
            try
            {
               List< Customer> customer = await _context.customers.ToListAsync();
                if (customer.Count()==0)
                { return CustomerResponse.NoCustomerFound(); }
                return CustomerResponse.CustomerFound(customer);
            }
            catch
            {
                return CustomerResponse.ServerError();
            }
        }



        public async Task<Response<Customer>> GetCustomerByName(string name)
        {
            try
            {
                List<Customer> customer =  _context.customers.Where(c => c.FirstName == name).ToList();
                if (customer.Count() == 0)
                    return CustomerResponse.CustomerNotFound(null,name);
                List<Customer> customers = customer;
                return CustomerResponse.CustomerFound(customers);
            }
            catch
            {
                return CustomerResponse.ServerError();
            }

        }

        public async Task<Response<Customer>> UpdateCustomer(int Id,JsonPatchDocument<Customer> patch)
        {
            
            try
            {
                Response<Customer> Respone = await GetCustomerByID(Id);
                Customer customer = Respone.Data == null ? null : Respone.Data.First();

                if (customer == null)
                { return CustomerResponse.CustomerNotFound(Id); }

                try { patch.ApplyTo(customer);
                    _context.customers.Update(customer);
                    return CustomerResponse.UpdateSeccessfully(customer);
                }
                catch { return CustomerResponse.BadRequest(); }


            }
            catch
            {
                
                return CustomerResponse.ServerError();
            }
           
             
        }
    }
    
}

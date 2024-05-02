using Base.Contracts;
using Base.DTOS;
using Base.Models;
using Base.Responces;
using Base.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

 
    [HttpPost(ApiRoute.CustomerRoute.CreateCustomer)]
    public async Task<IActionResult> AddCustomer(AddCustomer customer)
    {

        Response<Customer> response = await _unitOfWork.customerRepo.AddCustomer(customer);
        _unitOfWork.Commit();

        return Ok(response);

    }
    [HttpGet(ApiRoute.CustomerRoute.GetCustomer)]
    public async Task<IActionResult> GetCustomerById(int Id)
    {
        
     Response <Customer> response = await _unitOfWork.customerRepo.GetCustomerByID(Id);
        return Ok(response);
    }
    [HttpDelete(ApiRoute.CustomerRoute.DeleteCustomer)]
    public async Task<IActionResult> DeleteCustomer(int Id)
    {
        Response<Customer> response = await _unitOfWork.customerRepo.DeleteCustomer(Id);
        _unitOfWork.Commit();
        return Ok(response);
    }

    [HttpGet(ApiRoute.CustomerRoute.GetCustomers)]
    public async Task<IActionResult> GetAllCustomer()
    {
        Response<Customer> response = await _unitOfWork.customerRepo.GetAllCustomer();
        
        return Ok(response);
    }
    [HttpGet(ApiRoute.CustomerRoute.GetCustomerByNmae)]
    public async Task<IActionResult> GetCustomerByName(string name)
    {
        Response<Customer> response = await _unitOfWork.customerRepo.GetCustomerByName(name);
        return Ok(response);
    }
    [HttpPatch(ApiRoute.CustomerRoute.UpdateCustomer)]
    public async Task<IActionResult> UpdateCustomer(int Id, JsonPatchDocument<Customer> patch)
    {
        Response<Customer> response = await _unitOfWork.customerRepo.UpdateCustomer(Id,patch);
        _unitOfWork.Commit();
        return Ok(response);
    }
}


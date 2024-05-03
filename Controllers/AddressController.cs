using Customer_Information.Contracts;
using Customer_Information.DTOS;
using Customer_Information.Models;
using Customer_Information.Responces;
using Customer_Information.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost(ApiRoute.AddressRoute.CreateAddress)]
        public async Task<IActionResult> AddAddress(AddAddress address)
        {

            Response<Address> response = await _unitOfWork.addressRepo.AddAddress(address);
            _unitOfWork.Commit();

            return Ok(response);

        }
        [HttpGet(ApiRoute.AddressRoute.GetAddress)]
        public async Task<IActionResult> GetAddressById(int Id)
        {

            Response<Address> response = await _unitOfWork.addressRepo.GetAddressByID(Id);
            return Ok(response);
        }
        [HttpDelete(ApiRoute.AddressRoute.DeleteAddress)]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            Response<Address> response = await _unitOfWork.addressRepo.DeleteAddress(Id);
            _unitOfWork.Commit();
            return Ok(response);
        }

        [HttpGet(ApiRoute.AddressRoute.GetAddresses)]
        public async Task<IActionResult> GetAllAddresses()
        {
            Response<Address> response = await _unitOfWork.addressRepo.GetAllAddress();

            return Ok(response);
        }
        [HttpGet(ApiRoute.AddressRoute.GetAddressByCity)]
        public async Task<IActionResult> GetAddressByCity(string city)
        {
            Response<Address> response = await _unitOfWork.addressRepo.GetAddressByCity(city);
            return Ok(response);
        }
        [HttpPatch(ApiRoute.AddressRoute.UpdateAddresses)]
        public async Task<IActionResult> UpdateAddresses(int Id, JsonPatchDocument<Address> patch)
        {
            Response<Address> response = await _unitOfWork.addressRepo.UpdateAddress(Id, patch);
            _unitOfWork.Commit();
            return Ok(response);
        }
    }
}

using Customer_Information.DTOS;
using Customer_Information.Models;
using Customer_Information.Responces;
using Microsoft.AspNetCore.JsonPatch;

namespace Customer_Information.Services.AddressServices
{
    public interface IAddressRepo
    {
        public Task<Response<Address>> AddAddress(AddAddress address);
        public Task<Response<Address>> UpdateAddress(int Id, JsonPatchDocument<Address> patch);
        public Task<Response<Address>> DeleteAddress(int id);
        public Task<Response<Address>> GetAddressByID(int id);
        public Task<Response<Address>> GetAllAddress();
        public Task<Response<Address>> GetAddressByCity(string id);
    }
}

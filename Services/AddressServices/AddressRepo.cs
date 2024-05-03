using AutoMapper;
using Customer_Information.Data;
using Customer_Information.DTOS;
using Customer_Information.Models;
using Customer_Information.Responces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Customer_Information.Services.AddressServices
{
    public class AddressRepo :IAddressRepo
    {
        public IMapper mapper;
        readonly private ApplicationDbContext _context;
        public AddressRepo(ApplicationDbContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        public async Task<Response<Address>> AddAddress(AddAddress address)
        {

         
            try
            {
                if (address == null)
                { return AddressResponse.BadRequest(); }

                Customer customer = await _context.customers.FindAsync(address.CustomerId);
                if (customer == null)
                { return AddressResponse.BadRequest(); }
                Address newaddress = mapper.Map<Address>(address);


                await _context.addresses.AddAsync(newaddress);
                return AddressResponse.CreatedSeccessfully(newaddress);
            }
            catch
            {
                return AddressResponse.ServerError();
            }
        }


        public async Task<Response<Address>> GetAddressByID(int id)
        {
            try
            {
                Address address = await _context.addresses.FindAsync(id);
                if (address == null)
                    return AddressResponse.AddressNotFound(id);
                List<Address> addresses = new List<Address> { address };
                return AddressResponse.AddressFound(addresses);
            }
            catch
            {
                return AddressResponse.ServerError();
            }

        }



        public async Task<Response<Address>> DeleteAddress(int id)
        {

            try
            {
                Response<Address> Respone = await GetAddressByID(id);
                Address address = Respone.Data == null ? null : Respone.Data.First();

                if (address == null)
                { return AddressResponse.AddressNotFound(id); }
                _context.addresses.Remove(address);
                return AddressResponse.RemovedSeccessfully();
            }
            catch
            {
                return AddressResponse.ServerError();
            }

        }

        public async Task<Response<Address>> GetAllAddress()
        {
            try
            {
                List<Address> addresses = await _context.addresses.ToListAsync();
                if (addresses.Count() == 0)
                { return AddressResponse.NoAddressFound(); }
                return AddressResponse.AddressFound(addresses);
            }
            catch
            {
                return AddressResponse.ServerError();
            }
        }



        public async Task<Response<Address>> GetAddressByCity(string city)
        {
            try
            {
                List<Address> addresses = _context.addresses.Where(c => c.City == city).ToList();
                if (addresses.Count() == 0)
                    return AddressResponse.AddressNotFound(null, city);
                //List<Address> addresses = addresses;
                return AddressResponse.AddressFound(addresses);
            }
            catch
            {
                return AddressResponse.ServerError();
            }

        }

        public async Task<Response<Address>> UpdateAddress(int Id, JsonPatchDocument<Address> patch)
        {

            try
            {
                Response<Address> Respone = await GetAddressByID(Id);
                Address address = Respone.Data == null ? null : Respone.Data.First();

                if (address == null)
                { return AddressResponse.AddressNotFound(Id); }
                //check customer id
                Customer customer = await _context.customers.FindAsync(address.CustomerId);
                if (customer == null)
                { return AddressResponse.BadRequest(); }
                try
                {
                    patch.ApplyTo(address);
                    _context.addresses.Update(address);
                    return AddressResponse.UpdateSeccessfully(address);
                }
                catch { return AddressResponse.BadRequest(); }


            }
            catch
            {

                return AddressResponse.ServerError();
            }


        }
    }
}

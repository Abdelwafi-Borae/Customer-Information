using AutoMapper;
using Customer_Information.DTOS;
using Customer_Information.Models;

namespace Customer_Information.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, AddCustomer>().ReverseMap();
        }
    }
}

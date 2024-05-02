using AutoMapper;
using Base.DTOS;
using Base.Models;

namespace Base.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, AddCustomer>().ReverseMap();
        }
    }
}

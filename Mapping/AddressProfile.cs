using AutoMapper;
using Customer_Information.DTOS;
using Customer_Information.Models;

namespace Customer_Information.Mapping
{
    public class AddressProfile :Profile
	{
		public AddressProfile()
		{
            CreateMap<Address, AddAddress>().ReverseMap();
        }

}
}

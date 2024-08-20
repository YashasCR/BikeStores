using AutoMapper;
using BikeStores.Application.DTO;
using BikeStores.Domain.Entities;

namespace BikeStores.API.AutoMapper.Profiles
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
        }
    }
}

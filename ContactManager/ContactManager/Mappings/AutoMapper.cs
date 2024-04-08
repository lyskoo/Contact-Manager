using AutoMapper;
using Business.Dtos;
using Data.Entities;

namespace ContactManager.Mappings;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
    }
}

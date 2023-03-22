using AutoMapper;
using ContactAPI.DTO;
using ContactAPI.Models;
using System;

namespace ContactAPI.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact, ContactDto>();

        }
    }
}

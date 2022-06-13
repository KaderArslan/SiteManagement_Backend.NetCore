using AutoMapper;
using SiteManagement.Entity.Dto;
using SiteManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Admin
            CreateMap<Admin, DtoAdmin>().ReverseMap();

            CreateMap<Admin, DtoAdminLogin>();
            CreateMap<DtoALogin, Admin>();

            //Apartment
            CreateMap<Apartment, DtoApartment>().ReverseMap();
            CreateMap<Apartment, DtoApartmentAdmin>().ReverseMap();

            //Bill
            CreateMap<Bill, DtoBill>().ReverseMap();
            CreateMap<Bill, DtoBillAdmin>().ReverseMap();

            //Message
            CreateMap<Message, DtoMessage>().ReverseMap();
            CreateMap<Message, DtoMessageAdmin>().ReverseMap();

            //User
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<User, DtoUserAdmin>().ReverseMap();

            CreateMap<User, DtoUserLogin>();
            CreateMap<DtoULogin, User>();

        }
    }
}

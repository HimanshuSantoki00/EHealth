using AutoMapper;
using EH.Entities.Entities.CustomeEntities;
using EH.Entities.Entities.DbEntities;

namespace EH.ApplicationServer.ApiHelper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, UserContact>();

            CreateMap<UserContact, DbtoContact>()
               .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.Id))
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

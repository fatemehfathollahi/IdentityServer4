using AutoMapper;
using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    
    public static class PlusIdentityResourceMappers
    {
        static PlusIdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

       
        public static IdentityResource ToModel(this PlusIdentityResource entity)
        {
            return entity == null ? null : Mapper.Map<IdentityResource>(entity);
        }
      
        public static PlusIdentityResource ToEntity(this IdentityResource model)
        {
            return model == null ? null : Mapper.Map<PlusIdentityResource>(model);
        }
    }

    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            CreateMap<PlusIdentityResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<PlusIdentityResource, IdentityResource>(MemberList.Destination)
                .ConstructUsing(src => new IdentityResource())
                .ReverseMap();

            CreateMap<PlusIdentityClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
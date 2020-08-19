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

       
        public static IdentityServer4.Models.IdentityResource ToModel(this Domain.Models.IdentityResource entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.IdentityResource>(entity);
        }
      
        public static Domain.Models.IdentityResource ToEntity(this IdentityServer4.Models.IdentityResource model)
        {
            return model == null ? null : Mapper.Map<Domain.Models.IdentityResource>(model);
        }
    }

    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            CreateMap<Domain.Models.IdentityResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Domain.Models.IdentityResource, IdentityServer4.Models.IdentityResource>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.IdentityResource())
                .ReverseMap();

            CreateMap<Domain.Models.IdentityClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
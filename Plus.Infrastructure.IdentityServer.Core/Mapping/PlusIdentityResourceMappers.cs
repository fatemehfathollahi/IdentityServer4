using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Entities = IdentityServer4.EntityFramework.Entities;
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

       
        public static Entities.IdentityResource ToEntity(this IdentityResource model)
        {
            return model == null ? null : Mapper.Map<Entities.IdentityResource>(model);
        }
      
        public static IdentityResource ToModel(this Entities.IdentityResource entity)
        {
            return entity == null ? null : Mapper.Map<IdentityResource>(entity);
        }

        public static IEnumerable<IdentityResource> ToModel(this IEnumerable<Entities.IdentityResource> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<IdentityResource>>(entities);
            return modelList;
        }
    }

    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            CreateMap<IdentityResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<IdentityResource, Entities.IdentityResource>(MemberList.Destination)
                .ConstructUsing(src => new Entities.IdentityResource())
                .ReverseMap();

            CreateMap<IdentityClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
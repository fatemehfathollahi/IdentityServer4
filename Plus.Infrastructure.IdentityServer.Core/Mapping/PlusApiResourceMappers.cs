using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
   
    public static class PlusApiResourceMappers
    {
        static PlusApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
       
        public static Entities.ApiResource ToEntity(this ApiResource model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResource>(model);
        }

       
        public static ApiResource ToModel(this Entities.ApiResource entity)
        {
            return entity == null ? null : Mapper.Map<ApiResource>(entity);
        }

        public static IEnumerable<ApiResource> ToModel(this IEnumerable<Entities.ApiResource> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<ApiResource>>(entities);
            return modelList;
        }
    }

    public class ApiResourceMapperProfile : Profile
    {
      
        public ApiResourceMapperProfile()
        {
            CreateMap<ApiResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<ApiResource, Entities.ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new Entities.ApiResource())
                .ForMember(x => x.Secrets, opts => opts.MapFrom(x => x.Secrets))
                .ReverseMap();

            CreateMap<ApiResourceClaim, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<ApiSecret, Entities.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<ApiScope, Entities.ApiScope>(MemberList.Destination)
                .ConstructUsing(src => new Entities.ApiScope())
                .ReverseMap();

            CreateMap<ApiScopeClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
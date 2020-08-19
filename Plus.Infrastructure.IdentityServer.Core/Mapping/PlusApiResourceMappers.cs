using AutoMapper;
using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;

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
       
        public static IdentityServer4.Models.ApiResource ToModel(this Domain.Models.ApiResource entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.ApiResource>(entity);
        }

       
        public static Domain.Models.ApiResource ToEntity(this IdentityServer4.Models.ApiResource model)
        {
            return model == null ? null : Mapper.Map<Domain.Models.ApiResource>(model);
        }
    }

    public class ApiResourceMapperProfile : Profile
    {
      
        public ApiResourceMapperProfile()
        {
            CreateMap<ApiResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Domain.Models.ApiResource, IdentityServer4.Models.ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.ApiResource())
                .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(x => x.Secrets))
                .ReverseMap();

            CreateMap<Domain.Models.ApiResourceClaim, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<Domain.Models.ApiSecret, IdentityServer4.Models.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Domain.Models.ApiScope, IdentityServer4.Models.ApiScope>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.ApiScope())
                .ReverseMap();

            CreateMap<Domain.Models.ApiScopeClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
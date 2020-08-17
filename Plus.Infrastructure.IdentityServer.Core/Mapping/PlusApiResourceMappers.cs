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
       
        public static ApiResource ToModel(this PlusApiResource entity)
        {
            return entity == null ? null : Mapper.Map<ApiResource>(entity);
        }

       
        public static PlusApiResource ToEntity(this ApiResource model)
        {
            return model == null ? null : Mapper.Map<PlusApiResource>(model);
        }
    }

    public class ApiResourceMapperProfile : Profile
    {
      
        public ApiResourceMapperProfile()
        {
            CreateMap<PlusApiResourceProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<PlusApiResource, ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new ApiResource())
                .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(x => x.Secrets))
                .ReverseMap();

            CreateMap<PlusApiResourceClaim, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<PlusApiSecret, Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<PlusApiScope, ApiScope>(MemberList.Destination)
                .ConstructUsing(src => new ApiScope())
                .ReverseMap();

            CreateMap<PlusApiScopeClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}
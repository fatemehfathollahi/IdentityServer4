using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static  class PlusApiScopeMappers
    {
        static PlusApiScopeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiScopeMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static IdentityServer4.Models.ApiScope ToModel(this Domain.Models.ApiScope entity)
        {
            return entity == null ? null : Mapper.Map<IdentityServer4.Models.ApiScope>(entity);
        }

        public static Domain.Models.ApiScope ToEntity(this IdentityServer4.Models.ApiScope model)
        {
            return model == null ? null : Mapper.Map<Domain.Models.ApiScope>(model);
        }
    }

    public class ApiScopeMapperProfile : Profile
    {
        public ApiScopeMapperProfile()
        {
            CreateMap<Domain.Models.ApiResource, IdentityServer4.Models.ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.ApiResource())
                .ReverseMap();

            CreateMap<Domain.Models.IdentityClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    
}

}

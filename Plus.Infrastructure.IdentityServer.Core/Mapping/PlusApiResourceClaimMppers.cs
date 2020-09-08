using AutoMapper;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusApiResourceClaimMppers
    {
        static PlusApiResourceClaimMppers()
        {
            Mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<ApiResourceClaim, Entities.ApiResourceClaim>().ReverseMap();
                cfg.CreateMap<ApiResource, Entities.ApiResource>().ReverseMap();

            }).CreateMapper();

            //Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceClaimMapperProfile>())
            //    .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static Entities.ApiResourceClaim ToEntity(this ApiResourceClaim model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResourceClaim>(model);
        }

        public static ApiResourceClaim ToModel(this Entities.ApiResourceClaim entity)
        {
            return entity == null ? null : Mapper.Map<ApiResourceClaim>(entity);
        }

        public static IEnumerable<ApiResourceClaim> ToModel(this IEnumerable<Entities.ApiResourceClaim> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<ApiResourceClaim>>(entities);
            return modelList;
        }

    }

    public class ApiResourceClaimMapperProfile : Profile
    {
        public ApiResourceClaimMapperProfile()
        {
            CreateMap<ApiResource, Entities.ApiResource>(MemberList.Destination)
                .ConstructUsing(src => new Entities.ApiResource())
                .ReverseMap();

            CreateMap<IdentityClaim, string>()//todo
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }

    }
}

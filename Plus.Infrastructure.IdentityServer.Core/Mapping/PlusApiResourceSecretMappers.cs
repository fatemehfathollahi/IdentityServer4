using System;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Text;
using AutoMapper;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusApiResourceSecretMappers
    {
        static PlusApiResourceSecretMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceSecretMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static Entities.ApiResourceSecret ToEntity(this ApiResourceSecret model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResourceSecret>(model);
        }

        public static ApiResourceSecret ToModel(this Entities.ApiResourceSecret entity)
        {
            return entity == null ? null : Mapper.Map<ApiResourceSecret>(entity);
        }

        public static IEnumerable<ApiResourceSecret> ToModel(this IEnumerable<Entities.ApiResourceSecret> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<ApiResourceSecret>>(entities);
            return modelList;
        }
    }

    public class ApiResourceSecretMapperProfile : Profile
    {
        public ApiResourceSecretMapperProfile()
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

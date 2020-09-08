using AutoMapper;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusApiResourcePropertyMappers
    {
        static PlusApiResourcePropertyMappers()
        {
            Mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<ApiResourceProperty, Entities.ApiResourceProperty>().ReverseMap();
                cfg.CreateMap<ApiResource, Entities.ApiResource>().ReverseMap();

            }).CreateMapper();
            //Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourcePropertyMapperProfile>())
            //    .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static Entities.ApiResourceProperty ToEntity(this ApiResourceProperty model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResourceProperty>(model);
        }

        public static ApiResourceProperty ToModel(this Entities.ApiResourceProperty entity)
        {
            return entity == null ? null : Mapper.Map<ApiResourceProperty>(entity);
        }

        public static IEnumerable<ApiResourceProperty> ToModel(this IEnumerable<Entities.ApiResourceProperty> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<ApiResourceProperty>>(entities);
            return modelList;
        }

    }

    public class ApiResourcePropertyMapperProfile : Profile
    {
        public ApiResourcePropertyMapperProfile()
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

using AutoMapper;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static  class PlusApiResourceScopeMappers
    {
        static PlusApiResourceScopeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceScopeMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static Entities.ApiResourceScope ToEntity(this ApiResourceScope model)
        {
            return model == null ? null : Mapper.Map<Entities.ApiResourceScope>(model);
        }

        public static ApiResourceScope ToModel(this Entities.ApiResourceScope entity)
        {
            return entity == null ? null : Mapper.Map<ApiResourceScope>(entity);
        }

        public static IEnumerable<ApiResourceScope> ToModel(this IEnumerable<Entities.ApiResourceScope> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<ApiResourceScope>>(entities);
            return modelList;
        }
    }

    public class ApiResourceScopeMapperProfile : Profile
    {

        public override string ProfileName
        {
            get
            {
                return "PlusApiResourceScopeMappers";
            }
        }

        public ApiResourceScopeMapperProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<ApiResourceScope, Entities.ApiResourceScope>().ReverseMap();
        }
        //public ApiResourceScopeMapperProfile()
        //{
        //    CreateMap<ApiResource, Entities.ApiResource>(MemberList.Destination)
        //        .ConstructUsing(src => new Entities.ApiResource())
        //        .ReverseMap();

        //    CreateMap<IdentityClaim, string>()//todo
        //       .ConstructUsing(x => x.Type)
        //       .ReverseMap()
        //       .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        //}
    
    }

}

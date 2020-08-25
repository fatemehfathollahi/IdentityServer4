using System.Collections.Generic;
using AutoMapper;
using Models = Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientMappers
    {
        static PlusClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
        public static Entities.Client ToEntity(this Models.Client model)
        {
            return Mapper.Map<Entities.Client>(model);
        }

        public static Models.Client ToModel(this Entities.Client entity)
        {
            return Mapper.Map<Models.Client>(entity);
        }

        public static IEnumerable<Models.Client> ToModel(this IEnumerable<Entities.Client> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<Models.Client>>(entities);
            foreach (var model in modelList)
            {
                foreach (var item in entities)
                {
                    model.ClientSecrets = item.ClientSecrets.ToModel();
                    model.Claims = item.Claims.ToModel();
                }
            }

            return modelList;
        }
    }


    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Models.ClientProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Models.Client, Entities.Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Models.ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientClaim, Entities.ClientClaim>(MemberList.Destination)
               .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Models.ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType.ToString())
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));

            CreateMap<Models.ClientSecret, Entities.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
        }
    }

}
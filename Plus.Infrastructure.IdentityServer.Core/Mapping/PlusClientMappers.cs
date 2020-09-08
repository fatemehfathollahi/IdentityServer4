using System.Collections.Generic;
using AutoMapper;
using Models = Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Entities = IdentityServer4.EntityFramework.Entities;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

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
        public static Entities.Client ToEntity(this Client model)
        {
            return Mapper.Map<Entities.Client>(model);
        }

        public static Client ToModel(this Entities.Client entity)
        {
            return Mapper.Map<Client>(entity);
        }

        public static IEnumerable<Client> ToModel(this IEnumerable<Entities.Client> entities)
        {
            var modelList = entities == null ? null : Mapper.Map<IEnumerable<Client>>(entities);
            return modelList;
        }
    }


    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {

            CreateMap<ClientProperty, Entities.ClientProperty>(MemberList.Destination)
               .ConstructUsing(src => new Entities.ClientProperty())
               .ReverseMap();

            CreateMap<Client, Entities.Client>(MemberList.Destination)
                .ConstructUsing(src => new Entities.Client())
                .ForMember(x => x.ClientSecrets, opts => opts.MapFrom(x => x.ClientSecrets))
                .ReverseMap();

            CreateMap<ClientClaim, Entities.ClientClaim>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ForMember(dest => dest.Value, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<ClientSecret, Entities.ClientSecret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<ClientScope, Entities.ClientScope>(MemberList.Destination)
                .ConstructUsing(src => new Entities.ClientScope())
                .ReverseMap();

            CreateMap<ClientCorsOrigin, Entities.ClientCorsOrigin>(MemberList.Destination)
                .ConstructUsing(src => new Entities.ClientCorsOrigin())
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<ClientIdPRestriction, Entities.ClientIdPRestriction>()
                .ConstructUsing(src => new Entities.ClientIdPRestriction())
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<ClientPostLogoutRedirectUri, Entities.ClientPostLogoutRedirectUri>()
                .ConstructUsing(src => new Entities.ClientPostLogoutRedirectUri())
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientRedirectUri, Entities.ClientRedirectUri>()
                .ConstructUsing(src => new Entities.ClientRedirectUri())
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientGrantType, Entities.ClientGrantType>()
                .ConstructUsing(src => new Entities.ClientGrantType())
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));
        }
    }

}
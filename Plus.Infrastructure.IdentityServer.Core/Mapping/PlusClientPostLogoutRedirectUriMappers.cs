using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientPostLogoutRedirectUriMappers
    {
        static PlusClientPostLogoutRedirectUriMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientPostLogoutRedirectUriMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientPostLogoutRedirectUri ToEntity(this ClientPostLogoutRedirectUri model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientPostLogoutRedirectUri>(model);
        }


        public static ClientPostLogoutRedirectUri ToModel(this Entities.ClientPostLogoutRedirectUri entity)
        {
            return entity == null ? null : Mapper.Map<ClientPostLogoutRedirectUri>(entity);
        }

        public static List<ClientPostLogoutRedirectUri> ToModel(this List<Entities.ClientPostLogoutRedirectUri> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientPostLogoutRedirectUri>>(entities);
            return entityList;
        }
    }

    public class ClientPostLogoutRedirectUriMapperProfile : Profile
    {

        public ClientPostLogoutRedirectUriMapperProfile()
        {
            CreateMap<Entities.ClientPostLogoutRedirectUri, ClientPostLogoutRedirectUri>()
                .ConstructUsing(src => new ClientPostLogoutRedirectUri()).ReverseMap();
        }
    }
}

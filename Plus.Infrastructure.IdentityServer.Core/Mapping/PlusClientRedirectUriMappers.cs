using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static  class PlusClientRedirectUriMappers
    {
        static PlusClientRedirectUriMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientRedirectUriMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientRedirectUri ToEntity(this ClientRedirectUri model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientRedirectUri>(model);
        }


        public static ClientRedirectUri ToModel(this Entities.ClientRedirectUri entity)
        {
            return entity == null ? null : Mapper.Map<ClientRedirectUri>(entity);
        }

        public static List<ClientRedirectUri> ToModel(this List<Entities.ClientRedirectUri> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientRedirectUri>>(entities);
            return entityList;
        }
    }
    public class ClientRedirectUriMapperProfile : Profile
    {

        public ClientRedirectUriMapperProfile()
        {
            CreateMap<Entities.ClientRedirectUri, ClientRedirectUri>()
                .ConstructUsing(src => new ClientRedirectUri()).ReverseMap();
        }
    }
}

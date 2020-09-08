using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientScopeMappers
    {
        static PlusClientScopeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientScopeMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientScope ToEntity(this ClientScope model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientScope>(model);
        }

        public static ClientScope ToModel(this Entities.ClientScope entity)
        {
            return entity == null ? null : Mapper.Map<ClientScope>(entity);
        }

        public static List<ClientScope> ToModel(this List<Entities.ClientScope> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientScope>>(entities);
            return entityList;
        }
    }
    public class ClientScopeMapperProfile : Profile
    {

        public ClientScopeMapperProfile()
        {
            CreateMap<Entities.ClientScope, ClientScope>()
                .ConstructUsing(src => new ClientScope()).ReverseMap();
        }
    }
}

using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientPropertyMappers
    {
        static PlusClientPropertyMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientPropertyMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientProperty ToEntity(this ClientProperty model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientProperty>(model);
        }


        public static ClientProperty ToModel(this Entities.ClientProperty entity)
        {
            return entity == null ? null : Mapper.Map<ClientProperty>(entity);
        }

        public static List<ClientProperty> ToModel(this List<Entities.ClientProperty> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientProperty>>(entities);
            return entityList;
        }
    }
    public class ClientPropertyMapperProfile : Profile
    {

        public ClientPropertyMapperProfile()
        {
            CreateMap<Entities.ClientProperty, ClientProperty>()
                .ConstructUsing(src => new ClientProperty()).ReverseMap();
        }
    }
}

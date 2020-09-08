using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static  class PlusClientCorsOriginMappers
    {
        static PlusClientCorsOriginMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientCorsOriginMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientCorsOrigin ToEntity(this ClientCorsOrigin model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientCorsOrigin>(model);
        }


        public static ClientCorsOrigin ToModel(this Entities.ClientCorsOrigin entity)
        {
            return entity == null ? null : Mapper.Map<ClientCorsOrigin>(entity);
        }

        public static List<ClientCorsOrigin> ToModel(this List<Entities.ClientCorsOrigin> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientCorsOrigin>>(entities);
            return entityList;
        }
    }
    public class ClientCorsOriginMapperProfile : Profile
    {

        public ClientCorsOriginMapperProfile()
        {
            CreateMap<Entities.ClientCorsOrigin, ClientCorsOrigin>()
                .ConstructUsing(src => new ClientCorsOrigin()).ReverseMap();
        }
    }
}

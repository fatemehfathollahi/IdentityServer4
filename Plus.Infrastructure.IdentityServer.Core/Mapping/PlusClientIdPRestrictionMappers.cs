using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientIdPRestrictionMappers
    {
        static PlusClientIdPRestrictionMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientIdPRestrictionMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientIdPRestriction ToEntity(this ClientIdPRestriction model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientIdPRestriction>(model);
        }


        public static ClientIdPRestriction ToModel(this Entities.ClientIdPRestriction entity)
        {
            return entity == null ? null : Mapper.Map<ClientIdPRestriction>(entity);
        }

        public static List<ClientIdPRestriction> ToModel(this List<Entities.ClientIdPRestriction> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientIdPRestriction>>(entities);
            return entityList;
        }
    }

    public class ClientIdPRestrictionMapperProfile : Profile
    {

        public ClientIdPRestrictionMapperProfile()
        {
            CreateMap<Entities.ClientIdPRestriction, ClientIdPRestriction>()
                .ConstructUsing(src => new ClientIdPRestriction()).ReverseMap();
        }
    }
}

using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientClaimMappers
    {
        static PlusClientClaimMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientClaimMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientClaim ToEntity(this ClientClaim model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientClaim>(model);
        }


        public static ClientClaim ToModel(this Entities.ClientClaim entity)
        {
            return entity == null ? null : Mapper.Map<ClientClaim>(entity);
        }

        public static List<ClientClaim> ToModel(this List<Entities.ClientClaim> entities)
        {
            var entityList = entities == null ? null : Mapper.Map<List<ClientClaim>>(entities);
            return entityList;
        }
    }

    public class ClientClaimMapperProfile : Profile
    {

        public ClientClaimMapperProfile()
        {
            CreateMap<Entities.ClientClaim, ClientClaim>()
                .ConstructUsing(src => new ClientClaim())
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type))
                 .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value));
                  // .ForMember(x => x.ValueType, opt => opt.MapFrom(src => src.ValueType)) todo
        }
    }
}

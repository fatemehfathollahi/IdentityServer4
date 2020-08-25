using AutoMapper;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;

namespace Plus.Infrastructure.IdentityServer.Core.Mapping
{
    public static class PlusClientSecretMappers
    {
        static PlusClientSecretMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientSecretMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Entities.ClientSecret ToEntity(this ClientSecret model)
        {
            return model == null ? null : Mapper.Map<Entities.ClientSecret>(model);
        }


        public static ClientSecret ToModel(this Entities.ClientSecret entity)
        {
            return entity == null ? null : Mapper.Map<ClientSecret>(entity);
        }

        public static List<ClientSecret> ToModel(this List<Entities.ClientSecret> entity)
        {
            var modelList = entity == null ? null : Mapper.Map<List<ClientSecret>>(entity);
            return modelList;
        }
    }

    public class ClientSecretMapperProfile : Profile
    {

        public ClientSecretMapperProfile()
        {
            CreateMap<Entities.ClientSecret, ClientSecret>()
                .ConstructUsing(src => new ClientSecret())
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(x => x.Expiration, opt => opt.MapFrom(src => src.Expiration))
                  .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value))
                  .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
